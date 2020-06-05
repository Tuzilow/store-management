<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="TestWeb.WebForms.Staff" %>

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
    <div id="addStaff" class="drawer dw-xs-10 dw-sm-6 dw-md-4 fold" aria-labelledby="addStaff">
        <div class="drawer-contents">
            <div class="drawer-heading">
                <h4 class="drawer-title">添加员工</h4>
            </div>
            <div class="drawer-body">
                <form id="addStaffForm" action="AddStaffHandler.ashx" method="post">
                    <div class="form-group">
                        <label for="staff_account">账号</label>
                        <input type="text" class="form-control" id="staff_account" name="staff_account" />
                    </div>
                    <div class="form-group">
                        <label for="staff_password">密码</label>
                        <input type="text" class="form-control" id="staff_password" name="staff_password" />
                    </div>
                    <div class="form-group">
                        <label for="staff_name">姓名</label>
                        <input type="text" class="form-control" id="staff_name" name="staff_name" />
                    </div>
                    <div class="form-group">
                        <label for="staff_gender">性别</label>
                        <div class="form-check">
                            <input type="radio" name="staff_gender" id="staff_gender_m" value="m" />
                            <label class="form-check-label" for="staff_gender_m">
                                男
                            </label>
                            <input type="radio" name="staff_gender" id="staff_gender_f" value="f" />
                            <label class="form-check-label" for="staff_gender_f">
                                女
                            </label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="staff_birthday">生日</label>
                        <input type="date" class="form-control" id="staff_birthday" name="staff_birthday" />
                    </div>
                    <div class="form-group">
                        <label for="staff_address">地址</label>
                        <input type="text" class="form-control" id="staff_address" name="staff_address" />
                    </div>
                    <div class="form-group">
                        <label for="staff_salary">工资</label>
                        <input type="text" class="form-control" id="staff_salary" name="staff_salary" />
                    </div>
                    <div class="form-group">
                        <label for="staff_position_id">职位</label>
                        <select class="form-control" id="staff_position_id" name="staff_position_id">
                            <% 
                                string[] positionArr = GetPositions();
                                for (int i = 0; i < positionArr.Length; i++)
                                {
                                    if (positionArr[i] != null && positionArr[i] != "")
                                    {
                                        Response.Write($"<option value=\"{i}\">{positionArr[i]}</option>");
                                    }
                                }
                            %>
                        </select>
                    </div>
                    <button type="button" class="btn btn-secondary" href="#addStaff" data-toggle="drawer" aria-foldedopen="false" controls="addStaff">取消</button>
                    <button type="button" class="btn btn-success" id="addBtn">提交</button>
                </form>
            </div>
        </div>
    </div>

    <div id="updateStaff" class="drawer dw-xs-10 dw-sm-6 dw-md-4 fold" aria-labelledby="addStaff">
        <div class="drawer-contents">
            <div class="drawer-heading">
                <h2 class="drawer-title">修改员工信息</h2>
            </div>
            <div class="drawer-body">
                <form id="updateStaffForm">
                    <input type="hidden" id="staff_id_update" name="staff_id" value="0" />
                    <div class="form-group">
                        <label for="staff_account">账号</label>
                        <input type="text" class="form-control" id="staff_account_update" name="staff_account" disabled />
                    </div>
                    <div class="form-group">
                        <label for="staff_name">姓名</label>
                        <input type="text" class="form-control" id="staff_name_update" name="staff_name" />
                    </div>
                    <div class="form-group">
                        <label for="staff_gender">性别</label>
                        <div class="form-check">
                            <input type="radio" name="staff_gender_update" id="staff_gender_m_update" value="m" />
                            <label class="form-check-label" for="staff_gender_m">
                                男
                            </label>
                            <input type="radio" name="staff_gender_update" id="staff_gender_f_update" value="f" />
                            <label class="form-check-label" for="staff_gender_f">
                                女
                            </label>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="staff_birthday">生日</label>
                        <input type="date" class="form-control" id="staff_birthday_update" name="staff_birthday" />
                    </div>
                    <div class="form-group">
                        <label for="staff_address">地址</label>
                        <input type="text" class="form-control" id="staff_address_update" name="staff_address" />
                    </div>
                    <div class="form-group">
                        <label for="staff_salary">工资</label>
                        <input type="text" class="form-control" id="staff_salary_update" name="staff_salary" />
                    </div>
                    <div class="form-group">
                        <label for="staff_position_id">职位</label>
                        <select class="form-control" id="staff_position_id_update" name="staff_position_id">
                            <% 
                                for (int i = 0; i < positionArr.Length; i++)
                                {
                                    if (positionArr[i] != null && positionArr[i] != "")
                                    {
                                        Response.Write($"<option value=\"{i}\">{positionArr[i].Trim()}</option>");
                                    }
                                }
                            %>
                        </select>
                    </div>
                    <button type="button" class="btn btn-secondary" href="#updateStaff" data-toggle="drawer" aria-foldedopen="false" controls="updateStaff">取消</button>
                    <button type="button" class="btn btn-success" id="updateBtn">提交</button>
                </form>
            </div>
        </div>
    </div>


    <table class="table table-hover border table-striped">
        <caption class="h5 table-title">
            <span>员工表</span>
            <span>
                <button type="button" class="btn btn-info add-btn btn-sm" href="#addStaff" data-toggle="drawer" aria-foldedopen="false" aria-controls="addStaff">添加</button>
            </span>
        </caption>
        <thead class="table-dark">
            <tr>
                <th scope="col">ID</th>
                <th scope="col">账号</th>
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
        $('#staff_salary').on('input propertychange', function () {
            //如果输入非数字，则替换为''
            this.value = this.value.replace(/[^\d\.]/g, '');
            //必须保证第一个为数字而不是.     
            this.value = this.value.replace(/^\./g, '');
            //保证只有出现一个.而没有多个.     
            this.value = this.value.replace(/\.{2,}/g, '.');
            //保证.只出现一次，而不能出现两次以上     
            this.value = this.value.replace('.', '$#$').replace(/\./g, '').replace('$#$', '.');
            //只能输入两位小数
            this.value = this.value.replace(/^(\-)*(\d+)\.(\d\d).*$/, '$1$2.$3');
        });
        $('#addBtn').on('click', function () {
            $.ajax({
                type: 'POST',
                url: '/Handlers/AddStaffHandler.ashx',
                data: {
                    staff_account: $('#staff_account').val(),
                    staff_password: $('#staff_password').val(),
                    staff_name: $('#staff_name').val(),
                    staff_gender: $('input[name="staff_gender"]:checked').val(),
                    staff_birthday: $('#staff_birthday').val(),
                    staff_address: $('#staff_address').val(),
                    staff_salary: $('#staff_salary').val(),
                    staff_position_id: $('#staff_position_id').val()
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
                url: '/Handlers/UpdateStaffHandler.ashx',
                data: {
                    staff_id: $('#staff_id_update').val(),
                    staff_name: $('#staff_name_update').val(),
                    staff_gender: $('input[name="staff_gender_update"]:checked').val(),
                    staff_birthday: $('#staff_birthday_update').val(),
                    staff_address: $('#staff_address_update').val(),
                    staff_salary: $('#staff_salary_update').val(),
                    staff_position_id: $('#staff_position_id_update').val()
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
                url: '/Handlers/DeleteStaffHandler.ashx',
                data: {
                    staff_id: $('#deleteModal').attr('staff-id')
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
    // 加载员工信息
    function loadOneStaff(id) {
        var member = $(`#staff_${id}`)[0].childNodes;

        $('#staff_id_update').val(member[0].innerHTML);
        $('#staff_name_update').val(member[1].innerHTML);
        $('#staff_name_update').val(member[2].innerHTML);

        if (member[3].innerHTML === '男') {
            $('#staff_gender_m_update').attr('checked', true);
        } else {
            $('#staff_gender_f_update').attr('checked', true);
        }

        $('#staff_birthday_update').val(member[4].innerHTML);
        $('#staff_address_update').val(member[5].innerHTML);
        $('#staff_salary_update').val(member[6].innerHTML);


        var ops = $("#staff_position_id_update").find('option');
        for (var i = 0; i < ops.length; i++) {
            if (ops[i].innerHTML == member[7].innerHTML) {
                ops[i].setAttribute('selected', true);
            }
        }
    }
    // 弹出删除框
    function showDelete(id) {
        $('#deleteModal').attr('staff-id', id);
    }
</script>
