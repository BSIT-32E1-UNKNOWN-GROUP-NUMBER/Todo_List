document.querySelector('.save-edit-icon').addEventListener('click', function (e) {
    e.preventDefault();

    var editedTasks = {
        Id: parseInt(document.querySelector('.task-id').value),
        Description: document.querySelector('.input-field').value,
        Category: document.querySelector('.select-input').value,
        DueDate: document.querySelector('.date').value,
        // PriorityLevel: document.querySelector('.priority-level').value,
        // CompletionStatus: document.querySelector('.completion-status').checked
    };


    fetch('/Tasks/Edit', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'X-Requested-With': 'XMLHttpRequest'
        },
        body: JSON.stringify(editedTasks)
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
