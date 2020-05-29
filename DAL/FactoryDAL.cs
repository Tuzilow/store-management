using Commons;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 供货商数据访问层
    /// </summary>
    public class FactoryDAL
    {
        private readonly DBHelper db = DBHelper.Ins;

        /// <summary>
        /// 查询供货商表所有数据
        /// </summary>
        /// <returns></returns>
        public List<FactoryInfo> Find()
        {
            string sql =
                $"select " +
                $"factory_id," +
                $"factory_name," +
                $"factory_address," +
                $"factory_phone" +
                $"from factory;";

            return FactoryInfo.ToList(db.ExecuteDataSet(sql));
        }

        /// <summary>
        /// 查找某个供货商信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FactoryInfo FindOne(int id)
        {
            string sql =
                $"select " +
                $"factory_id," +
                $"factory_name," +
                $"factory_address," +
                $"factory_phone" +
                $"from factory where factory_id={id};";
            return FactoryInfo.ToList(db.ExecuteDataSet(sql))[0];
        }

        /// <summary>
        /// 判断某供货商是否存在
        /// </summary>
        /// <param name="name">商品名</param>
        /// <returns></returns>
        public int FindIdByName(string name)
        {
            string sql = $"select factory_id from factory where factory_name='{name}';";

            return Convert.ToInt32(db.ExecuteScalar(sql));
        }

        /// <summary>
        /// 增加新供货商
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        public bool Insert(FactoryInfo factory)
        {
            string sql =
                $"insert into factory(factory_name,factory_address,factory_phone) " +
                $"values ('{factory.Name}','{factory.Address}','{factory.Phone}');";

            return db.ExecuteNonquery(sql) > 0;
        }

        /// <summary>
        /// 更新某供货商信息
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        public bool Update(FactoryInfo factory)
        {
            string sql =
                $"update factory " +
                $"set factory_name='{factory.Name}',factory_address='{factory.Address}',factory_phone='{factory.Phone}' " +
                $"where factory_id={factory.Id};";

            return db.ExecuteNonquery(sql) > 0;
        }

        /// <summary>
        /// 删除供货商
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            string sql = $"delete from factory where factory_id={id}";

            return db.ExecuteNonquery(sql) > 0;
        }
    }
}
