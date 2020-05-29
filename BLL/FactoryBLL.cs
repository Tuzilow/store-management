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
    /// 供货商逻辑层
    /// </summary>
    public class FactoryBLL
    {
        private readonly FactoryDAL DAL = new FactoryDAL();

        /// <summary>
        /// 获取全部供货商数据
        /// </summary>
        /// <returns></returns>
        public List<FactoryInfo> Find()
        {
            return DAL.Find();
        }

        /// <summary>
        /// 根据id查供货商
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FactoryInfo FindOne(int id)
        {
            return DAL.FindOne(id);
        }

        /// <summary>
        /// 判断供货商事否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsFactoryExist(string name)
        {
            return DAL.FindIdByName(name) != 0;
        }

        /// <summary>
        /// 添加新的供货商
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public bool Insert(string name, string address, string phone)
        {
            // 如果供货商存在，返回false
            if (IsFactoryExist(name))
            {
                return false;
            }

            FactoryInfo factory = new FactoryInfo()
            {
                Name = name,
                Address = address,
                Phone = phone
            };

            return DAL.Insert(factory);
        }

        /// <summary>
        /// 更具id更新供货商信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public bool UpdateById(int id, string name, string address, string phone)
        {
            FactoryInfo factory = FindOne(id);
            factory.Name = name;
            factory.Address = address;
            factory.Phone = phone;

            return DAL.Update(factory);
        }

        /// <summary>
        /// 根据ID删除供货商
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteById(int id)
        {
            return DAL.Delete(id);
        }
    }
}
