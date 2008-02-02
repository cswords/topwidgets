var portalBar=new KMBar();
function setlink(text,href){
	portalBar.text=text;
	portalBar.href=href;
	document.getElementById('portlink').innerHTML=portalBar.getLinkNode();	
}
function setDetail(discriptions){
	//alert("detail:"+typeof(Delicious));
	if(portalBar.details.length!=0||portalBar.discriptions.length!=0){
		//alert("hi,refresh!")
		portalBar.details=new Array();
		portalBar.discriptions=new Array();
	}
	if(typeof(Delicious)!="undefined"){
		try{
		//alert("hi,here it is!"+Delicious.posts.length);
		for(var i=0;i<Delicious.posts.length;i++){
			//alert("want"+portalBar.details.length+":"+i+":"+Delicious.posts[i].u+":"+length);
			portalBar.details.push(Delicious.posts[i].u);
			//alert("now"+(portalBar.details.length-1).toString()+":"+i+":"+Delicious.posts[i].u+":"+length);
		}
		//alert(discriptions.length);
		portalBar.discriptions=discriptions;
		}catch(e){}
	}
	else{
		portalBar.details.push("");
		portalBar.discriptions.push("log in please!");
	}		
	var delement=document.getElementById('detail');
	delement.innerHTML=portalBar.getDetailContent();
	//alert(portalBar.getDetailContent());
}
