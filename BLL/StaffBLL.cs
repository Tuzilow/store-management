using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class StaffBLL
    {
        private readonly StaffDAL DAL = new StaffDAL();

        /// <summary>
        /// 查找所有员工
        /// </summary>
        /// <returns></returns>
        public List<StaffInfo> Find()
        {
            return DAL.Find();
        }

        /// <summary>
        /// 查找某个员工的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StaffInfo FindOne(int id)
        {
            return DAL.FindOne(id);
        }

        /// <summary>
        /// 判断某员工是否存在
        /// </summary>
        /// <param name="name">商品名</param>
        /// <returns></returns>
        public bool IsStaffExist(string name)
        {
            return DAL.FindIdByName(name) != 0;
        }

        /// <summary>
        /// 添加新员工
        /// </summary>
        /// <param name="name"></param>
        /// <param name="gender"></param>
        /// <param name="birthday"></param>
        /// <param name="address"></param>
        /// <param name="salary"></param>
        /// <param name="positionId"></param>
        /// <returns></returns>
        public bool Insert(string name, string gender, DateTime birthday, string address, double salary, int positionId)
        {
            // 如果商品存在，返回false
            if (IsStaffExist(name))
            {
                return false;
            }

            StaffInfo staff = new StaffInfo()
            {
                Name = name,
                Gender = gender,
                Birthday = birthday,
                Address = address,
                Salary = salary,
                PositionId = positionId
            };

            return DAL.Insert(staff);
        }

        /// <summary>
        /// 更新员工信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="gender"></param>
        /// <param name="birthday"></param>
        /// <param name="address"></param>
        /// <param name="salary"></param>
        /// <param name="positionId"></param>
        /// <returns></returns>
        public bool UpdateById(int id, string name, string gender, DateTime birthday, string address, double salary, int positionId)
        {
            StaffInfo staff = FindOne(id);
            staff.Name = name;
            staff.Gender = gender;
            staff.Birthday = birthday;
            staff.Address = address;
            staff.Salary = salary;
            staff.PositionId = positionId;

            return DAL.Update(staff);
        }

        /// <summary>
        /// 根据ID删除员工
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteById(int id)
        {
            return DAL.Delete(id);
        }
    }
}
