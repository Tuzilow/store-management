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
    public partial class Order : System.Web.UI.Page
    {
        OrderBLL orderBll = new OrderBLL();
        GoodsBLL goodsBll = new GoodsBLL();
        FactoryBLL factoryBll = new FactoryBLL();
        protected string oph = string.Empty;
        protected string ops = string.Empty;
        protected string OrderList = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            List<OrderInfo> orderInfo = orderBll.Find();
            StringBuilder sbTrs = new StringBuilder();
            foreach (OrderInfo order in orderInfo)
            {
                sbTrs.Append("<tr>");
                sbTrs.Append("<td>" + order.Id.ToString() + "</td>");
                sbTrs.Append("<td>" + order.GoodsId.ToString() + "</td>");
                sbTrs.Append("<td>" + order.GoodsCount.ToString() + "</td>");
                sbTrs.Append("<td>" + order.FactoryId.ToString() + "</td>");
                sbTrs.Append("<td>" + order.CreateTime.ToString("yyyy-MM-dd") + "</td>");
                sbTrs.Append("<td>" + order.OrderType + "</td>");
                sbTrs.Append("<td>" + order.Remakes + "</td>");
                //sbTrs.Append("<td><a class=\"btn btn-outline-primary btn-sm\" href=\"#update\" data-toggle=\"drawer\" aria-foldedopen=\"false\" aria-controls=\"updatetaff\" onclick=\"loadOneStaff({staff.Id})\">修改</a> <a class=\"btn btn-outline-danger btn-sm\" href='javascript:void(0)' data-toggle=\"modal\" data-target=\"#deleteModal\" onclick=\"showDelete({staff.Id})\"> 删除</a></td>");
                sbTrs.Append("<td><a href='javascript:void(0)' onclick='doDelete(" + order.Id + ")'> 删除</a></td>");
                sbTrs.Append("</tr>");
            }
            this.OrderList = sbTrs.ToString();

            //给商品id绑数据
            List<GoodsInfo> goodsInfo = goodsBll.Find();
            foreach (GoodsInfo cls in goodsInfo)
            {
                ops += "<option value='" + cls.Id + "'>" + cls.Name + "</option>";
            }
            //给供应商id绑数据
            List<FactoryInfo> factoryInfo = factoryBll.Find();
            foreach (FactoryInfo cls in factoryInfo)
            {
                oph += "<option value='" + cls.Id + "'>" + cls.Name + "</option>";
            }
        }
    }
}
