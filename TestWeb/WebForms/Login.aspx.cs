using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestWeb.WebForms
{
    public partial class Login : System.Web.UI.Page
    {
        readonly StaffBLL staffBLL = new StaffBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string account = Request["account"];
                string password = Request["password"];

                if (staffBLL.Login(account, password))
                {
                    Session["User"] = account;
                    Response.Redirect("/WebForms/Index.aspx");
                }else
                {
                    Response.Write("<script>alert('登陆失败，请检查账号密码')</script>");
                }
            }
        }


    }
}