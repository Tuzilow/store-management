using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using Models;

namespace TestWeb.Handlers
{
    /// <summary>
    /// DeleteOrderHandler 的摘要说明
    /// </summary>
    public class DeleteOrderHandler : IHttpHandler
    {

        OrderBLL orderBll = new OrderBLL();
        public void ProcessRequest(HttpContext context)
        {
            string Id = context.Request.QueryString["Id"];
            if (!string.IsNullOrEmpty(Id))
            {
                int sId = int.Parse(Id);
                if (orderBll.DeleteById(sId))
                {
                    context.Response.Redirect("../WebForms/Order.aspx");
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