$('.tab-item').click(function () {
    $(this).addClass('active');
    $('.tab-item').not(this).removeClass('active');
})

$('span.btn-show-menu, span.btn-close-menu').click(function () {
    if ($('.search-modal').hasClass('show')) {
        $('.search-modal').toggleClass('show')
    }
    $('.top-nav').toggle('fast').toggleClass('show');
})

$('span.search, span.btn-close-search-modal').click(function () {
    if ($('.top-nav').hasClass('show')) {
        $('.top-nav').toggle('fast').toggleClass('show');
    }
    $('.search-modal').toggleClass('show');
})