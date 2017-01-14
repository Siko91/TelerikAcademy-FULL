function DoTask12()
{
	ShowResult(Math.random(), "error", 12);

	var people = [];

	for (var i = 0; i < 30; i++) {
		people[i] = new SimplePerson("name"+i, i*2);
	}

	var textToImport = "<ul>"
							+ "<header>"
							+ "<li>"
							+ "<strong>-{Name}-</strong> <span>-{Age}-</span>"
							+ "</li>"
							+ "</header>"
							+ "<br />";

	for (var i = 0; i < people.length; i++) {
		textToImport += "<li>"
							+ people[i].toString()
							+ "</li>";
	}

	textToImport += "</ul>";

	ShowResult(textToImport, "done", 12);
}

function SimplePerson(fname, age)
{	
	this.fname = fname;
	this.age = age;

	this.formatedName = "<strong>" + this.fname + "</strong>";
	this.formatedAge = "<span>" + this.age + "</span>";

	this.toString = function() {
		return this.formatedName + " - " + this.formatedAge;
	}
}