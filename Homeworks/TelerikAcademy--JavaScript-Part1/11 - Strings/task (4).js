function DoTask4()
{
	var input = document.getElementById("input4").value;

	var openingTag = getFirstOpeningTag(input);
	var closingTag;

	
	while (openingTag != null) {
		closingTag = getCorespondingClosingTag(input, openingTag);

		if (closingTag != null) {
			input = convertBetweenTags(input, openingTag, closingTag);
		}

		openingTag = getFirstOpeningTag(input);
	}

	ShowResult(input, "done", 4);
}

function convertBetweenTags(text, startTag, endTag)
{
	switch (startTag.tagName) {
		case "<upcase>":
			text = convertToUpper(text, startTag.index, endTag.index);
			break;
		case "<mixcase>":
			text = convertToMixed(text, startTag.index, endTag.index);
			break;
		case "<lowcase>":
			text = convertToLower(text, startTag.index, endTag.index);
			break;
		default: break;
	}

	return text;
}

function convertToUpper(text, start, end)
{
	return (text.substring(0, start) + 
		text.substring(start + "<upcase>".length, end).toUpperCase() +
		text.substring(end + "</upcase>".length)
	);
}

function convertToMixed(text, start, end) 
{
	return (text.substring(0, start) + 
		mixTheCase(text.substring(start + "<mixcase>".length, end)) +
		text.substring(end + "</mixcase>".length)
	);
}

function mixTheCase(text) {
	var result = [];
	for (var i = 0; i < text.length; i++) {

		var rnd = Math.random();
		if (rnd > 0.5) {
			result.push(text[i].toUpperCase());
		}
		else {
			result.push(text[i].toLowerCase());
		}
	}
	return result.join("");
}

function convertToLower(text, start, end) 
{
	return (text.substring(0, start) + 
		text.substring(start + "<lowcase>".length, end).toLowerCase() +
		text.substring(end + "</lowcase>".length)
	);
}

function getFirstOpeningTag(text) 
{
	var index1 = text.indexOf("<upcase>");
	var index2 = text.indexOf("<mixcase>");
	var index3 = text.indexOf("<lowcase>");

	var min = Number.MAX_VALUE;
	var tagStr = "";
	var indexFound = false;

	if (index1 < min && index1 != -1) {
		min = index1;
		tagStr = "<upcase>";
		indexFound = true;
	}
	if (index2 < min && index2 != -1) {
		min = index2;
		tagStr = "<mixcase>";
		indexFound = true;
	}
	if (index3 < min && index3 != -1) {
		min = index3;
		tagStr = "<lowcase>";
		indexFound = true;
	}

	if (indexFound) {
		return new Tag(min, tagStr);
	}
	else {
		return null;
	}
}

function getCorespondingClosingTag(text, openingTag)
{
	var closingTagStr = "";
	switch(openingTag.tagName) {
		case "<upcase>":
			closingTagStr = "</upcase>";
			break;
		case "<mixcase>":
			closingTagStr = "</mixcase>";
			break;
		case "<lowcase>":
			closingTagStr = "</lowcase>";
			break;
		default: break;
	}

	var counter = 1;
	var closingTag = null;

	for (var i = openingTag.index+1; i < text.length - openingTag.tagName.length; i++) {
		if (text.substr(i, openingTag.tagName.length) === openingTag.tagName) {
			counter++;
		}
		else if (text.substr(i, closingTagStr.length) === closingTagStr) {
			counter--;
		}

		if (counter === 0) {
			closingTag = new Tag(i, closingTagStr);
			break;
		}
	}

	return closingTag;
}

function Tag(indexOfTag, stringOfTag)
{
	this.index = indexOfTag;
	this.tagName = stringOfTag;
}