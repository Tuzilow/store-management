using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Models;

namespace TestWeb.WebForms
{
    public partial class Goods : System.Web.UI.Page
    {
        GoodsBLL goodsBll = new GoodsBLL();
        FactoryBLL factoryBLL = new FactoryBLL();
        protected string ops = string.Empty;
        protected string goodsList = string.Empty;


        protected void Page_Load(object sender, EventArgs e)
        {
            List<GoodsInfo> goodsInfo = goodsBll.Find();
            StringBuilder sbTrs = new StringBuilder();
            foreach (GoodsInfo cls in goodsInfo)
            {
                sbTrs.Append("<tr>");
                sbTrs.Append("<td>" + cls.Id.ToString() + "</td>");
                sbTrs.Append("<td>" + cls.Name + "</td>");
                sbTrs.Append("<td>" + cls.Type + "</td>");
                sbTrs.Append("<td>" + cls.Count.ToString() + "</td>");
                sbTrs.Append("<td>" + cls.SellCount.ToString() + "</td>");
                sbTrs.Append("<td>" + cls.CreateTime.ToString("yyyy-MM-dd") + "</td>");
                sbTrs.Append("<td>" + cls.Cost.ToString() + "</td>");
                sbTrs.Append("<td>" + cls.Price.ToString() + "</td>");
                sbTrs.Append("<td>" + cls.EndTime.ToString("yyyy-MM-dd") + "</td>");
                sbTrs.Append("<td>" + GetFactory(cls.FactoryId) + "</td>");
                sbTrs.Append("<td><a href='../Handlers/UpdateGoodsHandler.ashx?Id=" + cls.Id + "'>修改</a> <a href='javascript:void(0)' onclick='doDelete(" + cls.Id + ")'> 删除</a></td>");
                sbTrs.Append("</tr>");
            }
            goodsList = sbTrs.ToString();


            List<FactoryInfo> factoryInfo = factoryBLL.Find();
            foreach (FactoryInfo cls in factoryInfo)
            {
                ops += "<option value='" + cls.Id + "'>" + cls.Name + "</option>";
            }
        }

        protected string GetFactory(int id)
        {
            FactoryInfo factory = factoryBLL.FindOne(id);
           
            return factory.Name;
        }
    }
}

