using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class VipBLL
    {
        private readonly VipDAL DAL = new VipDAL();

        /// <summary>
        /// 获取全部vip数据
        /// </summary>
        /// <returns></returns>
        public List<VipInfo> Find()
        {
            return DAL.Find();
        }

        /// <summary>
        /// 根据id查vip
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public VipInfo FindOne(int id)
        {
            return DAL.FindOne(id);
        }

        /// <summary>
        /// 判断某个vip否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsVipExist(string name)
        {
            return DAL.FindIdByName(name) != 0;
        }

   
      /// <summary>
      /// 添加vip
      /// </summary>
      /// <param name="name"></param>
      /// <param name="gender"></param>
      /// <param name="birthday"></param>
      /// <param name="joinTime"></param>
      /// <returns></returns>
        public bool Insert(string name, string gender, DateTime birthday, DateTime joinTime)
        {
            // 如果供货商存在，返回false
            if (IsVipExist(name))
            {
                return false;
            }

            VipInfo vip = new VipInfo()
            {
                Name = name,
                Gender = gender,
                Birthday = birthday,
                JoinTime = joinTime
            };

            return DAL.Insert(vip);
        }

        /// <summary>
        /// 更具id更新供货商信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public bool UpdateById(int id, string name, string gender, DateTime birthday, DateTime joinTime)
        {
            VipInfo vip = FindOne(id);
            vip.Name = name;
            vip.Gender = gender;
            vip.Birthday = birthday;
            vip.JoinTime = joinTime;

            return DAL.Update(vip);
        }

        /// <summary>
        /// 根据ID删除vip
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteById(int id)
        {
            return DAL.Delete(id);
        }
    }
}
