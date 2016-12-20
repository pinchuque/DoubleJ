var baseUrl = $('#urlSiteBase').attr('href');

function Reprint(e) {
    e.preventDefault();
    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    var poundWeightBox = $('#PoundWeight' + dataItem.LabelId).data("kendoNumericTextBox");
    $.post(baseUrl + 'Labels/Reprint', { labelId: dataItem.LabelId, poundWeight: poundWeightBox.value(), labelType: dataItem.LabelType }, function (data) {
        var grid = $("#LabelEditGrid").data("kendoGrid");
        grid.dataSource.read();
    });
}

function Remove(e) {
    e.preventDefault();
    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    $.post(baseUrl + 'Labels/Remove', { labelId: dataItem.LabelId }, function (data) {
        var grid = $("#LabelEditGrid").data("kendoGrid");
        grid.dataSource.read();
    });
}

function LabelEditGrid_DataBound(e) {
    $(".pound-weight").kendoNumericTextBox({
        format: "#.00 lb"
    });
}