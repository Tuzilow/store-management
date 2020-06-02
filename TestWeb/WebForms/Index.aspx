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
          <a class="nav-link active" href="#">商品管理</a>
          <a class="nav-link" href="#">订单管理</a>
          <a class="nav-link" href="#">供货商管理</a>
          <a class="nav-link" href="#">员工管理</a>
          <a class="nav-link" href="#">会员管理</a>
          <a class="nav-link" href="#">职位管理</a>
        </nav>
      </aside>
      <main>
        <table class="table table-hover border">
          <caption class="h5">
            商品表
          </caption>
          <thead>
            <tr>
              <th scope="col">ID</th>
              <th scope="col">商品名</th>
              <th scope="col">种类</th>
              <th scope="col">库存</th>
              <th scope="col">卖出数量</th>
              <th scope="col">生产日期</th>
              <th scope="col">成本</th>
              <th scope="col">售价</th>
              <th scope="col">保质期</th>
              <th scope="col">供应商</th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <th scope="row">1</th>
              <td>Mark</td>
              <td>Otto</td>
              <td>@mdo</td>
              <td>@mdo</td>
              <td>@mdo</td>
              <td>@mdo</td>
              <td>@mdo</td>
              <td>@mdo</td>
              <td>@mdo</td>
            </tr>
            <tr>
              <th scope="row">2</th>
              <td>Jacob</td>
              <td>Thornton</td>
              <td>@mdo</td>
              <td>@mdo</td>
              <td>@mdo</td>
              <td>@mdo</td>
              <td>@mdo</td>
              <td>@mdo</td>
              <td>@fat</td>
            </tr>
            <tr>
              <th scope="row">3</th>
              <td>Larry the Bird</td>
              <td>@mdo</td>
              <td>@mdo</td>
              <td>@mdo</td>
              <td>@mdo</td>
              <td>@mdo</td>
              <td>@mdo</td>
              <td>@mdo</td>
              <td>@twitter</td>
            </tr>
          </tbody>
        </table>
      </main>
    </div>
  </body>
</html>
