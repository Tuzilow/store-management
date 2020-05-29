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
    /// 商品逻辑层
    /// </summary>
    public class GoodsBLL
    {
        private readonly GoodsDAL DAL = new GoodsDAL();

        /// <summary>
        /// 查找所有商品
        /// </summary>
        /// <returns></returns>
        public List<GoodsInfo> Find()
        {
            return DAL.Find();
        }

        /// <summary>
        /// 查找某个商品的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GoodsInfo FindOne(int id)
        {
            return DAL.FindOne(id);
        }

        /// <summary>
        /// 判断某商品是否存在
        /// </summary>
        /// <param name="name">商品名</param>
        /// <returns></returns>
        public bool IsGoodsExist(string name)
        {
            return DAL.FindIdByName(name) != 0;
        }

        /// <summary>
        /// 添加新商品
        /// </summary>
        /// <param name="name">商品名</param>
        /// <param name="type">类型</param>
        /// <param name="count">数量</param>
        /// <param name="sellCount">售出数量</param>
        /// <param name="cost">成本</param>
        /// <param name="price">售价</param>
        /// <param name="createTime">生产日期</param>
        /// <param name="factoryId">供应商</param>
        /// <param name="endTime">保质期</param>
        /// <returns></returns>
        public bool Insert(string name, string type, int count, int sellCount, double cost, double price, DateTime createTime, DateTime endTime, int factoryId = 0)
        {
            // 如果商品存在，返回false
            if (IsGoodsExist(name))
            {
                return false;
            }

            GoodsInfo goods = new GoodsInfo()
            {
                Name = name,
                Type = type,
                Count = count,
                SellCount = sellCount,
                Cost = cost,
                Price = price,
                CreateTime = createTime,
                FactoryId = factoryId,
                EndTime = endTime
            };

            return DAL.Insert(goods);
        }

        /// <summary>
        /// 根据ID更新商品信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="count"></param>
        /// <param name="sellCount"></param>
        /// <param name="cost"></param>
        /// <param name="price"></param>
        /// <param name="createTime"></param>
        /// <param name="endTime"></param>
        /// <param name="factoryId"></param>
        /// <returns></returns>
        public bool UpdateById(int id, string name, string type, int count, int sellCount, double cost, double price, DateTime createTime, DateTime endTime, int factoryId)
        {
            GoodsInfo goods = FindOne(id);
            goods.Name = name;
            goods.Type = type;
            goods.Count = count;
            goods.SellCount = sellCount;
            goods.Cost = cost;
            goods.Price = price;
            goods.CreateTime = createTime;
            goods.FactoryId = factoryId;
            goods.EndTime = endTime;

            return DAL.Update(goods);
        }

        /// <summary>
        /// 根据ID删除商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteById(int id)
        {
            return DAL.Delete(id);
        }
    }
}
