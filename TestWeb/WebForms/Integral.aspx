<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Integral.aspx.cs" Inherits="TestWeb.WebForms.Integral" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <link href="../Content/bootstrap-drawer.css" rel="stylesheet" />
    <script src="../Scripts/jquery-3.3.1.js"></script>
    <script src="../Scripts/bootstrap.js"></script>
    <script src="../Scripts/drawer.js"></script>
    <style>
        body {
            box-sizing: border-box;
            padding: 1.5rem;
            padding-top: 0.5rem;
            padding-right: 2rem;
        }

        caption {
            caption-side: top;
            color: #111;
        }

        .add-btn {
            float: right;
            margin-right: 0.1rem;
        }
    </style>
</head>
<body>
     <div id="addIntegral" class="modal" tabindex="-1" role="dialog" aria-labelledby="addIntegral" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h2 class="modal-title">添加积分</h2>
                </div>
                <div class="modal-body">
                    <form id="addVipForm" action="AddIntegralHandler.ashx" method="post">
                        <div class="form-group">
                            <label for="integral_count">积分数量</label>
                            <input type="number" class="form-control" id="integral_count" name="integral_count" />
                        </div>
                        <div class="form-group">
                            <label for="is_out">是否为消费</label>
                            <div class="form-check">
                                <input type="radio" name="is_out" id="is_out_t" value="true" />
                                <label class="form-check-label" for="is_out_t">
                                    是
                                </label>
                                <input type="radio" name="is_out" id="is_out_f" value="false" />
                                <label class="form-check-label" for="is_out_f">
                                    否
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="vip_id">所属用户</label>
                            <select class="form-control" id="vip_id" name="vip_id">
                            <% 
                                string[] vipArr = GetVipList();
                                for (int i = 0; i < vipArr.Length; i++)
                                {
                                    if (vipArr[i] != null && vipArr[i] != "")
                                    {
                                        Response.Write($"<option value=\"{i}\">{vipArr[i]}</option>");
                                    }
                                }
                            %>
                        </select>
                        </div>
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">取消</button>
                        <button type="button" class="btn btn-success" id="addBtn">提交</button>
                    </form>
                </div>
            </div>
        </div>
    </div>

    <table class="table table-hover border table-striped">
        <caption class="h5 table-title">
            <span>积分表</span>
            <span>
                <button type="button" class="btn btn-info add-btn btn-sm" data-toggle="modal" data-target="#addIntegral">添加</button>
            </span>
        </caption>
        <thead class="table-dark">
            <tr>
                <th scope="col">ID</th>
                <th scope="col">积分数量</th>
                <th scope="col">是否为消费</th>
                <th scope="col">所属用户</th>
                <th scope="col">操作</th>
            </tr>
        </thead>
        <tbody>
            <%=GetIntegrals() %>
        </tbody>
    </table>
    <nav aria-label="Page navigation">
        <ul class="pagination">
            <li class="page-item <% if (pageIndex == 1) { Response.Write(" disabled"); } else { Response.Write(""); } %>">
                <a class="page-link" aria-label="Previous" onclick="arrClickHandler('prev')">
                    <span aria-hidden="true">&laquo;</span>
                </a>
            </li>
            <% 
                for (int i = 0; i < Convert.ToInt32(Math.Ceiling(1.0 * totalCount / pageSize)); i++)
                {
                    string page = "";

                    if (pageIndex == i + 1)
                    {
                        page += $"<li class=\"page-item active\"><a class=\"page-link\">{i + 1}</a></li>";
                    }
                    else
                    {
                        page += $"<li class=\"page-item\"><a class=\"page-link\" onclick=\"turnPage({i + 1}, {pageSize})\">{i + 1}</a></li>";
                    }

                    Response.Write(page);
                }
            %>
            <li class="page-item <% if (pageIndex == Convert.ToInt32(Math.Ceiling(1.0 * totalCount / pageSize))) { Response.Write(" disabled"); } else { Response.Write(""); } %>">
                <a class="page-link" aria-label="Next" onclick="arrClickHandler('next')">
                    <span aria-hidden="true">&raquo;</span>
                </a>
            </li>
        </ul>
    </nav>

    <div class="modal" tabindex="-1" role="dialog" id="deleteModal">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">警告</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <p>确定删除？</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" id="deleteBtn">删除</button>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
<script>
    $(function () {
        $('#addBtn').on('click', function () {
            $.ajax({
                type: 'POST',
                url: '/Handlers/AddIntegralHandler.ashx',
                data: {
                    integral_count: $('#integral_count').val(),
                    is_out: $('input[name="is_out"]:checked').val(),
                    vip_id: $('#vip_id').val()
                },
                success: function (res) {
                    var data = JSON.parse(res);
                    alert(data.message);
                    if (data.status == 0) {
                        location.reload();
                    }
                }
            });
        });
        $('#deleteBtn').on('click', function () {
            $.ajax({
                type: 'POST',
                url: '/Handlers/DeleteIntegralHandler.ashx',
                data: {
                    integral_id: $('#deleteModal').attr('integral-id')
                },
                success: function (res) {
                    var data = JSON.parse(res);
                    alert(data.message);
                    if (data.status == 0) {
                        location.reload();
                    }
                }
            });
        });
    });
    // 弹出删除框
    function showDelete(id) {
        $('#deleteModal').attr('integral-id', id);
    }
    // 改变页码
    function turnPage(index, size) {
        if (index <= size) {
            location.href = '?currentPage=' + index;
        }
    }
    // 点击箭头换页
    function arrClickHandler(action) {
        location.href = '?currentPage=' + action;
    }
</script>
