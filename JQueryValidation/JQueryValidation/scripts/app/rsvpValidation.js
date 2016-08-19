$(document)
    .ready(function() {
        $('#rsvpForm')
            .validate({
                rules: {
                    Name: {
                        required: true
                    },
                    Email: {
                        required: true
                    },
                    Phone: {
                        required: true
                        //phoneUS: true
                    },
                    FavoriteGame: {
                        required: true
                    },
                    WillAttend: {
                        required: true
                    }
                },
                messages: {
                    Name: "Enter your name",
                    Email: {
                        required: "Enter your email address",
                        email: "Thats not a format for email im awware of"
                    },
                    Phone: {
                        required: "Enter phone nember",
                        //phoneUS: $.validator.phoneUS(true)
                    },
                    FavoriteGame: {
                        required:   "tell me ehat your favorite game is",
                        minlength: $.validator.format("I don't know of any game with less than {0} characters...")
                    },
                    WillAttend: "I need to  know if you are coming or not"
                }
            });
    });