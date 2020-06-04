using Commons;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 员工数据访问层
    /// </summary>
    public class StaffDAL
    {
        readonly DBHelper db = DBHelper.Ins;

        /// <summary>
        /// 查询员工表所有数据
        /// </summary>
        /// <returns></returns>
        public List<StaffInfo> Find()
        {
            string sql =
                $"select " +
                $"staff_id," +
                $"staff_name," +
                $"staff_gender," +
                $"staff_birthday," +
                $"staff_address," +
                $"staff_salary," +
                $"staff_position_id " +
                $"from store_management.staff;";

            return StaffInfo.ToList(db.ExecuteDataSet(sql));
        }
        public List<StaffInfo> Find(int pageIndex, int pageSize)
        {
            string sql =
                $"select " +
                $"staff_id," +
                $"staff_name," +
                $"staff_gender," +
                $"staff_birthday," +
                $"staff_address," +
                $"staff_salary," +
                $"staff_position_id " +
                $"from store_management.staff " +
                $"order by staff_id limit {pageSize} offset {pageSize * (pageIndex - 1)};";

            return StaffInfo.ToList(db.ExecuteDataSet(sql));
        }


        /// <summary>
        /// 查找某个员工信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StaffInfo FindOne(int id)
        {
            string sql =
                $"select " +
                $"staff_id," +
                $"staff_name," +
                $"staff_gender," +
                $"staff_birthday," +
                $"staff_address," +
                $"staff_salary," +
                $"staff_position_id " +
                $"from store_management.staff where staff_id={id}";
            return StaffInfo.ToList(db.ExecuteDataSet(sql))[0];
        }

        /// <summary>
        /// 判断某员工是否存在
        /// </summary>
        /// <param name="name">商品名</param>
        /// <returns></returns>
        public int FindIdByName(string name)
        {
            string sql = $"select staff_id from store_management.staff where staff_name='{name}';";

            return Convert.ToInt32(db.ExecuteScalar(sql));
        }

        /// <summary>
        /// 增加新员工
        /// </summary>
        /// <param name="staff"></param>
        /// <returns></returns>
        public bool Insert(StaffInfo staff)
        {
            string sql =
                $"insert into staff(staff_name,staff_gender,staff_birthday,staff_address,staff_salary,staff_position_id) " +
                $"values ('{staff.Name}','{staff.Gender}','{staff.Birthday.ToString("yyyy-MM-dd")}','{staff.Address}',{staff.Salary},'{staff.PositionId}');";

            return db.ExecuteNonquery(sql) > 0;
        }

        /// <summary>
        /// 更新某员工信息
        /// </summary>
        /// <param name="staff"></param>
        /// <returns></returns>
        public bool Update(StaffInfo staff)
        {
            string sql =
                $"update staff " +
                $"set staff_name='{staff.Name}',staff_gender='{staff.Gender}',staff_birthday='{staff.Birthday.ToString("yyyy-MM-dd")}',staff_address='{staff.Address}',staff_salary={staff.Salary},staff_position_id='{staff.PositionId}' " +
                $"where staff_id={staff.Id};";

            return db.ExecuteNonquery(sql) > 0;
        }

        /// <summary>
        /// 删除员工
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            string sql = $"delete from store_management.staff where staff_id={id}";

            return db.ExecuteNonquery(sql) > 0;
        }
    }
}
