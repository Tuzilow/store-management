<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs"
    Inherits="TestWeb.WebForms.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>商店后台管理系统</title>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <script src="../Scripts/jquery-3.3.1.js"></script>
    <script src="../Scripts/bootstrap.js"></script>
    <link href="../Content/index.css" rel="stylesheet" />
    <style>
        main {
            padding-left: 0 !important;
            padding-right: 0 !important;
            padding-top: 0 !important;
        }

            main .iframe-class {
                width: 100%;
                height: 100%;
            }
    </style>
</head>
<body>
    <header>
        <nav class="navbar navbar-dark bg-dark">
            <span class="navbar-brand mb-0 h1">商店后台管理系统</span>
        </nav>
    </header>
    <div class="row content">
        <aside>
            <nav class="nav flex-column aside-nav">
                <a class="nav-link active" href="javascript:void(0);" onclick=" iframe.location='Goods.aspx'">商品管理</a>
                <a class="nav-link" href="javascript:void(0);" onclick=" iframe.location='Order.aspx?currentPage=1'">订单管理</a>
                <a class="nav-link" href="javascript:void(0);" onclick=" iframe.location='Factory.aspx'">供货商管理</a>
                <a class="nav-link" href="javascript:void(0);" onclick=" iframe.location='Staff.aspx?currentPage=1'">员工管理</a>
                <a class="nav-link" href="javascript:void(0);" onclick=" iframe.location='Position.aspx?currentPage=1'">职位管理</a>
                <a class="nav-link" href="javascript:void(0);" onclick=" iframe.location='Vip.aspx?currentPage=1'">会员管理</a>
                <a class="nav-link" href="javascript:void(0);" onclick=" iframe.location='Integral.aspx?currentPage=1'">积分管理</a>
            </nav>
        </aside>
        <main>
            <iframe name="iframe" class="iframe-class" src="Goods.aspx"></iframe>
        </main>
    </div>
</body>
</html>
