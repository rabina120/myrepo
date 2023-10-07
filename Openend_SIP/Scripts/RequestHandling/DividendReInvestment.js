function DPCharge(data) {
    var self = this;
    if (data != undefined) {
        self.Depo = ko.observable(data.Depo);
        self.DPName = ko.observable(data.DPName);
        self.DP_Id_Cds = ko.observable(data.DP_Id_Cds);
    }
}

function Bank(data) {
    var self = this;
    if (data != undefined) {
        self.bankcode = ko.observable(data.bankcode);
        self.bankname = ko.observable(data.bankname);
    }
}

function ParaComp(data) {
    var self = this;
    if (data != undefined) {
        self.scheme_code = ko.observable(data.scheme_code);
        self.SchemeEnName = ko.observable(data.SchemeEnName);
        self.PerShVal = ko.observable(data.PerShVal);
        self.MaxKitta = ko.observable(data.MaxKitta);
        self.minkitta = ko.observable(data.Minkitta);
    }
}

var DividendReInvestmentVM = function() {
    var self = this;
    var username = $("#username").text(); // logged in user
    var ccode = "1000"; // Distribution center id
    var scheme_code = "001"; /// company id
    var date = $("#date").text();
    var l_company_id = "001";
    var BOID = $("#BOID").text();
    var Contact_No = $("#Contact_No").text();
    var ProductIdentity = BOID.toString();
    var Contact_No2 = $("#Contact_No2").text();
    //DP
    self.Depo = ko.observable();
    self.DPName = ko.observable();
    self.SelectedDp = ko.observable();
    self.DP_Id_Cds = ko.observable();
    self.Boid_No = ko.observable();
    //Scheme
    self.scheme_code = ko.observable();
    self.SchemeEnName = ko.observable();
    self.SelectedScheme = ko.observable();
    self.Schemes = ko.observableArray();
    self.Email = ko.observable();

    self.UserName = ko.observable();
    self.Password = ko.observable();
    self.Contact_No = ko.observable();
    self.Name = ko.observable();

    self.Gender = ko.observable();
    //bank branch

    self.branch_code = ko.observable();
    self.branch_address = ko.observable();
    self.telno = ko.observable();
    self.SelectedBranch = ko.observable();
    self.Branches = ko.observableArray([]);

    // bank

    self.Bank_Account_No = ko.observable();
    self.scheme_code = ko.observable();
    self.ccode = ko.observable();
    self.REQUEST_NO = ko.observable();
    self.ShHolderNo = ko.observable();
    self.Name = ko.observable();
    self.FName = ko.observable();
    self.LName = ko.observable();
    self.MName = ko.observable();
    self.P_Mobile_no = ko.observable();
    self.P_TelNo = ko.observable();

    self.P_Tel_No = ko.observable();
    self.Email_ID = ko.observable();

    self.face_val = ko.observable();
    self.HasDrep = ko.observable();
    var SHHOLDERNO = $("#SHHOLDERNO").text();
    //Charges

    self.Bo_Account_No = ko.observable();
    self.minkitta = ko.observable();
    self.MaxKitta = ko.observable();

    self.Is_SIP = ko.observable();
    self.ShHolderNo = ko.observable();
    self.MName = ko.observable();
    self.LName = ko.observable();

    self.IsEnroll = ko.observable();
    self.CancelEnroll = ko.observable();
    self.IsPosted = ko.observable();

    self.datetime = ko.observable();
    self.startdate = ko.observable();
    self.Enddate = ko.observable();
    self.date = ko.observable();
    var today = new Date();
    var dd = String(today.getDate()).padStart(2, "0");
    var mm = String(today.getMonth() + 1).padStart(2, "0"); //January is 0!
    var yyyy = today.getFullYear();
    var datetime =
        today.getDate() +
        "-" +
        String(today.getMonth() + 1).padStart(2, "0") +
        "-" +
        today.getFullYear() +
        " " +
        today.getHours() +
        ":" +
        today.getMinutes() +
        ":" +
        today.getSeconds();
    self.datetime(datetime);
    today = yyyy + "-" + mm + "-" + dd;
    paydate = dd + "-" + mm + "-" + yyyy;
    self.date(today);

    self.LoadScheme = function() {
        $.ajax({
            dataType: "json",
            url: "/Handler/Security/LoginHandler.ashx",
            async: true,
            data: { method: "LoadSchemes", l_company_id: l_company_id, ccode: ccode },
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function(result) {
                var mappedTasks = $.map(result.ResponseData, function(item) {
                    return new ParaComp(item);
                });

                self.Schemes(mappedTasks);
                self.SelectedScheme(
                    self.Schemes().find((x) => x.scheme_code() == "001")
                );
                self.face_val(self.SelectedScheme().PerShVal());
                self.minkitta(self.SelectedScheme().minkitta());
                self.MaxKitta(self.SelectedScheme().MaxKitta());
            },
            error: function(err) {
                waitMsg.hide();
                msg(err.status + " - " + err.statusText, "FAILURE");
            },
        });
    };
    self.LoadScheme();

    self.LoadDp = function() {
        var url = "/Handler/RequestHandling/PurchaseRequestHandler.ashx";
        var data = { method: "GetDPInfo" };
        $.post(url, data, function(result) {
            waitMsg.hide();
            var obj = jQuery.parseJSON(result);
            var mappedTasks = $.map(obj.ResponseData, function(item) {
                return new DPCharge(item);
            });

            self.Depo(mappedTasks);
            if ($("#BOID").text() != undefined && $("#BOID").text() != "") {
                self.Boid_No($("#BOID").text().substr(8, 16));
                var dpcode = $("#BOID").text().substr(0, 8);
                self.SelectedDp(self.Depo().find((x) => x.DP_Id_Cds() === dpcode));
                // document.getElementById("select2-dp-container").innerHTML=ko.toJS(self.SelectedDp().DPName);
            }
        });
    };
    self.LoadDp();

    self.BOIDValidation = function() {
        var errMsg = "";
        var objFocus = null;
        //#region Validating required fields

        if (Validate.empty(self.Boid_No())) {
            errMsg += "Please Enter BOID!!!<br>";
        }
        if (self.SelectedDp() == undefined) {
            errMsg += "Please Select Depository Participants!!!<br>";
        }
        if (self.Boid_No().length < 8) {
            errMsg += "Please Enter 8-digit BOID!!!<br>";
        }
        //#endregion
        if (errMsg !== "") {
            msg(errMsg, "ALERT");

            return false;
        } else {
            return true;
        }
    };

    if (self.BOIDValidation()) {
        var Bo_Account_No = self.SelectedDp().DP_Id_Cds() + self.Boid_No();
        self.Bo_Account_No(Bo_Account_No);
        var url = "/Handler/RequestHandling/ShHolderHandler.ashx";
        var data = {
            method: "GetSHolders",
            scheme_code: scheme_code,
            l_company_id: l_company_id,
            Bo_Account_No: self.Bo_Account_No(),
            ccode: ccode,
            SHHOLDERNO: null,
        };
        $.post(url, data, function(result) {
            var data = jQuery.parseJSON(result);
            if (data.IsSucess) {
                if (data.ResponseData.length > 0) {
                    var SHolder = data.ResponseData[0];

                    self.Name(SHolder.FName + " " + SHolder.MName + " " + SHolder.LName);
                    self.MName(SHolder.MName);
                    self.LName(SHolder.LName);

                    self.P_Tel_No($("#Contact_No").text());
                    self.P_Mobile_no($("#Contact_No2").text());

                    self.ShHolderNo(SHolder.ShHolderNo);
                    self.Bank_Account_No(SHolder.Bank_Account_No);

                    if (SHolder.HasDrep == true) {
                        self.HasDrep(true);
                    } else {
                        self.HasDrep(false);
                    }


                }
            } else {
                msg("Error Occur, Please Try Later !!", "WARNING");
            }
        });
    }

    self.CheckPosted = function() {
        
        var boidToCheck = self.Bo_Account_No();
        
        var url = "/Handler/Dividend/DividendHandler.ashx";
        var data = {
            method: "CheckBoidPosted",
            Bo_Account_No: self.Bo_Account_No()
        };

        $.post(url, data, function(result) {
           var data = jQuery.parseJSON(result);
            if (data.IsSucess) {
                    var CheckBoid = data.ResponseData;


                    if (CheckBoid.Status == "POSTED") {
                        self.IsPosted("POSTED");
                    } else if (CheckBoid.Status == "UNPOSTED"){
                        self.IsPosted("UNPOSTED");
                    }
                    else{
                        self.IsPosted("null");
                    }
                    


                
            } else {
                msg("Error Occur, Please Try Later !!", "WARNING");
            }
        });
    }

    self.CheckPosted();

    //button enable disable for enrolling

    self.CheckEnroll = function() {
        if ($("#enrollDrep").prop("checked")) {
            self.IsEnroll("true");

            document.getElementById("btnEnroll").disabled = false;
        } else {
            self.IsEnroll("false");
            document.getElementById("btnEnroll").disabled = true;
        }
    };

    self.ErollDReP = function() {
        if (ko.toJS(self.IsEnroll) == "true") {
            self.RequestEnrollDrep();
        }
    };
    //button enable disable for cancellling

    self.CheckCancelEnroll = function() {
        
        if ($("#cancelDrep").prop("checked")) {
            self.CancelEnroll("true");

            document.getElementById("btnCancel").disabled = false;
        } else {
            self.CancelEnroll("false");
            document.getElementById("btnCancel").disabled = true;
        }
    };

    self.CancelDReP = function() {
        if (ko.toJS(self.CancelEnroll) == "true") {
            self.RequestCancelDrep();
        }
    };

    // function nfor enrolling
    self.RequestEnrollDrep = function() {
        var args = {
            l_company_id: l_company_id,
            scheme_code: scheme_code,
            ccode: ccode,
            ShHolderNo: self.ShHolderNo(),
            Bo_Account_No: ko.toJS(self.SelectedDp().DP_Id_Cds()) + ko.toJS(self.Boid_No),
            ENTRY_BY: "Online User",
            ENTRY_Date: today,
            TranType: "02",
            RequestType: "01",
        };

        $.ajax({
            dataType: "json",
            url: "../../Handler/Dividend/DividendHandler.ashx",
            async: true,
            data: { method: "SubmitDivRequest", args: JSON.stringify(args) },
            contentType: "application/json; charset=utf-8",

            success: function(result) {
                if (result.IsSucess) {
                    waitMsg.hide1();
                    waitMsg.hide();
                    
                    self.IsEnroll("false");
                    document.getElementById("btnEnroll").disabled = true;
                    alert("Request Sent Successfully!!!");
                    window.location = 'DividendReInvestment.aspx';
                        

                }
            },
            error: function(err) {
                waitMsg.hide1();
                waitMsg.hide();
                msg(err.status + " - " + err.statusText, "FAILURE");
                self.IsEnroll("false");
                document.getElementById("btnEnroll").disabled = true;
                window.location = 'DividendReInvestment.aspx';

            },
        });
    };

    //function for cancelling
    self.RequestCancelDrep = function() {
        var args = {
            l_company_id: l_company_id,
            scheme_code: scheme_code,
            ccode: ccode,
            ShHolderNo: self.ShHolderNo(),
            Bo_Account_No: ko.toJS(self.SelectedDp().DP_Id_Cds()) + ko.toJS(self.Boid_No),
            ENTRY_BY: "Online User",
            ENTRY_Date: today,
            TranType: "02",
            RequestType: "02",
        };

        $.ajax({
            dataType: "json",
            url: "../../Handler/Dividend/DividendHandler.ashx",
            async: true,
            data: { method: "SubmitDivRequest", args: JSON.stringify(args) },
            contentType: "application/json; charset=utf-8",

            success: function(result) {
                if (result.IsSucess) {
                    waitMsg.hide1();
                    waitMsg.hide();
                    self.CancelEnroll("false");
                    document.getElementById("btnCancel").disabled = true;
                    ("Request Sent Successfully!!!");
                            window.location = 'DividendReInvestment.aspx';
                        

                }
            },
            error: function(err) {
                waitMsg.hide1();
                waitMsg.hide();
                msg(err.status + " - " + err.statusText, "FAILURE");
                self.CancelEnroll("false");
                document.getElementById("btnCancel").disabled = true;
                window.location = 'DividendReInvestment.aspx';

            },
        });
    };
};

$(document).ready(function() {
    validLoginUser();
    ValidateSession();
    ko.applyBindings(new DividendReInvestmentVM());
    var now = new Date();
    maxDate = now.toISOString().substring(0, 10);
    $("#txtapplydt").prop("max", maxDate);
});