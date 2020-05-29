using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    /// <summary>
    /// 项目数据库生成类
    /// </summary>
    public class ProjectDB
    {
        private readonly DBHelper Db = DBHelper.Ins;

        /// <summary>
        /// 创建数据库
        /// </summary>
        /// <param name="database">数据库名称</param>
        /// <returns></returns>
        public bool CreateDatabase()
        {
            string sql = $"create database if not exists `store_management`;";

            return Db.ExecuteScalar(sql) == null;
        }

        /// <summary>
        /// 删除数据库
        /// </summary>
        /// <param name="database">数据库名称</param>
        /// <returns></returns>
        public bool DropDatabase()
        {
            string sql = $"drop database `store_management`;";

            return Db.ExecuteScalar(sql) == null;
        }

        /// <summary>
        /// 切换数据库
        /// </summary>
        /// <param name="database">数据库名称</param>
        /// <returns></returns>
        public bool ChangeDatabase()
        {
            string sql = $"use `store_management`;";

            return Db.ExecuteScalar(sql) == null;
        }

        /// <summary>
        /// 删除表
        /// </summary>
        /// <param name="table">表名</param>
        /// <returns></returns>
        public bool DropTable(string table)
        {
            string sql = $"drop table {table}";

            return Db.ExecuteScalar(sql) == null;
        }

        /// <summary>
        /// 创建供应商表
        /// </summary>
        /// <returns></returns>
        public bool CreateFactoryTable()
        {
            string sql =
                $"create table if not exists factory(" +
                $"factory_id int primary key not null auto_increment," +
                $"factory_name nvarchar(64) not null," +
                $"factory_address nvarchar(128) not null," +
                $"factory_phone char(11) not null" +
                $");";

            return Db.ExecuteScalar(sql) == null;
        }

        /// <summary>
        /// 创建商品表
        /// </summary>
        /// <returns></returns>
        public bool CreateGoodsTable()
        {
            string sql =
                $"create table if not exists goods(" +
                $"goods_id int primary key not null auto_increment," +
                $"goods_name nvarchar(64) not null," +
                $"goods_type nvarchar(8) not null," +
                $"goods_count int not null default 0," +
                $"goods_sell_count int not null default 0," +
                $"goods_cost double not null default 0," +
                $"goods_price double not null default 0," +
                $"goods_create_time datetime not null," +
                $"factory_id int not null," +
                $"goods_end_time datetime not null," +
                $"foreign key(factory_id) references factory(factory_id)" +
                $");";

            return Db.ExecuteScalar(sql) == null;
        }
    }
}
