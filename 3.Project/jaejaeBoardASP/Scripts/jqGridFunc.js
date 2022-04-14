var rownumber = 0;

jQuery.fn.gridInit = function (common) {
    var _sortname = common.sortname != null && common.sortname != undefined ? common.sortname : "";
    var _sortorder = common.sortorder != null && common.sortorder != undefined ? common.sortorder : "asc";
    var _rowNum = common.rowNum != null && common.rowNum != undefined ? common.rowNum : 1000;
    if (common.postData != null && common.postData != undefined && common.postData.args != null && common.postData.args != undefined) {
        _rowNum = common.postData.args.pDisplayCnt != null && common.postData.args.pDisplayCnt != undefined ? common.postData.args.pDisplayCnt : 1000;
    }
    var _rowTotal = common.rowTotal != null && common.rowTotal != undefined ? common.rowTotal : _rowNum;
    var _multiselect = common.multiselect != null && common.multiselect != undefined ? common.multiselect : false;
    var _width = common.width != null && common.width != undefined ? common.width : '100%';
    var _height = common.height != null && common.height != undefined ? common.height : '400';
    var _loadonce = common.loadonce != null && common.loadonce != undefined ? common.loadonce : false;
    var _scroll = common.scroll != null && common.scroll != undefined ? common.scroll : false;
    var _editurl = common.editurl != null && common.editurl != undefined ? common.editurl : null;
    var _cellEdit = common.cellEdit != null && common.cellEdit != undefined ? common.cellEdit : false;
    var _cellurl = common.cellurl != null && common.cellurl != undefined ? common.cellurl : null;
    var _cellsubmit = common.cellsubmit != null && common.cellsubmit != undefined ? common.cellsubmit : 'remote';
    var _pager = common.pager != null && common.pager != undefined ? common.pager : null;
    var _grouping = common.grouping != null && common.grouping != undefined ? common.grouping : null;
    var _groupingView = common.groupingView != null && common.groupingView != undefined ? common.groupingView : null;
    var _sortable = common.sortable != null && common.sortable != undefined ? common.sortable : _loadonce;
    var _datatype = common.datatype != null && common.datatype != undefined ? common.datatype : 'json';
    var _title = common.title != null && common.title != undefined ? common.title : false;
    var _shrinkToFit = common.shrinkToFit != null && common.shrinkToFit != undefined ? common.shrinkToFit : false;
    var _rownumbers = common.rownumbers != null && common.rownumbers != undefined ? common.rownumbers : true;
    var _autowidth = common.autowidth != null && common.autowidth != undefined ? common.autowidth : true;
    var _reload = common.reload != null && common.reload != undefined ? common.reload : true;
    var _async = common.async != null && common.async != undefined ? common.async : true;
    var _cache = common.cache != null && common.cache != undefined ? common.cache : false;
    var _subGrid = common.subGrid != null && common.subGrid != undefined ? common.subGrid : false;
    var _subGridOptions = common.subGridOptions != null && common.subGridOptions != undefined ? common.subGridOptions : null;
    var _multikey = common.multikey != null && common.multikey != undefined ? common.multikey : null;
    var _multiboxonly = common.multiboxonly != null && common.multiboxonly != undefined ? common.multiboxonly : false;

    var _grid = $(this);

    var pager = jQuery('<div/>');
    pager.attr('id', 'pager' + rownumber);
    $(this).after(pager);

    if (_pager == null) { _pager = '#pager' + rownumber; }

    this.jqGrid({
        url: common.url,
        postData: common.postData,
        mtype: 'POST',
        datatype: _datatype,
        width: _width,
        autowidth: _autowidth,
        shrinkToFit: _shrinkToFit,
        rownumWidth: 20,
        height: _height,
        colModel: common.colModel,
        scroll: _scroll,
        cmTemplate: { title: _title, sortable: _sortable },
        rowNum: _rowNum,
        async: _async,
        cache: _cache,
        pager: _pager,
        toolbar: false,
        viewrecords: true,
        gridview: true,
        grouping: _grouping,
        groupingView: _groupingView,
        sortname: _sortname,
        sortorder: _sortorder,
        scrollrows: false, /** 스크롤 위치 내용 표시 **/
        multiSort: false,
        rownumbers: _rownumbers,
        editurl: _editurl,
        cellEdit: _cellEdit,
        cellsubmit: _cellsubmit,
        cellurl: _cellurl,
        loadonce: _loadonce,
        subGrid: _subGrid,
        subGridOptions: _subGridOptions,
        multiselect: _multiselect,
        multiboxonly: _multiboxonly,
        multikey: _multikey,
        emptyrecords: "<span style='align:center'>조회된 결과가 없습니다.</span>",
        loadtext: '조회중입니다. 잠시만 기다려주세요.',
        loadError: function (xhr, status, error) {
            //alert('jqgrid:' + xhr.responseText);
        },
        onSortCol: function (index, idxcol, sortorder) {
            // 고정 사용 시
            //this.jqGrid('destroyFrozenColumns');
            var $icons = $(this.grid.headers[idxcol].el).find(">div.ui-jqgrid-sortable>span.s-ico");
            if (this.p.sortorder === "asc") {
                $icons.find(">span.ui-icon-asc")[0].style.display = "";
                $icons.find(">span.ui-icon-asc")[0].style.marginTop = "1px";
                $icons.find(">span.ui-icon-desc").hide();
            } else {
                $icons.find(">span.ui-icon-desc")[0].style.display = "";
                $icons.find(">span.ui-icon-asc").hide();
            }
        },
        loadComplete: common.loadComplete,
        gridComplete: common.gridComplete,
        ondblClickRow: common.ondblClickRow,
        onCellSelect: common.onCellSelect,
        onSelectRow: common.onSelectRow,
        subGridRowExpanded: common.subGridRowExpanded,
        afterInsertRow: common.afterInsertRow,
        afterEditCell: common.afterEditCell,
        beforeSubmitCell: common.beforeSubmitCell,
        afterSaveCell: common.afterSaveCell,
        afterSubmitCell: common.afterSubmitCell,
        onRightClickRow: common.onRightClickRow,
        beforeSubmit: common.beforeSubmit,
        onSelectCell: common.onSelectCell,
        onSelectAll: common.onSelectAll,
        beforeSelectRow: common.beforeSelectRow,
        error: function (xhr, status, error) {
            //alert('jqgrid:' + error);
        }
    });

    if (this.attr('summary') != null && this.attr('summary') != undefined && this.find("caption").length == 0) {
        this.append("<caption>" + this.attr('summary') + "</caption>");
        this.closest(".ui-jqgrid-view").find("div.ui-jqgrid-hdiv table").append("<caption>" + this.attr('summary') + "</caption>");
    }
    rownumber++;
}

function attrSetting(rowId, val, rawObject, cm) {
    var attr = rawObject.attr[cm.name], result;
    if (attr.rowspan) {
        result = ' rowspan=' + '"' + attr.rowspan + '"';
    } else if (attr.display) {
        result = ' class="display' + attr.display + '"';
    }
    return result;
}

function gf_GridRowMerger(gridName, CellName, viewRow) {
    var strBorderColor = "#aaaaaa";
    var strColor = "#222222";
    var strBorderBlurColor = "#f8f8f8";
    var strBlurColor = "#f8f8f8";
    var mya = $("#" + gridName + "").getDataIDs();
    var length = mya.length;
    var i;
    var rowSpanTaxCount = 0;
    for (i = 0; i < length; i++) {
        var before = $("#" + gridName + "").jqGrid('getRowData', mya[i]);
        var rowSpanTaxCount = 1;
        for (j = i + 1; j <= length; j++) {
            var end = $("#" + gridName + "").jqGrid('getRowData', mya[j]);
            if (before[CellName] == end[CellName]) {
                if (viewRow) {
                    if (rowSpanTaxCount == 1) {
                        $("#" + gridName + "").setCell(mya[j - 1], CellName, '', { 'color': strColor });
                    }
                }
                rowSpanTaxCount++;
                if (viewRow) {
                    $("#" + gridName + "").setCell(mya[j], CellName, '', {
                        'border-bottom': '1px solid ' + strBorderBlurColor,
                        color: strBlurColor
                    });
                }
                else {
                    $("#" + gridName + "").setCell(mya[j], CellName, '', {
                        display: 'none'
                    });
                }
            } else {
                if (viewRow) {
                    if (rowSpanTaxCount > 1) {
                        $("#" + gridName + "").setCell(mya[i], CellName, '', { 'border-bottom': '1px solid ' + strBorderBlurColor });
                    }
                    $("#" + gridName + "").setCell(mya[j - 1], CellName, '', { 'border-bottom': '1px solid ' + strBorderColor });
                }
                else {
                    $("#" + gridName + "").setCell(mya[i], CellName, '', { 'vertical-align': 'text-top' }, { rowspan: rowSpanTaxCount });
                }
                if (i == length - 1) {
                    if (viewRow) {
                        if (rowSpanTaxCount == 1) {
                            $("#" + gridName + "").setCell(mya[j - 1], CellName, '', { 'color': strColor });
                        }
                    }
                }

                if (viewRow) {
                    if (rowSpanTaxCount == 1) {
                        $("#" + gridName + "").setCell(mya[j - 1], CellName, '', { 'color': strColor });
                    }
                }

                rowSpanTaxCount = 1;
                i = j - 1;
                break;
            }
        }
        if (i == length - 1) {
            if (!viewRow) {
                $("#" + gridName + "").setCell(mya[i], CellName, '', { 'vertical-align': 'text-top' }, { rowspan: rowSpanTaxCount });
            }
        }
    }
}