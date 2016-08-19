$(document)
    .ready(function() {
        $('jobForm')
            .validate({
                rules: {
                    Position: {
                        required: true
                    },
                    Discription: {
                        required: true,
                        minlength: 5
                    }
                },
                messages: {
                    Position: "Enter a new job position",
                    Discription: {
                        required: "Enter the new jobs discription",
                        minlength: $.validator.format("Discription can not be that short")
                    } 
                }
            });
    });