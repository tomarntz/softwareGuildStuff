var uri = '/api/contacts/';

$(document)
    .ready(function () {
        //add click handler for id get contact
        $('#getContact')
            .on('click',
                function () {
                    //get the value of the field wioth contact id
                    var id = $('#ContactID').val();

                    //call the web api method that takes the id 
                    $.getJSON(uri + id)
                        .done(function(data) {
                            //put contact into the paragraph with id contact
                            if (data != null) {
                                $('#contact').text(data.Name + ' - ' + data.PhoneNumber);
                            } else {
                                $('#contact').text('Not Found');
                            }
                        })
                        .fail(function(jqXhr, status, err) {
                            //print error
                            $('#contact').text('Error' + err);
                        });
                });
    });