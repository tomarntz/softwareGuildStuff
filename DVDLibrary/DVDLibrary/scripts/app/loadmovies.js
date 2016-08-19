var uri = '/api/movie/';

$(document)
    .ready(function() {
        loadMovies();
    });

function loadMovies() {
    $.getJSON(uri)
        .done(function(data) {
            $('#movies tbody tr').remove();
            $.each(data,
                function(index, movie) {
                    $(createRow(movie)).appendTo($('#movies tbody'));
                });
        });
};

function createRow(movie) {
    return '<tr><td>' +
        movie.MovieId +
        '</td><td>' +
        movie.Title +
        '</td><td>' +
        movie.RealseDate +
        '</td><td>'+
        movie.MPAARating +
        '</td><td>'+
        movie.Studio +
        '</td></tr>';
}