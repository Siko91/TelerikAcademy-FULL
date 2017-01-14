define(["jquery", "underscore", "utils"], function($, _, utils) {
    function doTheTask(){
    	var humans = utils.getSomeHumans(15);

    	var names = _.chain(humans)
    		.groupBy(function(human){
    			return human.firstName;
    		})
    		.map(function(nameGroup){
    			return {
    				name: nameGroup[0].firstName,
    				count: nameGroup.length
    			}
    		})
    		.sortBy(function(nameObj){
    			return -nameObj.count;
    		})
    		.map(function(nameObj){
    			return "" + nameObj.name + " - " + nameObj.count + " times";
    		})
    		.value();

    	$("#result").empty().append(
    		_.map(
    			humans,
    			function(st){
    				return st.toString();
    			})
    		.join("<br/>")

    		+ "<br/><br/><strong>Find the most common first names:</strong><br/><br/>"

    		+ names.join("<br/>")
    		);
	}

	$("#task7btn").click(doTheTask);
});