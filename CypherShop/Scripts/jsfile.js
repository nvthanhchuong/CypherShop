$(document).ready(function(){
	$('.product_hot_slick').slick({
		slidesToShow: 4,
		slidesToScroll: 3,
		infinite: true,
		autoplay: true,
		autoplaySpeed: 4000,
  });
});

/* Js Button Số Lượng Sản Phẩm */
function increaseCount(a, b) {
	var input = b.previousElementSibling;
	var value = parseInt(input.value, 10);
	value = isNaN(value) ? 0 : value;
	value++;
	input.value = value;
}
function decreaseCount(a, b) {
	var input = b.nextElementSibling;
	var value = parseInt(input.value, 10);
	if (value > 1) {
		value = isNaN(value) ? 0 : value;
		value--;
		input.value = value;
	}
}

/* Slick jquery Tabpanel */
$(document).ready(function () {
	$('.slick_dcb').slick({
	slidesToShow: 4,
	slidesToScroll: 1,
	});
});
/* Count down time */
// Set the date we're counting down to
var countDownDate = new Date("Aug 10, 2021 15:37:25").getTime();

// Update the count down every 1 second
var x = setInterval(function () {

	// Get today's date and time
	var now = new Date().getTime();

	// Find the distance between now and the count down date
	var distance = countDownDate - now;

	// Time calculations for days, hours, minutes and seconds
	var days = Math.floor(distance / (1000 * 60 * 60 * 24));
	var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
	var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
	var seconds = Math.floor((distance % (1000 * 60)) / 1000);

	// Output the result in an element with id="demo"
	document.getElementById("countdown-days").innerHTML = days;
	document.getElementById("countdown-hours").innerHTML = hours+"h";
	document.getElementById("countdown-minutes").innerHTML = minutes+"p";
	document.getElementById("countdown-seconds").innerHTML = seconds+"s";

	// If the count down is over, write some text 
	if (distance < 0) {
		clearInterval(x);
		document.getElementById(".countdown").innerHTML = "EXPIRED";
	}
}, 1000);

/* discount product slide*/
var slideIndex = 0;
showSlides();

function showSlides() {
	var i;
	var slides = document.getElementsByClassName("mySlides");
	var dots = document.getElementsByClassName("dot");
	for (i = 0; i < slides.length; i++) {
		slides[i].style.display = "none";
	}
	slideIndex++;
	if (slideIndex > slides.length) { slideIndex = 1 }
	for (i = 0; i < dots.length; i++) {
		dots[i].className = dots[i].className.replace(" active", "");
	}
	slides[slideIndex - 1].style.display = "block";
	dots[slideIndex - 1].className += " active";
	setTimeout(showSlides, 2000); // Change image every 2 seconds
}



/*discount slick*/
$(document).ready(function () {
	$('.product_ba_slick').slick({
		slidesToShow: 4,
		slidesToScroll: 3,
		infinite: true,
		autoplay: true,
		autoplaySpeed: 4000,
	});
});