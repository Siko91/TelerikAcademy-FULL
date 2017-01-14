function generateDynamicSelect() {
    // this is not really needed but it's a proof of point
    $("#template-container").html(generateTask2Template())
    // I mean - I could've just used the text dyrectly.

    $('#the-result-box').html("This'll take some time.<br/>The select has 30'000 options!<br/>");

    var template = Handlebars.compile($("#template-container").html());
    var options = dataCreator(['text'], 30000);
    var html = template({ options: options });
    $('#the-result-box').append(html);
}

function generateTask2Template() {
    return ('<select>'
                + '{{#each options}}'
                    + '<option value="{{@index}}">'
                        +'{{text}}'
                    + '</option>'
                + '{{/each}}'
            + '</select>'
            );
}