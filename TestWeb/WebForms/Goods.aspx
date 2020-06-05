<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Goods.aspx.cs" Inherits="TestWeb.WebForms.Goods" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <script src="../Scripts/jquery-3.3.1.js"></script>
    <script src="../Scripts/bootstrap.js"></script>
    <link href="../Content/index.css" rel="stylesheet" />
    <script type="text/javascript">
        function doDelete(id) {
            if (confirm("你真的要删除id为：" + id + "商品信息？")) {
                window.location = "../Handlers/DeleteGoodsHandler.ashx?Id=" + id;
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
        <span class="h2 col-10">商品表</span>
        <input type="button" class="btn btn-info cbtn text-right" data-toggle="modal" data-target="#exampleModal" style="margin-left: 10px;" value="添  加 " />
    </div>
    <table class="table table-hover border">

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
                <th scope="col">操  作</th>
            </tr>
        </thead>
        <tbody id="adminTbody">
            <foreach items="${user }" var="user"> <%=goodsList %> </foreach>
        </tbody>
    </table>
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
                    <h4 class="modal-title">添加商品</h4>
                    <button type="button" class="close" data-dismiss="modal">
                        &times;
                   
                    </button>
                </div>

                <div class="modal-body">
                    <form
                        action="../Handlers/InsertGoodsHandler.ashx"
                        method="POST"
                        id="addForm"
                        accept-charset="UTF-8">
                        <div class="form-group">
                            <label for="pName" class="col-form-label">商品名字</label>
                            <input
                                name="pName"
                                type="text"
                                class="form-control"
                                id="pName" />
                        </div>
                        <div class="form-group">
                            <label for="pType" class="col-form-label">商品种类：</label>
                            <input
                                name="pType"
                                type="text"
                                class="form-control"
                                id="pType" />
                        </div>
                        <div class="form-group">
                            <label for="pCount" class="col-form-label">库存:</label>
                            <input
                                name="pCount"
                                type="text"
                                class="form-control"
                                id="pCount" />
                        </div>
                        <div class="form-group">
                            <label for="pSellCount" class="col-form-label">卖出数量:</label>
                            <input
                                name="pSellCount"
                                type="text"
                                class="form-control"
                                id="pSellCount" />
                        </div>
                        <div class="form-group">
                            <label for="pCreateTime" class="col-form-label">生产日期</label>
                            <input
                                name="pCreateTime"
                                type="date"
                                class="form-control"
                                id="pCreateTime" />
                        </div>
                        <div class="form-group">
                            <label for="pCost" class="col-form-label">成本:</label>
                            <input
                                name="pCost"
                                type="text"
                                class="form-control"
                                id="pCost" />
                        </div>
                        <div class="form-group">
                            <label for="pPrice" class="col-form-label">售价：</label>
                            <input
                                name="pPrice"
                                type="text"
                                class="form-control"
                                id="pPrice" />
                        </div>
                        <div class="form-group">
                            <label for="pEndTime" class="col-form-label">保质期</label>
                            <input
                                name="pEndTime"
                                type="date"
                                class="form-control"
                                id="pEndTime" />
                        </div>
                        <div class="form-group">
                            <label for="pFactoryId" class="col-form-label">供应商:</label>
                            <select name="pFactoryId" class="form-control" id="pFactoryId"><%=ops %></select>
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

    var pageSize = 0;
    var currentPage_ = 1;
    var totalPage;
    function goPage(pno, psize) {
        var itable = document.getElementById("adminTbody");
        var num = itable.rows.length;

        pageSize = psize;

        if (num / pageSize > parseInt(num / pageSize)) {
            totalPage = parseInt(num / pageSize) + 1;
        } else {
            totalPage = parseInt(num / pageSize);
        }
        var currentPage = pno;
        currentPage_ = currentPage;
        var startRow = (currentPage - 1) * pageSize + 1;
        var endRow = currentPage * pageSize;
        endRow = (endRow > num) ? num : endRow;

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
