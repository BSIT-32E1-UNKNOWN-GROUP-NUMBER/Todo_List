$(document).ready(function () {
    $('.delete-icon').click(function () {
        var taskId = parseInt($(this).data('id'));

        $.ajax({
            url: '/Tasks/DeleteConfirmed/' + taskId,
            type: 'POST',
            data: {
                __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val()
            },
            success: function (result) {
                console.log('Task deleted, reloading page');
                location.reload();
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.error(textStatus, errorThrown);
            }
        });
    });
});