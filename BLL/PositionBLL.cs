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
    /// 职位逻辑
    /// </summary>
    public class PositionBLL
    {
        private readonly PositionDAL DAL = new PositionDAL();

        /// <summary>
        /// 查找所有职位
        /// </summary>
        /// <returns></returns>
        public List<PositionInfo> Find()
        {
            return DAL.Find();
        }

        public List<PositionInfo> Find(int pageIndex, int pageSize)
        {
            return DAL.Find(pageIndex, pageSize);
        }

        /// <summary>
        /// 查找某个职位的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PositionInfo FindOne(int id)
        {
            return DAL.FindOne(id);
        }

        /// <summary>
        /// 判断职位是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsPositionExist(string name)
        {
            return DAL.FindIdByName(name) != 0;
        }

        /// <summary>
        /// 添加新职位
        /// </summary>
        /// <param name="name"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        public bool Insert(string name, string desc)
        {
            if(IsPositionExist(name))
            {
                return false;
            }
            PositionInfo position = new PositionInfo()
            {
                Name = name,
                Desc = desc
            };
            return DAL.Insert(position);
        }

        /// <summary>
        /// 更新职位信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        public bool Update(int id, string name, string desc)
        {
            PositionInfo position = DAL.FindOne(id);
            position.Name = name;
            position.Desc = desc;

            return DAL.Update(position);
        }

        /// <summary>
        /// 根据id删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return DAL.Delete(id);
        }
    }
}
