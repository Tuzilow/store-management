using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using Models;

namespace TestWeb.Handlers
{
    /// <summary>
    /// InsertGoodsHandler 的摘要说明
    /// </summary>
    public class InsertGoodsHandler : IHttpHandler
    {
        GoodsBLL goods = new GoodsBLL();
        public void ProcessRequest(HttpContext context)
        {

            string pName = context.Request.Form["pName"];
            string pType = context.Request.Form["pType"];
            string pCount = context.Request.Form["pCount"];
            string pSellCount = context.Request.Form["pSellCount"];
            DateTime pCreateTime = Convert.ToDateTime(context.Request.Form["pCreateTime"]);
            string pCost = context.Request.Form["pCost"];
            string pPrice = context.Request.Form["pPrice"];
            DateTime pEndTime = Convert.ToDateTime(context.Request.Form["pEndTime"]);
            string pFactoryId = context.Request.Form["pFactoryId"];

            GoodsInfo goodsInfo = new GoodsInfo();
            goodsInfo.Name = pName;
            goodsInfo.Type = pType;
            goodsInfo.Count = Convert.ToInt32(pCount);
            goodsInfo.SellCount = Convert.ToInt32(pSellCount);
            goodsInfo.Cost = Convert.ToInt64(pCount);
            goodsInfo.Price = Convert.ToInt64(pPrice);
            goodsInfo.CreateTime = Convert.ToDateTime(pCreateTime);
            goodsInfo.EndTime = Convert.ToDateTime(pEndTime);
            goodsInfo.FactoryId = Convert.ToInt32(pFactoryId);

            if (goods.Insert(goodsInfo.Name,goodsInfo.Type,goodsInfo.Count,goodsInfo.SellCount,goodsInfo.Cost,goodsInfo.Price,goodsInfo.CreateTime,goodsInfo.EndTime,goodsInfo.FactoryId))
            {
                context.Response.Write("<script>alert('商品添加成功！');window.location='../WebForms/Goods.aspx'</script>");
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