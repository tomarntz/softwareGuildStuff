$(document)
    .ready(function () {
        $('#postForm')
            .validate({
                rules: {
                    Title: {
                        required: true
                    },
                    ImagePath: {
                        required: true
                    },
                    Content: {
                        required: true,
                        minlength: 40
                    }
                },
                messages: {
                    Title: "Enter a title",
                    ImagePath: "Enter an image path",
                    Content: {
                        required: "Enter content into the post",
                        minlength: "Please enter at least 40 characters"
                    }
                    
                }
            });
    });