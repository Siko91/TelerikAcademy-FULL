function DoTask11()
{
	var text = "";
	var args = [];

	for (var i = 0; i < 50; i++) {
		text += "{" + i + "}" + " - "
		args.push("thing #"+i);
	}

	var result = "";
	result += "--==<< Original Text >>==--<br />"
	result += text;

	text = formatString(text, args);

	result += "<br /><br />--==<< Formated Text >>==--<br />"
	result += text;

	ShowResult(result, "done", 11);
}

function formatString(text, args)
{
	for (var i = args.length - 1; i >= 0; i--) {
		text = text.replace("{" + i + "}", args[i].toString());
	}

	return text;
}