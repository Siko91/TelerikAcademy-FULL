define(["jquery", "underscore", "utils"], function($, _, utils) {
    function doTheTask(){
    	var students = utils.getSomeStudents(10);
    	var filteredStudents = _.chain(students)
    		.filter(function(st){
    			return (18 <= st.age && st.age <= 24);
    		}).map(function(st){
    			return st.fullName() + " (" + st.age + ")";
    		}).value();

    	$("#result").empty().append(
    		_.map(
    			students,
    			function(st){
    				return st.toString();
    			})
    		.join("<br/>")

    		+ "<br/><br/><strong>Filter('age' between 18 and 24), Show(fullName):</strong><br/><br/>"

    		+ filteredStudents.join("<br/>")
    		);
	}

	$("#task2btn").click(doTheTask);
});