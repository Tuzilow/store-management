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
    public partial class Position : System.Web.UI.Page
    {
        readonly PositionBLL positionBLL = new PositionBLL();

        protected int pageIndex = 1;
        protected int pageSize = 9;
        protected int totalCount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

            string currentPage = Request.QueryString["currentPage"];

            if (currentPage == "next" && pageIndex < pageSize)
            {
                pageIndex++;
            }
            else if (currentPage == "prev" && pageIndex > 1)
            {
                pageIndex--;
            }
            else if (currentPage != "next" && currentPage != "prev")
            {
                pageIndex = Convert.ToInt32(currentPage);
            }
        }

        /// <summary>
        /// 获取职位表
        /// </summary>
        /// <returns></returns>
        protected string GetPostions()
        {
            totalCount = new ProjectDB().GetTableDataNum("`position`");

            List<PositionInfo> positionList = positionBLL.Find(pageIndex, pageSize);

            if (positionList.Count() == 0)
            {
                return "<tr><td colspan=\"4\" style=\"text-align:center;\">暂无数据</td></tr>";
            }

            StringBuilder @string = new StringBuilder();
            foreach (PositionInfo position in positionList)
            {
                @string.Append($"<tr id=\"position_{position.Id}\">");
                @string.Append($"<th scope=\"row\">{position.Id}</th>");
                @string.Append($"<td>{position.Name}</td>");
                @string.Append($"<td>{position.Desc}</td>");
                @string.Append($"<td><a class=\"btn btn-outline-primary btn-sm\" href=\"#updatePosition\" data-toggle=\"drawer\" aria-foldedopen=\"false\" aria-controls=\"updatePosition\" onclick=\"loadOnePosition({position.Id})\">修改</a> <a class=\"btn btn-outline-danger btn-sm\" href='javascript:void(0)' data-toggle=\"modal\" data-target=\"#deleteModal\" onclick=\"showDelete({position.Id})\"> 删除</a></td>");
                @string.Append("</tr>");
            }

            return @string.ToString();
        }
    }
}