(function () {
    require.config({
        paths: {
            utils: "utils",
            content: "content",
            jquery: "JQuery-min",
            handlebars: "handlebars-v1.3.0",
            underscore: "underscore-min",
            task1: "task(1)",
            task2: "task(2)",
            task3: "task(3)",
            task4: "task(4)",
            task5: "task(5)",
            task6: "task(6)",
            task7: "task(7)"
        }
    });
    define(["jquery", "content", "utils", "task1", "task2", "task3", "task4", "task5", "task6", "task7"], function ($) {
        alert('Warning. The Data is randomized and different every time. If no matches are found, please press the task button again.');
    });
} ());