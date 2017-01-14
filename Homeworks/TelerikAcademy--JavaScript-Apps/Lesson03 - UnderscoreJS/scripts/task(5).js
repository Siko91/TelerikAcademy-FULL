define(["jquery", "underscore", "utils"], function($, _, utils) {
    function doTheTask(){
    	var animals = utils.getSomeAnimals(15);

    	$("#result").empty().append(
    		_.map(
    			animals,
    			function(st){
    				return st.toString();
    			})
    		.join("<br/>")

    		+ "<br/><br/><strong>Calculate total number of leggs of animals:</strong><br/><br/>"

    		+ _.chain(animals)
    			.map(function(an){
    				return an.numbersOfLeggs;
    			})
    			.reduce(function(memo, nextNum){
    				return memo + nextNum;
    			})
    			.value()
    		);
	}

	$("#task5btn").click(doTheTask);
});