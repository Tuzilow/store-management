<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vip.aspx.cs" Inherits="TestWeb.WebForms.Vip" %>

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
    <div id="addVip" class="modal" tabindex="-1" role="dialog" aria-labelledby="addVip" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h2 class="modal-title">添加会员</h2>
                </div>
                <div class="modal-body">
                    <form id="addVipForm" action="AddVipHandler.ashx" method="post">
                        <div class="form-group">
                            <label for="vip_name">姓名</label>
                            <input type="text" class="form-control" id="vip_name" name="vip_name" />
                        </div>
                        <div class="form-group">
                            <label for="vip_gender">性别</label>
                            <div class="form-check">
                                <input type="radio" name="vip_gender" id="vip_gender_m" value="m" />
                                <label class="form-check-label" for="vip_gender_m">
                                    男
                                </label>
                                <input type="radio" name="vip_gender" id="vip_gender_f" value="f" />
                                <label class="form-check-label" for="vip_gender_f">
                                    女
                                </label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="vip_birthday">生日</label>
                            <input type="date" class="form-control" id="vip_birthday" name="vip_birthday" />
                        </div>
                        <div class="form-group">
                            <label for="vip_join">加入时间</label>
                            <input type="date" class="form-control" id="vip_join" name="vip_join" />
                        </div>
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">取消</button>
                        <button type="button" class="btn btn-success" id="addBtn">提交</button>
                    </form>
                </div>
            </div>
        </div>
    </div>

    <div id="updateVip" class="modal" tabindex="-1" role="dialog" aria-labelledby="updateVip" aria-hidden="true">
         <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <h2 class="modal-title">修改会员信息</h2>
            </div>
            <div class="modal-body">
                <form id="updateVipForm" action="AddVipHandler.ashx" method="post">
                    <input type="hidden" id="vip_id_update" name="vip_id" value="0" />
                    <div class="form-group">
                        <label for="vip_name">姓名</label>
                        <input type="text" class="form-control" id="vip_name_update" name="vip_name" />
                    </div>
                    <div class="form-group">
                        <label for="vip_gender">性别</label>
                        <div class="form-check">
                            <input type="radio" name="vip_gender_update" id="vip_gender_m_update" value="m" />
                            <label class="form-check-label" for="vip_gender_m">
                                男
                            </label>
                            <input type="radio" name="vip_gender_update" id="vip_gender_f_update" value="f" />
                            <label class="form-check-label" for="vip_gender_f">
                                女
                            </label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="vip_birthday">生日</label>
                        <input type="date" class="form-control" id="vip_birthday_update" name="vip_birthday" />
                    </div>
                    <div class="form-group">
                        <label for="vip_join">加入时间</label>
                        <input type="date" class="form-control" id="vip_join_update" name="vip_join" />
                    </div>
                    <button type="button" class="btn btn-secondary"  data-dismiss="modal">取消</button>
                    <button type="button" class="btn btn-success" id="updateBtn">提交</button>
                </form>
            </div>
            </div>
        </div>
    </div>

    <table class="table table-hover border table-striped">
        <caption class="h5 table-title">
            <span>会员表</span>
            <span>
                <button type="button" class="btn btn-info add-btn btn-sm" data-toggle="modal" data-target="#addVip">添加</button>
            </span>
        </caption>
        <thead class="table-dark">
            <tr>
                <th scope="col">ID</th>
                <th scope="col">姓名</th>
                <th scope="col">性别</th>
                <th scope="col">生日</th>
                <th scope="col">加入时间</th>
                <th scope="col">积分</th>
                <th scope="col">操作</th>
            </tr>
        </thead>
        <tbody>
            <%=GetVips() %>
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
                url: '/Handlers/AddVipHandler.ashx',
                data: {
                    vip_name: $('#vip_name').val(),
                    vip_gender: $('input[name="vip_gender"]:checked').val(),
                    vip_birthday: $('#vip_birthday').val(),
                    vip_join: $('#vip_join').val()
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
                url: '/Handlers/UpdateVipHandler.ashx',
                data: {
                    vip_id: $('#vip_id_update').val(),
                    vip_name: $('#vip_name_update').val(),
                    vip_gender: $('input[name="vip_gender_update"]:checked').val(),
                    vip_birthday: $('#vip_birthday_update').val(),
                    vip_join: $('#vip_join_update').val()
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
                url: '/Handlers/DeleteVipHandler.ashx',
                data: {
                    vip_id: $('#deleteModal').attr('vip-id')
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
        $('#deleteModal').attr('vip-id', id);
    }
    // 加载会员信息
    function loadOneVip(id) {
        var member = $(`#vip_${id}`)[0].childNodes;

        $('#vip_id_update').val(member[0].innerHTML);
        $('#vip_name_update').val(member[1].innerHTML);

        if (member[2].innerHTML === '男') {
            $('#vip_gender_m_update').attr('checked', true);
        } else {
            $('#vip_gender_f_update').attr('checked', true);
        }

        $('#vip_birthday_update').val(member[3].innerHTML);
        $('#vip_join_update').val(member[4].innerHTML);
    }
</script>
