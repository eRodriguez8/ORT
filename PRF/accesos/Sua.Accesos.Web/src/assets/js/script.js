$(document).scroll(function () {
    var scroll_pos = $(this).scrollTop();
    if (scroll_pos > 45) {
        $("#menu").addClass('bg-menu');
        $('.header').addClass('bg-black');
    } else {
        $('.header').removeClass('bg-black');
        $("#menu").removeClass('bg-menu');
    }
});

$(document).on('click', '.data-table-wrapper', function (event) {
    if ($(event.target).hasClass('pagination-nextpage') ||     
        $(event.target).hasClass('pagination-prevpage') ||      
        $(event.target).hasClass('column-resize-handle')) {
        event.preventDefault();
    }

    if ($(event.target).parent().hasClass('pagination-nextpage') ||
        $(event.target).parent().hasClass('pagination-prevpage'))
    {
        event.preventDefault();
    }
});
