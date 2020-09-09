$(window).on('click', function (event) {
    // element over which click was made
    var clickOver = $(event.target)
    if ($('.navbar .navbar-toggler').attr('aria-expanded') == 'true' && clickOver.closest('.navbar').length === 0) {
        // Click on navbar toggler button
        $('button[aria-expanded="true"]').click();
    }
});

$('.activemenu').on('click', 'li', function () {
    //$('.activemenu li.active').removeClass('active');
    //$(this).addClass('active');
   
    if (!$(this).hasClass('dropdown')) {
        $('.navbar-collapse').collapse('hide');
        //alert('')
    }
    if ($(this).next().hasClass('show')) {
        $('.navbar-collapse').collapse('hide');
    }
    if ($(this).hasClass('show')) {
        $('.navbar-collapse').collapse('hide');
    }

});
//$('.dropdown-submenu').on('click','li', function () {
  
//    $('.dropdown-menu').css('display: block');
//    alert('adwad')

//});

$('.dropdown-menu a.dropdown-toggle').on('click', function (e) {
    if (!$(this).next().hasClass('show')) {
        $(this).parents('.dropdown-menu').first().find('.show').removeClass("show");
        
    }
    var $subMenu = $(this).next(".dropdown-menu");
    $subMenu.toggleClass('show');


    $(this).parents('li.nav-item.dropdown.show').on('hidden.bs.dropdown', function (e) {
        $('.dropdown-submenu .show').removeClass("show");
    });


    return false;
});