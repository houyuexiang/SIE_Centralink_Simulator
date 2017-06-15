using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;
using System.Data;

namespace Simulator.ClassLib
{
    class DataBaseSQLite
    {
        public SQLiteConnection SQLConnect = null;
        string logfile = Directory.GetCurrentDirectory() + "\\UpdateErrMessage.txt";
        public DataBaseSQLite(string DataBaseName)
        {
            SQLConnect = new SQLiteConnection("Data Source = "  + DataBaseName);
            SQLConnect.Open();
            InitDataBase();


        }
        private void  InitDataBase()
        {
            string sql;
            sql = "CREATE TABLE IF NOT EXISTS Setup( indexs varchar(20) ,SetupNa varchar(40),SetupValue varchar(20),primary key(indexs,SetupNa))";
            ExecuteSQL(sql);
            sql = "CREATE TABLE IF NOT EXISTS TransTable( indexs varchar(20),Centralink_sampleid varchar(20),Instrument_sampleid varchar(20),primary key(indexs,Centralink_sampleid,Instrument_sampleid))";
            ExecuteSQL(sql);
        }
        
        private int UpdateDatabase(int DBV)
        {
            
            
            string S_read = "",S_tmp;
            int dbversion = 0;
            string filename = Directory.GetCurrentDirectory() + "\\DatabaseUpdate.txt",sql;
            StreamReader SR = new StreamReader(@filename);
            SQLiteCommand sqlcomm = new SQLiteCommand(SQLConnect);

            S_read = SR.ReadToEnd();
            SR.Close();

            S_read = S_read.Replace("\r\n", " ");
            
            
            while (S_read.IndexOf("}") > 0)
            {
                S_tmp = S_read.Substring(0, S_read.IndexOf("}") + 1);
                S_read = S_read.Substring(S_read.IndexOf("}") + 1);
                try
                {
                   
                    dbversion = Convert.ToInt16(S_tmp.Substring(S_tmp.IndexOf("[") + 1, S_tmp.IndexOf("]") - S_tmp.IndexOf("[") - 1).Trim());
                }
                catch
                {
                    return -1;
                }
                if (dbversion <= DBV) continue;
                int s = S_tmp.IndexOf("{") + 1;
                int e = S_tmp.IndexOf("}") - s - 1;
                S_tmp = S_tmp.Substring(s, e);
                while (S_tmp.IndexOf(";") > 0)
                {
                    sql = S_tmp.Substring(0, S_tmp.IndexOf(";"));
                    S_tmp = S_tmp.Substring(S_tmp.IndexOf(";") + 1);
                    sqlcomm.CommandText = sql ;
                    try
                    {
                        sqlcomm.ExecuteNonQuery();
                    }
                    catch(Exception ex)
                    {
                        GlobalValue.WriteLog(DateTime.Now.ToString() + ":SQL" + sql + ":" +  ex.Message.ToString(),logfile);
                        continue;
                    }
                }


            }
            sql = "update TAT_Dictonary set kvalue = '" + dbversion + "' where ktype='DBV' and Kname='DatabaseVersion'";
            sqlcomm.CommandText = sql;
            sqlcomm.ExecuteNonQuery();

            

            return 0;
        }

        public int GetSelectValue(string sql)
        {
            SQLiteCommand sqlcom = new SQLiteCommand(sql,SQLConnect);
            SQLiteDataReader reader = sqlcom.ExecuteReader();
            int count = 0;
            reader.Read();
            try
            {
                if (reader.HasRows)
                {
                    count = reader.GetInt32(0);
                    
                }
            }
            catch(Exception ex)
            {
                GlobalValue.WriteLog(DateTime.Now.ToString() + ":SQL" + sql + ":" + ex.Message.ToString(), logfile);
                count = 0;
            }
            reader.Close();
            sqlcom.Dispose();
            return count;
        }
        public int ExecuteSQL(string sql)
        {
            SQLiteCommand  sqlcomm = new SQLiteCommand(SQLConnect);
            try
            {
                sqlcomm.CommandText = sql;
                sqlcomm.ExecuteNonQuery();
                
            }
            catch(Exception ex)
            {
                GlobalValue.WriteLog(DateTime.Now.ToString() + ":SQL" + sql + ":" + ex.Message.ToString(), logfile);
                return -1;
            }
            sqlcomm.Dispose();
            return 0;
        }
        
        //public DataGridViewRow[] GetRowsBySQL(string sql)
        //{
        //    DataGridView dgv = new DataGridView();
        //    SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, SQLConnect);
        //    DataSet ds = new DataSet();
        //    adapter.Fill(ds);
        //    DataView dv = ds.Tables[0].DefaultView;
        //    dgv.DataSource = dv;
            
        //    DataGridViewRow[] dgvr = null;
        //    dgv.Rows.CopyTo(dgvr,0);
        //    return dgvr;
        //}

        public string GetValue(string tablename,string columname,string condition)
        {
            string sql,value;
            if (condition == "")
            {
                sql = "select " + columname + " from " + tablename;
            }
            else
            {
                sql = "select " + columname + " from " + tablename + " where " + condition;
            }
            

            SQLiteCommand command = new SQLiteCommand(sql, SQLConnect);
            SQLiteDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                value = reader[columname].ToString();
                if (value == null) value = "";
                return value;
            }
            else
            {
                return null;
            }
            

            
        }
        


        public void Close()
        {
            if (SQLConnect != null)
            {
                SQLConnect.Close();
            }

        }
    }
}
