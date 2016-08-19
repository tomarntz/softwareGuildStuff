var uri = '/api/Tags/';

$(document).ready(function() {
    $.getJSON(uri)
        .done(function(data) {
            $('#Post_Tags')
                .autocomplete({
                    source: data
                });
        });
})