using BLL;
using Commons;
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
        readonly ProjectDB db = new ProjectDB();
        readonly FactoryBLL factoryBLL = new FactoryBLL();
        readonly GoodsBLL goodsBLL = new GoodsBLL();
        readonly OrderBLL orderBLL = new OrderBLL();
        readonly PositionBLL positionBLL = new PositionBLL();
        readonly StaffBLL staffBLL = new StaffBLL();
        readonly VipBLL vipBLL = new VipBLL();
        readonly IntegralBLL integralBLL = new IntegralBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            db.DoAllCreate();
            InsertData();

            if (IsPostBack)
            {
                string account = Request["account"];
                string password = Request["password"];

                if (staffBLL.Login(account, password))
                {
                    Session["User"] = account;
                    Response.Redirect("/WebForms/Index.aspx");
                }
                else
                {
                    Response.Write("<script>alert('登陆失败，请检查账号密码')</script>");
                }
            }
        }

        /// <summary>
        /// 插入虚拟数据
        /// </summary>
        protected void InsertData()
        {
            if (db.GetTableDataNum("factory") == 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    factoryBLL.Insert("供应商" + i, "郑州", "1591591357" + i);
                }
            }

            if (db.GetTableDataNum("goods") == 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    goodsBLL.Insert("商品" + i, "食物", 10, 0, 2, 10, Convert.ToDateTime("2020-01-05"), Convert.ToDateTime("2021-01-05"), 1);
                }
            }

            if (db.GetTableDataNum("`order`") == 0)
            {
                orderBLL.Insert(1, 2, 1, Convert.ToDateTime("2020-06-01"), "进货", "无");
                orderBLL.Insert(2, 4, 1, Convert.ToDateTime("2020-06-01"), "进货", "无");
                orderBLL.Insert(3, 10, 1, Convert.ToDateTime("2020-06-01"), "进货", "无");
                orderBLL.Insert(4, 2, 1, Convert.ToDateTime("2020-06-01"), "进货", "无");
            }

            if (db.GetTableDataNum("`position`") == 0)
            {
                positionBLL.Insert("总经理", "总经理");
                positionBLL.Insert("人事", "管人的");
                positionBLL.Insert("经理", "经理");
                positionBLL.Insert("组长", "组长");
                positionBLL.Insert("员工", "员工");
            }

            if (db.GetTableDataNum("staff") == 0)
            {
                staffBLL.Insert("184804314", "王小明", "m", Convert.ToDateTime("1990-01-01"), "郑州", 20000, 1, "123465");
                staffBLL.Insert("145369214", "李小狼", "m", Convert.ToDateTime("1990-01-01"), "郑州", 2000, 2, "123465");
                staffBLL.Insert("145369215", "李梅", "f", Convert.ToDateTime("1990-01-01"), "上海", 10000, 3, "123465");
                staffBLL.Insert("145369216", "刘芳芳", "f", Convert.ToDateTime("1990-01-01"), "郑州", 2000, 4, "123465");
                for (int i = 0; i < 5; i++)
                {
                    staffBLL.Insert("12345678" + i, "员工" + i, "m", Convert.ToDateTime("1990-01-01"), "郑州", 1000, 5, "123465");
                }
            }

            if (db.GetTableDataNum("vip") == 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    vipBLL.Insert("会员" + i, "f", Convert.ToDateTime("2000-01-01"), Convert.ToDateTime("2020-01-01"));
                }
            }

            if (db.GetTableDataNum("integral") == 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    integralBLL.Insert(false, 100, i + 1);
                }
            }
        }
    }
}