<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Notice.aspx.cs" Inherits="Pages.Message.Notice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../CSS/common.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/cuscosky.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/jquery-ui-1.8.16.custom.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/jNotify.jquery.css" rel="stylesheet" type="text/css" />

    <link href="../../CSS/page.css" rel="stylesheet" type="text/css" />

    <style type="text/css">
     
       .titlebtncls{ position:absolute; right:40px;}
       .siftdata, .addmsglink,.datago{ font-size:12px; font-weight:bold; margin-right:10px; color:#718ABE; cursor:pointer;}
       .datago{ margin-left:0px;}
       .titlebtncls input{  width:12px; height:12px; border:0; margin-top:5px; margin-right:0px;}
       img{ border:0}
         
                
    </style>

    <script src="../../Scripts/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script src="../../Scripts/zDialog.js" type="text/javascript"></script>
    <script src="../../Scripts/zDrag.js" type="text/javascript"></script>

    <script type="text/javascript">
        
        
      
        function click2(NoticeId) {
            var diag = new Dialog();
            diag.Width = 500;
            diag.Height = 300;
            //diag.Drag = false;
            diag.URL = "Detial.aspx?NoticeId=" + NoticeId;
            diag.show();
        }



        window.onload = function () {
            var getid = window.document.getElementById;
            getid("datago").onclick = function () {
                getid("imgbtndata").click();
            }

        }


    </script>


</head>

<body>
    <form id="form1" runat="server">
    <div>
        <table id="tabledata" style="width: 100%;">
            <tr>
               <td colspan="8" style="background-image: url('../../Images/win_top.png'); background-repeat: repeat-x; height:24px;">
                 <span style="font-size: 13px; font-weight: bold; margin-top: 5px; margin-left: 10px;">
                  <img style="vertical-align:middle" src="../../Images/chartorg.png" alt="导航" />
                   公告管理—>公告查看
                 </span>
                 <span class="titlebtncls">
                    <a href="AddNotice.aspx" class="addmsglink">
                      <img src="../../Images/addapply.gif" alt="添加公告" />添加公告
                   </a>
                  <asp:ImageButton runat="server"  ID="imgbtndata" 
                        ImageUrl="~/Images/tablesave.png" onclick="imgbtndata_Click"/>
                 <span id="datago" class="datago">数据导出</span> 
                </span>
               </td>
            </tr>
            <tr>
                <td colspan="8">
                    <table cellpadding="0" cellspacing="0" border="0" id="table" class="sortable">
                        <thead>
                            <tr>
                                <th>
                                    <h3>
                                        编号</h3>
                                </th>
                                <th>
                                    
                                       <h3> 公告标题</h3>
                                </th>
                                <th>
                                    
                                     <h3>   创建人</h3>
                                </th>
                                <th>
                                    
                                     <h3>   分类</h3>
                                </th>
                                <th>
                                    
                                      <h3>  开始时间</h3>
                                </th>
                                <th>
                                    
                                       <h3> 结束时间</h3>
                                </th>
                                <th>
                                    
                                       <h3> 状态</h3>
                                </th>
                                <th class="nosort">
                                    
                                        公告内容
                                </th>
                                
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <%# Eval("NoticeId") %>
                                        </td>
                                        <td>
                                            <%# Eval("Title") %>
                                        </td>
                                        <td>
                                            <%# Eval("Fromuser")%>
                                        </td>
                                        <td>
                                            <%# Eval("Sortname") %>
                                        </td>
                                        <td>
                                            <%# Eval("Begintime") %>
                                        </td>
                                        <td>
                                            <%# Eval("Endtime") %>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Pages.Message.Notice.getNoticeState(Eval("Attribute").ToString()) %>'></asp:Label>
                                        </td>
                                        <td>
                                            <a href="#" onclick='click2(<%# Eval("NoticeId") %>)'>
                                                <img src="../../Images/person.gif" alt="详细" style="border-width: 0" />
                                            </a>
                                        </td>
                                       
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <script src="../../Scripts/script.js" type="text/javascript"></script>
                    <script type="text/javascript">
                        var sorter = new TINY.table.sorter("sorter");
                        sorter.head = "head";
                        sorter.asc = "asc";
                        sorter.desc = "desc";
                        sorter.even = "evenrow";
                        sorter.odd = "oddrow";
                        sorter.evensel = "evenselected";
                        sorter.oddsel = "oddselected";
                        sorter.paginate = true;
                        sorter.currentid = "currentpage";
                        sorter.limitid = "pagelimit";
                        sorter.init("table", 1);
                    </script>
                </td>
            </tr>
        </table>
        <div id="pages" runat="server" visible="true"> </div>
    </div>
    </form>
</body>
</html>
