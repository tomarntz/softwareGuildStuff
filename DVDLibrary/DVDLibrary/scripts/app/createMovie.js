$(document)
    .ready(function() {
        $('#btnShowAddMovie')
            .on('click',
                function() {
                    $('#addMovieModal').modal('show');
                });

        $('#btnSaveMovie')
            .on('click',
                function() {
                    var movie = {};
                    movie.Title = $('#Title').val();
                    movie.MPAARating = $('#MPAARating').val();
                    movie.RealseDate = $('#RealseDate').val();
                    movie.Studio = $('#Studio').val();

                    $.post(uri, movie)
                        .done(function() {
                            loadMovies();
                            $('#addMovieModal').modal('hide');
                        })
                        .fail(function(jqXhr, status, err) {
                            alert(status +  '-' + err);
                        });
                });
        $('#addMovieModal')
            .on('hidden.bs.modal',
                function () {
                    $('#Title').val('');
                    $('#MPAARating').val('');
                });
    });