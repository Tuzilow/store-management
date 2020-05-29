using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    /// <summary>
    /// 数据库帮助类
    /// </summary>
    public class DBHelper
    {
        public string ConnStr { get; set; }

        private DBHelper()
        {
            ConnStr = ConfigurationManager.ConnectionStrings["connStr"].ToString();
        }

        // 使用单例模式创建
        private static DBHelper _instance = null;
        public static DBHelper Ins
        {
            get { if (_instance == null) { _instance = new DBHelper(); } return _instance; }
        }

        /// <summary>
        /// 需要获得多个结果集的时候用该方法，返回DataSet对象。
        /// </summary>
        /// <param name="sql语句"></param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(string sql, params MySqlParameter[] paras)
        {
            using (MySqlConnection con = new MySqlConnection(ConnStr))
            {
                //数据适配器
                using (MySqlDataAdapter sqlda = new MySqlDataAdapter(sql, con))
                {
                    sqlda.SelectCommand.Parameters.AddRange(paras);
                    DataSet ds = new DataSet();
                    sqlda.Fill(ds);
                    return ds;
                }
                //不需要打开和关闭链接.
            }
        }

        /// <summary>
        /// 获得单个结果集时使用该方法，返回DataTable对象。
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable ExcuteDataTable(string sql, params MySqlParameter[] paras)
        {
            using (MySqlConnection con = new MySqlConnection(ConnStr))
            {
                using (MySqlDataAdapter sqlda = new MySqlDataAdapter(sql, con))
                {
                    sqlda.SelectCommand.Parameters.AddRange(paras);
                    DataTable dt = new DataTable();
                    sqlda.Fill(dt);
                    return dt;
                }
            }
        }


        /// <summary>   
        /// 执行一条计算查询结果语句，返回查询结果（object）。   
        /// </summary>   
        /// <param name="SQLString">计算查询结果语句</param>   
        /// <returns>查询结果（object）</returns>   
        public object ExecuteScalar(string SQLString, params MySqlParameter[] paras)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnStr))
            {
                using (MySqlCommand cmd = new MySqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.Parameters.AddRange(paras);
                        object obj = cmd.ExecuteScalar();
                        if (Equals(obj, null) || Equals(obj, DBNull.Value))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (MySqlException e)
                    {
                        connection.Close();
                        return e;
                    }
                }
            }
        }

        /// <summary>
        /// 执行Update,Delete,Insert操作
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ExecuteNonquery(string sql, params MySqlParameter[] paras)
        {
            using (MySqlConnection con = new MySqlConnection(ConnStr))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddRange(paras);
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 调用存储过程 无返回值
        /// </summary>
        /// <param name="procname">存储过程名</param>
        /// <param name="paras">sql语句中的参数数组</param>
        /// <returns></returns>
        public int ExecuteProcNonQuery(string procname, params MySqlParameter[] paras)
        {
            using (MySqlConnection con = new MySqlConnection(ConnStr))
            {
                using (MySqlCommand cmd = new MySqlCommand(procname, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(paras);
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 存储过程 返回Datatable
        /// </summary>
        /// <param name="procname"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public DataTable ExecuteProcQuery(string procname, params MySqlParameter[] paras)
        {
            using (MySqlConnection con = new MySqlConnection(ConnStr))
            {
                using (MySqlCommand cmd = new MySqlCommand(procname, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (MySqlDataAdapter sqlda = new MySqlDataAdapter(procname, con))
                    {
                        sqlda.SelectCommand.Parameters.AddRange(paras);
                        DataTable dt = new DataTable();
                        sqlda.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        /// <summary>
        /// 多语句的事务管理
        /// </summary>
        /// <param name="cmds">命令数组</param>
        /// <returns></returns>
        public bool ExcuteCommandByTran(params MySqlCommand[] cmds)
        {
            using (MySqlConnection con = new MySqlConnection(ConnStr))
            {
                con.Open();
                MySqlTransaction tran = con.BeginTransaction();
                foreach (MySqlCommand cmd in cmds)
                {
                    cmd.Connection = con;
                    cmd.Transaction = tran;
                    cmd.ExecuteNonQuery();
                }
                tran.Commit();
                return true;
            }
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="totalCount"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public DataTable ExcuteDataWithPage(string sql, ref int totalCount, params MySqlParameter[] paras)
        {
            using (MySqlConnection con = new MySqlConnection(ConnStr))
            {
                using (MySqlDataAdapter dap = new MySqlDataAdapter(sql, con))
                {
                    DataTable dt = new DataTable();
                    dap.SelectCommand.Parameters.AddRange(paras);
                    dap.Fill(dt);
                    MySqlParameter ttc = dap.SelectCommand.Parameters["@totalCount"];
                    if (ttc != null)
                    {
                        totalCount = Convert.ToInt32(ttc.Value);
                    }
                    return dt;
                }
            }
        }

    }
}
