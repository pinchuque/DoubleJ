$('#btnSearch').on('click', function (event) {
    // $('#search-results').load('Products/_SearchResult');
    $.post($('#ProductSearchForm').attr('action'), $('#ProductSearchForm').serialize(), function (data) {
        if ($('.validation-summary-errors', data).length) {
            $('#search-critieria').html(data);
        } else {
            $('#search-results').html(data);
        }
    });
});


function searchCriteria() {
    return $('#ProductSearchForm').serializeObject();
}


