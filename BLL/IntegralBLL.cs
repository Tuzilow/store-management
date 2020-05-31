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
    /// 积分逻辑层
    /// </summary>
    public class IntegralBLL
    {
        private readonly IntegralDAL DAL = new IntegralDAL();

        /// <summary>
        /// 获取全部积分记录数据
        /// </summary>
        /// <returns></returns>
        public List<IntegralInfo> Find()
        {
            return DAL.Find();
        }

        /// <summary>
        /// 根据id查积分记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IntegralInfo FindOne(int id)
        {
            return DAL.FindOne(id);
        }

        /// <summary>
        /// 添加新的积分记录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public bool Insert(bool isOut, int count, int vipId)
        {
            IntegralInfo integral = new IntegralInfo()
            {
                IsOut = isOut,
                Count = count,
                VipId = vipId
            };

            return DAL.Insert(integral);
        }

        /// <summary>
        /// 根据ID删除积分记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteById(int id)
        {
            return DAL.Delete(id);
        }
    }
}
