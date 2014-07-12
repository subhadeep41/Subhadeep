$(function(){ 							   

	// radiys box
	$('.header').css({"border-radius": "10px 0 10px 0", "-moz-border-radius":"10px 0 10px 0", "-webkit-border-radius":"10px 0 10px 0"});
	$('.hbg').css({"border-radius": "0 20px 20px 0", "-moz-border-radius":"0 20px 20px 0", "-webkit-border-radius":"0 20px 20px 0"});
	$('.pagenavi a, .pagenavi .current').css({"border-radius": "5px", "-moz-border-radius":"5px", "-webkit-border-radius":"5px"});
	$('.mainbar .spec a.rm').css({"border-radius": "10px", "-moz-border-radius":"10px", "-webkit-border-radius":"10px"});
	$('.fbg').css({"border-radius": "20px 0 0 0", "-moz-border-radius":"20px 0 0 0", "-webkit-border-radius":"20px 0 0 0"});
	$('.content').css({"border-radius": "0 20px 0 20px", "-moz-border-radius":"0 20px 0 20px", "-webkit-border-radius":"0 20px 0 20px"});

});

function datahandler() {

    var input1 = $('input[id=TextBox1]').val();
    var input2 = $('input[id=TextBox2]').val();
    alert(input1);
}