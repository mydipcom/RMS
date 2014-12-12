var NOPARALLAX_WIDTH = 1024; // The screen width beneath which parallax is not allowed. (inclusive)

$( document ).ready(function() {
    var parallaxActive = true;
    var types = [];
    var ratios = [];
    var pageOffsets = [];
    var customOffsets = [];
    function setParallaxActive() {
        parallaxActive = $( window ).width() > NOPARALLAX_WIDTH;
        if (!parallaxActive) {
            $( '.parallax' ).css({ 'background-position':'', 'top':'' }); // Clear effects of parallax
        }
    }
    function updateParallaxTypes() {
        elements = $('.parallax');
        types = [];
        $.each(elements, function(i,element) {
            if ($( this ).attr('data-parallax-type'))
                types.push( $( this ).attr('data-parallax-type') );
            else
                types.push('background');
        });
    }
    function updateParallaxRatios() {
        elements = $('.parallax');
        ratios = [];
        $.each(elements, function(i,element) {
            ratios.push( $( this ).attr('data-parallax-ratio') );
        });
    }
    function updateParallaxOffsets() {
        elements = $('.parallax');
        var newPageOffsets = [];
        customOffsets = [];
        $.each(elements, function(i,element) {
            if (pageOffsets[i] && $( this ).attr('data-parallax-type') == 'position') {
                // The offsets have already been set once and we are looking at an absolutely positioned element
                // Push the old offset that was calculated
                newPageOffsets.push( pageOffsets[i] );
            } else
                newPageOffsets.push( $( this ).offset().top );

            var customOffset = $(element).attr('data-parallax-offset');
            if (!customOffset)
                customOffset = 0;
            customOffsets.push( parseInt(customOffset) );
        });
        pageOffsets = newPageOffsets;
    }
    function updateParallax() {
        if (parallaxActive) {
            s = $( document ).scrollTop();
            mult = $( window ).width() / 1440; // 1440 is the width of the photoshop file (thus, the "master width")
            $.each(elements, function(i, element) {
                if (types[i] == 'position')
                    $( this ).css('top', (s - pageOffsets[i] + customOffsets[i]) * ratios[i] + 'px');
                else if (types[i] == 'background')
                    $( this ).css('background-position', "0 " + (s - pageOffsets[i] + (customOffsets[i] * mult)) * ratios[i] + "px");
            });
        }
    }
    setParallaxActive();
    updateParallaxTypes();
    updateParallaxRatios();
    updateParallaxOffsets();
    updateParallax();
    $( document ).scroll(function(){
        requestAnimationFrame(updateParallax)
    });
    $( window ).resize(function() {
        setParallaxActive();
        updateParallaxOffsets();
        updateParallax();
    });
    $( window ).load(function() {
        // In case the layout wasn't fully loaded before
        updateParallaxOffsets();
        updateParallax();
    });
});
