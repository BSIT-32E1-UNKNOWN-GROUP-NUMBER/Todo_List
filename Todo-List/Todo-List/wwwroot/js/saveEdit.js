$(document).ready(function () {
    $('.save-edit-icon').click(function (e) {
        e.preventDefault();

        
        var editedTasks = {
            Id: $('.task-id').val(), 
            Description: $('.input-field').val(),
            Category: $('.select-input').val(),
            DueDate: $('.date').val(),
            PriorityLevel: $('.priority-level').val(), 
            CompletionStatus: $('.completion-status').is(':checked')
        };

        
        $.ajax({
            url: '/Tasks/Edit',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(editedTasks),
            success: function (response) {
                if (response.success) {
                    location.reload();
                }
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.error("AJAX call failed: " + textStatus + ', ' + errorThrown);
                console.error("Response text: " + jqXHR.responseText);
            }
        });
    });
});