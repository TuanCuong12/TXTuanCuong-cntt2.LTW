$(function () {
    $('#menu').on('click', 'a.js-loai', function (e) {
        e.preventDefault();

        var $link = $(this);
        var maLoai = $link.data('id');

        $.get('/Home/Loc', { maLoai: maLoai })
            .done(function (html) {
                $('#content').html(html);
                $('#menu li').removeClass('active');
                $link.closest('li').addClass('active');
            })
            .fail(function () {
                alert('Không tải được dữ liệu. Vui lòng thử lại.');
            });
    });
});