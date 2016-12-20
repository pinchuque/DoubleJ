$('#OrderId').on('change', function (event) {
    $(this).parents('form:first').submit();
});


function SelectRow(e) {
    e.preventDefault();
    var selectedRow = $(e.currentTarget).closest("tr");
    var selectedRowData = this.dataItem(selectedRow).toJSON();

    Row_ClearSelections();
    Row_SetSelection(selectedRow);
    Bag_ProcessProduct(selectedRow, selectedRowData);
}

function Bag_ProcessProduct(selectedRow, selectedRowData)
{
    var url = $('#urlWeighAndPrint').attr('href');
    var currentLocationTotal = 0, currentLocationCompletedCount = 0, scaleStatus = 0, completedLocations = 0, j = 0;
    var locationsCount = $('#Locations_Count').val();
    
    for (var k = 0; k < locationsCount && scaleStatus==0; k++) {
        currentLocationTotal = eval('selectedRowData.Locations[k].Total');
        if(currentLocationTotal != null) {
            currentLocationCompletedCount = eval('selectedRowData.Locations[k].CompletedCount');
            for (j = currentLocationCompletedCount; j < currentLocationTotal; j++) {
                scaleStatus = EngageScale(url + "?id=" + eval('selectedRowData.Locations[k].CompletedCountOrderDetailId') + "&labelType=Bag");
                if (scaleStatus == 0) {
                    selectedRow.find('td:eq(' + (k + 2) + ')').html(Cell_FormatProductLocationCount(currentLocationTotal, ++currentLocationCompletedCount));
                } else {
                    break;
                }
            }
        }
    }
    (scaleStatus == 0) ? Row_SetComplete(selectedRow) : Row_ClearSelections();
    DisconnectScale();
}

function Row_SetComplete(selectedRow) {
    selectedRow.find("td:eq(0)").html('<div class="completed">completed</div>');
    selectedRow.removeClass('oms-selected');
}

function Row_SetSelection(selectedRow) {
    selectedRow.addClass('oms-selected');
    selectedRow.find('a.k-grid-SetFocus').hide();
    selectedRow.find("td:eq(0)").append('<div class="progress"><span class="progress-img"></span>processing</div>');
}

function Row_ClearSelections() {
    $("#BagLabelGrid tr.oms-selected").each(function () {
        $(this).removeClass('oms-selected');
        $(this).find('a.k-grid-SetFocus').show();
        $(this).find("td:eq(0)").children("div:not('.completed')").remove();
    });
}


function EngageScale(url) {
    var status = 0;
    $.ajax({
        url: url,
        async: false,
    }).done(function (result) {
        status=result.status;
    });
    return status;
}

function DisconnectScale() {
    var url = $('#urlDisconnectScale').attr('href');
    $.get(url, function (data) {
    });
}

function Cell_FormatProductLocationCount(locationTotal, locationCompletedCount) {
    if (locationTotal != null) {
        if (locationTotal == locationCompletedCount) {
            return "<div class='green'>" + locationCompletedCount + "/" + locationTotal + "</div>";
        }
        if (locationCompletedCount == 0) {
            return "<div class='red'>" + locationCompletedCount + "/" + locationTotal + "</div>";
        }
        if (locationCompletedCount > 0) {
            return "<div class='yellow'>" + locationCompletedCount + "/" + locationTotal + "</div>";
        }
    }
    return "";
}


//BOX

function Box_InitProductLocationCount(locationTotal, locationCompletedCount, locationIndex) {
    var buttonHtml = "<a href='#' class='k-button k-grid-SetFocus set-cell' data-location-index='" + locationIndex + "'>set</a>";
    if (locationTotal != null) {
        if (locationTotal == locationCompletedCount) {
            return "<div class='green'>" + locationCompletedCount + "/" + locationTotal + "</div>";
        }
        if (locationCompletedCount == 0) {
            return "<div class='red'>" + locationCompletedCount + "/" + locationTotal + "</div>" + buttonHtml;
        }
        if (locationCompletedCount > 0) {
            return "<div class='yellow'>" + locationCompletedCount + "/" + locationTotal + "</div>" + buttonHtml;
        }
    }
    return "";
}


$('.set-cell').live('click', function (e) {
   e.preventDefault();
    var selectedRow = $(e.currentTarget).closest("tr");
    var selectedCell = $(e.currentTarget).closest("td");
    var grid = $("#BoxLabelGrid").data("kendoGrid");
    var selectedRowData = grid.dataItem(selectedRow).toJSON();
    var locationIndex = $(this).attr('data-location-index');
    Cell_ClearSelections();
    Cell_SetSelection(selectedCell);
    Box_ProcessProduct(selectedCell, selectedRowData, locationIndex);
});


function Box_ProcessProduct(selectedCell, selectedRowData,locationIndex) {
    var url = $('#urlWeighAndPrint').attr('href');
    var currentLocationTotal = 0, currentLocationCompletedCount = 0, scaleStatus = 0, j = 0;
    var k = locationIndex;
    currentLocationTotal = eval('selectedRowData.Locations[k].Total');
    if (currentLocationTotal != null) {
        currentLocationCompletedCount = eval('selectedRowData.Locations[k].CompletedCount');
        for (j = currentLocationCompletedCount; j < currentLocationTotal; j++) {
            scaleStatus = EngageScale(url + "?id=" + eval('selectedRowData.Locations[k].OrderDetailId') + "&labelType=Box");
            if (scaleStatus == 0) {
                $('div.red, div.yellow',selectedCell).replaceWith(Cell_FormatProductLocationCount(currentLocationTotal, ++currentLocationCompletedCount));
            } else {
                break;
            }
        }
    }
    (scaleStatus == 0) ? Cell_SetComplete(selectedCell) : Cell_ClearSelections();
    DisconnectScale();
}

function Cell_SetSelection(selectedCell) {
    selectedCell.addClass('oms-selected');
    selectedCell.find('a.k-grid-SetFocus').hide();
    selectedCell.append('<div class="progress"><span class="progress-img"></span>processing</div>');
}

function Cell_ClearSelections() {
    $("#BoxLabelGrid td.oms-selected").each(function () {
        $(this).removeClass('oms-selected');
        $(this).find('a.k-grid-SetFocus').show();
        $(this).find('div.progress').remove();
    });
}

function Cell_SetComplete(selectedCell) {
    $('.progress', selectedCell).html('completed');
    selectedCell.removeClass('oms-selected');
}




