var TaskEdit = {

    init: function (idTable, classFielCalendar) {
        $("#" + idTable + " tbody td input." + classFielCalendar).datetimepicker({ language: "es", formatTime: 'H:i', formatDate: 'd/m/Y', format: 'd/m/Y H:i' });
    }
}

function eventHistorial(i)
{
    var _element = $("#history_"+i);
    var _row = $("#rowhistorial_" + _element.attr('numrow'));
    var _requestAjax = true;

    if (_row.attr('class') === 'hide') _row.attr('class', 'showRow');
    else {
        _row.attr('class', 'hide');
        _requestAjax = false;
    }

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
                    addDataInit(i, response);
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

function addDataInit(index, data) {
    var _data = (typeof data === 'undefined' || data === null) ? [] : data;
    if (_data.length !== 0) $("#rowtable_" + index + " tbody").empty();

    for (var i = 0; i < _data.length; i++) {
        var _elementTR = $("<tr>");
        _elementTR.attr('id', 'row_' + this.count);

        // DNI
        var _elementTDOne = $("<td>");
        _elementTDOne.html(_data[i]['dni']);
        _elementTR.append(_elementTDOne);

        // Nombre
        var _elementTDTwo = $("<td>");
        _elementTDTwo.html(_data[i]['nombre']);
        _elementTR.append(_elementTDTwo);

        // Telefono
        var _elementTDThree = $("<td>");
        _elementTDThree.html(_data[i]['telefono']);
        _elementTR.append(_elementTDThree);

        // Llamar
        var _elementTDFour = $("<td>");
        _elementTDFour.html(_data[i]['llamar_asegurado']);
        _elementTR.append(_elementTDFour);

        var _elementTDFive = $("<td>");
        _elementTDFive.html(_data[i]['fecha_hora']);
        _elementTR.append(_elementTDFive);

        $("#rowtable_" + index + " tbody").append(_elementTR);
    }
}