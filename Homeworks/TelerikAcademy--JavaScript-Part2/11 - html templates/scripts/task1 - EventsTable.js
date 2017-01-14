function generateEventsTable() {
    // clean up
    var $resultChildren = $('#the-result-box *');
    $resultChildren.remove();

    // this is not really needed but it's a proof of point
    $("#template-container").html(generateTask1Template())
    // I mean - I could've just used the text dyrectly.

    var template = Handlebars.compile($("#template-container").html());
    var events = dataCreator(['title', 'firstDate', 'secondDate'], 20);
    var html = template({ events: events });
    $('#the-result-box').append(html);
}

function dataCreator(fields, rowsCount) {
    var data = [];
    for (var i = 0; i < rowsCount; i++) {
        var row = {}
        for (var y = 0; y < fields.length; y++) {
            row[fields[y]] = fields[y] + " Number " + i;
        }
        data.push(row);
    }
    return data;
}

function generateTask1Template() {
    return  ('<table>'
                +'<thead>'
                    +'<tr>'
                        +'<th>N</th>'
                        +'<th>Title</th>'
                        +'<th>Date #1</th>'
                        +'<th>Date #2</th>'
                    +'</tr>'
                +'</thead>'
    
                +'{{#each events}}'
                    +'<tr>'
                        +'<td>{{@index}}</th>'
                        +'<td>{{title}}</th>'
                        +'<td>{{firstDate}}</th>'
                        +'<td>{{secondDate}}</th>'
                    +'</tr>'
                +'{{/each}}'
            + '</table>'
            );
}