function DoTask6()
{
	alert(document.getElementById("wrapper").innerHTML);
	var result = ExtractContent(document.getElementById("wrapper").innerHTML);
	ShowResult(result, "done", 6);
}

function ExtractContent(text) 
{
	return text.split(/<[^>]+>/).join("");
}