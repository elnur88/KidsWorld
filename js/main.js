var globaluserid ="0";

function addadvsearchGood() {
    $.ajax({
        url: 'cs?action=aaaa',
        type: 'GET',
        datatype: 'html',
        success: function (data) {
            $('#accordgood').html(data);
        },
        error: function (data) {
            alert("catalog list xetali");
        }
    });
}

function getUserLists() {



    $.ajax({
        url: 'cs?action=getUserLists',
        type: 'GET',
        // data: 'adi--'+name,
        datatype: 'html',
        success: function (data) {
            $('.content').html(data);
         /* $("#newuserdialog").dialog("close");  */
        },
        /* complete: function(data){
             alert("")              ;
         } ,*/
        error: function (data) {
            alert("xetali");
        }
    });

}


function getCatalogLists() {



    $.ajax({
        url: 'cs?action=getCatalogists',
        type: 'GET',
        datatype: 'html',
        success: function (data) {
            $('#content').append(data);
        },
        error: function (data) {
            alert("catalog list xetali");
        }
    });

}

function getGoodsLists() {



    $.ajax({
        url: 'cs?action=getGoodsists',
        type: 'GET',
        datatype: 'html',
        success: function (data) {
            $('#content').append(data);
        },
        error: function (data) {
            alert("good list xetali");
        }
    });

}




function Insert_Users(aduserrrr) {
    var username = $('#usernameid').val();
    var psw = $('#usepasid').val();
    var name = $('#useradid').val();
    var lastname = $('#usersoyadid').val();
    var middlename = $('#userataadid').val();
    var cins =  $('#genderid option:selected').text() ;
    var olke = $('#userolkeid').val();
    var seher = $('#usercityid').val();
    var unvan = $('#userunvanid').val();
    //var adgunu = $('#userunvanid').val();
    var mobil = $('#usertelid').val();
    var mail = $('#usermailid').val();
    var birtthday = $('#birthdateid').val();
    var rolename =  $('#userroleid').val();
    var gender =  $('#genderid').val();
   /* var aduser =  $('#adusid').val();*/
    var aduser =  aduserrrr;

    if (username=='' || psw=='')           {
        alert("elave edin")          ;
    }    else {
           $.ajax({
                 url: 'cs?action=InsertUser',
                 type: 'POST',
                 data:'name='+name+'&lastname='+lastname
                     +'&middlename='+middlename
                     +'&cins='+cins+'&olke='+olke+'&aduser='+aduser
                     +'&seher='+seher+'&unvan='+unvan
                     +'&mobil='+mobil+'&mail='+mail+'&gender='+gender
                     +'&birtthday='+birtthday +'&rolename='+rolename
                     +'&username='+username+'&psw='+psw,
                 datatype: 'text',
                 success: function () {
                     alert("Elave olundu");
                     getUserLists();
                 }
             });

    }

        





}


function checkUserFun(aduserrrr) {
     
    var username = $('#usernameid').val();
    $.ajax({
        url: 'cs?action=checkUser',
        type: 'POST',
        data:'&username='+username,
        datatype: 'text',
        success: function (data) {

            if(data == "1") {
                alert("movcud");

            } else {
                Insert_Users(aduserrrr) ;


            }
        }
    });
}

function InsertCatalog(aduserrrr) {
    var name = $('#catalognameid').val();
    var aduser =  aduserrrr;


    $.ajax({
        url: 'cs?action=InsertCatalog',
        type: 'POST',
        data:'name='+name+'&aduser='+aduser,
        datatype: 'text',
        success: function () {
            alert(data);
        }
    });
}


function InsertGoods(aduserrrr) {

    var name = $('#goodnameid').val();
    var countt = $('#goodcountid').val();
    var size = $('#goodsizeid').val();
    var age = $('#goodageid').val();
    var description = $('#gooddescid').val();
    var good_code = $('#goodcodeid').val();
    var catalogid = $('#goodcatalogid').val();
    var catalog_name = $('#goodcatalogid option:selected').text() ;
    var aduser =  aduserrrr;
    var image = $('#goodimageid').val();



    $.ajax({
        url: 'cs?action=InsertGoods',
        type: 'POST',
        data:'name='+name+'&size='+size
            +'&age='+age+'&aduser='+aduser
            +'&countt='+countt+'&good_code='+good_code
            +'&description='+description+'&catalogid='+catalogid
            +'&catalog_name='+catalog_name+'&image='+image,
        datatype: 'text',
        success: function () {
            alert(data);
        }
    });
}



function editUser(userid) {
    globaluserid =userid ;
    $.ajax({
        url: 'cs?action=editUser',
        type: 'GET',
        data:  'userid=' +userid ,
        datatype: 'html',
        success: function (data) {
        $("#editserdialog").html(data) ;
        $("#editserdialog").dialog('open') ;
            getComboRoleLists();
        },
        /* complete: function(data){
             alert("")              ;
         } ,*/
        error: function (data) {
            alert("xetali");
        }
    });

}

function editCatalog(catalogid) {
    globaluserid =catalogid ;
    $.ajax({
        url: 'cs?action=editCatalog',
        type: 'GET',
        data:  'userid=' +catalogid ,
        datatype: 'html',
        success: function (data) {
            $("#editcatalogdialog").html(data) ;
            $("#editcatalogdialog").dialog('open') ;
        },
        /* complete: function(data){
             alert("")              ;
         } ,*/
        error: function (data) {
            alert("edit catalog xetali");
        }
    });

}


function editGood(goodsid) {
    globaluserid =goodsid ;
    $.ajax({
        url: 'cs?action=editGoods',
        type: 'GET',
        data:  'userid=' +goodsid ,
        datatype: 'html',
        success: function (data) {
            $("#editgoodsdialog").html(data) ;
            $("#editgoodsdialog").dialog('open') ;
        },
        /* complete: function(data){
             alert("")              ;
         } ,*/
        error: function (data) {
            alert("edit goods xetali");
        }
    });

}


function Update_Users() {

    var username = $('#usernameid7').val();
    var psw = $('#usepasid7').val();
    var name = $('#useradid7').val();
    var lastname = $('#usersoyadid7').val();
    var middlename = $('#userataadid7').val();
    var cins =   $('#genderid7 option:selected').text();
    var olke = $('#userolkeid7').val();
    var seher = $('#usercityid7').val();
    var unvan = $('#userunvanid7').val();
    var mobil = $('#usertelid7').val();
    var mail = $('#usermailid7').val();
    var birtthday = $('#birthdateid7').val();
    var rolename =  $('#userroleid1').val();
    var gender =  $('#genderid7').val();
    var oid =  $('#useriiiid7').val();


    $.ajax({
        url: 'cs?action=updateUsers',
        type: 'POST',
        data:'name='+name+'&lastname='+lastname+'&oid='+oid
            +'&middlename='+middlename
            +'&cins='+cins+'&olke='+olke
            +'&seher='+seher+'&unvan='+unvan
            +'&mobil='+mobil+'&mail='+mail+'&gender='+gender
            +'&birtthday='+birtthday +'&rolename='+rolename
            +'&username='+username+'&psw='+psw+'&globaluserid='+globaluserid,
        datatype: 'text',
        success: function () {
            alert("ugurlu");
        }     ,
        error: function (data) {
            alert("User deyisiklik edilmedi")   ;

        }
    });
}


function Update_Catalog() {

    var name = $('#catalognameid7').val();
    var oidd = $('#catalogoidd7').val();




    $.ajax({
        url: 'cs?action=updateCatalog',
        type: 'POST',
        data:'name='+name+'&catalogid='+oidd,
        datatype: 'text',
        success: function () {
            alert(data);
        }
    });
}


function Update_Goods() {
    var name = $('#goodnameid7').val();
    var countt = $('#goodcountid7').val();
    var oid = $('#gooogid7').val();
    var size = $('#goodsizeid7').val();
    var age = $('#goodageid7').val();
    var description = $('#gooddescid7').val();
    var good_code = $('#goodcodeid7').val();
    var catalogid = $('#goodcatalogid7').val();
    var catalog_name = $('#goodcatalogid7 option:selected').text();
    var image = $('#goodimageid7').val();



    $.ajax({
        url: 'cs?action=updateGoods',
        type: 'POST',
        data:'name='+name+'&size='+size
            +'&age='+age+'&oid='+oid
            +'&countt='+countt+'&good_code='+good_code
            +'&description='+description+'&catalogid='+catalogid
            +'&catalog_name='+catalog_name+'&image='+image,
        datatype: 'text',
        success: function () {
            alert(data);
        }
    });
}


function searchuserfun(keyword) {

        $.ajax({
                    url: 'cs?action=getSearchUser',
                    type: 'GET',
                    data: 'keyword=' +keyword,
                    datatype: 'html',
                    success: function (data) {
                        $('#content').html(data);

                    },
                    error: function (data) {
                        alert("search error")   ;

                    }
                });


}


function advgoodsearch() {

    var kataloqoid ="'"+$('#searchkatalqid').val()+"'";
    var goodsoid ="'"+$('#searchgoodsid').val()+"'";
    var begindateid =$('#begindate').val();
    var enddateid =$('#enddate').val();


    $.ajax({
        url: 'cs?action=getadvgoodssearch',
        type: 'GET',
        data: 'kataloqoid='+kataloqoid+'&goodsoid='+goodsoid
            +'&begindateid='+begindateid+'&enddateid='+enddateid,
        datatype: 'html',
        success: function (data) {
            $('#content').append(data);

        },
        error: function (data) {
            alert("search error")   ;

        }
    });

}
