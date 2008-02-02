function request(key)
{
    var url=location.href;
    var pos=url.indexOf("?");
    var allValues=url.substring(pos+1,url.length);
    //alert(allValues);
    var tmpValues = allValues.split("&");
    for(var i = 0; i < tmpValues.length; i++)
    {
        var tmpValue = tmpValues[i].split("=");

        if(tmpValue[0].toUpperCase()==key.toUpperCase())
            return tmpValue[1];
    }
    return "";
}