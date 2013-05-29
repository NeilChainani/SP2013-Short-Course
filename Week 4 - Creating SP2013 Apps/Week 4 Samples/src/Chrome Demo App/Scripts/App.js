'use strict';
var hostweburl;

$(document).ready(function () {
    $.getScript("../scripts/sp.ui.controls.js", renderChrome);
});

function renderChrome() {
    var options = {
        "appIconUrl": "../Images/AppIcon.png",
        "appTitle": "Chrome control app",
        "appHelpPageUrl": "Help.html?"
            + document.URL.split("?")[1],
        "settingsLinks": [
            {
                "linkUrl": "Account.html?"
                    + document.URL.split("?")[1],
                "displayName": "Account settings"
            },
            {
                "linkUrl": "Contact.html?"
                    + document.URL.split("?")[1],
                "displayName": "Contact us"
            }
        ]
    };

    var nav = new SP.UI.Controls.Navigation(
                            "chrome_ctrl_container",
                            options
                      );
    nav.setVisible(true);
}
