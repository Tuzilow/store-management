using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class StaffInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        // 工资
        public double Salary { get; set; }
        // 职位
        public int PositionId { get; set; }
        public string Account { get; set; }

        /// <summary>
        /// DataSet转List
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static List<StaffInfo> ToList(DataSet ds)
        {
            List<StaffInfo> staffList = new List<StaffInfo>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                StaffInfo staff = new StaffInfo();
                foreach (DataColumn dc in ds.Tables[0].Columns)
                {
                    switch (dc.ToString())
                    {
                        case "staff_id":
                            staff.Id = Convert.ToInt32(dr[dc]);
                            break;
                        case "staff_name":
                            staff.Name = dr[dc].ToString();
                            break;
                        case "staff_gender":
                            staff.Gender = dr[dc].ToString();
                            break;
                        case "staff_birthday":
                            staff.Birthday = Convert.ToDateTime(dr[dc]);
                            break;
                        case "staff_address":
                            staff.Address = dr[dc].ToString();
                            break;
                        case "staff_position_id":
                            staff.PositionId = Convert.ToInt32(dr[dc]);
                            break;
                        case "staff_salary":
                            staff.Salary = Convert.ToDouble(dr[dc]);
                            break;
                        case "staff_account":
                            staff.Account = dr[dc].ToString();
                            break;
                    }
                }
                staffList.Add(staff);

            }
            return staffList;
        }
    }
}
