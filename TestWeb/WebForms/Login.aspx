<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TestWeb.WebForms.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>登陆</title>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <script src="../Scripts/jquery-3.3.1.js"></script>
    <script src="../Scripts/bootstrap.js"></script>
    <style>
        body {
            height: 80vh;
            display: flex;
            justify-content: center;
            align-items: center;
            background-color: #f9f9f9;
        }

        .btn {
            width: 100%;
        }

        .card {
            width: 20rem;
        }
    </style>
</head>
<body>
    <div class="card">
        <div class="card-body">
            <h5 class="card-title">登陆商店后台系统</h5>
            <form id="loginForm" runat="server">
                <div class="form-group">
                    <label for="account">账号</label>
                    <input type="text" class="form-control" id="account" name="account" required>
                </div>
                <div class="form-group">
                    <label for="password">密码</label>
                    <input type="password" class="form-control" id="password" name="password" required>
                </div>
                <button type="submit" class="btn btn-primary">登陆</button>

                <small class="text-muted">如果没有账号，请联系人事注册</small>
            </form>
        </div>
    </div>
</body>
</html>
