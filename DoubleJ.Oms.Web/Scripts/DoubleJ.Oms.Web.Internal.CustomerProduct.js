$(document).ready(function () {
    SetProductCodeItemDisplay();

    $('input[type=checkbox][name^=CustomerProductCodeList]').change(selectAllCheckbox);

    $('#SelectAllCustomers, #SelectAllProducts').change(function () {
        $('.checkboxList').find("input[type=checkbox]").prop("checked", $(this).is(':checked'));
        SetProductCodeItemDisplay();
    });
});

function SetProductCodeItemDisplay() {
    $('input[type=checkbox][name^=CustomerProductCodeList]').each(selectAllCheckbox);
}

function selectAllCheckbox() {
    if ($(this).is(':checked')) {
        $(this).siblings("input[type='text']").show();
    } else {
        $(this).siblings("input[type='text']").hide();
    }
}