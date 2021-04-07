$(document).ready(function () {
  $("#home-slider").owlCarousel({
    items: 1,
    loop: true,
    dots: true,
    margin: 0,
    nav: false,
    autoplay: true,
    autoplayHoverPause: false,
    autoplayTimeout: 4000,
    smartSpeed: 800,
  });

  if ($("#contact-form").length > 0) {
    $("#contact-form").validate({
      rules: {
        name: "required",
        subject: "required",
        textareas: "required",
        email: {
          required: true,
          email: true,
        },
      },
      messages: {
        name: {
          required: "",
        },
        subject: {
          required: "",
        },
        textareas: {
          required: "",
        },
        email: {
          required: "",
          email: "",
        },
      },
    });
  }

  $(document).scroll(function () {
    var y = $(this).scrollTop();
    if (y > 10) {
      $("nav").addClass("style");
      $(".menu-main").addClass("style-2");
      $(".navbar-logo").addClass("none");
      $(".line").addClass("none");
      $(".menu-list").addClass("dada");
    } else {
      $("nav").removeClass("style");
      $(".menu-list").removeClass("dada");
      $(".line").removeClass("none");
      $(".menu-main").removeClass(".style-2");
      $(".navbar-logo").removeClass("none");
    }
  });

  var addClassOnScroll = function () {
    var windowTop = $(window).scrollTop();
    $("section[id],header[id]").each(function (index, elem) {
      var offsetTop = $(elem).offset().top;
      var outerHeight = $(this).outerHeight(true);

      if (windowTop > offsetTop - 50 && windowTop < offsetTop + outerHeight) {
        var elemId = $(elem).attr("id");
        $("nav ul li a.active").removeClass("active");
        $("nav ul li a[href='#" + elemId + "']").addClass("active");
      }
    });
  };

  $(function () {
    $(window).on("scroll", function () {
      addClassOnScroll();
    });
  });

  $("nav ul li a").click(function () {
    $("nav ul li a").removeClass("active");
    $(this).addClass("active");
  });

  jQuery("img.svg").each(function () {
    var $img = jQuery(this);
    var imgID = $img.attr("id");
    var imgClass = $img.attr("class");
    var imgURL = $img.attr("src");
    jQuery.get(
      imgURL,
      function (data) {
        var $svg = jQuery(data).find("svg");
        if (typeof imgID !== "undefined") {
          $svg = $svg.attr("id", imgID);
        }
        if (typeof imgClass !== "undefined") {
          $svg = $svg.attr("class", imgClass + " replaced-svg");
        }
        $svg = $svg.removeAttr("xmlns:a");
        if (
          !$svg.attr("viewBox") &&
          $svg.attr("height") &&
          $svg.attr("width")
        ) {
          $svg.attr(
            "viewBox",
            "0 0 " + $svg.attr("height") + " " + $svg.attr("width")
          );
        }
        $img.replaceWith($svg);
      },
      "xml"
    );
  });

  $(document).on("submit", "#contact-form", function (e) {
    e.preventDefault();
    var FullName = $("#name").val();
    var Email = $("#email").val();
    var Subject = $("#subject").val();
    var Message = $("#textareas").val();
    $.ajax({
      url: "anasayfa/iletisim",
      type: "POST",
      data: {
        fullName: FullName,
        email: Email,
        subject: Subject,
        message: Message
      },
      dataType: "json",
      success: function (data) {
        Swal.fire({
          title: "Başarılı!",
          text: "Kaydınız alındı. En kısa süre içerisinde size geri dönüş yapılacaktır.",
          icon: "success",
          timer: 3000,
          showConfirmButton: false,
        });
        closeModal();
      },
      error: function (data) {
        Swal.fire({
          title: "Başarısız!",
          text: "Kaydınız alınırken bir hata oluştu. Lütfen daha sonra tekrar deneyiniz.",
          icon: "error",
          timer: 3000,
          showConfirmButton: false,
        });
      },
    });
  });
});
