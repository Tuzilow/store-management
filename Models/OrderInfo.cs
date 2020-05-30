using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 订单
    /// </summary>
    public class OrderInfo
    {
        public int Id { get; set; }
        // 商品ID
        public int GoodsId { get; set; }
        // 商品交易数量
        public int GoodsCount { get; set; }
        public int FactoryId { get; set; }
        public DateTime CreateTime { get; set; }
        // 订单类型
        public string OrderType { get; set; }
        // 备注
        public string Remakes { get; set; }

        /// <summary>
        /// DataSet转List
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static List<OrderInfo> ToList(DataSet ds)
        {
            List<OrderInfo> orderList = new List<OrderInfo>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                OrderInfo order = new OrderInfo();
                foreach (DataColumn dc in ds.Tables[0].Columns)
                {
                    switch (dc.ToString())
                    {
                        case "order_id":
                            order.Id = Convert.ToInt32(dr[dc]);
                            break;
                        case "goods_id":
                            order.GoodsId = Convert.ToInt32(dr[dc]);
                            break;
                        case "goods_count":
                            order.GoodsCount = Convert.ToInt32(dr[dc]);
                            break;
                        case "factory_id":
                            order.FactoryId = Convert.ToInt32(dr[dc]);
                            break;
                        case "order_create_time":
                            order.CreateTime = Convert.ToDateTime(dr[dc]);
                            break;
                        case "order_type":
                            order.OrderType = dr[dc].ToString();
                            break;
                        case "order_remarks":
                            order.Remakes = dr[dc].ToString();
                            break;
                    }
                }
                orderList.Add(order);

            }
            return orderList;
        }
    }
}
