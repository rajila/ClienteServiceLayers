var TaskEdit = {

    init: function (idTable, classFielCalendar) {
        $("#" + idTable + " tbody td input." + classFielCalendar).datetimepicker({ language: "es", formatTime: 'H:i', formatDate: 'd/m/Y', format: 'd/m/Y H:i' });
    }
}

function eventHistorial(i)
{
    var _element = $("#history_"+i);
    var _row = $("#rowhistorial_" + _element.attr('numrow'));

    if (_row.attr('class') === 'hide') _row.attr('class', 'showRow');
    else _row.attr('class', 'hide');

    if (_element.attr('class') === 'glyphicon glyphicon-eye-close') _element.attr('class', 'glyphicon glyphicon-eye-open');
    else _element.attr('class', 'glyphicon glyphicon-eye-close');

    var _historicoTareaJSON = new Object();
    _historicoTareaJSON.id_asegurado = _element.attr('idasegurado');

    if ( _historicoTareaJSON != null )
    {
        $.ajax({
            type: "POST",
            url: "/Home/AjaxPostCallHistory",
            data: JSON.stringify(_historicoTareaJSON),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                if (response != null) {
                    console.log(response);
                } else {
                    alert("Something went wrong");
                }
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    }
}