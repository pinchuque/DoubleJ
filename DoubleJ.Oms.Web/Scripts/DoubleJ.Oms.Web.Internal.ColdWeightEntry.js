var needUpdateColdWeightDetail = false;
var numberClickAddWeight = 0;

function completeAnimal() {
    var animalNumber = $('#AnimalNumber');
    var earTag = $('#EarTag');

    needUpdateColdWeightDetail = false;
    numberClickAddWeight = 0;

    animalNumber.val("");
    earTag.val("");
    $('#ColdWeight').val("");
   
    animalNumber.prop("disabled", needUpdateColdWeightDetail);
    earTag.prop('disabled', needUpdateColdWeightDetail);
    $('#Section').prop('disabled', needUpdateColdWeightDetail);
}

function addAttach() {
    $('#btnAdd').click(function (e) {
        var animalNumber = $('#AnimalNumber');
        var earTag = $('#EarTag');
        var coldWeight = $('#ColdWeight');

        if (!coldWeight.valid() || !coldWeight.val()) {
            alert(coldWeight.attr('data-val-number'));
            return;
        }

        $('#btnAdd').prop('disabled', true);

        $.post(checkIfAnimalNumberAlreadyExists, { value: animalNumber.val() }, function(animaNumberExists) {
            if (animaNumberExists.LogonRequired)
                window.location = loginUrl;

            if (needUpdateColdWeightDetail || animaNumberExists) {
                $.post(checkIfEarTagAlreadyExists, { value: earTag.val() }, function(earTagExists) {
                    numberClickAddWeight++;
                    if (needUpdateColdWeightDetail || earTagExists) {
                        var postObject = {
                            OrderId: $('#OrderId').val(),
                            AnimalNumber: animalNumber.val(),
                            EarTag: earTag.val(),
                            Update: needUpdateColdWeightDetail,
                            NumberClickAddWeight: numberClickAddWeight
                        };

                        switch (numberClickAddWeight) {
                            case 1: postObject["FirstSideWeight"]  = coldWeight.val(); break;
                            case 2: postObject["SecondSideWeight"] = coldWeight.val(); break;
                            case 3: postObject["ThirdSideWeight"]  = coldWeight.val(); break;
                            case 4: postObject["FourthSideWeight"] = coldWeight.val(); break;
                        }

                        $.post(addDetailUrl, postObject, function(data) {
                            if (data.success) {
                                if (animalNumber.val() != "" || earTag.val() != "") {
                                    if ($('#Section').val() === "Halves") {
                                        needUpdateColdWeightDetail = numberClickAddWeight !== 2;
                                        if (numberClickAddWeight === 2) numberClickAddWeight = 0;
                                    }

                                    if ($('#Section').val() !== "Halves") {
                                        needUpdateColdWeightDetail = numberClickAddWeight !== 4;
                                        if (numberClickAddWeight === 4) numberClickAddWeight = 0;
                                    }

                                    animalNumber.prop("disabled", needUpdateColdWeightDetail);
                                    earTag.prop('disabled', needUpdateColdWeightDetail);
                                    $('#Section').prop('disabled', needUpdateColdWeightDetail);

                                    coldWeight.val("");
                                }

                                if (!needUpdateColdWeightDetail) {
                                    animalNumber.val("");
                                    earTag.val("");
                                    coldWeight.val("");
                                }

                                recalc(data.coldWeight);
                            }
                        });
                    } else {
                        alert("Entered Ear Tag already added");
                        return;
                    }
                });
            } else {
                alert("Entered Animal Number already added");
                return;
            }
        }).done(function () {
            $('#btnAdd').prop('disabled', false);
        });
        e.preventDefault();
    });
}

function onRemove(e) {
    e.preventDefault();
    var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
    $.post(removeDetailUrl, {
        Id: dataItem.Id,
        ColdWeightId: dataItem.ColdWeightId,
        Weight: dataItem.Weight
    }, function (data) {
        if (data.success) {
            recalc(data.coldWeight);
        }
    });
}

function recalc(coldWeight) {
    $("#ColdWeightGrid").data("kendoGrid").dataSource.read();

    $('#TotalCount').text(coldWeight.TotalCount);
    $('#TotalWeight').text(coldWeight.TotalWeight + ' LBS');
    $('input#TotalCount').val(coldWeight.TotalCount);
    $('input#TotalWeight').val(coldWeight.TotalWeight);
}

$('#OrderId').on('change', function () {
    var orderId = $('#OrderId').val();
    $.post(coldWeightEntryUrl, { orderId: orderId }, function (data) {
        if (data.LogonRequired) {
            window.location = coldWeightIndexUrl;
        } else {
            $('#coldweigthentry').html(data);
            var form = $('#coldweigthentry').parents('form:first');
            form.removeData("validator");
            form.removeData("unobtrusiveValidation");
            $.validator.unobtrusive.parse('#coldweigthentry');
            addAttach();
        }
    });
    if ($('.buttonRow').is(':hidden'))
        $('.buttonRow').show();
});

function onSelectSectionChange() {
    var grid = $("#ColdWeightGrid").data("kendoGrid");
    var selectSection = $('#Section').val();
    if (selectSection == "Halves") {
        grid.hideColumn("ThirdSideWeight");
        grid.hideColumn("FourthSideWeight");
    } else {
        grid.showColumn("ThirdSideWeight");
        grid.showColumn("FourthSideWeight");
    }
}

$(function() {
    addAttach();
    $('.buttonRow').hide();
});
