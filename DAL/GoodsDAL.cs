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
    /// 商品数据访问层
    /// </summary>
    public class GoodsDAL
    {
        DBHelper db = DBHelper.Ins;

        /// <summary>
        /// 查询商品表所有数据
        /// </summary>
        /// <returns></returns>
        public List<GoodsInfo> Find()
        {
            string sql =
                $"select " +
                $"goods_id," +
                $"goods_name," +
                $"goods_type," +
                $"goods_count," +
                $"goods_sell_count," +
                $"goods_cost," +
                $"goods_price," +
                $"goods_create_time," +
                $"factory_id," +
                $"goods_end_time " +
                $"from store_management.goods;";

            return GoodsInfo.ToList(db.ExecuteDataSet(sql));
        }

        /// <summary>
        /// 查找某个商品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GoodsInfo FindOne(int id)
        {
            string sql =
                $"select " +
                $"goods_id," +
                $"goods_name," +
                $"goods_type," +
                $"goods_count," +
                $"goods_sell_count," +
                $"goods_cost," +
                $"goods_price," +
                $"goods_create_time," +
                $"factory_id," +
                $"goods_end_time " +
                $"from store_management.goods where goods_id={id}";
            return GoodsInfo.ToList(db.ExecuteDataSet(sql))[0];
        }

        /// <summary>
        /// 判断某商品是否存在
        /// </summary>
        /// <param name="name">商品名</param>
        /// <returns></returns>
        public int FindIdByName(string name)
        {
            string sql = $"select goods_id from store_management.goods where goods_name='{name}';";

            return Convert.ToInt32(db.ExecuteScalar(sql));
        }

        /// <summary>
        /// 增加新商品
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        public bool Insert(GoodsInfo goods)
        {
            string sql =
                $"insert into goods(goods_name,goods_type,goods_count,goods_sell_count,goods_cost,goods_price,goods_create_time,factory_id,goods_end_time) " +
                $"values ('{goods.Name}','{goods.Type}',{goods.Count},{goods.SellCount},{goods.Cost},{goods.Price},'{goods.CreateTime}',{goods.FactoryId},'{goods.EndTime}');";

            return db.ExecuteNonquery(sql) > 0;
        }

        /// <summary>
        /// 更新某商品信息
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        public bool Update(GoodsInfo goods)
        {
            string sql =
                $"update goods " +
                $"set goods_name='{goods.Name}',goods_type='{goods.Type}',goods_count={goods.Count},goods_sell_count={goods.SellCount},goods_cost={goods.Cost},goods_price={goods.Price},goods_create_time='{goods.CreateTime}',factory_id={goods.FactoryId},goods_end_time='{goods.EndTime}' " +
                $"where goods_id={goods.Id};";

            return db.ExecuteNonquery(sql) > 0;
        }

        /// <summary>
        /// 删除商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            string sql = $"delete from store_management.goods where goods_id={id}";

            return db.ExecuteNonquery(sql) > 0;
        }
    }
}
