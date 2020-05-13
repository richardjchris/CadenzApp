function FadeOutPreloader() {
	$('#basePreloader').delay(400).fadeOut('slow');
	$('#preloader').delay(400).fadeOut();
};

function FadeOutPreloaderModal() {
	var def = new $.Deferred();
	$('#basePreloader').fadeOut('slow');
	$('#preloader').fadeOut();
	def.resolve();
	return def.promise();
};

function FadeInPreloader() {
	$('#basePreloader').fadeIn('slow');
	$('#preloader').fadeIn();
};

function FadeInPreloaderFast() {
	$('#basePreloader').fadeIn(200);
	$('#preloader').fadeIn(200);
};

function FadeOutPreloaderFast() {
	$('#basePreloader').fadeOut(300);
	$('#preloader').fadeOut(300);
};

function FadeOutPreloaderSmall() {
	$('#containerPreloader').delay(1700).fadeOut('slow');
	$('#preloader2').delay(1700).fadeOut();
};

function FadeOutPreloaderSmallModal() {
	var def = new $.Deferred();
	$('#containerPreloader').fadeOut('slow');
	$('#preloader2').fadeOut();
	def.resolve();
	return def.promise();
};

function FadeInPreloaderSmall() {
	$('#containerPreloader').fadeIn();
	$('#preloader2').fadeIn();
};

//window.addEventListener("load", function () {
//	$('#basePreloader').delay(1700).fadeOut('slow');
//	$('#preloader').delay(1700).fadeOut();
//}, false);