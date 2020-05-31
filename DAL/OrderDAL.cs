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
    /// 订单数据访问层
    /// </summary>
    public class OrderDAL
    {
        readonly DBHelper db = DBHelper.Ins;

        /// <summary>
        /// 查询订单表所有数据
        /// </summary>
        /// <returns></returns>
        public List<OrderInfo> Find()
        {
            string sql =
                $"select " +
                $"order_id," +
                $"goods_id," +
                $"factory_id," +
                $"order_create_time," +
                $"order_type," +
                $"order_remarks" +
                $"from store_management.`order`;";

            return OrderInfo.ToList(db.ExecuteDataSet(sql));
        }

        /// <summary>
        /// 查找某个订单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OrderInfo FindOne(int id)
        {
            string sql =
                $"select " +
                $"order_id," +
                $"goods_id," +
                $"factory_id," +
                $"order_create_time," +
                $"order_type," +
                $"order_remarks" +
                $"from store_management.`order` where order_id={id}";
            return OrderInfo.ToList(db.ExecuteDataSet(sql))[0];
        }

        /// <summary>
        /// 增加新订单
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        public bool Insert(OrderInfo order)
        {
            string sql =
                $"insert into `order`(goods_id,factory_id,order_create_time,order_type,order_remarks) " +
                $"values ({order.GoodsId},{order.FactoryId},'{order.CreateTime}','{order.OrderType}','{order.Remakes}');";

            return db.ExecuteNonquery(sql) > 0;
        }

        /// <summary>
        /// 删除订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            string sql = $"delete from store_management.`order` where order_id={id}";

            return db.ExecuteNonquery(sql) > 0;
        }
    }
}
