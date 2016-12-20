$(document).ready(function () {
    $("*").ajaxComplete(function (e, xhr, settings) {
        IsLogonRequired(xhr.responseText);
        SyncHeights();
    });
    SyncHeights();

});

function SyncHeights() {
    var contentHeight = $('#content').height();
    $('#hud').css('min-height', contentHeight);
}

function IsLogonRequired(response_data) {
    var data = null;
    try {
        data = $.parseJSON(response_data);
    }
    catch (ex) {
    };
    if (data != null && data.LogonRequired != undefined && data.LogonRequired == true)
        window.location.href = data.Url;
};

function setBestBeforeDateValidationRule() {
    $("#SlaughterDate").on("change", function () {
        var slaughterDate = $("#SlaughterDate").data("kendoDatePicker");
        var sDate = new Date();
        var maxDate = new Date(sDate);
        var minDate = new Date(sDate);
        minDate.setDate(sDate.getDate() + 10);
        maxDate.setDate(sDate.getDate() + 365);

        var bestBeforeDate = $("#BestBeforeDate").data("kendoDatePicker");
        if (bestBeforeDate != null) {
            bestBeforeDate.min(minDate);
            bestBeforeDate.max(maxDate);
            var bDate = new Date(bestBeforeDate.value());
            if (bDate > maxDate || bDate < minDate) {
                bestBeforeDate.value(minDate);
            }
        }
    });
}
