define(["jquery", "underscore", "utils"], function($, _, utils) {
    function doTheTask(){
    	var animals = utils.getSomeAnimals(10);

    	var result = _.groupBy(animals, function(an){
    			return an.specie;
    		});
    	for (var prop in result) {
    		result[prop] = _.sortBy(result[prop], function(an) {
    			return an.numbersOfLeggs;
    		});
    	}

    	var stringified = "";
    	for (var prop in result) {
	    	stringified += "<strong>" + prop + "</strong><br/>";
	    	for (var innerProp in result[prop]) {
	    		stringified += result[prop][innerProp].toString() + "<br/>";
	    	}
	    }

    	$("#result").empty().append(
    		_.map(
    			animals,
    			function(st){
    				return st.toString();
    			})
    		.join("<br/>")

    		+ "<br/><br/><strong>Group Animals by specie and sort the groups by number of leggs:</strong><br/><br/>"

    		+ stringified
    		);
	}

	$("#task4btn").click(doTheTask);
});