// Write your Javascript code

$(".SelectUser").click('[data-id]', function (e) {
    e.preventDefault();
    var id = $(this).data('id');

    $.ajax({
        method: 'GET',
        url: '/Home/SelectUser/' + id
    })
        .done(function (data) {
            $("#SelectUserModal").html(data);
            $("#SelectUserModal").find('#SelectUserModals').modal('show');
        })
        .error(function () {
            alert('Erro');
        });
});