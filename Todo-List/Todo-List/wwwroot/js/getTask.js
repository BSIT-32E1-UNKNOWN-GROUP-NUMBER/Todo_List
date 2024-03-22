document.addEventListener('DOMContentLoaded', function() {
    var editIcons = document.querySelectorAll('.edit-icon');
    editIcons.forEach(function(editIcon) {
        editIcon.addEventListener('click', function() {
            var taskId = parseInt(this.getAttribute('data-id'));

            fetch('/Tasks/GetTask/' + taskId)
            .then(response => response.json())
            .then(task => {
                document.querySelector('.input-field[name="Description"]').value = task.description;
                document.querySelector('.select-input[name="Category"]').value = task.category;
                document.querySelector('#dateTimeInput').value = task.dueDate;
            })
            .catch((error) => {
                console.error('Error:', error);
            });
        });
    });
});