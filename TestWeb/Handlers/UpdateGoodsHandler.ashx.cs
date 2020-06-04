using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using System.IO;
using Models;

namespace TestWeb.Handlers
{
    /// <summary>
    /// UpdateGoodsHandler 的摘要说明
    /// </summary>
    public class UpdateGoodsHandler : IHttpHandler
    {
        GoodsBLL goodsBll = new GoodsBLL();
        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.HttpMethod.ToUpper() == "GET")
            {
                this.DoGet(context);
            }
            else
            {
                this.DoPost(context);
            }
        }
        private void DoGet(HttpContext context)
        {
            string pId = context.Request.QueryString["Id"];
            if (!string.IsNullOrEmpty(pId))
            {
                int sId = int.Parse(pId);
                string html = File.ReadAllText(context.Request.MapPath("../HTML/UpdateGoods.html"));
                GoodsInfo pro = goodsBll.FindOne(sId);
                html = html.Replace("{@pId}", pro.Id.ToString()).Replace("{@pName}", pro.Name).Replace("{@pType}", pro.Type);
                html = html.Replace("{@pCount}", pro.Count.ToString()).Replace("{@pSellCount}", pro.SellCount.ToString()).Replace("{@pCreateTime}", pro.CreateTime.ToString("yyyy-MM-dd"));
                html = html.Replace("{@pCost}", pro.Cost.ToString()).Replace("{@pPrice}", pro.Price.ToString()).Replace("{@pEndTime}", pro.EndTime.ToString("yyyy-MM-dd")).Replace("{@pFactoryId}", pro.FactoryId.ToString());
                context.Response.Write(html);
            }
        }

        private void DoPost(HttpContext context)
        {
            string pId = context.Request.Form["pId"];
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
            goodsInfo.Id = Convert.ToInt32(pId);
            goodsInfo.Name = pName;
            goodsInfo.Type = pType;
            goodsInfo.Count = Convert.ToInt32(pCount);
            goodsInfo.SellCount = Convert.ToInt32(pSellCount);
            goodsInfo.Cost = Convert.ToInt64(pCost);
            goodsInfo.Price = Convert.ToInt64(pPrice);
            goodsInfo.CreateTime = pCreateTime;
            goodsInfo.EndTime = Convert.ToDateTime(pEndTime);
            goodsInfo.FactoryId = Convert.ToInt32(pFactoryId);
            if (goodsBll.UpdateById(goodsInfo.Id,goodsInfo.Name, goodsInfo.Type, goodsInfo.Count, goodsInfo.SellCount, goodsInfo.Cost, goodsInfo.Price, goodsInfo.CreateTime, goodsInfo.EndTime, goodsInfo.FactoryId))
             {
                context.Response.Write("<script>alert('修改成功！');window.location='../WebForms/Goods.aspx'</script>");
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