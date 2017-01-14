/// <reference path="JQuery-min.js" />
/// <reference path="handlebars-v1.3.0.js" />
/// <reference path="peopleData.js" />
/// <reference path="populateWithPeople.js" />
/// <reference path="comboBox.js" />

(function () {
    require.config({
        paths: {
            peopleData: "peopleData",
            handlebars: "handlebars-v1.3.0",
            populate: "populateWithPeople",
            JQuery: "JQuery-min",
            comboBox: "comboBox"
        }
    });

    require(["JQuery", "populate", "comboBox", "peopleData"], function () {
        $("#combo-box-container")
            .populateWithPeople(peopleData)
            .comboBox();
    });
} ());