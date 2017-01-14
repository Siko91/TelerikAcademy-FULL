function DoTask6()
{
	var people = new Array();
	for (var i = 0; i < 5; i++) {
		people.push( MakeAPerson(Math.floor((Math.random() * 90 ) + 11)) );
	}

	result = ""
	result += "--==<< By First Name / Normal >>==--";
	result += "<br /><br />";

	people = SortByCriteria(people, "fname", false);
	for (var i = 0; i < people.length; i++) {
		result += people[i].toString();
		result += "<br />";
	}
	result += "<br /><br />";

	result += "--==<< By First Name / Reversed >>==--";
	result += "<br /><br />";

	people = SortByCriteria(people, "fname", true);
	for (var i = 0; i < people.length; i++) {
		result += people[i].toString();
		result += "<br />";
	}
	result += "<br /><br />";

	result += "--==<< By Last Name / Normal >>==--";
	result += "<br /><br />";

	people = SortByCriteria(people, "fname", false);
	for (var i = 0; i < people.length; i++) {
		result += people[i].toString();
		result += "<br />";
	}
	result += "<br /><br />";
	result += "--==<< By Last Name / Reversed >>==--";
	result += "<br /><br />";

	people = SortByCriteria(people, "lname", true);
	for (var i = 0; i < people.length; i++) {
		result += people[i].toString();
		result += "<br />";
	}
	result += "<br /><br />";

	result += "--==<< By Age / Normal >>==--";
	result += "<br /><br />";

	people = SortByCriteria(people, "age", false);
	for (var i = 0; i < people.length; i++) {
		result += people[i].toString();
		result += "<br />";
	}
	result += "<br /><br />";

	result += "--==<< By Age / Reversed >>==--";
	result += "<br /><br />";

	people = SortByCriteria(people, "age", true);
	for (var i = 0; i < people.length; i++) {
		result += people[i].toString();
		result += "<br />";
	}

	ShowResult(result, "done", 6);
}

function SortByCriteria(arrayOfObjects, criteria, reversed) {
	var sorted = arrayOfObjects.sort(function(a, b) { return MyComparison(a[criteria], b[criteria]) });

	if (reversed == true) {
		sorted = sorted.reverse();
	}
	return sorted;
}

function MyComparison(a, b) {
	if (typeof a == "string") {
		return a.localeCompare(b);
	}
	if (typeof a == "number") {
		return a - b;
	}
	if (typeof a == "boolean") {
		if ((a && b) || (!a && !b)) {
			return 0;
		}
		if (a && !b) {
			return 1;
		}
		if (!a && b) {
			return 0;
		}
	}
	return 0;
}