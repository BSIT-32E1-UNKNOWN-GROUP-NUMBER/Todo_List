document.addEventListener('DOMContentLoaded', function () {
    var deleteIcons = document.querySelectorAll('.delete-icon');
    deleteIcons.forEach(function(deleteIcon) {
        deleteIcon.addEventListener('click', function () {
            var taskId = parseInt(this.getAttribute('data-id'));

            var token = document.querySelector('input[name="__RequestVerificationToken"]').value;
            var headers = new Headers();
            headers.append('Content-Type', 'application/x-www-form-urlencoded');

            fetch('/Tasks/DeleteConfirmed/' + taskId, {
                method: 'POST',
                headers: headers,
                body: '__RequestVerificationToken=' + encodeURIComponent(token)
            })
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                location.reload();
            })
            .catch(error => {
                console.error('Error:', error);
            });
        });
    });
});