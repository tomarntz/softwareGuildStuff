$(document)
    .ready(function () {
        $('#postForm')
            .validate({
                rules: {
                    'Post.Title': {
                        required: true
                    },
                    'Post.Content': {
                        required: true,
                        minlength: 40
                    },
                    'Post.Tags': {
                        required: true
                    },
                    'Post.ImagePath': {
                        required: true
                    }
                   
                },
                messages: {
                    'Post.Title': "Enter a title",
                    'Post.Content': {
                        required: "Enter content into the post",
                        minlength: "Please enter at least 40 characters"
                    },
                    'Post.Tags': "Enter some tags for the post",
                    'Post.ImagePath': "Enter your image path for the blog"
                }
            });
    });