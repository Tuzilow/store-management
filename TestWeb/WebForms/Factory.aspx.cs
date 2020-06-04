using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using BLL;
using Models;

namespace TestWeb.WebForms
{
    public partial class Factory : System.Web.UI.Page
    {
        FactoryBLL factoryBll = new FactoryBLL();
        protected string FactoryList = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            List<FactoryInfo> factoryInfo = factoryBll.Find();
            StringBuilder sbTrs = new StringBuilder();
            foreach (FactoryInfo factory in factoryInfo)
            {
                sbTrs.Append("<tr>");
                sbTrs.Append("<td>" + factory.Id.ToString() + "</td>");
                sbTrs.Append("<td>" + factory.Name + "</td>");
                sbTrs.Append("<td>" + factory.Address + "</td>");
                sbTrs.Append("<td>" + factory.Phone + "</td>");
                sbTrs.Append("<td><a href='../Handlers/UpdateFactoryHandler.ashx?Id=" + factory.Id + "'>修改</a> <a href='javascript:void(0)' onclick='doDelete(" + factory.Id + ")'> 删除</a></td>");
                sbTrs.Append("</tr>");
            }
            this.FactoryList = sbTrs.ToString();
        }
    }
}