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
    public partial class Vip : System.Web.UI.Page
    {
        readonly VipBLL vipBLL = new VipBLL();
        readonly IntegralBLL integralBLL = new IntegralBLL();

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
        /// 获取VIP表
        /// </summary>
        /// <returns></returns>
        protected string GetVips()
        {
            totalCount = new ProjectDB().GetTableDataNum("vip");

            List<VipInfo> vipList = vipBLL.Find(pageIndex, pageSize);

            if (vipList.Count() == 0)
            {
                return "<tr><td colspan=\"8\" style=\"text-align:center;\">暂无数据</td></tr>";
            }

            StringBuilder @string = new StringBuilder();
            foreach (VipInfo vip in vipList)
            {
                @string.Append($"<tr id=\"vip_{vip.Id}\">");
                @string.Append($"<th scope=\"row\">{vip.Id}</th>");
                @string.Append($"<td>{vip.Name}</td>");
                @string.Append($"<td>{(vip.Gender == "m" ? "男" : "女")}</td>");
                @string.Append($"<td>{vip.Birthday.ToString("yyyy-MM-dd")}</td>");
                @string.Append($"<td>{vip.JoinTime.ToString("yyyy-MM-dd")}</td>");
                @string.Append($"<td>{GetOneIntegral(vip.Id)}</td>");
                @string.Append($"<td><a class=\"btn btn-outline-primary btn-sm\"  data-toggle=\"modal\" data-target=\"#updateVip\" onclick=\"loadOneVip({vip.Id})\">修改</a> <a class=\"btn btn-outline-danger btn-sm\" href='javascript:void(0)' data-toggle=\"modal\" data-target=\"#deleteModal\" onclick=\"showDelete({vip.Id})\"> 删除</a></td>");
                @string.Append("</tr>");
            }

            return @string.ToString();
        }

        protected int GetOneIntegral(int id)
        {
            List<IntegralInfo> vipIntegral = integralBLL.FindOne(id);

            if (vipIntegral.Count() == 0)
            {
                return 0;
            }

            int num = 0;

            foreach (IntegralInfo integral in vipIntegral)
            {
                if (integral.IsOut)
                {
                    num -= integral.Count;
                }
                else
                {
                    num += integral.Count;
                }
            }

            return num;
        }
    }
}