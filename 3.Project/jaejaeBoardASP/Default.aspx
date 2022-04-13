<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="jaejaeBoardASP._Default" %>
<asp:Content ID="cMainContent" ContentPlaceHolderID="MainContent" runat="server">
    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            Initialize();
            LoadGridDataCommonCodeGroup();
        });
        function Initialize() {

            $("#gridCommonCodeGroup").gridInit({
                //colNames: ['사용자ID', '이름', '승인상태', '이메일'],
                colModel: [{
                    label: "사용자ID", name: "USERID", width: 40, align: 'center', hidden: false,
                    formatter: function (cellValue, options, rowData) {
                        return "<a href='javascript:openPopupAdd(" + rowData.UKID + ");'>" + cellValue + "</a>";
                    }
                },
                { label: "이름", name: 'USERNM', width: 40, align: 'center', hidden: false },
                { label: "승인상태", name: 'AUTHTYPE', width: 40, align: 'center', hidden: false },
                {
                    label: "이메일", name: 'EMAIL1', width: 80, resizable: true, align: 'center', hidden: false,
                    formatter: function (cellValue, options, rowdata, action) {
                        if (rowdata.EMAIL1 != "") {
                            return rowdata.EMAIL1 + '@@' + rowdata.EMAIL2;
                        } else {
                            return "";
                        }
                    }
                },
                { name: 'UKID', hidden: true }
                ],
                cellattr: function () { return " class='table'" },
                height: 500,
                autowidth: true,
                rowNum: 9999999,
                datatype: 'local',
                loadonce: false,
                gridview: true,
                rownumbers: true,

                onSelectRow: function (ids) {
                    selGroupIdx = $("#gridCommonCodeGroup").jqGrid('getRowData', ids).CommonCodeGroupIdx;
                    //LoadGridDataCommonCode(selGroupIdx);
                },
                loadComplete: function () {
                    //count row
                    $("#txtCodeGroupCount").text($("#gridCommonCodeGroup").getGridParam("records"));
                    var ids = $("#gridCommonCodeGroup").jqGrid('getDataIDs');
                    for (var i = 0; i < ids.length; i++) {
                        $("#gridCommonCodeGroup").jqGrid('setRowData', ids[i], { Idx: i + 1 });
                    }
                }
            });
        }
        function LoadGridDataCommonCodeGroup() {
            $("#tbSTUDYLIST").jqGrid('setGridParam', {
                url: '/Common/ServiceHandler/UserBizHandler.ashx',
                postData: {
                    method: 'GETUSERLIST_PROC',
                    args: {
                        sData:''
                    },
                    returnType: 'json'
                },
                datatype: 'json'
            }).trigger("reloadGrid");
        }
        function openPopupAdd(ukid) {
            window.open('/testTBs/Create?Ukid=' + ukid, '사용자추가', 'width=990, height=580, top=100, left=100, fullscreen=no, menubar=no, status=no, toolbar=no, titlebar=yes, location=no, scrollbar=no');

        }
        function searchCondition() {
            var strSearchText = $("#txtSearch").val();
            if (strSearchText.length <= 0) {
                alert("검색조건을 입력하여 주세요.");
                return;
            }
            $("#gridCommonCodeGroup").clearGridData();
            $.ajax({
                type: "POST",
                url: '@Url.Action("SelectCondition", "testTBs")',
                data: {
                    strSearchText: strSearchText
                },
                success: function (data) {
                    if (data.List != null) {
                        var list = JSON.parse(data.List);
                        $("#gridCommonCodeGroup").jqGrid('setGridParam', { data: list }).trigger('reloadGrid');

                    }
                },
                error: function () {
                    alert("(ERROR) 서버와의 통신에 실패하였습니다.");
                    // hide the show message
                }
            });
        }

    </script>
    <div class="content">
    <h2 style="font-weight: bold;">사용자등록</h2>
    <div class="search_box">
        <label style="padding-right: 20px; padding-top: 10px;">
            <span class="star">*</span>검색어
            <input type="text" id="txtSearch" style="width:350px;" placeholder="사용자명, ID를 검색하세요" />
        </label>
        <label style="padding-right: 20px;">
            <span class="star">*</span>구분
            <select style="width: 100px;height: 25px;" name="" id="lstUserTypeCd" data-model="tSearchData.USERTYPECD">
                <option value="">전체</option>
                <option value="INR">내부</option>
                <option value="OUR">외부</option>
                <option value="MASTER">관리자</option>
            </select>
        </label>
        <label style="padding-right: 20px;">
            <span class="star">*</span>SMS
            <select style="width: 100px;height: 25px;" name="" id="lstIsSms" data-model="tSearchData.ISSSMS">
                <option value="">전체</option>
                <option value="Y">수신</option>
                <option value="N">미수신</option>
            </select>
        </label>
        <label style="padding-right: 20px;">
            <span class="star">*</span>이메일
            <select style="width: 100px;height: 25px;" name="" id="lstIsEmail" data-model="tSearchData.ISEMAIL">
                <option value="">전체</option>
                <option value="Y">수신</option>
                <option value="N">미수신</option>
            </select>
        </label>
        <button class="btn type2" onclick="searchCondition()">조회</button>
    </div>
    <!-- 코드현황 -->
    <div style="width:100%;">
        <div class="btn_wrap">
            <p style="padding-top:10px;">
                총
                <span id="txtCodeGroupCount">0</span>건
                <button type="button" onclick="openPopupAdd(0)" class="btn type2" style="float:right">코드추가</button>
            </p>
        </div>

        <table class="table type1" id="gridCommonCodeGroup"> </table>
    </div>
</div>

</asp:Content>
