using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// 订单逻辑层
    /// </summary>
    public class OrderBLL
    {
        private readonly OrderDAL DAL = new OrderDAL();

        /// <summary>
        /// 获取全部订单数据
        /// </summary>
        /// <returns></returns>
        public List<OrderInfo> Find()
        {
            return DAL.Find();
        }

        /// <summary>
        /// 根据id查订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OrderInfo FindOne(int id)
        {
            return DAL.FindOne(id);
        }

        /// <summary>
        /// 添加新的订单
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public bool Insert(int goodsId, int goodsCount, int factoryId, DateTime createTime, string orderType, string remarks)
        {
            OrderInfo order = new OrderInfo()
            {
               GoodsId = goodsId,
               GoodsCount = goodsCount,
               FactoryId = factoryId,
               CreateTime = createTime,
               OrderType = orderType,
               Remakes = remarks
            };

            return DAL.Insert(order);
        }

        /// <summary>
        /// 根据ID删除订单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteById(int id)
        {
            return DAL.Delete(id);
        }
    }
}
