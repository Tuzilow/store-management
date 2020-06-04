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
    public partial class Integral : System.Web.UI.Page
    {
        readonly VipBLL vipBLL = new VipBLL();
        readonly IntegralBLL integralBLL = new IntegralBLL();

        protected int pageIndex = 1;
        protected int pageSize = 9;
        protected int totalCount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected string GetIntegrals()
        {
            totalCount = new ProjectDB().GetTableDataNum("integral");

            List<IntegralInfo> integralList = integralBLL.Find(pageIndex, pageSize);

            if (integralList.Count() == 0)
            {
                return "<tr><td colspan=\"5\" style=\"text-align:center;\">暂无数据</td></tr>";
            }

            StringBuilder @string = new StringBuilder();
            foreach (IntegralInfo integral in integralList)
            {
                @string.Append($"<tr id=\"vip_{integral.Id}\">");
                @string.Append($"<th scope=\"row\">{integral.Id}</th>");
                @string.Append($"<td>{integral.Count}</td>");
                @string.Append($"<td>{(integral.IsOut == true ? "是" : "否")}</td>");
                @string.Append($"<td>{GetVipName(integral.VipId)}</td>");
                @string.Append($"<td><a class=\"btn btn-outline-danger btn-sm\" href='javascript:void(0)' data-toggle=\"modal\" data-target=\"#deleteModal\" onclick=\"showDelete({integral.Id})\"> 删除</a></td>");
                @string.Append("</tr>");
            }

            return @string.ToString();
        }

        /// <summary>
        /// 获取vip名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        protected string GetVipName(int id)
        {
            VipInfo vip = vipBLL.FindOne(id);

            return vip.Name;
        }

        /// <summary>
        /// 获取vip列表
        /// </summary>
        /// <returns></returns>
        protected string[] GetVipList()
        {
            List<VipInfo> vipList = vipBLL.Find();

            if (vipList.Count() == 0)
            {
                return null;
            }
            // 获取最大的ID以保证数组足够长
            string[] vipArr = new string[vipList[vipList.Count() - 1].Id + 1];

            foreach (VipInfo vip in vipList)
            {
                vipArr[vip.Id] = vip.Name;
            }

            return vipArr;
        }
    }
}