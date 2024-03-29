<%@ Page Language="C#" AutoEventWireup="true" CodeFile="left.aspx.cs" Inherits="Management_left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>导航</title>
    <style type="text/css">
body {
	BACKGROUND: #799ae1; MARGIN: 0px; FONT: 9pt 宋体
}
table {
	BORDER-RIGHT: 0px; BORDER-TOP: 0px; BORDER-LEFT: 0px; BORDER-BOTTOM: 0px
}
td {
	FONT: 12px 宋体
}
img {
	BORDER-RIGHT: 0px; BORDER-TOP: 0px; VERTICAL-ALIGN: bottom; BORDER-LEFT: 0px; BORDER-BOTTOM: 0px
}
a {
	FONT: 12px 宋体; COLOR: #000000; TEXT-DECORATION: none
}
a:hover {
	COLOR: #428eff; TEXT-DECORATION: underline
}
.sec_menu {
	BORDER-RIGHT: white 1px solid; BACKGROUND: #d6dff7; OVERFLOW: hidden; BORDER-LEFT: white 1px solid; BORDER-BOTTOM: white 1px solid
}
.menu_title {
	
}
.menu_title span {
	FONT-WEIGHT: bold; LEFT: 7px; COLOR: #215dc6; POSITION: relative; TOP: 2px
}
.menu_title2 {
	
}
.menu_title2 span {
	FONT-WEIGHT: bold; LEFT: 8px; COLOR: #428eff; POSITION: relative; TOP: 2px
}
</style>

<script type="text/javascript">
function showsubmenu(sid)
{
whichEl = eval("submenu" + sid);
if (whichEl.style.display == "none")
{
eval("submenu" + sid + ".style.display=\"\";");
}
else
{
eval("submenu" + sid + ".style.display=\"none\";");
}
}
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table cellspacing="0" cellpadding="0" width="100%" align="left" border="0">
  <tr>
    <td valign="top" bgcolor="#799ae1">
      <table cellspacing="0" cellpadding="0" width="158" align="center">
        <tr>
          <td valign="bottom" height="42">
            <img height="38" src="left.files/title.gif" width="158" />
          </td>
        </tr>
      </table>
      <table cellspacing="0" cellpadding="0" width="158" align="center">
        <tr>
          <td class="menu_title" onmouseover="this.className='menu_title2';" onmouseout="this.className='menu_title';" height="25">
          <span>&nbsp;<asp:LinkButton ID="LBLogout" runat="server" OnClick="LBLogout_Click">退出管理</asp:LinkButton></span></td>
        </tr>
        <tr>
          <td class="menu_title" onmouseover="this.className='menu_title2';" onmouseout="this.className='menu_title';" height="25">
            &nbsp;
          </td>
        </tr>
      </table>
      
      <asp:Panel ID="PanelAdmin" runat="server">
	  <table cellspacing="0" cellpadding="0" width="158px" align="center">
        <tr>
          <td class="menu_title" id="menuTitle1" onmouseover="this.className='menu_title2';" onclick="showsubmenu(0)" onmouseout="this.className='menu_title';" background="left.files/admin_left_1.gif" height="25">
          <span>
            <b>管理员管理</b>
          </span>
          </td>
        </tr>
        <tr>
          <td id="submenu0">
            <div class="sec_menu" style="WIDTH: 156px ">
            <table cellspacing="0" cellpadding="0" width="135" align="center">
              <tr>
                <td height="20">
                  <a href="AdminManage/AddAdmin.aspx" target="mainFrame">添加管理员</a>
                </td>
              </tr>
               <tr>
                <td height="20">
                  <a href="AdminManage/ListAdmin.aspx" target="mainFrame">管理员显示|调整|删除</a>
                </td>
              </tr>
              <tr>
                <td height="20">
                  <a href="AdminManage/ListUser.aspx" target="mainFrame">用户显示|调整|删除</a>
                </td>
              </tr>
               <tr>
                 <td height="20">
                   <a href="AdminManage/ModiAdminSelf.aspx" target="mainFrame">修改我的信息</a>
                 </td>
               </tr>
            </table>
            </div>
            <div style="WIDTH: 156px">
            <table cellspacing="0" cellPadding="0" width="135px" align="center">
              <tr>
                <td height="20">
                </td>
              </tr>
            </table>
            </div>
          </td>
        </tr>
      </table>
      </asp:Panel>
      
      <asp:Panel ID="PanelWorker" runat="server">
	  <table cellspacing="0" cellpadding="0" width="158" align="center">
        
        <tr>
          <td class="menu_title" id="Td1" onmouseover="this.className='menu_title2';" onclick="showsubmenu(1)" onmouseout="this.className='menu_title';" background="left.files/admin_left_2.gif" height="25">
            <span>工作人员管理</span> 
          </td>
        </tr>
        <tr>
          <td id="submenu1">
            <div class="sec_menu" style="WIDTH: 156px">
            <table cellspacing="0" cellpadding="0" width="135" align="center">
              <tr>
                <td height="20">
                  <a href="WorkerManage/AddWorker.aspx"target="mainFrame">工作人员添加</a>
                </td>
              </tr>
              <tr>
                <td height="20">
                  <a href="WorkerManage/ListWorker.aspx" target="mainFrame">工作人员显示|调整|删除</a>
                </td>
              </tr>
              <tr>
                <td height="20">
                  <a href="WorkerManage/ModiWorker.aspx" target="mainFrame">修改我的信息</a>
                </td>
              </tr>
              </table>
            </div>
            <div style="WIDTH: 156px">
            <table cellspacing="0" cellpadding="0" width="135px" align="center">
              <tr>
                <td height="20">
                </td>
              </tr>
            </table>
            </div>
          </td>
        </tr>
      </table>
      </asp:Panel>
      
      
      <asp:Panel ID="PanelGoods" runat="server">
      <table cellspacing="0" cellpadding="0" width="158px" align="center"> 
          <tr>
            <td class="menu_title" id="Td2" onmouseover="this.className='menu_title2';" onclick="showsubmenu(2)" onmouseout="this.className='menu_title';" background="left.files/admin_left_2.gif" height="25">
              <span>商品管理</span>
            </td>
          </tr>
          <tr>
            <td id="submenu2">
            <div class="sec_menu" style="WIDTH: 156px">
                <table cellspacing="0" cellpadding="0" width="135" align="center">
                    <tr>
                      <td height="20">
                        <a href="/Web/Management/WorkerManage/AddGoods.aspx" target="mainFrame">商品添加</a>
                      </td>
                    </tr>
                    <tr>
                      <td height="20">
                        <a href="/Web/Management/WorkerManage/FindGoods.aspx" target="mainFrame">商品查找</a>
                      </td>
                    </tr>
                </table>
            </div>
                <div style="WIDTH: 156px">
                  <table cellspacing="0" cellpadding="0" width="135" align="center">
                      <tr>
                        <td height="20"></td>
                      </tr>
                  </table>
                </div>
            </td>
          </tr>
      </table>
	  </asp:Panel>
	  
	  <asp:Panel ID="PanelCallCenter" runat="server">
	  <table cellspacing="0" cellpadding="0" width="158px" align="center">
        
          <tr>
            <td class="menu_title" id="Td6" onmouseover="this.className='menu_title2';" onclick="showsubmenu(25)" onmouseout="this.className='menu_title';" background="left.files/admin_left_2.gif" height="25">
              <span>电话销售</span>
            </td>
          </tr>
          <tr>
            <td id="submenu25">
			 <div class="sec_menu" style="WIDTH: 156px">
			   <table cellspacing="0" cellpadding="0" width="135" align="center">
                   <tr>
                     <td height="20">
                       <a href="/Web/Management/WorkerManage/AddOrder.aspx" target="mainFrame">添加订单</a>
                     </td>
                   </tr>
                   <tr>
                     <td height="20">
                       <a href="/Web/Management/WorkerManage/OrderFromCallCenter.aspx" target="mainFrame">订单显示</a>
                     </td>
                   </tr>
                </table>
			 </div>
            <div style="WIDTH: 156px">
            <table cellspacing="0" cellpadding="0" width="135" align="center">
              <tr>
                <td height="20">
                </td>
              </tr>
            </table>
            </div>
			</td>
          </tr>
      </table>
      </asp:Panel>
	  
	  <asp:Panel ID="PanelLogistic" runat="server">
	  <table cellspacing="0" cellpadding="0" width="158px" align="center">
        
          <tr>
            <td class="menu_title" id="Td3" onmouseover="this.className='menu_title2';" onclick="showsubmenu(30)" onmouseout="this.className='menu_title';" background="left.files/admin_left_2.gif" height="25">
              <span>物流管理</span>
            </td>
          </tr>
          <tr>
            <td id="submenu30">
			 <div class="sec_menu" style="WIDTH: 156px">
			   <table cellspacing="0" cellpadding="0" width="135" align="center">
                   <tr>
                     <td height="20">
                       <a href="WorkerManage/ShowOrderForWorker.aspx" target="mainFrame">工作人员查看订单</a>
                     </td>
                   </tr>
                   <asp:Panel ID="PanelManagerOrder" runat="server">
				    <tr>
                     <td height="20">
                       <a href="WorkerManage/ShowOrdersForManager.aspx" target="mainFrame">负责人查看订单</a>
                     </td>
                   </tr>
                   </asp:Panel>
                </table>
			 </div>
            <div style="WIDTH: 156px">
            <table cellspacing="0" cellpadding="0" width="135" align="center">
              <tr>
                <td height="20">
                </td>
              </tr>
            </table>
            </div>
			</td>
          </tr>
      </table>
      </asp:Panel>
	
	<asp:Panel ID="MarketDecisonPanel" runat="server">
	  <table cellspacing="0" cellpadding="0" width="158" align="center">
        
          <tr>
            <td class="menu_title" id="Td6" onmouseover="this.className='menu_title2';" onclick="showsubmenu(78)" onmouseout="this.className='menu_title';" background="left.files/admin_left_2.gif" style="height: 24px">
              <span>市场决策</span>
            </td>
          </tr>
          <tr>
            <td id="submenu78">
			 <div class="sec_menu" style="WIDTH: 156px">
			   <table cellspacing="0" cellpadding="0" width="135" align="center">
			        <tr>
                     <td height="20">
                       <a href="/Web/Management/AdminManage/Upload.aspx" target="mainFrame">店面销售信息导入</a>
                     </td>
                   </tr>
                   <tr>
                     <td height="20">
                       <a href="/Web/Management/AdminManage/MarketDecision.aspx" target="mainFrame">市场决策</a>
                     </td>
                   </tr>
				
                </table>
			 </div>
            <div style="WIDTH: 156px">
            <table cellspacing="0" cellpadding="0" width="135" align="center">
              <tr>
                <td height="20">
                </td>
              </tr>
            </table>
            </div>
			</td>
          </tr>
      </table>
      </asp:Panel>
      
      
      
      
      <asp:Panel ID="PanelService" runat="server">
      <table cellspacing="0" cellpadding="0" width="158px" align="center"> 
          <tr>
            <td class="menu_title" id="Td4" onmouseover="this.className='menu_title2';" onclick="showsubmenu(20)" onmouseout="this.className='menu_title';" background="left.files/admin_left_2.gif" height="25">
              <span>客户服务</span>
            </td>
          </tr>
          <tr>
            <td id="submenu20">
			 <div class="sec_menu" style="WIDTH: 156px">
			   <table cellspacing="0" cellpadding="0" width="135" align="center">
                   <tr>
                     <td height="20">
                       <a href="AdminManage/AddPoll.aspx" target="mainFrame">添加投票</a>
                     </td>
                   </tr>
				    <tr>
                     <td height="20">
                       <a href="AdminManage/EditPoll.aspx" target="mainFrame">编辑投票</a>
                     </td>
                   </tr>
                   <tr>
                     <td height="20">
                       <a href="AdminManage/CSManage.aspx" target="mainFrame">回复留言</a>
                     </td>
                   </tr>
                </table>
			 </div>
            <div style="WIDTH: 156px">
            <table cellspacing="0" cellpadding="0" width="135" align="center">
              <tr>
                <td height="20">
                </td>
              </tr>
            </table>
            </div>
			</td>
          </tr>
      </table>
	  </asp:Panel>
	  
	  
      <table cellspacing="0" cellpadding="0" width="158px" align="center">
        
        <tr>
          <td class="menu_title" id="Td5" onmouseover="this.className='menu_title2';" onmouseout="this.className='menu_title';" background="left.files/admin_left_9.gif" height="25">
            <span>个人信息</span>
          </td>
        </tr>
        <tr>
          <td>
            <div class="sec_menu" style="WIDTH: 156px">
            <table cellspacing="0" cellpadding="0" width="135" align="center">
              <tr>
                <td height=20 bgcolor="#D6DFF7" style="LINE-HEIGHT: 150%">
                    <asp:Literal ID="ltlModiSelf" runat="server"></asp:Literal>
                </td>
              </tr>
            </table>
            </div>
          </td>
        </tr>
      </table>
     
   </td> 
  </tr>
</table>

    </div>
    </form>
</body>
</html>
