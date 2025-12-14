$(document).ready(function () {
    $(window).scroll(function () {
        if ($(this).scrollTop() > 50) {
            $('.navbar').addClass('navbar-scrolled');
        } else {
            $('.navbar').removeClass('navbar-scrolled');
        }
    });

    function checkFadeIn() {
        $('.fade-in, .fade-up').each(function () {
            var elementTop = $(this).offset().top;
            var elementBottom = elementTop + $(this).outerHeight();
            var viewportTop = $(window).scrollTop();
            var viewportBottom = viewportTop + $(window).height();

            if (elementBottom > viewportTop && elementTop < viewportBottom) {
                $(this).addClass('visible');
            }
        });
    }

    $(window).on('scroll', checkFadeIn);
    checkFadeIn();

    $('a[href*="#"]').not('[href="#"]').not('[data-toggle]').click(function (event) {
        if (
            location.pathname.replace(/^\//, '') === this.pathname.replace(/^\//, '') &&
            location.hostname === this.hostname
        ) {
            var target = $(this.hash);
            target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
            if (target.length) {
                event.preventDefault();
                $('html, body').animate({
                    scrollTop: target.offset().top - 80
                }, 800, 'easeInOutCubic');
            }
        }
    });

    $('form').on('submit', function () {
        var $btn = $(this).find('button[type="submit"]');
        var originalText = $btn.html();
        
        if (this.checkValidity()) {
            $btn.html('<span class="spinner"></span> İşleniyor...');
            $btn.prop('disabled', true);
            
            setTimeout(function () {
                $btn.html(originalText);
                $btn.prop('disabled', false);
            }, 10000);
        }
    });

    $('.form-control').on('focus', function () {
        $(this).parent().addClass('input-focused');
    }).on('blur', function () {
        $(this).parent().removeClass('input-focused');
    });

    $('[data-toggle="tooltip"]').tooltip();

    $('.table tbody tr').hover(
        function () {
            $(this).css('transform', 'scale(1.01)');
        },
        function () {
            $(this).css('transform', 'scale(1)');
        }
    );

    setTimeout(function () {
        $('.alert').fadeOut('slow');
    }, 5000);

    function animateCounter($el) {
        var target = parseInt($el.text());
        $el.text('0');
        $({ count: 0 }).animate({ count: target }, {
            duration: 2000,
            easing: 'swing',
            step: function () {
                $el.text(Math.floor(this.count));
            },
            complete: function () {
                $el.text(target);
            }
        });
    }

    var countersAnimated = false;
    $(window).on('scroll', function () {
        if (!countersAnimated) {
            $('.panel-body h3, .stat-number').each(function () {
                var $this = $(this);
                var elementTop = $this.offset().top;
                var viewportBottom = $(window).scrollTop() + $(window).height();

                if (elementTop < viewportBottom && !$this.hasClass('animated')) {
                    $this.addClass('animated');
                    animateCounter($this);
                }
            });
        }
    });

    $('.navbar-toggler').on('click', function () {
        $('.navbar-collapse').toggleClass('show');
    });

    $('[data-confirm]').on('click', function (e) {
        if (!confirm($(this).data('confirm'))) {
            e.preventDefault();
        }
    });

    var $backToTop = $('<button class="back-to-top" title="Yukarı Çık"><i class="glyphicon glyphicon-chevron-up"></i></button>');
    $('body').append($backToTop);

    $(window).scroll(function () {
        if ($(this).scrollTop() > 300) {
            $backToTop.addClass('visible');
        } else {
            $backToTop.removeClass('visible');
        }
    });

    $backToTop.on('click', function () {
        $('html, body').animate({ scrollTop: 0 }, 600);
    });

    $('.btn').on('click', function (e) {
        var $this = $(this);
        var offset = $this.offset();
        var x = e.pageX - offset.left;
        var y = e.pageY - offset.top;

        var $ripple = $('<span class="ripple"></span>');
        $ripple.css({
            left: x,
            top: y
        });

        $this.append($ripple);

        setTimeout(function () {
            $ripple.remove();
        }, 600);
    });
});

$.easing.easeInOutCubic = function (x, t, b, c, d) {
    if ((t /= d / 2) < 1) return c / 2 * t * t * t + b;
    return c / 2 * ((t -= 2) * t * t + 2) + b;
};
