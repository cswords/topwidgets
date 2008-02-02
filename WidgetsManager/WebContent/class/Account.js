//a class for account to login or logout
Account.prototype=new Object();
function Account(){};

//attributes
Account.prototype.server="";//server id
Account.prototype.loginAction="";//
Account.prototype.logoutAction="";//
	
//list of matched attributes' names and values
Account.prototype.anames=new Array();
Account.prototype.attributes=new Array();

Account.prototype.setAttribute=function(aname,avalue){//seter
	this.anames.push(aname);
	this.attributes[aname]=avalue;
}

//functions
Account.prototype.login=function(){
	var loginURL=this.loginAction;
	var aname;
	for(var i=0;i<this.anames.length;i++){
		if(i==0)
			loginURL+='?';
		else
			loginURL+='&';
		aname=this.anames[i];
		loginURL+=aname+'='+this.attributes[aname];
	}
	//do login here
	alert(loginURL);
}

Account.prototype.logout=function(){
	//do logout here
	alert(this.logoutAction);
}

Array.prototype.indexOf=function(value){
	for(var i=0;i<this.length;i++){
		if(this[i]==value)
			return i;
	}
	return -1;
}
Account.prototype.initAccount=function(xmlDoc,servername){
	//xmlDoc=new Document();
	var account=getNode(xmlDoc.documentElement,'account','server',servername);
	//account=new Node();
	this.server=servername;
	this.loginAction=account.attributes.getNamedItem('login').nodeValue;
	this.logoutAction=account.attributes.getNamedItem('logout').nodeValue;
	for(var i=0;i<account.childNodes.length;i++){
		if(account.childNodes.item(i).nodeName=='attribute'){
			//alert(account.childNodes.item(i).attributes.getNamedItem('name').nodeValue); 
			//alert(account.childNodes.item(i).attributes.getNamedItem('value').nodeValue);
			this.setAttribute(
					account.childNodes.item(i).attributes.getNamedItem('name').nodeValue, 
					account.childNodes.item(i).attributes.getNamedItem('value').nodeValue);		
		}
	}
}