$(document).ready(function () {
    

    $(".TituloPantalla").text(document.title);

    /*--------------------------------------------------------------------Para los checkbox*/
    $('.on_off :checkbox').iphoneStyle();
    $('.disabled :checkbox').iphoneStyle();
    $('.css_sized_container :checkbox').iphoneStyle({ resizeContainer: false, resizeHandle: false });
    $('.long_tiny :checkbox').iphoneStyle({ checkedLabel: 'Very Long Text', uncheckedLabel: 'Tiny' });

    var onchange_checkbox = ($('.onchange :checkbox')).iphoneStyle({
        onChange: function (elem, value) {
            $('span#status').html(value.toString());
        }
    });

    setInterval(function () {
        onchange_checkbox.prop('checked', !onchange_checkbox.is(':checked')).iphoneStyle("refresh");
        return
    }, 2500);
    /*-------------------------------------------------------------------------------------*/


    /*---------------------------------------------------------------------fechas  */

    $('.dtFecha_inicio').datetimepicker({
        format: 'Y/m/d',
        onShow: function (ct) {
            this.setOptions({
                maxDate: jQuery('.dfecha_Fin').val() ? jQuery('.dfecha_Fin').val() : false
            })
        },
        timepicker: false,
        mask: '19/39/9999',
        lang: 'es'
    });

    $('.dfecha_Fin').datetimepicker({
        format: 'Y/m/d',
        onShow: function (ct) {
            this.setOptions({
                minDate: jQuery('.dtFecha_inicio').val() ? jQuery('.dtFecha_inicio').val() : false
            })
        },
        timepicker: false,
        mask: '19/39/9999',
        lang: 'es'
    });



    $('.Fecha').datetimepicker({
        timepicker: false,
        format: 'd/m/Y',
        formatDate: 'Y/m/d',
        mask: '19/39/9999',
        lang: 'es'
    });


    $(".MayorIgual").datetimepicker({
        timepicker: false,
        format: 'd/m/Y',
        formatDate: 'Y/m/d',
        minDate: '-1970/01/02',
        mask: '19/39/9999',
        lang: 'es'
    });


    $('.L_V').datetimepicker({
        timepicker: false,
        format: 'd/m/Y',
        formatDate: 'Y/m/d',
        mask: '19/39/9999',
        lang: 'es',
        onGenerate: function (ct) {
            $(this).find('.xdsoft_date.xdsoft_weekend')
			.addClass('xdsoft_disabled');
        }
    });

    /**-------------------------------------------------------------------------------*/

    /*----------------------------------------------------------------------TABLAS*/


    //$(".grid tr th").remove();
    var titles1 = $(".grid th");
    $(".grid th").parent().parent().parent().append("<thead><tr class='header'>" + titles1.parent().html() + "</tr></thead>");
    titles1.parent().remove();

    var titles = $(".grid thead tr th");
    for (var c = 0; c <= titles.length - 1; c++) {
        titles[c].className = "title";
    }
    if (titles.length > 0) {
        titles[0].parentElement.className = "FilaTitulo";
        titles[0].className = "titleLeft";
        titles[titles.length - 1].className = "titleRight";

        var titulos = $(".title");

        for (var cc = 0; cc <= titulos.length - 1; cc++) {
            titulos[cc].innerHTML = "<div>" + titulos[cc].innerHTML + "</div>";
        }

        $(".titleLeft").html("<div>" + $(".titleLeft").html() + "</div>")
        $(".titleRight").html("<div>" + $(".titleRight").html() + "</div>")

        var rows = $(".grid tbody tr");

        var rowclase = "row1";

        for (var c = 0; c <= rows.length - 1; c++) {
            if (rowclase == "row1") {
                rows[c].className = rowclase;
                rowclase = "row2";
            }
            else {
                rows[c].className = rowclase;
                rowclase = "row1";
            }

            for (var J = 0; J <= rows[c].children.length - 1; J++) {
                rows[c].children[J].className = "celda";

                if (c == rows.length - 1) {
                    rows[c].children[J].className = "celdaBottom";
                }
            }
            rows[c].children[0].className = "celdaLeft";
            rows[c].children[rows[c].children.length - 1].className = "celdaRight";

        }

        rows[rows.length - 1].children[0].className = "celdaBottomLeft";
        rows[rows.length - 1].children[rows[rows.length - 1].children.length - 1].className = "celdaBottomRight";
    }

    /*--------------------------------------------------------------------------------*/


});
/* fin document ready */


function message_info(M, t) {
    $.blockUI({ message: '...' });
    new Messi(M, {
        title: t,
        titleClass: 'success',
        buttons: [{ id: 0, label: 'Aceptar', val: 'X'}],
        callback: function (val) {
            $.unblockUI();
        }
    });
}

function message_yesno(M, t,cmd) {
    $.blockUI({ message: '...' });
    new Messi(M,
           { title: t,
               buttons: [{ id: 0, label: 'Si', value: 'Y' },
                         { id: 1, label: 'No', value: 'N'}],
               callback: function (value) {
                   $.unblockUI();
                   if (value == 'Y') {
                       doPostBack('', cmd + "_" + value); 
                   }

               }
           });
}

function message_YesNoCancel(M, t, cmd) {
    $.blockUI({ message: '...' });
    new Messi(M, {
        title: t,
        buttons: [{ id: 0, label: 'Si', value: 'Y', class: '' },
                         { id: 1, label: 'No', value: 'N', class: '' },
                         { id: 2, label: 'Cancelar', value: 'C'}],
        callback: function (value) {
            $.unblockUI();
            if (value == 'Y') {
                doPostBack('', cmd + "_" + value);
            }
            else if (value == 'N') {
                doPostBack('', cmd + "_" + value);
            }
            else if (value == 'C') {
                doPostBack('', cmd + "_" + value);
            }
        }
    });
}

function message_error(M, t) {
    //$.blockUI({ message: '...' });
    new Messi(M, {
        title: t,
        titleClass: 'anim error',
        buttons: [{ id: 0, label: 'Aceptar', val: 'X'}],
        callback: function (val) {
            $.unblockUI();
        }
    });

}

function doPostBack(eventTarget, eventArgument) {
    var theForm = document.forms[0];
    if (!theForm.onsubmit || (theForm.onsubmit() != false)) {
        theForm._parametro.value = eventArgument;
        theForm.submit();

    }
}