using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// 货物
    /// </summary>
    public class GoodsInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // 商品图片
        public string ImgUrl { get; set; }
        // 种类
        public string Type { get; set; }
        // 库存
        public int Count { get; set; }
        // 卖出数量
        public int SellCount { get; set; }
        // 生产日期
        public DateTime CreateTime { get; set; }
        // 成本
        public double Cost { get; set; }
        // 售价
        public double Price { get; set; }
        // 保质期
        public DateTime EndTime { get; set; }
        // 供应商
        public int FactoryId { get; set; }

        /// <summary>
        /// DataSet转List
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static List<GoodsInfo> ToList(DataSet ds)
        {
            List<GoodsInfo> goodsList = new List<GoodsInfo>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                GoodsInfo goods = new GoodsInfo();
                foreach (DataColumn dc in ds.Tables[0].Columns)
                {
                    switch (dc.ToString())
                    {
                        case "goods_id":
                            goods.Id = Convert.ToInt32(dr[dc]);
                            break;
                        case "goods_name":
                            goods.Name = dr[dc].ToString();
                            break;
                        case "goods_type":
                            goods.Type = dr[dc].ToString();
                            break;
                        case "goods_count":
                            goods.Count = Convert.ToInt32(dr[dc]);
                            break;
                        case "goods_sell_count":
                            goods.SellCount = Convert.ToInt32(dr[dc]);
                            break;
                        case "goods_cost":
                            goods.Cost = Convert.ToDouble(dr[dc]);
                            break;
                        case "goods_price":
                            goods.Price = Convert.ToDouble(dr[dc]);
                            break;
                        case "goods_create_time":
                            goods.CreateTime = Convert.ToDateTime(dr[dc]);
                            break;
                        case "factory_id":
                            goods.FactoryId = Convert.ToInt32(dr[dc]);
                            break;
                        case "goods_end_time":
                            goods.EndTime = Convert.ToDateTime(dr[dc]);
                            break;
                    }
                }
                goodsList.Add(goods);

            }
            return goodsList;
        }
    }
}
