$('#btnSearch').on('click', function (event) {
    $.post($('#OrderSearchForm').attr('action'), $('#OrderSearchForm').serialize(), function (data) {
        if ($('.validation-summary-errors', data).length) {
            $('#order-search-critieria').html(data);
        } else {
            $('#order-search-results').html(data);
        }
    });
});


function searchCriteria() {
    return $('#OrderSearchForm').serializeObject();
}
