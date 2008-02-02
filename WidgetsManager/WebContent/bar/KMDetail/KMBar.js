//a class to create KM portal bar
KMBar.prototype=new Object();
function KMBar(){};

//attributes
KMBar.prototype.href="";
KMBar.prototype.text="";
KMBar.prototype.details=new Array();
KMBar.prototype.discriptions=new Array();

//functions
KMBar.prototype.getLinkNode=function(){
	var linkNode='<a target="_blank" onclick="window.open('+"'"
			+this.href
	+"','_blank','resizable=yes,status=no,toolbar=no,menubar=no,location=no')"
	+'"'+' style="CURSOR:hand;">'
		linkNode+=this.text+"</a>";
	return linkNode;
}

KMBar.prototype.getDetailContent=function(){
	var dContent="(";
	for(var i=0;i<this.discriptions.length;i++){
		dContent+="<FONT color=#ff0000 id='info"+(i+1).toString()+"'>";
		dContent+=this.details[i]+"</FONT>";
		dContent+=this.discriptions[i];
		if(i==this.discriptions.length-1)
			dContent+=")";
		else
			dContent+=",";
	}
	return dContent;
}