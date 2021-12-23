// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$('.nav-link').on('click', function () {
    var $this = $(this);
    var $alias = $this.data('alias');

    $('.active').removeClass('active');
    $this.toggleClass('active')
    console.log($alias);

})