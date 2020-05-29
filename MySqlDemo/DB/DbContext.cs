using MySql.Data.MySqlClient;
using MySqlDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySqlDemo.DB
{
    /// <summary>
    /// 连接上下文
    /// </summary>
    public class DbContext : IDisposable
    {
        public MySqlConnection Connection;

        public DbContext(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        public void Dispose()
        {
            Connection.Close();
        }
    }
}
