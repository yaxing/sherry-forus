<%@ Page Language="C#" MasterPageFile="~/IndexMaster.master" AutoEventWireup="true"
    CodeFile="Index.aspx.cs" Inherits="Index" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentHolder" runat="Server">
    <div class="main float-l">
        <div id="slide" style="border: #b4b4b4 1px solid; padding: 4px; width: 412px; height: 330px">
            <!-- slide start -->

            <script language="JavaScript" type="text/javascript">
			var m_nPageInitTime = new Date();
			var MainTopRoll = new xwzRollingImageTrans("img_MAIN_TOP_ROLL_DETAIL", "imgS_MAIN_TOP_ROLL_THUMBNAIL");
						MainTopRoll.addItem("ProductInfo.aspx?ID=5","images/eg1.jpg");
						MainTopRoll.addItem("ProductInfo.aspx?ID=6","images/eg6.jpg");
						MainTopRoll.addItem("ProductInfo.aspx?ID=7","images/eg4.jpg");						
            </script>

            <div id="SlideMain">
                <img src="images/eg1.jpg" name="img_MAIN_TOP_ROLL_DETAIL" width="410" height="330"
                    class="SlideMainRoll" id="img_MAIN_TOP_ROLL_DETAIL" />
                <div style="clear: both">
                </div>
            </div>
            <div id="SlideMenu">
                <ul>
                    <li class="SlideMenuOut" id="0-l" onmouseover="document.getElementById('0-l').className='SlideMenuOver'"
                        onmouseout="document.getElementById('0-l').className='SlideMenuOut'">
                        <img name="imgS_MAIN_TOP_ROLL_THUMBNAIL" id="imgS_MAIN_TOP_ROLL_THUMBNAIL" style="display: none" />
                        <img onmouseover="MainTopRoll.alterImage(0)" style="cursor: pointer" height="50"
                            src="images/eg1.jpg" width="50" border="0" />
                    </li>
                    <li class="SlideMenuOut" id="1-l" onmouseover="document.getElementById('1-l').className='SlideMenuOver'"
                        onmouseout="document.getElementById('1-l').className='SlideMenuOut'">
                        <img name="imgS_MAIN_TOP_ROLL_THUMBNAIL" id="img1" style="display: none" />
                        <img onmouseover="MainTopRoll.alterImage(1)" style="cursor: pointer" height="50"
                            src="images/eg6.jpg" width="50" border="0" />
                    </li>
                    <li class="SlideMenuOut" id="2-l" onmouseover="document.getElementById('2-l').className='SlideMenuOver'"
                        onmouseout="document.getElementById('2-l').className='SlideMenuOut'">
                        <img name="imgS_MAIN_TOP_ROLL_THUMBNAIL" id="img2" style="display: none" />
                        <img onmouseover="MainTopRoll.alterImage(2)" style="cursor: pointer" height="50"
                            src="images/eg4.jpg" width="50" border="0" />
                    </li>
                </ul>
            </div>
            <div style="clear: both">
            </div>

            <script language="JavaScript" type="text/javascript">
			MainTopRoll.Index =  parseInt('0');
			MainTopRoll.install();
            </script>

            <!-- slide end -->
        </div>
        <div id="col" style="left: 30px; top: -31px">
            <div class=" first float-l">
                <ul>
                    <li><a href="#">　　　　　　最新产品 </a></li>
                    <li><a href="#">　　　　　　热点推荐 </a></li>
                    <li><a href="#">　　　　　　优惠促销 </a></li>
                    <li><a href="#">　　　　　　快乐抽奖 </a></li>
                    <li><a href="#">　　　　　　用户调查 </a></li>
                </ul>
            </div>
            <div class=" folat-r ">
                <ul>
                    <li><a href="#">最新产品 </a></li>
                    <li><a href="#">热点推荐 </a></li>
                    <li><a href="#">优惠促销 </a></li>
                    <li><a href="#">快乐抽奖 </a></li>
                    <li><a href="#">用户调查 </a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="side folat-r" style="font-family: 微软雅黑">
        <div id="top">
            <h2>
                产品推荐</h2>
            <table>
                <tr>
                    <td style="width: 10px">
                    </td>
                    <td>
                        <a href="ProductInfo.aspx?ID=6"><img style="width: 80px; height: 80px" src="images/eg2.jpg" /></a>
                    </td>
                    <td style="width: 10px">
                    </td>
                    <td>
                        <a href="ProductInfo.aspx?ID=6">
                            <p>
                                纪梵希感光皙颜粉底液</p>
                        </a>
                        <p>
                            &nbsp;</p>
                        <p style="font-size: 12px;">
                            肌肤的“隐形修正液” 纪梵希感光皙颜粉底...<a href="ProductInfo.aspx?ID=6">>>查看详情</a></p>
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px">
                    </td>
                    <td>
                        <a href="ProductInfo.aspx?ID=5"><img style="width: 80px; height: 80px" src="images/eg1.jpg" /></a>
                    </td>
                    <td style="width: 10px">
                    </td>
                    <td>
                        <a href="ProductInfo.aspx?ID=5">
                            <p>
                                纪梵希感光皙颜粉底液1</p>
                        </a>
                        <p>
                            &nbsp;</p>
                        <p style="font-size: 12px;">
                            肌肤的“隐形修正液” 纪梵希感光皙颜粉底...<a href="ProductInfo.aspx?ID=5">>>查看详情</a></p>
                    </td>
                </tr>
                <tr>
                    <td style="width: 10px">
                    </td>
                    <td>
                        <a href="ProductInfo.aspx?ID=9"><img style="width: 80px; height: 80px" src="images/eg6.jpg" /></a>
                    </td>
                    <td style="width: 10px">
                    </td>
                    <td>
                        <a href="ProductInfo.aspx?ID=9">
                            <p>
                                纪梵希感光皙颜粉底液2</p>
                        </a>
                        <p>
                            &nbsp;</p>
                        <p style="font-size: 12px;">
                            肌肤的“隐形修正液” 纪梵希感光皙颜粉底...<a href="ProductInfo.aspx?ID=9">>>查看详情</a></p>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td align="right">
                        <a href="#">更多...</a>
                    </td>
                </tr>
            </table>
        </div>
        <div id="bm">
            <h2>
                畅销分类</h2>
            <ul class="meun">
                <li><a href="#">炫彩眼影</a></li>
                <li><a href="#">唇膏</a></li>
                <li><a href="#">面膜</a></li>
                <li><a href="#">粉饼</a></li>
            </ul>
        </div>
    </div>
</asp:Content>
