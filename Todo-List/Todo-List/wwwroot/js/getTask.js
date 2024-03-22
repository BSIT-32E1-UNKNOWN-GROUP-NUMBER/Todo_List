$(document).ready(function () {
    $('.edit-icon').click(function () {
        var taskId = parseInt($(this).data('id'));

        $.ajax({
            url: '/Tasks/GetTask/' + taskId, 
            type: 'GET',
            success: function (task) {
                $('.input-field[name="Description"]').val(task.description);
                $('.select-input[name="Category"]').val(task.category);
                $('#dateTimeInput').val(task.dueDate);
                
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.error(textStatus, errorThrown);
            }
        });
    });
});