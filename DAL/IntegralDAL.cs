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
    /// 积分数据操作
    /// </summary>
    public class IntegralDAL
    {
        private readonly DBHelper db = DBHelper.Ins;

        /// <summary>
        /// 查询vip所有数据
        /// </summary>
        /// <returns></returns>
        public List<IntegralInfo> Find()
        {
            string sql =
                $"select " +
                $"integral_id," +
                $"is_out," +
                $"integral_count," +
                $"vip_id" +
                $"from store_management.integral;";

            return IntegralInfo.ToList(db.ExecuteDataSet(sql));
        }

        /// <summary>
        /// 查找某个vip信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IntegralInfo FindOne(int id)
        {
            string sql =
                $"select " +
                $"integral_id," +
                $"is_out," +
                $"integral_count," +
                $"vip_id" +
                $"from store_management.vip integral integral_id={id};";
            return IntegralInfo.ToList(db.ExecuteDataSet(sql))[0];
        }

        /// <summary>
        /// 增加新积分记录
        /// </summary>
        /// <param name="integral"></param>
        /// <returns></returns>
        public bool Insert(IntegralInfo integral)
        {
            string sql =
                $"insert into integral(is_out,integral_count,vip_id) " +
                $"values ('{integral.IsOut}',{integral.Count},{integral.VipId});";

            return db.ExecuteNonquery(sql) > 0;
        }

        /// <summary>
        /// 更新某积分记录信息
        /// </summary>
        /// <param name="vip"></param>
        /// <returns></returns>
        public bool Update(IntegralInfo integral)
        {
            string sql =
                $"update integral " +
                $"set is_out='{integral.IsOut}',integral_count={integral.Count},vip_id={integral.VipId} " +
                $"where integral_id={integral.Id};";

            return db.ExecuteNonquery(sql) > 0;
        }

        /// <summary>
        /// 删除积分记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            string sql = $"delete from store_management.integral where integral_id={id}";

            return db.ExecuteNonquery(sql) > 0;
        }
    }
}
