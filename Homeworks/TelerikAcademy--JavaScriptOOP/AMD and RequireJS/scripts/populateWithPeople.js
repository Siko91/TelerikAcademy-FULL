define(["JQuery", "handlebars", ], function () {
    return $.fn.populateWithPeople = function populateWithPeople(peopleData) {
        var $this = $(this);

        var template = Handlebars.compile($("#person-template").html());
        var resultHtml = template({ people: peopleData });


        $this
            .empty()
            .append(resultHtml);

        return $this;
    }
});