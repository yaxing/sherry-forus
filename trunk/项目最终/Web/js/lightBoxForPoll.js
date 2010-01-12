function $(id){return document.getElementById(id);}
//var isIE = (document.all) ? true : false;
function Box(objID,W,H,inner,footerInner){
	var objHead2,objBody2,objFooter2,inner,footerInner;
	if(!$(objID)){
	//创建html结构并赋id以及class		
		var obj2 = document.createElement("div");		
		var objHead2 = document.createElement("div");
		var objBody2 = document.createElement("div");
		var objFooter2 = document.createElement("div");
		obj2.id=objID;
		obj2.className="lightBox";		
		objHead2.id=objID+"_head";
		objBody2.id=objID+"_body";
		objFooter2.id=objID+"_footer";
		objHead2.className="Boxheader";
		objBody2.className="Boxbody";
		objFooter2.className="Boxfooter";		
		obj2.appendChild(objHead2);
		obj2.appendChild(objBody2);
		obj2.appendChild(objFooter2);
		document.body.appendChild(obj2);
		//如果参数为空时的处理
		if(W==undefined||W<200||W==""){W=200}//最小宽度
		if(H==undefined||H<60||H==""){H=60}
		if(inner==undefined || inner=="" ){inner="欢迎光临书序网！这里有很多简历和范文哦！"}
		if(footerInner==undefined || footerInner=="" ){footerInner="www.shuxu.com &copy; 2009"}//页脚没有内容时默认值
		var BodyLid = objID+"BodyL",BodyRid = objID+"BodyR",headerLid = objID+"headerL",FooterLid= objID+"FooterL",closeBtn= objID+"closeBtn",cancelBtn =objID+"cancel";		
		objBody2.innerHTML='<div class="BodyL" id='+BodyLid+'>'+inner+'</div><div class="BodyR" id='+BodyRid+'></div>';
		objHead2.innerHTML='<div class="headerL" id='+headerLid+'><span style="float:right;background:url(images/lightbox-close.png) no-repeat 0 center;display:inline-block;height:46px;width:16px;cursor:pointer;" id='+closeBtn+'></span></div><div class="headerR"></div>';
		objFooter2.innerHTML='<div class="FooterL" id='+FooterLid+'>'+footerInner+'</div><div class="FooterR"></div>';
		//js样式设置
		$(BodyLid).style.height=H+"px";
		$(BodyLid).style.width=W+"px";
		$(FooterLid).style.width=$(headerLid).style.width=W+"px";
		$(BodyRid).style.height=$(BodyLid).clientHeight+"px";		
		obj2.style.cssText+=";position:absolute;left:50%;top:50%;z-index:901;";		
		obj2.style.marginLeft=-obj2.scrollWidth/2+"px";
		obj2.style.marginTop=-obj2.scrollHeight/2+"px";	
		
		document.body.style.cssText+="height:100%;overflow:hidden;";		
		var mask=1;//是否创建遮罩层
		if(mask){
			var objMask = document.createElement("div");
				objMask.id="Mask";objMask.className="BoxMask";
				document.body.appendChild(objMask);objMask.style.cssText+=";position:absolute;z-index:900;";
				objMask.style.height=document.documentElement.scrollHeight+document.documentElement.scrollTop+"px";
			}
		function Close(objID){
			document.body.removeChild($(objID));document.body.style.cssText+="width:100%;overflow:auto;"; if(objMask){document.body.removeChild(objMask)}
		}
		$(closeBtn).onclick = function(){Close(objID)};//关闭按钮
		if($(cancelBtn)){$(cancelBtn).onclick = function(){Close(objID)}}//取消按钮
		
		//拖动功能			
	//if(evt.keycode==27){alert("esc")};
	var w = obj2.scrollWidth,h = obj2.scrollHeight;
	var iWidth = document.documentElement.clientWidth; 
	var iHeight = document.documentElement.clientHeight; 	
	var moveX = 0,moveY = 0,moveTop = 0,moveLeft = 0,moveable = false;
		objHead2.onmousedown = function(e) {	
		moveable = true; 	
		e = window.event?window.event:e;
		moveX = e.clientX-obj2.offsetLeft;		
		moveY = e.clientY-obj2.offsetTop;
		obj2.style.zIndex++;
		document.onmousemove = function(e) {
				if (moveable) {
				e = window.event?window.event:e;		
				var x = e.clientX - moveX;
				var y = e.clientY - moveY;
					if ( x > 0 &&( x + w < iWidth) && y > 0 && (y + h < iHeight) ) {
						obj2.style.left = x + "px";
						obj2.style.top = y + "px";
						obj2.style.margin = "auto";
						}
					}
				}
				document.onmouseup = function () {moveable = false;};
		}
	}else(alert("has been opened!"));
	
}//box();End
