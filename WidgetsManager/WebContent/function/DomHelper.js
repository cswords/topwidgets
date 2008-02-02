//it is syncronized
/**
 * function loadXML(xml)
 * @type Document
 * @param xml String
 * @return Document
 */
function loadXML(xml) {
	//alert(navigator.appName);
	var xmlDoc;
	//alert("loading "+xml);
	// load xml file
	// code for IE
	try{
	if (navigator.appName=="Microsoft Internet Explorer"){//typeof (ActiveXObject) != "undefined") {
		//alert("ie"+xml);
		xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
		xmlDoc.async = false;
		eval('xmlDoc.load("' + xml + '")');
		//alert("ie"+xml);
	}
	// code for Mozilla, Firefox, Opera, etc.
	else if (navigator.appName=='Netscape'){//document.implementation && document.implementation.createDocument) {
		//alert("ff"+xml);
		xmlDoc = document.implementation.createDocument("", "", null);
		xmlDoc.async = false;
		xmlDoc.load(xml);
		//alert("ff"+xml);
	} else {	
		try{
			var req=new XMLHttpRequest();
			//req.overrideMimeType("text/xml");
			req.open('POST', xml, false) ;
			req.send(null);
			var xmlString=req.responseText;
			alert(req.responseText);
			var appXml=new DOMParser();
			xmlDoc=appXml.parseFromString(xmlString,"text/xml");
		}catch(e){
			alert('unknown browser: '+navigator.appName);
		}
	}
	}catch(Exception){
		try{
			if (window.runtime) 
			{
			    File = window.runtime.flash.filesystem.File;
			    FileStream = window.runtime.flash.filesystem.FileStream;
			    FileMode = window.runtime.flash.filesystem.FileMode;
		        file=File.desktopDirectory.resolvePath('kmdetail.xml');
		        stream = new FileStream();
		        stream.open(file, FileMode.READ );
		        data = stream.readMultiByte( stream.bytesAvailable, File.systemCharset );
		        //alert(data);
		        stream.close();
				var appXml=new DOMParser();
				xmlDoc=appXml.parseFromString(data,"text/xml");
				alert(xmlDoc);
			}
			else{
				alert("no air.");
			}
		}catch(e){
			alert('loadXML() Error!! in '+navigator.appName);
		}
	}
	return xmlDoc;
}

//get a XML sub node
/**
 * @param parentNode Node
 * @param tagname String
 * @param aname String
 * @param avalue String
 * @return Node
 */
function getNode(parentNode,tagname,aname,avalue){
	//alert("search:"+parentNode.nodeName+":"+tagname);
	var list=parentNode.childNodes;
	for(var i=0;i<list.length;i++){
		if(list.item(i).nodeName==tagname){
			if(aname.length==0){
				//alert("find:"+parentNode.nodeName+":"+tagname);
				return list.item(i);
			}
			for(var j=0;j<list.item(i).attributes.length;j++){
				if(list.item(i).attributes.item(j).nodeName==aname){
					if(list.item(i).attributes.item(j).nodeValue==avalue)
						//alert("find:"+parentNode.nodeName+":"+tagname+":"+aname+":"+avalue);
						return list.item(i);
				}
			}
		}
	}
	return null;
}


/**
 * @Type String
 * @param source String
 * @param node Node
 * @return String
 */
function suffixURL(source,node,refPath){
	var tscript=source;
	try{
	var portalDoc=loadXML(refPath);
	}catch(Exception){alert('suffixURL:refPath error!')}
	try{
	var k=0;
	for(var j=0;j<node.childNodes.length;j++){
		if(node.childNodes.item(j).nodeName=='attribute'){
			attribute=node.childNodes.item(j);
			if(k==0)tscript+='?';
			else tscript+='&';
			tscript+=attribute.attributes.getNamedItem('name').nodeValue;
			tscript+= '=';
			for(var l=0;l<attribute.childNodes.length;l++){
				if(attribute.childNodes.item(l).nodeName=='reference'){
					var ref=attribute.firstChild;
					var account=new Account();
					//alert(attribute.childNodes.item(l).nodeName);
					//alert(attribute.childNodes.item(l).attributes.getNamedItem('refPortal').nodeValue);
					//alert(attribute.childNodes.item(l).attributes.getNamedItem('refAttribute').nodeValue);
					account.initAccount(portalDoc,
							attribute.childNodes.item(l).attributes.getNamedItem('refPortal').nodeValue
							);
					tscript+=account.attributes[
					        attribute.childNodes.item(l).attributes.getNamedItem('refAttribute').nodeValue
					        ];
					break;
				}
				if(attribute.childNodes.item(l).nodeName=='constant'){
					//alert(attribute.childNodes.item(l).nodeName);
					tscript+=attribute.childNodes.item(l).attributes.getNamedItem('value').nodeValue;
					break;
				}
			}
			k++;
		}
	}
	}catch(Exception){
		alert('suffixURL:load reference error!');
	}
	//alert(tscript);
	return tscript;
}