using BLL;
using Commons;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestWeb.WebForms
{
    public partial class Staff : System.Web.UI.Page
    {
        readonly StaffBLL staffBLL = new StaffBLL();
        readonly PositionBLL positionBLL = new PositionBLL();

        protected int pageIndex = 1;
        protected int pageSize = 10;
        protected int totalCount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 获取员工表
        /// </summary>
        /// <returns></returns>
        protected string GetStaffs()
        {
            totalCount = new ProjectDB().GetTableDataNum("staff");

            List<StaffInfo> staffList = staffBLL.Find(pageIndex, pageSize);

            if (staffList.Count() == 0)
            {
                return "<tr><td colspan=\"8\" style=\"text-align:center;\">暂无数据</td></tr>";
            }
            
            string[] positionArr = GetPositions();
            StringBuilder @string = new StringBuilder();
            foreach (StaffInfo staff in staffList)
            {
                @string.Append("<tr>");
                @string.Append($"<th scope=\"row\">{staff.Id}</th>");
                @string.Append($"<td>{staff.Name}</td>");
                @string.Append($"<td>{(staff.Gender == "m" ? "男" : "女")}</td>");
                @string.Append($"<td>{staff.Birthday.ToString("yyyy-MM-dd")}</td>");
                @string.Append($"<td>{staff.Address}</td>");
                @string.Append($"<td>{staff.Salary}</td>");
                @string.Append($"<td>{(positionArr[staff.PositionId] ?? "暂无职位")}</td>");
                @string.Append($"<td><a class=\"btn btn-outline-primary btn-sm\" href=''>修改</a> <a class=\"btn btn-outline-danger btn-sm\" href='javascript:void(0)' onclick=''> 删除</a></td>");
                @string.Append("</tr>");
            }

            return @string.ToString();
        }

        /// <summary>
        /// 获取职位与职位ID对应数组
        /// </summary>
        /// <returns></returns>
        protected string[] GetPositions()
        {
            List<PositionInfo> positionList = positionBLL.Find();
            
            if (positionList.Count() == 0)
            {
                return null;
            }
            // 获取最大的ID以保证数组足够长
            string[] positionArr = new string[positionList[positionList.Count() - 1].Id + 1];

            foreach (PositionInfo position in positionList)
            {
                positionArr[position.Id] = position.Name;
            }

            return positionArr;
        }
    }
}