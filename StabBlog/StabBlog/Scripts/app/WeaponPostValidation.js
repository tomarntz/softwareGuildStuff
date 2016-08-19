$(document)
    .ready(function () {
        $('#postForm')
            .validate({
                rules: {
                    'Weapon.Title': {
                        required: true
                    },
                    'Weapon.Content': {
                        required: true,
                        minlength: 40
                    },
                    'Weapon.ImagePath': {
                        required: true
                    },
                    'Weapon.ExhibitId': {
                        required: true
                    }

                },
                messages: {
                    'Weapon.Title': "Enter a title",
                    'Weapon.Content': {
                        required: "Enter content into the post",
                        minlength: "Please enter at least 40 characters"
                    },
                    'Weapon.ExhibitId': "Please select an exhibit that this weapon is in" 
                }
            });
    });