$(document)
    .ready(function() {
        $('#btnShowAddContact')
            .on('click',
                function() {
                    $('#addContactModal').modal('show');
                });

        $('#btnSaveContact')
            .on('click',
                function() {
                    var contact = {}; // new object
                    //get values from the inputs
                    contact.Name = $('#Name').val();
                    contact.PhoneNumber = $('#phonenumber').val();

                    //post it  to the webAPI, passing the javascript object
                    $.post(uri, contact)
                        .done(function() {
                            loadContacts();
                            $('#addContactModal').modal('hide');
                        })
                        .fail(function(jqXhr, status, err) {
                            alert(status + ' - ' + err);
                        });
                });
        $('#addContactModal')
            .on('hidden.bs.modal',
                function() {
                    $('#Name').val('');
                    $('#phonenumber').val('');
                });
    });