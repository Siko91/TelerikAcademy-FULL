define(["jquery", "underscore", "utils"], function($, _, utils) {
    function doTheTask(){
    	var books = utils.getSomeBooks(15);

    	var author = _.chain(books)
    		.groupBy(function(an){
    			return an.author;
    		})
    		.sortBy(function(author){
    			return -author.length;
    		})
    		.map(function(author){
    			return {
    				authorName: author[0].author,
    				books: author.length
    			};
    		})
    		.first()
    		.value();

    	$("#result").empty().append(
    		_.map(
    			books,
    			function(st){
    				return st.toString();
    			})
    		.join("<br/>")

    		+ "<br/><br/><strong>Best selling author:</strong><br/><br/>"

    		+ "The author '" + author.authorName + "' has written " + author.books + " books."
    		);
	}

	$("#task6btn").click(doTheTask);
});