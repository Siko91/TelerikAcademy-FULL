function DoTask7()
{
	var input = document.getElementById("input7").value;

	var tempIndex = input.indexOf("://");

	var protocol = input.substring(0, tempIndex);
	var server = input.substring(tempIndex+3, input.indexOf("/", tempIndex+3));
	var resource = input.substring(input.indexOf("/", tempIndex+3), input.length-1);

	var URL = {
		protocol: protocol,
		server: server,
		resource: resource
	};

	var result = "<strong>protocol: </strong>" + URL.protocol 
		+ "<br /><strong>server: </strong>" + URL.server 
		+ "<br /><strong>resource: </strong>" + URL.resource;

	ShowResult(result, "done", 7);
}