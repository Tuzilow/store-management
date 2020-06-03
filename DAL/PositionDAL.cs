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
    /// 职位数据访问
    /// </summary>
    public class PositionDAL
    {
        readonly DBHelper db = DBHelper.Ins;

        /// <summary>
        /// 查询职位所有数据
        /// </summary>
        /// <returns></returns>
        public List<PositionInfo> Find()
        {
            string sql =
                $"select " +
                $"position_id," +
                $"position_name," +
                $"position_desc " +
                $"from store_management.`position`;";

            return PositionInfo.ToList(db.ExecuteDataSet(sql));
        }

        /// <summary>
        /// 查找某个职位信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PositionInfo FindOne(int id)
        {
            string sql =
                $"select " +
                $"position_id," +
                $"position_name," +
                $"position_desc " +
                $"from store_management.`position` where position_id={id};";
            return PositionInfo.ToList(db.ExecuteDataSet(sql))[0];
        }

        /// <summary>
        /// 判断某职位是否存在
        /// </summary>
        /// <param name="name">职位名</param>
        /// <returns></returns>
        public int FindIdByName(string name)
        {
            string sql = $"select position_id from store_management.`position` where position_name='{name}';";

            return Convert.ToInt32(db.ExecuteScalar(sql));
        }

        /// <summary>
        /// 增加新职位
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool Insert(PositionInfo position)
        {
            string sql =
                $"insert into store_management.`position`(position_name,position_desc) " +
                $"values ('{position.Name}','{position.Desc}');";

            return db.ExecuteNonquery(sql) > 0;
        }

        /// <summary>
        /// 更新某职位信息
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        public bool Update(PositionInfo position)
        {
            string sql =
                $"update store_management.`position` " +
                $"set position_name='{position.Name}',position_desc='{position.Desc}' " +
                $"where position_id={position.Id};";

            return db.ExecuteNonquery(sql) > 0;
        }

        /// <summary>
        /// 删除职位
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            string sql = $"delete from store_management.`position` where position_id={id}";

            return db.ExecuteNonquery(sql) > 0;
        }
    }
}
