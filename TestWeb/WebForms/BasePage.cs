using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWeb.WebForms
{
    public class BasePage: System.Web.UI.Page
    {
        protected virtual void Page_Init(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("/WebForms/Login.aspx");
                return;
            }
        }
    }
}