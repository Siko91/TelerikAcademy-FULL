// Data
// NOTE - the three must be ordered from the last generation towards the first!
// (start from the bottom to the top);

var familyMembers = [
// generation 3
    {
    mother: 'TeodoraPetrova',
    father: 'John Doe',
    children: ['Stamat'] // the little "stamat is 4'th generation"
},
// generation 2
    {
    mother: 'Maria Petrova',
    father: 'Georgi Petrov',
    children: ['TeodoraPetrova', 'Peter Petrov']
},
// generation 1
    {
    mother: 'Jhona Dane',
    father: 'Vasilii Kojarov',
    children: ['Georgi Petrov', 'Nim Hou Qiu']
},
// generation 1
{
    mother: 'Petra Stamatova',
    father: 'Todor Stamatov',
    children: ['Maria Petrova']
}
];

function makeChildrenRelation(generationReversed, index) {
    return {
        generation: generationReversed, // will be reversed back later
        index: index
    }
};

function makePerson(name) {
    return {
        name: name,
        childrenRelations: []
    };
};

function addPeopleFromObject(relationObject, generations) {
    var mother = makePerson(relationObject.mother),
        father = makePerson(relationObject.father);

    for (var ch = 0; ch < relationObject.children.length; ch++) {
        var childExists = false,
            childGeneration = generations.length - 1,
            childIndex = generations[generations.length - 1].length;

        var child = makePerson(relationObject.children[ch]);

        // check if child already exists
        for (var g = 0; g < generations.length; g++) {
            for (var i = 0; i < generations[g].length; i++) {
                if (generations[g][i].name == child.name) {
                    childExists = true;
                    child = generations[g][i];
                    childGeneration = g,
                    childIndex = i;
                    break;
                }
            }
            if (childExists) {
                break;
            }
        }

        mother.childrenRelations.push(
            makeChildrenRelation(
                childGeneration,
                childIndex
            )
        );
        father.childrenRelations.push(
            makeChildrenRelation(
                childGeneration,
                childIndex
            )
        );
        if (!childExists) {
            generations[generations.length - 1].push(child);
        }
    }
    
    if (childGeneration === generations.length-1) {
        generations.push([]);
    }
    
    generations[childGeneration + 1].push(father);
    generations[childGeneration + 1].push(mother);
};

function drawPersonAtPosition(row, col, person, peopleLayer, nameLayer, relationsLayer, stage) {
    var rowStep = 80,
        colStep = 120,
        leftPadding = 50,
        topPadding = 50,
        rectSize = 20;
    
    var name = new Kinetic.Text({
        x: col * colStep + leftPadding + rectSize / 2 - leftPadding / 2,
        y: row * rowStep + topPadding + rectSize,
        text: "" + person.name,
        fontSize: 15,
        fontFamily: 'Calibri',
        fill: 'black'
    });

    var rect = new Kinetic.Rect({
        x: col * colStep + leftPadding,
        y: row * rowStep + topPadding,
        width: rectSize,
        height: rectSize,
        fill: 'rgba(0, 255, 2, 0.3)',
        stroke: 'black',
        strokeWidth: 1
    });
    rect.on('mouseenter', function() {
        nameLayer.add(name);
        nameLayer.draw();
    });
    rect.on('mouseout', function() {
        nameLayer.removeChildren();
        nameLayer.draw();
    });

    peopleLayer.add(rect);
    
    for (var i = 0; i < person.childrenRelations.length; i++) {
        
        var childX = person.childrenRelations[i].index * colStep + leftPadding + rectSize / 2,
            childY = person.childrenRelations[i].generation * rowStep + topPadding + rectSize / 2;

        var line = new Kinetic.Line({
            points: [
                col * colStep + leftPadding + rectSize / 2,
                row * rowStep + topPadding + rectSize / 2,
                childX,
                childY-rectSize
                ],
            stroke: 'blue',
            strokeWidth: 1,
            lineCap: 'round',
            lineJoin: 'round',
        });

        var wedge = new Kinetic.Wedge({
            x: childX,
            y: childY,
            radius: rectSize,
            angle: 60,
            fill: 'red',
            stroke: 'black',
            strokeWidth: 1,
            rotation: -120
        });
        
        var childTag = new Kinetic.Text({
        x: childX,
        y: childY - rectSize * 1.5,
        text: "CHILD",
        fontSize: 10,
        fontFamily: 'Calibri',
        fill: 'black'
        });

        relationsLayer.add(line);
        relationsLayer.add(wedge);
        relationsLayer.add(childTag);
    }
};

function drawFamilyInCanvas(generations, stage, peopleLayer, nameLayer, relationsLayer) {
    var generation = 0;

    for (var generationReversed = generations.length - 1; generationReversed >= 0; generationReversed--) {
        for (var person = generations[generationReversed].length - 1; person >= 0; person--) {
        
            // change all the relations according to the reversed generations
            for (var relation = 0; relation < generations[generationReversed][person].childrenRelations.length; relation++) {
                generations[generationReversed][person].childrenRelations[relation].generation = 
                    generations.length - 1 
                    - generations[generationReversed][person].childrenRelations[relation].generation;
            }

            // draw using "generation" witch is the actual generation order,
            // instead of "generationReversed" wich is simply an index
            drawPersonAtPosition(generation, person, generations[generationReversed][person], peopleLayer, nameLayer, relationsLayer, stage);
        }
        generation++;
    }
    stage.add(relationsLayer);
    stage.add(nameLayer);
    stage.add(peopleLayer);
};

function displayFamilyTree() {

    alert("It's ALIIIii-iiIIIVE !!!" + "\n" + "\n"
        + "I actually made it somewhat automatic." + "\n" + "\n"
        + "- No repeating people" + "\n"
        + "- No crossgeneration parents" + "\n"
        + "- Names display on hover");

    var stage = new Kinetic.Stage({
        container: 'the-canvas-container',
        width: 500,
        height: 500
    });
    var peopleLayer = new Kinetic.Layer();
    var nameLayer = new Kinetic.Layer();
    var relationsLayer = new Kinetic.Layer();

    var generations = [[]];

    for (var i = 0; i < familyMembers.length; i++) {
        addPeopleFromObject(familyMembers[i], generations);
    }
    drawFamilyInCanvas(generations, stage, peopleLayer, nameLayer, relationsLayer);
};