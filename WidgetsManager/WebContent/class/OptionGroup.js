OptionGroup.prototype=new Object();
function OptionGroup(){};

OptionGroup.prototype.pageList=new Array();

OptionGroup.prototype.containerId;
OptionGroup.prototype.container;
OptionGroup.prototype.tagbar;
OptionGroup.prototype.pagebox;

OptionGroup.prototype.setContainer=function(id,tagbarId,pageboxId){
	this.containerId=id;
	this.container=document.getElementById(id);
	var th=document.createElement('th');
	this.tagbar=document.createElement('span');
	th.appendChild(this.tagbar);
	this.container.getElementsByTagName('thead').item(0).getElementsByTagName('tr').item(0).appendChild(th);
	this.tagbar.setAttribute('nowrap','nowrap');
	this.pagebox=this.container.getElementsByTagName('tbody').item(0).getElementsByTagName('tr').item(0);
	OptionGroupList[id]=this;
}

OptionGroup.prototype.addOptionPage=function(title,content){
	var tag=document.createElement('button');
	var nowOG=this.containerId;
	var nowOption=OptionGroupList[nowOG].pageList.length;
	tag.setAttribute('onclick',"select('"+nowOG+"',"+nowOption+")");
	try{
		eval("tag.attachEvent('onclick',function(){"
			+"select('"+nowOG+"',"+nowOption+")})");
	}catch(Exception){}
	tag.appendChild(document.createTextNode(title));
	this.tagbar.appendChild(tag);
	this.pageList.push(content);
}

OptionGroup.prototype.select=function(index){
	//alert(this.container.innerHTML);
	var l=this.tagbar.getElementsByTagName('button').length;
	var inWidth=(100/l*0.8).toString()+'%';
	var outWidth=(100/l*0.1).toString()+'%';
	for(var i=0;i<l;i++){
		var now=this.tagbar.getElementsByTagName('button').item(i);
		if(now.attributes.getNamedItem('class').nodeValue!='unselectTab'){
			now.setAttribute('class','unselectTab');
			now.className='unselectTab';
			now.setAttribute('style',"width:"+inWidth+";margin-right: "+outWidth+";");
			try{
			now.style.width=inWidth;
			now.style.marginRight = outWidth;
			}
			catch(Exception){alert('haha')}
		}
	}
	this.tagbar.getElementsByTagName('button').item(index).setAttribute('class','selectTab');
	this.tagbar.getElementsByTagName('button').item(index).className='selectTab';
	for(i=0;i<this.pagebox.childNodes.length;i++){
		this.pagebox.removeChild(this.pagebox.childNodes[i]);
	}
	var td=document.createElement('td');
	//td.setAttribute('class',  'selectContent')
	td.className='selectContent';
	td.appendChild(this.pageList[index])
	//alert(td.innerHTML);
	td.setAttribute('colspan', this.pageList.length);
	this.pagebox.appendChild(td);
}

var OptionGroupList=new Array();

function select(id,index){
	OptionGroupList[id].select(index);
}

function test(){
	var og=new OptionGroup();
	og.setContainer('og1','tag1','box1');
	/////////////////////////////////////////////////////
	var nowPage;
	
	var xmlDoc=loadXML("./XML/MiniPortal.xml");
	var i=0;
	for(i=0;i<xmlDoc.documentElement.childNodes.length;i++){
		var nowGroup=xmlDoc.documentElement.childNodes.item(i);
		if(nowGroup.nodeName=="BarGroup"){
			//make the group table;
			nowPage=document.createElement('table');
			var tbody=document.createElement('tbody');
			var title="";
			title=nowGroup.attributes.getNamedItem("name").nodeValue;
			var j=0;
			for(j=0;j<nowGroup.childNodes.length;j++){
				if(nowGroup.childNodes.item(j).nodeName=="PortalBar"){
					//make portal bar
					var tr=document.createElement('tr');
					var td=document.createElement('td');
					
					var nowBar=nowGroup.childNodes.item(j);
					var k=0;
					for(k=0;k<nowBar.childNodes.length;k++){
						var nowNode=nowBar.childNodes.item(k);
						var content;
						var path='';
						if(nowNode.nodeName=="page"){
							//make a iframe
							content=document.createElement('iframe');
							path=nowNode.attributes.getNamedItem('href').nodeValue;
							////suffix
							
							content.setAttribute('src', path)
							content.frameBorder='0';
							content.scrolling='no';
							break;
						}else if(nowNode.nodeName=="link"){
							//make a hyperlink
							content=document.createElement('span');
							var text='';
							text=nowNode.attributes.getNamedItem('text').nodeValue;
							path=nowNode.attributes.getNamedItem('href').nodeValue;
							////suffix

							content.innerHTML="<a onclick=window.open('"+path+"') style='CURSOR:hand;color:#10598F'>"+text+"</a>"
							break;
						}
						content=document.createElement("span");
						content.appendChild(document.createTextNode("some thing wrong."));
					}
					//add the portal bar;
					td.appendChild(content);
					tr.appendChild(td);
					tbody.appendChild(tr);
				}
			}
			//add the group table to main group
			//alert(nowPage.innerHTML);
			nowPage.appendChild(tbody);
			og.addOptionPage(title, nowPage);
		}		
	}
	/////////////////////////////////////////////////////
	/*
	var p2=document.createElement('iframe');
	
	p2.setAttribute('src', "./bar/KMTool/KMTool.html");
	p2.frameBorder='0';
	p2.scrolling='no';	
	p2.align='left';
	p2.setAttribute('align', 'center');
	var kk=document.createElement('table');
	tbody=document.createElement('tbody');
	tr=document.createElement('tr');
	td=document.createElement('td');
	td.appendChild(p2);
	tr.appendChild(td);
	tbody.appendChild(tr);
	kk.appendChild(tbody);
	og.addOptionPage('测试板', kk);*/
	og.select(0);
}

function relogin()
{
	document.getElementById('action').setAttribute('src', './login/kmbaklogin.html')
}

function logout()
{
	document.getElementById('action').setAttribute('src', './login/KMLogout.html')
}