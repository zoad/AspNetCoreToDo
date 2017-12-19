// Write your JavaScript code.
$(document).ready(function () {
    $('#add-item-button').on('click', addItem);

    $('.done-checkbox').on('click', function (e) {

        markCompleted(e.target);
    });

});

function addItem() {
    $('#add-item-error').hide();
    let newTitle = $('#add-item-title').val();
    //let newDueDate = Date.parse($('#add-item-dueDate').val()).getTimezoneOffset();

    let newDueDate = $('#add-item-dueDate').val();


    $.post('/Todo/AddItem', { title: newTitle, dueAt: newDueDate }, function () {
        window.location = '/Todo';
    }).fail(function (data) {
        if (data && data.responseJSON) {
            var firstError = data.responseJSON[Object.keys(data.responseJSON)[0]];

            $('#add-item-error').text(firstError);
            $('#add-item-error').show();
        }
    });
}

function markCompleted(checkbox) {
    checkbox.disabled = true;

    $.post('/Todo/MarkDone', { id: checkbox.name }, function () {
        let row = checkbox.parentElement.parentElement;
        $(row).addClass('done');
    });
}