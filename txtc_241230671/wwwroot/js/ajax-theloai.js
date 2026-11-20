$(function () {
    $('#menu').on('click', 'a.js-theloai', function (e) {
        e.preventDefault();

        var $link = $(this);
        var maTL = $link.data('id');

        $.get('/Home/Loc', { maTL: maTL })
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