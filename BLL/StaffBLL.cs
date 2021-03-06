﻿using DAL;
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

        public List<StaffInfo> Find(int pageIndex, int pageSize)
        {
            return DAL.Find(pageIndex, pageSize);
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
        public StaffInfo FindOne(string account)
        {
            return FindOne(DAL.FindIdByName(account));
        }

        /// <summary>
        /// 判断某员工是否存在
        /// </summary>
        /// <param name="name">商品名</param>
        /// <returns></returns>
        public bool IsStaffExist(string account)
        {
            return DAL.FindIdByName(account) != 0;
        }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Login(string account, string password)
        {
            return DAL.Login(account, password) != 0;
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
        public bool Insert(string account, string name, string gender, DateTime birthday, string address, double salary, int positionId, string password)
        {
            if (IsStaffExist(account))
            {
                return false;
            }

            StaffInfo staff = new StaffInfo()
            {
                Account = account,
                Name = name,
                Gender = gender,
                Birthday = birthday,
                Address = address,
                Salary = salary,
                PositionId = positionId,
                Password = password
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
