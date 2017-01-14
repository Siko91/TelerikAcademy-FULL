define(["jquery", "underscore", "utils"], function($, _, utils) {
    function doTheTask(){
    	var marksCountPerStudent = Math.floor(Math.random() * 4) + 1;
    	var students = utils.getSomeStudents(10, marksCountPerStudent);

    	var bestStudent = _.chain(students)
    		.sortBy(function(st){
    			var avg = st.avgMark();
    			return -avg;
    		}).first().value();

    	$("#result").empty().append(
    		_.map(
    			students,
    			function(st){
    				return st.toString();
    			})
    		.join("<br/>")

    		+ "<br/><br/><strong>Find the student with the highest average marks:</strong><br/><br/>"

    		+ bestStudent.toString()
    		);
	}

	$("#task3btn").click(doTheTask);
});