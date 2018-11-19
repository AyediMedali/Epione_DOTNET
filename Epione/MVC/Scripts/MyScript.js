
		$(document).ready(function(){
		    var arrow = $('.arrow-up');
		    var form = $('.form');
		    var status =false;
		    $('#login').click(function(){
		        if(status == false){
		            arrow.fadeIn();
		            form.fadeIn();
		            status = true;
		        }
		        else{
		            arrow.fadeOut();
		            form.fadeOut();
		            status = false;
		        }
		    });

		});
