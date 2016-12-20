var ScannerViewModel = function (i) {
    var self = this;

    self.titleLabel = ko.observable("");
    self.jobId = ko.observable("").extend({
        required: {
            params: true,
            message: "Enter Job ID"
        }
    });
    self.error = ko.observable("");
    self.scanCode = ko.observable("");
    self.codes = ko.observableArray();

    self.onJobIdEntered = function () {
        var errors = ko.validation.group(self.jobId, { deep: true });
        if (errors().length > 0) {
            self.error(errors());
        } else {
            self.error("");
            self.titleLabel("Job: " + self.jobId());
            $("#job-id-container").hide();
            $("#scan-container").show();
            $("#scan-code").focus();
            $("#job-id").off("focusout");
            self.initFocusScan();
        }
    };

    self.Init = function () {
        ko.mapping.fromJS(
            {
                titleLabel: "Scan",
                jobId: "",
                scanCode: "",
                error: "",
                codes: []
            }
            , {}, self);
        $("#job-id").off("focusout");
        $("#job-id").focus();
        self.initFocusJob();
        ko.validation.init({ decorateInputElement: true, insertMessages: false });
        ko.applyBindingsWithValidation(self, $("#job-container")[0]);
    };

    $("#job-id").keyup(function (event) {
        if (event.keyCode == 13) {
            self.onJobIdEntered();
        }
    });

    $("#scan-code").keyup(function (event) {
        if (event.keyCode == 13) {
            if (self.scanCode().length > 0) {
                self.codes.push({
                    value: self.scanCode(),
                    removeCode: function (item) {
                        self.codes.remove(item);
                    }
                });
                self.scanCode("");
            };
        }
    });

    self.initFocusJob = function () {
        $("#job-id").focusout(function () {
            $("#job-id").focus();
        });
    };

    self.initFocusScan = function () {
        $("#scan-code").focusout(function () {
            $("#scan-code").focus();
        });
    };

    self.generateReport = function () {
        var rows = getRowsForReport();
        if (rows.length > 0) {
            var date = (new Date()).toLocaleDateString();
            var title = date + "Job" + self.jobId();
            saveReport(rows, title);
            reInitValues();
        }
    };

    function reInitValues() {
        $("#scan-code").off("focusout");
        $("#scan-container").hide();
        $("#job-id-container").show();
        self.codes([]);
        self.jobId("");
        self.error("");
        self.titleLabel("Scan");
        self.scanCode("");
        $("#job-id").off("focusout");
        $("#job-id").focus();
        self.initFocusJob();
    };

    function saveReport(rows, title) {
        var workbook = new kendo.ooxml.Workbook({
            sheets: [
                {
                    columns: [
                        { autoWidth: true },
                        { autoWidth: true }
                    ],
                    title: title,
                    rows: rows
                }
            ]
        });
        debugger;
        kendo.saveAs({
            dataURI: workbook.toDataURL(),
            fileName: title + ".xlsx",
            proxyURL: "@Url.Action('Save', 'Scanner')"
        });
        //var a = document.createElement('a');
        //a.download = title + ".xlsx";
        //a.href = workbook.toDataURL();
        //if (/MSIE 10/i.test(navigator.userAgent) || /MSIE 9/i.test(navigator.userAgent)
        //            || /rv:11.0/i.test(navigator.userAgent) || /Edge\/12./i.test(navigator.userAgent)) {
        //    var blob = window.dataURLtoBlob && window.dataURLtoBlob(workbook.toDataURL());
        //    saveAs(blob, title + ".xlsx");
        //} else {
        //    $("#save").html(a);
        //    a.click();
        //}
    };

    function getRowsForReport() {
        var rows = [];
        if (self.codes().length !== 0) {
            $.each(self.codes(), function (index, val) {
                var scanData = val.value;
                var row1 = { cells: [] };
                var row2 = { cells: [] };
                var i = 1;
                row1.cells.push({ value: "scan" });
                row2.cells.push({ value: scanData });
                while (scanData !== "") {
                    if (scanData.indexOf("(")!==-1) {
                        var chapter = scanData.substring(scanData.indexOf("(") + 1,
                            scanData.indexOf(")"));
                        var scanData2 = scanData.substring(scanData.indexOf(")") + 1,
                            scanData.length);
                        var length = scanData2.indexOf("(") !== -1
                            ? scanData2.indexOf("(")
                            : scanData2.length;
                        var value_ = scanData2.substring(0, length);
                        row1.cells.push({ value: chapter });
                        row2.cells.push({ value: value_ });
                        scanData = scanData2.includes("(")
                            ? scanData2.substring(scanData2.indexOf("("))
                            : "";
                        i++;
                    } else {
                        break;
                    }
                }
                rows.push(row1);
                rows.push(row2);
            });
        }
        return rows;
    };
};

var viewModel;
$(function () {
    viewModel = new ScannerViewModel();
    viewModel.Init();
});