function frameLayer(){
	//var myPortal=new Document();
	var plength=5;//myPortal.getElementsByTagName('PortalBar').length
	var portalBody=document.createElement('tbody');
	for(var i=0;i<plength;i++){
		var tr=document.createElement('tr');
		var td=document.createElement('td');
		if(true){
			var iframe=document.createElement('iframe');
			iframe.setAttribute('src', 'KMDetail/KMPortalBar.html');
			td.appendChild(iframe);
		}
		else if(true){
		}
		tr.appendChild(td);
		portalBody.appendChild(tr);
	}
	document.getElementById('portal').appendChild(portalBody);
}

function getBarList(path){
	var barList=new Array();
	var xmlDoc=loadXML(path);
	
	
	return barList;
}

MiniPortalBar.prototype=new Object();
function MiniPortalBar(){};

IFrameBar.prototype=new MiniPortalBar();

LinkBar.prototype=new MiniPortalBar();
