function generateTagClould() {
    var resultDiv = document.getElementById('the-result-box');
    while (resultDiv.firstChild) {
        resultDiv.removeChild(resultDiv.firstChild);
    }

    var tags = ["cms", "javascript", "js", "ASP.NET MVC", ".net", ".net", "css", "wordpress", "xaml", "js", "http", "web", "asp.net", "asp.net MVC", "ASP.NET MVC", "wp", "javascript", "js", "cms", "html", "javascript", "http", "http", "CMS"];
    generateTagCloud(tags, 17, 42);
}

function generateTagCloud(tags, fontSizeMin, FontSixeMax) {
    var dictionaryOfAppearences = {};
    for (var i = 0; i < tags.length; i++) {
        var tagToLower = tags[i].toLowerCase();
        if (dictionaryOfAppearences[tagToLower]) {
            dictionaryOfAppearences[tagToLower].count++;
        }
        else {
            dictionaryOfAppearences[tagToLower] = {
                count: 1,
                tag: tags[i],
                font: undefined
            };
        }
    }

    // sort & find the min and max counts
    var sortedTags = []
    for (var tagName in dictionaryOfAppearences) {
        sortedTags.push(dictionaryOfAppearences[tagName])
    }
    sortedTags.sort(function (a, b) {
        var countA = a.count;
        var countB = b.count;

        return countA < countB;
    });
    var minCount = sortedTags[sortedTags.length-1].count,
        maxCount = sortedTags[0].count;

    // Calculate font and prepare to display
    var tagsFragment = document.createDocumentFragment();
    var fontStep = (FontSixeMax - fontSizeMin) / (maxCount - minCount);
    for (var i = 0; i < sortedTags.length; i++) {
        sortedTags[i].font = 17 + sortedTags[i].count * fontStep;
        var tag = MakeTagElement(sortedTags[i]);
        tagsFragment.appendChild(tag);
    }
    document.getElementById('the-result-box').appendChild(tagsFragment);
}

function MakeTagElement(tagData) {
    var tag = document.createElement('span');
    tag.innerHTML = tagData.tag;
    tag.style.fontSize = tagData.font + 'px';
    tag.style.display = 'inline-block';
    tag.style.margin = '10px';
    return tag;
}