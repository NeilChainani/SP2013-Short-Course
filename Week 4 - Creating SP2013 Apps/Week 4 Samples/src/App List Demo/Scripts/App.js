'use strict';

var context = SP.ClientContext.get_current();
var user = context.get_web().get_currentUser();
var _surlWeb = "";

$(document).ready(function () {
    _surlWeb = _spPageContextInfo.webServerRelativeUrl;

    if (_surlWeb.length > 0 && _surlWeb.substring(
    _surlWeb.length - 1, _surlWeb.length) != "/") {
        _surlWeb += "/";
    }

    loadMessages();
});

function loadMessages() {
    $.ajax({
        url: _surlWeb +
 "_api/lists/getbytitle('Custom Task List')/items?$select=ID,Title&$orderby=ID desc",
        headers: {
            "accept": "application/json;odata=verbose",
            "X-RequestDigest": $("#__REQUESTDIGEST").val()
        },
        success: postMessageListRetrieve,
        error: oops


    });
}

function postMessageListRetrieve(data) {
    var items = [];

    items.push("<table class='messages'>");

    $.each(data.d.results, function (key, val) {
        items.push('<tr id="' + val.ID + '"><td><div>' +
          val.Title + '</div></td></tr>');
    });

    items.push("</table>");

    $('#messages').html(items.join(''));
}

function oops(data) {
    alert(data.responseText);
}

function addMessage() {
    $.ajax({
        url: _surlWeb + "_api/lists/getbytitle('Custom Task List')/items",
        type: "POST",
        data: JSON.stringify(
                {
                    '__metadata': {
                        'type': 'SP.Data.Custom_x0020_Task_x0020_ListListItem'
                    },
                    'Title': $('#messageInput').val()
                }),
        headers: {
            "Content-Type": "application/json;odata=verbose",
            "accept": "application/json;odata=verbose",
            "X-RequestDigest": $("#__REQUESTDIGEST").val()
        },
        success: loadMessages,
        error: oops
    });
}
