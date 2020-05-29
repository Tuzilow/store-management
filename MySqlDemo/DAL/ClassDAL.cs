using MySql.Data.MySqlClient;
using MySqlDemo.DB;
using MySqlDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace MySqlDemo.DAL
{
    public class ClassDAL
    {
        readonly DbContext context;
        public ClassDAL(DbContext context)
        {
            this.context = context;
        }

        public DbDataReader Find()
        {
            var cmd = context.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM `tb_classes`";

            return cmd.ExecuteReader();
        }
    }
}
