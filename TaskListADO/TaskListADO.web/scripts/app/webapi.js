$(document)
    .ready(function() {
        loadEmployees();
    });

function loadEmployees() {
    $.getJSON('api/Employees')
        .done(function(data) {
            $('#employees tbody tr').remove();
            $.each(data,
                function(index, employee) {
                    $(createRow(employee)).appendTo($('#employees tbody'));
                });
        });
}

function createRow(employee) {
    return '<tr><td>' +
        employee.EmployeeId +
        '</td><td>' +
        employee.FirstName +
        '</td><td>' +
        employee.LastName +
        '</td><td>'+
        employee.Grants+
        '</td></tr>';
}