using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using Models;

namespace TestWeb.Handlers
{
    /// <summary>
    /// DeleteGoodsHandler 的摘要说明
    /// </summary>
    public class DeleteGoodsHandler : IHttpHandler
    {
        GoodsBLL goodsBll = new GoodsBLL();
        public void ProcessRequest(HttpContext context)
        {
            string Id = context.Request.QueryString["Id"];
            if (!string.IsNullOrEmpty(Id))
            {
                int sId = int.Parse(Id);
                if (goodsBll.DeleteById(sId))
                {
                    context.Response.Redirect("../WebForms/Goods.aspx");
                }
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