function ChangeStatus() {
    $('.btn-active').off('click').on('click', function (e) {
        e.preventDefault();
        var textChange = $(this);
        var id = textChange.data('id');
       // console.log(id);
        $.ajax({
            url: '/Admin/Home/UpStatus',
            data: { id: id },
            dataType: 'json',
            type: 'POST',
            success: function (response) {
                if (response.status) {
                    textChange.text("Active");
                } else {
                    textChange.text("Block");
                }
            }

        })
    })
}
ChangeStatus();