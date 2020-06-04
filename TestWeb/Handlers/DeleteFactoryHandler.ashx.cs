using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using Models;

namespace TestWeb.Handlers
{
    /// <summary>
    /// DeleteFactoryHandler 的摘要说明
    /// </summary>
    public class DeleteFactoryHandler : IHttpHandler
    {
        FactoryBLL factoryBLL = new FactoryBLL();
        public void ProcessRequest(HttpContext context)
        {
            string Id = context.Request.QueryString["Id"];
            if (!string.IsNullOrEmpty(Id))
            {
                int sId = int.Parse(Id);
                if (factoryBLL.DeleteById(sId))
                {
                    context.Response.Redirect("../WebForms/Factory.aspx");
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