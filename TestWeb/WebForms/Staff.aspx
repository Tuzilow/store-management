<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="TestWeb.WebForms.Staff" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <style>
        body {
            padding: 1.5rem;
        }

        caption {
            caption-side: top;
            color: #111;
        }

        .add-btn {
            float:right;
            margin-right:0.1rem;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-hover border table-striped">
            <caption class="h5 table-title">
                <span>商品表</span>
                <span>
                    <button type="button" class="btn btn-info add-btn btn-sm">添加</button>
                </span>
            </caption>
            <thead class="table-dark">
                <tr>
                    <th scope="col">ID</th>
                    <th scope="col">姓名</th>
                    <th scope="col">性别</th>
                    <th scope="col">生日</th>
                    <th scope="col">地址</th>
                    <th scope="col">工资</th>
                    <th scope="col">职位</th>
                    <th scope="col">操作</th>
                </tr>
            </thead>
            <tbody>
                <%=GetStaffs() %>
            </tbody>
        </table>
        <nav aria-label="Page navigation">
            <ul class="pagination">
                <li class="page-item <% if (pageIndex == 1) { Response.Write(" disabled"); } else { Response.Write(""); } %>">
                    <a class="page-link" href="#" aria-label="Previous">
                        <span aria-hidden="true">&laquo;</span>
                    </a>
                </li>
                <% 
                    for (int i = 0; i < Convert.ToInt32(Math.Ceiling(1.0 * totalCount / pageSize)); i++)
                    {
                        string page = "";

                        if (pageIndex == i + 1)
                        {
                            page += $"<li class=\"page-item active\"><a class=\"page-link\" href=\"\">{i + 1}</a></li>";
                        }
                        else
                        {
                            page += $"<li class=\"page-item\"><a class=\"page-link\" href=\"\">{i + 1}</a></li>";
                        }

                        Response.Write(page);
                    }
                %>
                <li class="page-item <% if (pageIndex == Convert.ToInt32(Math.Ceiling(1.0 * totalCount / pageSize))) { Response.Write(" disabled"); } else { Response.Write(""); } %>">
                    <a class="page-link" href="#" aria-label="Next">
                        <span aria-hidden="true">&raquo;</span>
                    </a>
                </li>
            </ul>
        </nav>
    </form>
</body>
</html>
