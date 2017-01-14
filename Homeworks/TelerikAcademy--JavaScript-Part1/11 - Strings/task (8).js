function DoTask8()
{
	var text = document.getElementById("input8").value;
	text = ReplaceTags(text);
	text = EscapeSymbols(text);
	ShowResult(text, "done", 8);
}

function ReplaceTags(text) 
{
	var index = text.indexOf("<a href=\"");
	while (index != -1) {
		
		text = ReplaceSubstr(text, index, "<a href=\"", "[URL=");

		var index2 = text.indexOf("\">", index);
		text = ReplaceSubstr(text, index2, "\">", "]");

		var index3 = text.indexOf("</a>", index);
		text = ReplaceSubstr(text, index3, "</a>", "[/URL]");
		
		index = text.indexOf("<a href=\"");
	}

	return text;
}

function ReplaceSubstr(text, index, substr, newSubstr)
{
	var result = (text.substring(0, index) + 
		newSubstr +
		text.substring(index + substr.length)
	);
	return result;
}

function EscapeSymbols(text)
{
	text = text.replace("<","&lt;");
	text = text.replace(">","&gt;");

	return text;
}