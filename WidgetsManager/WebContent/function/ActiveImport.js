//definition pool
var Top_Definition=new Array();

//import a css file
function importCSS(href){
	if(!Top_Defined(href)){
		var newLink = document.createElement("link");
		newLink.rel="stylesheet";
		newLink.type="text/css";
		newLink.href=href;
		document.getElementById("head").appendChild(newLink);
		Top_Define(href);
		//alert("imported:"+href);
	}
}

//import a JS file
function importJS(href){
	if(!Top_Defined(href)){
		var newLink = document.createElement("script");
		newLink.language="javascript";
		//newLink.type="text/javascript";
		newLink.src=href;
		document.getElementsByTagName("head").item(0).appendChild(newLink);
		Top_Define(href);
		//alert("imported:"+href);
	}
}

//cover a JS file
function coverJS(href){
	//alert("run cover");
	if(Top_Defined(href)==true){
		var newLink = document.createElement("script");
		newLink.language="javascript";
		//newLink.type="text/javascript";
		newLink.src=href;
		document.getElementsByTagName("head").item(0).appendChild(newLink);
		//Top_Define(href);
		//alert("covered:"+href);
	}
	else importJS(href);
}

//import a javascript
function Top_Define(defName){
	Top_Definition.push(defName);
	Top_Definition.length++;
}

//is the defName defined?
function Top_Defined(defName){
	for(var i=0;i<Top_Definition.length;i++){
		if(Top_Definition[i]==defName)
			return true;
	}
	return false;
}
