

var InternalOrders = InternalOrders || (function () {
    var self = null;
    var view = {

        urls: {
            getCustomerUrl: null
        },
        data: {
        },
        elements: {
            customerDropDown: null,
            dateTypeInput: null,
            logoTypeInput: null,
            slaughterDate: null,
        },

        UpdateBestBeforeDate: function (params) {
            
            if (params.slaughterDate == null || params.bestBeforeDateDays == null) return;

            var bestBeforeDate = new Date(params.slaughterDate);
            bestBeforeDate.setDate(bestBeforeDate.getDate() + params.bestBeforeDateDays);

            if (self.elements.dateTypeInput != null) self.elements.dateTypeInput.data("kendoDatePicker").value(bestBeforeDate);
        },

        UpdateSlaughterDate: function () {
            self.UpdateBestBeforeDate({
                slaughterDate: this.value(),
            });
        },

        GetCustomerPreferences: function (customerId) {
            $.ajaxSetup({ cache: false });
            $.get(self.urls.getCustomerUrl, { customerId: customerId }, function (data) {
                
                if (self.elements.bestBeforeDateDays != null) self.elements.bestBeforeDateDays.innerHTML = data.BestBeforeDays;
                if (self.elements.logoTypeInput != null) self.elements.logoTypeInput.val(data.LogoTypeIdEnumName);

                if (self.elements.slaughterDate != null) {
                    
                    self.UpdateBestBeforeDate({

                        slaughterDate: new Date(self.elements.slaughterDate.val()),
                    });
                }
            });
        },

        Init: function (params) {
            self.urls = params.urls || self.urls;
            self.data = params.data || self.data;
            self.elements = params.elements || self.elements;

            self.elements.customerDropDown.on('change', function (event) {
                var customerId = $(this).val();
                self.GetCustomerPreferences(customerId);
            });
        }
    };

    self = view;
    return view;
})();

var isEdit, btnAnimals;


$('#Organic').change(function () {
    var name = $(this).attr("name");
    var organicOrGrassFedCheckBox = $('input:hidden[name=' + name + ']').val();
    $('input:hidden[name=' + name + ']').val(organicOrGrassFedCheckBox === "false");
});

function addNumbers() {
    var validStartNumber = $('#formAnimalTracking').valid();
    if (validStartNumber) {
        btnAnimals.children('#btnSave').show();
        disableTrackAnimalFilters(true);
        $("#btnResetnumber").prop("disabled", false);
        var organic = $('input:hidden[name=Organic]').val();
        var animalStartNumber = $('#StartNumber').val();
        var animalEndNumber = $('#EndNumber').val();
        var orderId = $('#OrderId').val();
        var track = $("select#TrackAnimalBy").val();
        var customerLocationid = $('select#CustomerLocationID').val();
        var customerLocationname = $('select#CustomerLocationID option:selected').text();
        var speciesid = $('select#AnimalLabelId').val();
        var speciesName = $('select#AnimalLabelId option:selected').text();
        var qualityId = $('select#QualityGradeId').val();
        var qualityName = $('select#QualityGradeId option:selected').text();
        var postObject = {
            StartNumber: animalStartNumber,
            EndNumber: animalEndNumber,
            OrderId: orderId,
            IsExist: false,
            TrackAnimalBy: track,
            Organic: organic,
            FirstCustomer: {
                CustomerLocationId: customerLocationid,
                CustomerLocationName: customerLocationname
            },
            SecondCustomer: {
                CustomerLocationId: customerLocationid,
                CustomerLocationName: customerLocationname
            },
            ThirdCustomer: {
                CustomerLocationId: customerLocationid,
                CustomerLocationName: customerLocationname
            },
            FourthCustomer: {
                CustomerLocationId: customerLocationid,
                CustomerLocationName: customerLocationname
            },
            AnimalLabel: {
                Species: {
                    Id: speciesid,
                    Name: speciesName
                }
            },
            QualityGrade: {
                Id: qualityId,
                Name: qualityName
            }
        }
        var animalNumbers = null;
        if (!!$("#AT").html())
            animalNumbers = getGridJson();

        $.ajax({
            url: getGrid,
            type: 'POST',
            data: { cold: postObject },
            async: false,
            success: function(html) { $("#AT").html(html); }
        });
        $.ajax({
            url: addAnimalNumbers,
            type: 'POST',
            data: { newAnimalNumbers: animalNumbers, item: postObject },
            async: false,
            success: function (data) {
                getDataSource().data(data);
            }
        });
    }
}

var getGridJson = function() {
    var o = kendo.observable({
        animalNumbersInGrid: getDataSource().data()
    });
    return JSON.stringify(o);
};

function saveAnimals() {
    if (!$("#AT").html())
        return;
    kendo.ui.progress($("#loading"), true);
    $.ajax({
        url: saveAnimalNumbers,
        type: "POST",
        data: {
            animalNumbers: getGridJson(),
            orderId: $('#OrderId').val(),
            trackAnimal: $("select#TrackAnimalBy").val()
        },
        success: function(a) {
            if (isEdit === "False") nextTab();
            else {
                $("#btnResetnumber").prop("disabled", false);

                kendo.ui.progress($("#loading"), false);
            }
        }
    });
};

function disableTrackAnimalFilters(disable) {
    $("select#TrackAnimalBy, #Organic, #CustomerLocationID, #AnimalLabelId, select#QualityGradeId").prop("disabled", disable);
}

function onRemove(e) {
    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    var postObject = {
        item: {
            Id: dataItem.Id,
            OrderId: $('#OrderId').val(),
            AnimalNumber: dataItem.AnimalNumber
        },
        animalNumbers: getGridJson()
    };
    $.post(removeDetailUrl, postObject, function (data) {
        if (!data.length) {
            disableTrackAnimalFilters(false);
            $("#btnResetnumber").prop("disabled", true);
        }
        getDataSource().data(data);
    });
}

function RemoveAll() {
    var data = getDataSource()._data;
    return $.post(removeAllDetailUrl, {
        coldId: data[0].ColdWeightId
    });
}

function getDataSource() {
    return $("#AnimalTrackingGrid").data("kendoGrid").dataSource;
}

var nextTabUrl;
function nextTab() {
    $.get(nextTabUrl, {
        orderId: $('#OrderId').val(),
        mode: "Add"
    }, function (data) {
        kendo.ui.progress($("#loading"), false);
         $("body").html(data);
    });
}

function orderDetailProductChange(e) {
    var dataItem = this.dataItem(e.item);
    var currentRow = $(this.element).closest("tr");
    $.get(getProductUrl, {
        productId: dataItem.Value
    }, function (data) {
        currentRow.children("#BagPieceQuantity").html(data.BagPieceQuantity);
        currentRow.children("#BoxBagQuantity").html(data.BoxBagQuantity);
    });
}


$(function () {
    $("#CutSheetDetailGreed").kendoWindow({
        title: "CUT SHEET DETAIL",
        visible: false,
        activate: function () {
            $('#form-customer').validate({
                errorElement: "span",
                errorClass: "input-validation-error",
                validClass: "valid",
                errorPlacement: function (error, element) {
                    $(element).next().html(error.html()).addClass('field-validation-error');
                }
            });
            $('#form-customer input[type=text]').each(function () {
                if ($(this).data('need-required') === true) {
                    $(this).rules("add", "required");
                }
            });
            $('#form-customer input[type=text]').bind("change keyup input", function () {
                if ($(this).valid()) {
                    $(this).next().removeClass('field-validation-error');
                }
            });
        }
    });
});

function enter(e) {
    cutsheet(e);
}


function email() {
}


function dup() {
}

function enter3(e) { cutsheet(e); }

function enter4(e) { cutsheet(e); }
function enter2(e) { cutsheet(e); }


function cutsheet(e) {
    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));

    var cutSheetValues =
    {
        AnimalNumber: dataItem.AnimalNumber,
        ColdWeightId: dataItem.Id,
        SelectedCustomerLocation: $(e.currentTarget).closest("td").prev("td").text()
    }

    var window = $("#CutSheetDetailGreed").data("kendoWindow");
    window.refresh({
        url: getCutSheetGrid,
        data: cutSheetValues
    });
    window.center();
    window.open();
}
