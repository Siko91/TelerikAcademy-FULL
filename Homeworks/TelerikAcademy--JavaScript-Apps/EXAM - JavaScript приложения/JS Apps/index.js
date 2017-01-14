/// <reference path="node_modules/handlebars/dist/handlebars.js" />
/// <reference path="node_modules/jquery/dist/jquery.js" />
/// <reference path="node_modules/underscore/underscore.js" />

/// <reference path="scripts/UserInterface.js" />
/// <reference path="scripts/REST-Handler.js" />
/// <reference path="scripts/settings.js" />
/// <reference path="scripts/PostHandler.js" />
/// <reference path="scripts/SHA1.js" />
/// <reference path="scripts/userControls.js" />

(function () {
    require.config({
        paths: {
            underscore: "node_modules/underscore/underscore",
            handlebars: "node_modules/handlebars/dist/handlebars",
            JQuery: "node_modules/jquery/dist/jquery",
            UI: "scripts/UserInterface",
            RESThandler: "scripts/REST-Handler",
            SHA1: "scripts/SHA1",
            settings: "scripts/settings",
            posts: "scripts/PostHandler",
            user: "scripts/userControls"
        }
    });

    require(["UI"], function (ui) {
        ui.run();
    });
}());