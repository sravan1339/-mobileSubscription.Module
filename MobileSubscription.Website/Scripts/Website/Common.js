(function (Common, $, undefined) {

    "use strict";
    var columnNamesSelector = "#columnNames",
        filterKeywordsSelector = "#filterKeywords",
        goBtnSelector = "#goBtn",
        resetBtnSelector = "#resetBtn",
        operatorsTableSelector = "#operatorsTable";

    Common.prototype = {

        sortColumn: function () {

            var thisTable = $(this).parents("table").eq(0),
                rows = $(thisTable).find("tr:gt(1)").toArray().sort(Common.prototype.comparer($(this).index()));

            this.asc = !this.asc;

            if (!this.asc) { rows = rows.reverse(); }

            for (var i = 0; i < rows.length; i++) {

                $(thisTable).append(rows[i]);
            }
        },

        comparer: function (i) {

            return function (aVal, bVal) {

                var valA = Common.prototype.getCellText(aVal, i),
                    valB = Common.prototype.getCellText(bVal, i);

                return ($.isNumeric(valA) && $.isNumeric(valB)) ? (valB - valA) : valA.localeCompare(valB);
            };
        },

        getCellText: function (row, index) {

            return $(row).children("td").eq(index).text();
        },

        filterTable: function () {

            var filterCriteria = $(filterKeywordsSelector).val();

            if (filterCriteria != "") {

                var selectedColumn = $(columnNamesSelector).find(":selected").val(),
                    selectorStr = "tbody tr td:nth-child(" + selectedColumn + "):not(:contains('" + filterCriteria + "'))";

                $(operatorsTableSelector).find(selectorStr).parent().hide();

            } else {

                $(operatorsTableSelector).find("tbody tr").show();
            }
        },

        resetTable: function () {

            $(filterKeywordsSelector).val("");
            $(operatorsTableSelector).find("tbody tr").show();
        }
    };

}(window.Common = window.Common || {}, jQuery));

$(document).ready(function () {

    $("th.sortable").on("click", Common.prototype.sortColumn);
});