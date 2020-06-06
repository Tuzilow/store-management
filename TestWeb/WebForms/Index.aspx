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
            margin: 0;
        }

            main .iframe-class {
                width: 100%;
                height: 93vh;
                overflow-y: scroll !important;
            }

        .hidden {
            display: none;
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
                <a id="goods" class="nav-link active" href="javascript:void(0);">商品管理</a>
                <a id="order" class="nav-link" href="javascript:void(0);">订单管理</a>
                <a id="factory" class="nav-link" href="javascript:void(0);">供货商管理</a>
                <a id="staff" class="nav-link" href="javascript:void(0);">员工管理</a>
                <a id="position" class="nav-link" href="javascript:void(0);">职位管理</a>
                <a id="vip" class="nav-link" href="javascript:void(0);">会员管理</a>
                <a id="integral" class="nav-link" href="javascript:void(0);">积分管理</a>
            </nav>
        </aside>
        <main>
            <iframe name="iframe" class="iframe-class" src="Goods.aspx" scrolling="yes"></iframe>
        </main>
    </div>
</body>
</html>
<script>
    $(function () {
        console.log(localStorage.getItem('user_position_id') == 1)
        if (localStorage.getItem('user_position_id') != 1 && localStorage.getItem('user_position_id') != 2 && localStorage.getItem('user_position_id') != 3) {
            $('#staff').addClass('hidden');
            $('#position').addClass('hidden');
        } else {
            $('#staff').removeClass('hidden');
            $('#position').removeClass('hidden');
        }
        // 切换tab
        $('#goods').on('click', function () {
            iframe.location = 'Goods.aspx';

            $('#goods').removeClass('active');
            $('#order').removeClass('active');
            $('#factory').removeClass('active');
            $('#staff').removeClass('active');
            $('#position').removeClass('active');
            $('#vip').removeClass('active');
            $('#integral').removeClass('active');
            $('#goods').addClass('active');
        });
        $('#order').on('click', function () {
            iframe.location = 'Order.aspx?currentPage=1';

            $('#goods').removeClass('active');
            $('#order').removeClass('active');
            $('#factory').removeClass('active');
            $('#staff').removeClass('active');
            $('#position').removeClass('active');
            $('#vip').removeClass('active');
            $('#integral').removeClass('active');
            $('#order').addClass('active');
        });
        $('#factory').on('click', function () {
            iframe.location = 'Factory.aspx';

            $('#goods').removeClass('active');
            $('#order').removeClass('active');
            $('#factory').removeClass('active');
            $('#staff').removeClass('active');
            $('#position').removeClass('active');
            $('#vip').removeClass('active');
            $('#integral').removeClass('active');
            $('#factory').addClass('active');
        });
        $('#staff').on('click', function () {
            iframe.location = 'Staff.aspx?currentPage=1';

            $('#goods').removeClass('active');
            $('#order').removeClass('active');
            $('#factory').removeClass('active');
            $('#staff').removeClass('active');
            $('#position').removeClass('active');
            $('#vip').removeClass('active');
            $('#integral').removeClass('active');
            $('#staff').addClass('active');
        });
        $('#position').on('click', function () {
            iframe.location = 'Position.aspx?currentPage=1';

            $('#goods').removeClass('active');
            $('#order').removeClass('active');
            $('#factory').removeClass('active');
            $('#staff').removeClass('active');
            $('#position').removeClass('active');
            $('#vip').removeClass('active');
            $('#integral').removeClass('active');
            $('#position').addClass('active');
        });
        $('#vip').on('click', function () {
            iframe.location = 'Vip.aspx?currentPage=1';

            $('#goods').removeClass('active');
            $('#order').removeClass('active');
            $('#factory').removeClass('active');
            $('#staff').removeClass('active');
            $('#position').removeClass('active');
            $('#vip').removeClass('active');
            $('#integral').removeClass('active');
            $('#vip').addClass('active');
        });
        $('#integral').on('click', function () {
            iframe.location = 'Integral.aspx?currentPage=1';

            $('#goods').removeClass('active');
            $('#order').removeClass('active');
            $('#factory').removeClass('active');
            $('#staff').removeClass('active');
            $('#position').removeClass('active');
            $('#vip').removeClass('active');
            $('#integral').removeClass('active');
            $('#integral').addClass('active');
        });
    });
    localStorage.setItem('user_position_id', <%=GetUser().PositionId %>);
</script>
