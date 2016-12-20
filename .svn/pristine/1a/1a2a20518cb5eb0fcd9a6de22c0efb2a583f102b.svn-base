$(document).ready(function () {
    handleAjaxNotifications();
    displayNotifications();
});

function displayNotification(notification, notificationType) {
    $("#notificationwrapper").html('<div class="notificationbox ' + notificationType.toLowerCase() + '"></div><div class="notificationbox-close"></div>');
    $("#notificationwrapper .notificationbox").text(notification);
    displayNotifications();
}

function displayNotifications() {
    if ($("#notificationwrapper").children().length > 0) {
        $("#notificationwrapper").show();
        setTimeout(clearNotifications, 10000);
        $("#notificationwrapper").click(function () {
            clearNotifications();
        });
        /*$(document).click(function () {
            clearNotifications();
        });*/
    }
    else {
        $("#notificationwrapper").hide();
    }
}

function clearNotifications() {
    $("#notificationwrapper").fadeOut(500, function () {
        $("#notificationwrapper").empty();
    });
}

function handleAjaxNotifications() {
    $(document).ajaxSuccess(function (event, request) {
        checkAndHandleNotificationFromHeader(request);
    }).ajaxError(function (event, request) {
        displayNotification(request.responseText, "error");
    });
}

function checkAndHandleNotificationFromHeader(request) {
    var msg = request.getResponseHeader('X-Notification');
    if (msg) {
        displayNotification(msg, request.getResponseHeader('X-Notification-Type'));
    }
}