document.addEventListener('DOMContentLoaded', function() {
    var editIcons = document.querySelectorAll('.edit-icon');
    editIcons.forEach(function(editIcon) {
        editIcon.addEventListener('click', function() {
            var saveIcons = document.querySelectorAll('.save-icon');
            saveIcons.forEach(function(saveIcon) {
                saveIcon.style.visibility = 'hidden';
            });
            var saveEditIcons = document.querySelectorAll('.save-edit-icon');
            saveEditIcons.forEach(function(saveEditIcon) {
                saveEditIcon.style.visibility = 'visible';
            });
        });
    });
});