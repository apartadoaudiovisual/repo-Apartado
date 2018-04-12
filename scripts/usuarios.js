$(document).ready(function () {

    $("[id*=GridUsuarios] tr:has(td)").each(function () {
        var t = $(this).text().toLowerCase(); //all row text
        $("<td class='indexColumn'></td>")
          .hide().text(t).appendTo(this);
    }); //each tr
    $("#FilterTextBox").keyup(function () {

        var valor = $(this).val().toLowerCase();
        $("#gridAreasServicio").filter(function () {

            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
        });



    });
});
        