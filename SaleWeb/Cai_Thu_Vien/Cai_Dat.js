/*
CÀI CKFINTER. 2.6
    1 TẢI & GIẢI NÉN VERSION 2.6
    2 TẠO THƯ MỤC PLUGINS TRONG THƯ MỤC JS PASS VÀO
    3 INCLUDE TẤT CẢ FILE TRONG THƯ MỤC PLUGINS VÀO & XÓA 2 FODEL ĐÀU TIÊN
    4 KÉO IMPORT LINK FINDER.JS VÀO _LAYOUT CHUNG
    5 IMPORT REFERENCE FINDER.DLL VÀO PROJECT NẰM TRONG THƯ MỤC BIN , IMPORT VÀO REFERENCE RỒI THÌ XÓA FOLDER BIN
    6 ADD MỚI FOLDER DATA VÀO PROJECT
    7 VÀO CONFIG TRONG FINDER ---- AUTHENTICATION(TRUE) & BaseUrl = "/data/";
    8 TẠO BUTTON & INPUT ĐỂ VIẾT JS
    9  $(" #selectImage").click(function (e) { ====>(TEN BUTTON)
         e.preventDefault();
         var finder=new CKFinder();
         finder.selectActionFunction=function (url) {
         $("#txtid").val(url); ====>(TEN INPUT)
         };
         finder.popup(); ====> popup viết thường.
         })
         //////////////////////////////////
CÀI CKEDITER 5
      1 GIẢI NÉN VÀ COPPY VÀO PLUGINS CHUNG CKFINDER
      2 NHÚNG VÀO LAYOUT CHUNG HOẶC HTML CẦN SỬ DỤNG
      3 VÀO COFIG.JS CẤU HÌNH EDITER
      4 NHUNG VÀO THẺ HTML & DÁN ĐƯỜNG DẪN CONFIG EDITER
*/