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
    /// 会员数据访问层
    /// </summary>
    public class VipDAL
    {
        private readonly DBHelper db = DBHelper.Ins;

        /// <summary>
        /// 查询vip所有数据
        /// </summary>
        /// <returns></returns>
        public List<VipInfo> Find()
        {
            string sql =
                $"select " +
                $"vip_id," +
                $"vip_name," +
                $"vip_gender," +
                $"vip_birthday," +
                $"vip_join " +
                $"from store_management.vip;";

            return VipInfo.ToList(db.ExecuteDataSet(sql));
        }
        public List<VipInfo> Find(int pageIndex, int pageSize)
        {
            string sql =
                $"select " +
                $"vip_id," +
                $"vip_name," +
                $"vip_gender," +
                $"vip_birthday," +
                $"vip_join " +
                $"from store_management.vip " +
                $"order by vip_id limit {pageSize} offset {pageSize * (pageIndex - 1)};";

            return VipInfo.ToList(db.ExecuteDataSet(sql));
        }

        /// <summary>
        /// 查找某个vip信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public VipInfo FindOne(int id)
        {
            string sql =
                $"select " +
                $"vip_id," +
                $"vip_name," +
                $"vip_gender," +
                $"vip_birthday," +
                $"vip_join " +
                $"from store_management.vip where vip_id={id};";
            return VipInfo.ToList(db.ExecuteDataSet(sql))[0];
        }

        /// <summary>
        /// 判断某vip是否存在
        /// </summary>
        /// <param name="name">商品名</param>
        /// <returns></returns>
        public int FindIdByName(string name)
        {
            string sql = $"select vip_id from store_management.vip where vip_name='{name}';";

            return Convert.ToInt32(db.ExecuteScalar(sql));
        }

        /// <summary>
        /// 增加新vip
        /// </summary>
        /// <param name="vip"></param>
        /// <returns></returns>
        public bool Insert(VipInfo vip)
        {
            string sql =
                $"insert into vip(vip_name,vip_gender,vip_birthday,vip_join) " +
                $"values ('{vip.Name}','{vip.Gender}','{vip.Birthday.ToString("yyyy-MM-dd")}','{vip.JoinTime.ToString("yyyy-MM-dd")}');";

            return db.ExecuteNonquery(sql) > 0;
        }

        /// <summary>
        /// 更新某vip信息
        /// </summary>
        /// <param name="vip"></param>
        /// <returns></returns>
        public bool Update(VipInfo vip)
        {
            string sql =
                $"update vip " +
                $"set vip_name='{vip.Name}',vip_gender='{vip.Gender}',vip_birthday='{vip.Birthday.ToString("yyyy-MM-dd")}',vip_join='{vip.JoinTime.ToString("yyyy-MM-dd")}' " +
                $"where vip_id={vip.Id};";

            return db.ExecuteNonquery(sql) > 0;
        }

        /// <summary>
        /// 删除vip
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            string sql = $"delete from store_management.vip where vip_id={id}";

            return db.ExecuteNonquery(sql) > 0;
        }
    }
}
