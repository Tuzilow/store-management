using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using Models;

namespace TestWeb.Handlers
{
    /// <summary>
    /// InsertOrderHandler 的摘要说明
    /// </summary>
    public class InsertOrderHandler : IHttpHandler
    {
        OrderBLL orderBLL = new OrderBLL();
        public void ProcessRequest(HttpContext context)
        {
            string pGoodsId = context.Request.Form["pGoodsId"];
            string pGoodsCount = context.Request.Form["pGoodsCount"];
            string pFactoryId = context.Request.Form["pFactoryId"];
            DateTime pCreateTime = Convert.ToDateTime(context.Request.Form["pCreateTime"]);
            string pOrderType = context.Request.Form["pOrderType"];
            string pRemakes = context.Request.Form["pRemakes"];

            OrderInfo orderInfo = new OrderInfo();
            orderInfo.GoodsId = Convert.ToInt32(pGoodsId);
            orderInfo.GoodsCount = Convert.ToInt32(pGoodsCount);
            orderInfo.FactoryId = Convert.ToInt32(pFactoryId);
            orderInfo.CreateTime = Convert.ToDateTime(pCreateTime);
            orderInfo.OrderType = pOrderType;
            orderInfo.Remakes = pRemakes;
            

            if (orderBLL.Insert(orderInfo.GoodsId, orderInfo.GoodsCount, orderInfo.FactoryId, orderInfo.CreateTime, orderInfo.OrderType, orderInfo.Remakes))
            {
                context.Response.Write("<script>alert('订单添加成功！');window.location='../WebForms/Order.aspx'</script>");
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}