var user = {
    init:function() {
        user.registerEvents();
    },
    registerEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {//off do co nhieu record nen can set off de reset va khoi tao lai su kien
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');//lay tat ca gia tri id cua prefix data-id
            $.ajax({
                url: "/Admin/User/ChangeStatus/",
                data: { id: id },//id  khai bao ben controller, id cua var id
                dataType: "json",
                type: "POST",
                success: function (response) {//response: status=result ben controller
                    if(response.status==true)
                    {
                        btn.text('Kích hoạt');
                    }
                    else
                    {
                        btn.text('Khóa');
                    }
                }
            });
        }); 
    }
}
user.init();