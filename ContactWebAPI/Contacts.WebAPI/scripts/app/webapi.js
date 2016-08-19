var uri = '/api/contacts/';

$(document)
    .ready(function() {
        loadContacts();
    });

function loadContacts() {
    //sending get rquest to web api end point
    $.getJSON(uri)
        .done(function(data) {
            //clear table
            $('#contacts tbody tr').remove();

            //on success, 'data' contains a list of contacts
            $.each(data,
                function(index, contact) {
                    //add row to table for contact
                    $(createRow(contact)).appendTo($('#contacts tbody'));
                });
        });
};

function createRow(contact) {
    return '<tr><td>' +
        contact.ContactID +
        '</td><<td>' +
        contact.Name +
        '</td><td>' +
        contact.PhoneNumber +
        '</td></tr>';
}