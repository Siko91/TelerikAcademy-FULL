function DoTask5()
{
	var people = new Array();
	for (var i = 0; i < 55; i++) {
		people.push( MakeAPerson(i) );
	}
	alert(people.join("\n"));

	people = people.sort(function(a, b){return a.age - b.age});
	var yangest = people[0];

	var result = "";

	result += "--==<< Yangest: >>==--<br /><br />";
	result += yangest.toString();
	result += "<br /><br />--==<< The next 5 people: >>==--<br /><br />"
	for (var i = 1; i <= 5; i++) {
		result += people[i].toString();
		result += "<br />"
	}

	ShowResult(result, "done", 5);
}

function MakeAPerson(i) {
	return {

			fname: "Gogo #" + i,

			lname: "Petkov #" + i,

			age: Math.floor((Math.random() * 80 ) + 1),

			toString: function () {
				return ("" + this.fname + " " + this.lname + " [" + this.age + " years old]");
			}

		};

}