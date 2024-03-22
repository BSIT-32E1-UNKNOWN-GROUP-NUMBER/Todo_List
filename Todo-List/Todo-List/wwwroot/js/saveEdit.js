document.querySelector('.save-edit-icon').addEventListener('click', function (e) {
    e.preventDefault();

    var editedTasks = new FormData();
    editedTasks.append('Id', parseInt(document.querySelector('.task-id').value));
    editedTasks.append('Description', document.querySelector('.input-field').value);
    editedTasks.append('Category', document.querySelector('.select-input').value);
    editedTasks.append('DueDate', document.querySelector('.date').value);
    // editedTasks.append('PriorityLevel', document.querySelector('.priority-level').value);
    // editedTasks.append('CompletionStatus', document.querySelector('.completion-status').checked);

    fetch('/Tasks/Edit', {
        method: 'POST',
        body: editedTasks
    })
    .then(response => {
        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }
        return response.json();
    })
    .then(data => {
        if (data.success) {
            location.reload();
        }
    })
    .catch((error) => {
        console.error('Error:', error);
    });
});