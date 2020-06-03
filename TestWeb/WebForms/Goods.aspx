<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Goods.aspx.cs" Inherits="TestWeb.WebForms.Goods" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
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
            <!--<tr>
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
            </tr>-->
              <%=goodsList %>
          </tbody>
        </table>
       
    </form>
</body>
</html>
