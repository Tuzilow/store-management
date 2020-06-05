<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Position.aspx.cs" Inherits="TestWeb.WebForms.Position" %>

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
    <div id="addPosition" class="drawer dw-xs-10 dw-sm-6 dw-md-4 fold" aria-labelledby="addPosition">
        <div class="drawer-contents">
            <div class="drawer-heading">
                <h2 class="drawer-title">添加职位</h2>
            </div>
            <div class="drawer-body">
                <form id="addPositionForm" action="AddPositionHandler.ashx" method="post">
                    <div class="form-group">
                        <label for="position_name">职位名</label>
                        <input type="text" class="form-control" id="position_name" name="position_name" />
                    </div>
                    <div class="form-group">
                        <label for="position_desc">职位描述</label>
                        <input type="text" class="form-control" id="position_desc" name="position_desc" />
                    </div>
                    <button type="button" class="btn btn-secondary" href="#addPosition" data-toggle="drawer" aria-foldedopen="false" controls="addPosition">取消</button>
                    <button type="button" class="btn btn-success" id="addBtn">提交</button>
                </form>
            </div>
        </div>
    </div>
        <div id="updatePosition" class="drawer dw-xs-10 dw-sm-6 dw-md-4 fold" aria-labelledby="updatePosition">
        <div class="drawer-contents">
            <div class="drawer-heading">
                <h2 class="drawer-title">修改职位</h2>
            </div>
            <div class="drawer-body">
                <form id="updatePositionForm" action="AddPositionHandler.ashx" method="post">
                     <input type="hidden" id="position_id_update" name="staff_id" value="0" />
                    <div class="form-group">
                        <label for="position_name">职位名</label>
                        <input type="text" class="form-control" id="position_name_update" name="position_name" />
                    </div>
                    <div class="form-group">
                        <label for="position_desc">职位描述</label>
                        <input type="text" class="form-control" id="position_desc_update" name="position_desc" />
                    </div>
                    <button type="button" class="btn btn-secondary" href="#updatePosition" data-toggle="drawer" aria-foldedopen="false" controls="updatePosition">取消</button>
                    <button type="button" class="btn btn-success" id="updateBtn">提交</button>
                </form>
            </div>
        </div>
    </div>
    <table class="table table-hover border table-striped">
        <caption class="h5 table-title">
            <span>职位表</span>
            <span>
                <button type="button" class="btn btn-info add-btn btn-sm" href="#addPosition" data-toggle="drawer" aria-foldedopen="false" aria-controls="addPosition">添加</button>
            </span>
        </caption>
        <thead class="table-dark">
            <tr>
                <th scope="col">ID</th>
                <th scope="col">职位名</th>
                <th scope="col">职位描述</th>
                <th scope="col">操作</th>
            </tr>
        </thead>
        <tbody>
            <%=GetPostions() %>
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
                url: '/Handlers/AddPositionHandler.ashx',
                data: {
                    position_name: $('#position_name').val(),
                    position_desc: $('#position_desc').val()
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
        $('#updateBtn').on('click', function () {
            $.ajax({
                type: 'POST',
                url: '/Handlers/UpdatePositionHandler.ashx',
                data: {
                    position_id: $('#position_id_update').val(),
                    position_name: $('#position_name_update').val(),
                    position_desc: $('#position_desc_update').val()
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
            var id = $('#deleteModal').attr('position-id');
            if (id == 1 || id == 2 || id == 3) {
                alert('该职位禁止删除');
                return;
            }
            $.ajax({
                type: 'POST',
                url: '/Handlers/DeletePositionHandler.ashx',
                data: {
                    position_id: $('#deleteModal').attr('position-id')
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
    // 弹出删除框
    function showDelete(id) {
        $('#deleteModal').attr('position-id', id);
    }
    // 加载职位信息
    function loadOnePosition(id) {
        var member = $(`#position_${id}`)[0].childNodes;

        $('#position_id_update').val(member[0].innerHTML);
        $('#position_name_update').val(member[1].innerHTML);
        $('#position_desc_update').val(member[2].innerHTML);
    }
</script>
