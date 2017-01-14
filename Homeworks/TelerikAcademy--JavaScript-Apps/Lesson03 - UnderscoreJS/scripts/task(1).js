define(["jquery", "underscore", "utils"], function($, _, utils) {
    function doTheTask(){
    	var students = utils.getSomeStudents(10);
    	var filteredAndSortedFunction = _.chain(students)
    		.filter(function(st){
    			return st.firstName.toLowerCase() < st.lastName.toLowerCase();
    		}).sortBy(function(st){
    			return st.fullName().toLowerCase();
    		}).map(function(st){
    			return st.toString();
    		}).value();

    	$("#result").empty().append(
    		_.map(
    			students,
    			function(st){
    				return st.toString();
    			})
    		.join("<br/>")

    		+ "<br/><br/><strong>Filter('fname' less than 'lname'), SortDescending(fullName):</strong><br/><br/>"

    		+ filteredAndSortedFunction.join("<br/>")
    		);
	}

	$("#task1btn").click(doTheTask);
});