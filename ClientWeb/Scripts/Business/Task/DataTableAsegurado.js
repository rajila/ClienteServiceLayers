var DataTableAsegurado = {
    count: 0,
    countRow: 0,
    messageElement: '<tr><td valign="top" colspan="10" class="dataTables_empty">No existe información para presentar</td></tr>',
    idTabla: 'defaultTable',
    idAdd: 'defaultAdd',
    idDelete: 'defaultEdit',
    elementsTable: [],

    init: function (idTabla, idAdd, idDelete, elementsTable) {
        self = this;
        this.idTabla = (typeof idTabla === 'undefined' && idTabla === '') ? 'defaultTable' : idTabla;
        this.idAdd = (typeof idAdd === 'undefined' && idAdd === '') ? 'defaultTable' : idAdd;
        this.idDelete = (typeof idDelete === 'undefined' && idDelete === '') ? 'defaultTable' : idDelete;
        this.elementsTable = (typeof elementsTable === 'undefined') ? [] : elementsTable;

        $("#" + this.idAdd).click(function () {
            self.addRow();
        });
    },

    addRow: function () {
        if (this.elementsTable.length === 0) return;
        if (this.countRow === 0) $("#" + this.idTabla + " tbody").empty();
        var _elementTR = $("<tr>");
        _elementTR.attr('id', 'row_' + this.count);
        for (var _element in this.elementsTable)
        {
            var _elementTD = $("<td>");
            if (this.elementsTable[_element] === 'llamarDATA') {
                //var _elementINPUT = $("<select><option value=''>Seleccionar</option><option value='SI'>SI</option ><option value='NO'>NO</option></select>");
                //_elementINPUT.attr('class', 'form-control');
                var _elementINPUT = $("<input readonly>");
                _elementINPUT.attr('type', 'text');
                _elementINPUT.attr('class', 'form-control text-box single-line');
                _elementINPUT.attr('value','SI');
            } else if (this.elementsTable[_element] === 'telefonoDATA') {
                var _elementINPUT = $("<input>");
                _elementINPUT.attr('type', 'number');
                _elementINPUT.attr('class', 'form-control text-box single-line');
            } else if (this.elementsTable[_element] === 'fechaDATA') {
                var _elementINPUT = $("<input>");
                _elementINPUT.attr('type', 'text');
                _elementINPUT.attr('autocomplete', 'off');
                _elementINPUT.attr('class', 'form-control text-box single-line');
                _elementINPUT.datetimepicker({language: "es",formatTime: 'H:i',formatDate: 'd/m/Y',format: 'd/m/Y H:i'});
            } else {
                var _elementINPUT = $("<input>");
                _elementINPUT.attr('type', 'text');
                _elementINPUT.attr('class', 'form-control');
            }

            _elementINPUT.attr('name', this.elementsTable[_element] + '_' + this.count);
            _elementINPUT.attr('id', this.elementsTable[_element] + '_' + this.count);
            
            _elementTD.append(_elementINPUT);
            _elementTR.append(_elementTD);
        }
        var _links = $("<td style='text-align:center'>");
        var _elementA = $("<a>");
        _elementA.attr('id', 'delete_' + this.count);
        _elementA.attr("numRow", this.count);
        _elementA.attr("class", "glyphicon glyphicon-trash");
        _elementA.attr("title", "Eliminar");
        _elementA.click(function () {
            self.deleteRow(this);
        });
        _links.append(_elementA);
        _elementTR.append(_links);
        $("#" + this.idTabla + " tbody").append(_elementTR);
        this.count++;
        this.countRow++;
    },

    deleteRow: function (e) {
        $("#row_" + $(e).attr('numRow')).remove();
        if (--this.countRow === 0) $("#" + this.idTabla + " tbody").append($(this.messageElement));
    }
}