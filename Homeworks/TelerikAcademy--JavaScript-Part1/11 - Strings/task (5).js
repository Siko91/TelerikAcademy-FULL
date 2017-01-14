function DoTask5()
{
	var originalText = "This&nbsp;is&nbsp;some&nbsp;sample&nbsp;text.&nbsp;It&nbsp;will&nbsp;be&nbsp;put&nbsp;In&nbsp;the&nbsp;function"
	var newText = ReplaceNonBreakingSpace(originalText);

	ShowResult(originalText + "<br /><br /><br />" + newText, "done", 5);
}

function ReplaceNonBreakingSpace(text) 
{
	return text.split("&nbsp;").join(" <strong>&amp;nbsp;</strong> ");
}