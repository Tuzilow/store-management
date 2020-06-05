<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Factory.aspx.cs" Inherits="TestWeb.WebForms.Factory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../Content/index.css" rel="stylesheet" />
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <script src="../Scripts/jquery-3.3.1.js"></script>
    <script src="../Scripts/bootstrap.js"></script>
    <script type="text/javascript">
        function doDelete(id) {
            if (confirm("你真的要删除id为：" + id + "商品信息？")) {
                window.location = "../Handlers/DeleteFactoryHandler.ashx?Id=" + id;
            }
        }
</script>
    <style>
        body {
            box-sizing: border-box;
            padding: 1.5rem;
            padding-top: 0.5rem;
            padding-right: 2rem;
        }
    </style>
</head>
<body>
    <div class="col-sm-12" style="width: 100%">
        <span class="h2 col-10">供应商表</span>
        <input type="button" class="btn btn-info cbtn text-right" data-toggle="modal" data-target="#exampleModal" style="margin-left: 10px;" value="添  加 " />
    </div>

    <table class="table table-hover border">
        <thead>
            <tr>
                <th scope="col">供应商编号</th>
                <th scope="col">供应商名字</th>
                <th scope="col">地  址</th>
                <th scope="col">电  话</th>
                <th scope="col">操  作</th>
            </tr>
        </thead>
        <tbody id="adminTbody">
            <foreach items="${user }" var="user"> <%=FactoryList %> </foreach>
        </tbody>
    </table>
    <!--分页标签-->
    <div>
        <div id="barcon1" class="barcon1 h5 text-center"></div>
        <button type="button" class="btn btn-primary" id="firstPage">首页</button>
        <button type="button" class="btn btn-primary " id="prePage">上一页</button>
        <button type="button" class="btn btn-primary" id="nextPage">下一页</button>
        <button type="button" class="btn btn-primary" id="lastPage">尾 页</button>
        <select id="jumpWhere" class="btn btn-primary"></select>
        <button type="button" class="btn btn-primary" id="jumpPage" οnclick="jumpPage()">跳转</button>
    </div>
    <!-- 添加 -->
    <div class="modal fade my-modal add-modal" id="exampleModal">
        <div class="modal-dialog">
            <div class="modal-content">

                <div class="modal-header">
                    <h4 class="modal-title">添加供应商信息</h4>
                    <button type="button" class="close" data-dismiss="modal">
                        &times;
                   
                    </button>
                </div>

                <div class="modal-body">
                    <form
                        action="../Handlers/InsertFactoryHandler.ashx"
                        method="POST"
                        id="addForm"
                        accept-charset="UTF-8">
                        <div class="form-group">
                            <label for="pName" class="col-form-label">供应商名字：</label>
                            <input
                                name="pName"
                                type="text"
                                class="form-control"
                                id="pName" />
                        </div>
                        <div class="form-group">
                            <label for="pAddress" class="col-form-label">地  址:</label>
                            <input
                                name="pAddress"
                                type="text"
                                class="form-control"
                                id="pAddress" />
                        </div>
                        <div class="form-group">
                            <label for="pPhone" class="col-form-label">电  话:</label>
                            <input
                                name="pPhone"
                                type="text"
                                class="form-control"
                                id="pPhone" />
                        </div>
                    </form>
                </div>

                <div class="modal-footer">
                    <button
                        type="button"
                        class="btn btn-info btn-sm"
                        data-dismiss="modal"
                        id="sendAddBtn">
                        添加
                   
                    </button>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
<script>
    $('#sendAddBtn').on('click', function () {
        $('#addForm').submit();
    });
</script>

<script>
    $(function () {
        goPage(1, 10);
        var tempOption = "";
        for (var i = 1; i <= totalPage; i++) {
            tempOption += '<option value=' + i + '>' + i + '</option>'
        }
        $("#jumpWhere").html(tempOption);
    })

    var pageSize = 0;//每页显示行数
    var currentPage_ = 1;//当前页全局变量，用于跳转时判断是否在相同页，在就不跳，否则跳转。
    var totalPage;//总页数
    function goPage(pno, psize) {
        var itable = document.getElementById("adminTbody");
        var num = itable.rows.length;//表格所有行数(所有记录数)

        pageSize = psize;//每页显示行数
        //总共分几页 
        if (num / pageSize > parseInt(num / pageSize)) {
            totalPage = parseInt(num / pageSize) + 1;
        } else {
            totalPage = parseInt(num / pageSize);
        }
        var currentPage = pno;//当前页数
        currentPage_ = currentPage;
        var startRow = (currentPage - 1) * pageSize + 1;
        var endRow = currentPage * pageSize;
        endRow = (endRow > num) ? num : endRow;
        //遍历显示数据实现分页
        /*for(var i=1;i<(num+1);i++){    
            var irow = itable.rows[i-1];
            if(i>=startRow && i<=endRow){
                irow.style.display = "";    
            }else{
                irow.style.display = "none";
            }
        }*/

        $("#adminTbody tr").hide();
        for (var i = startRow - 1; i < endRow; i++) {
            $("#adminTbody tr").eq(i).show();
        }
        var tempStr = "共" + num + "条记录 分" + totalPage + "页 当前第" + currentPage + "页";
        document.getElementById("barcon1").innerHTML = tempStr;

        if (currentPage > 1) {
            $("#firstPage").on("click", function () {
                goPage(1, psize);
            }).removeClass("ban");
            $("#prePage").on("click", function () {
                goPage(currentPage - 1, psize);
            }).removeClass("ban");
        } else {
            $("#firstPage").off("click").addClass("ban");
            $("#prePage").off("click").addClass("ban");
        }

        if (currentPage < totalPage) {
            $("#nextPage").on("click", function () {
                goPage(currentPage + 1, psize);
            }).removeClass("ban")
            $("#lastPage").on("click", function () {
                goPage(totalPage, psize);
            }).removeClass("ban")
        } else {
            $("#nextPage").off("click").addClass("ban");
            $("#lastPage").off("click").addClass("ban");
        }

        $("#jumpWhere").val(currentPage);
    }


    function jumpPage() {
        var num = parseInt($("#jumpWhere").val());
        if (num != currentPage_) {
            goPage(num, pageSize);
        }
    }

</script>

