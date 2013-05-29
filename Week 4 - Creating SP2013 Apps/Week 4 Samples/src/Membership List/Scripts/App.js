'use strict';

var context = SP.ClientContext.get_current();
var user = context.get_web().get_currentUser();

$(document).ready(function () {

    var membership = {
        element: '',
        url: '',

        init: function (element) {
            membership.element = element;
            membership.url = window._spPageContextInfo.webAbsoluteUrl + "/_api/site/rootweb/lists/getByTitle('User%20Information%20List')/items?$select=Title,Name";
        },

        load: function () {
            $.ajax(
                {
                    url: membership.url,
                    method: "GET",
                    headers: {
                        "Accept": "application/json;odata=verbose",
                    },
                    success: membership.onSuccess,
                    error: membership.onError
                }
            );
        },

        onSuccess: function (data) {
            var results = data.d.results;
            var html = "<table>";

            for (var i = 0; i < results.length; i++) {
                html += "<tr><td>";
                html += results[i].Title;
                html += "</td><td>"
                html += results[i].Name;
                html += "</td><tr>";
            }

            html += "</table>";
            membership.element.html(html);
        },

        onError: function (err) {
            alert(JSON.stringify(err));
        }
    };

    membership.init($('#peopleDiv'));
    membership.load();

});
