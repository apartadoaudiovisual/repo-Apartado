$(document).ready(function () {

    /*$("[id*=GridView1] tr:has(td)").each(function () {
        var t = $(this).text().toLowerCase(); //all row text
        $("<td class='indexColumn'></td>")
          .hide().text(t).appendTo(this);
    }); //each tr
    $("#FilterTextBox").keyup(function () {

        var s = $(this).val().toLowerCase().split(" ");
        if ($(this).val() == "") {
            s = "";
        }

        $("#ContentPlaceHolder1_gridAreasServicio tr:hidden").show();
        $.each(s, function () {

            $("#ContentPlaceHolder1_gridAreasServicio tr:visible .indexColumn:not(:contains('"
                  + this + "'))").parent().hide();
        });



    });*/

    $("#FilterTextBox").on("keyup", function () {

        var value = $(this).val().toLowerCase();
        $(".grid tbody tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });

    });
});