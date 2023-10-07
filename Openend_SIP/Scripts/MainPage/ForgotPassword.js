function User(data) {
    var self = this;
    if (data != undefined) {
        self.l_company_id = ko.observable(data.l_company_id);
        self.scheme_code = ko.observable(data.scheme_code);
        self.UserId = ko.observable(data.UserId);
        self.UserName = ko.observable(data.UserName);
        self.Password = ko.observable(data.Password);
        self.BOID = ko.observable(data.BOID);
        self.DOB = ko.observable(data.DOB);
        self.Email = ko.observable(data.Email);
        self.Name = ko.observable(data.Name);
        self.Contact_No = ko.observable(data.Contact_No);
        self.UploadFile = ko.observable(data.UploadFile);
        self.Signature1 = ko.observable(data.Signature1);
        self.CreatedDate = ko.observable(data.CreatedDate);
        self.activationcode = ko.observable(data.activationcode);
        self.ActiveStatus = ko.observable(data.ActiveStatus);
        self.AppStatus = ko.observable(data.AppStatus);
        self.IsApproved = ko.observable(data.IsApproved);
        self.AppStatus = ko.observable(data.AppStatus);
        self.ApprovedBy = ko.observable(data.ApprovedBy);
        self.ApprovedDate = ko.observable(data.ApprovedDate);
        self.Counter = ko.observable(data.Counter);
    }
}

function DPCharge(data) {
    var self = this;
    if (data != undefined) {
        self.Depo = ko.observable(data.Depo);
        self.DPName = ko.observable(data.DPName);
        self.DP_Id_Cds = ko.observable(data.DP_Id_Cds);


    }
}

var ForgotPasswordViewModel = function () {
    var self = this;
    //DP
    self.Depo = ko.observable();
    self.DPName = ko.observable();
    self.SelectedDp = ko.observable();
    self.DP_Id_Cds = ko.observable();
    self.Boid_No = ko.observable();

    self.UserId = ko.observable();
    self.Name = ko.observable();
    self.Email = ko.observable();
    self.DOB = ko.observable();
    self.UserName = ko.observable();
    self.Password = ko.observable();
    self.Contact_No = ko.observable();
    self.Name = ko.observable();
    self.Signature1 = ko.observable();
    self.SignName = ko.observable();
    self.UploadFile = ko.observable();
    self.FileName = ko.observable();
    self.Bo_Account_No = ko.observable();
    self.IS_UNIT_HOLDER = ko.observable();
    self.P_Mobile_no = ko.observable();
    self.Gender = ko.observable();
    var username = $("#username").text(); // logged in user 
    var ccode = '1000' // Distribution center id
    var scheme_code = '001'; /// company id 
    var date = $("#date").text();
    var UserId = $('#UserId').text();
    var l_company_id = '001';
    self.P_Tel_No = ko.observable();
    self.OldPass = ko.observable();
    self.ReNewPass = ko.observable();
    self.Reg_email_address = ko.observable();
    const lockModal = $("#lock-modal");
    const loadingCircle = $("#loading-circle");


    self.LoadDp = function () {

        var url = "/Handler/RequestHandling/PurchaseRequestHandler.ashx";
        var data = { 'method': 'GetDPInfo' };
        $.post(url, data,
        function (result) {

            var obj = jQuery.parseJSON(result);
            var mappedTasks = $.map(obj.ResponseData, function (item) {
                return new DPCharge(item)
            });

            self.Depo(mappedTasks);

        });

    }
    self.LoadDp();


    self.GenerateRandomPassword = function () {
        //  #region To Create Random Characters for Agreement
        var len = 8;
        var code = "";
        var charset = "abcdefghijklmnopqrstuvwxyz0123456789";

        for (var i = 0; i < len; i++)
            code += charset.charAt(Math.floor(Math.random() * charset.length));

        self.Password(code);

        //#endregion of Agreement code generation
    }
    self.Validation = function () {
        var errMsg = "";
        var objFocus = null;
        if (Validate.empty(self.SelectedDp())) {
            errMsg += "Please Select DP !!!<br>";
        }
        if (Validate.empty(self.Boid_No())) {
            errMsg += "Please Enter BOID !!!<br>";
        }
        else if (self.Boid_No().length < 8) {
            errMsg += "Please Enter 8 Digit BOID !!!<br>";
        }
        if (Validate.empty(self.UserName())) {
            errMsg += "Please Enter Username !!!<br>";
        }
        if (Validate.empty(self.Email())) {
            errMsg += "Please Enter Email !!!<br>";
        }

        if (errMsg !== "") {

            msg(errMsg, "ALERT");

            return false;
        }
        else {
            return true;
        }

    }
    self.SendEmail = function () {

        if (self.Validation()) {
            openloader();
            var boid = ko.toJS(self.SelectedDp().DP_Id_Cds()) + ko.toJS(self.Boid_No);
            var url= '/Handler/Security/EmailHandler.ashx';
            var  data= { 'method': 'SendMail', 'BOID': ko.toJS(boid), 'Username': self.UserName(), 'Email': self.Email()}
            $.post(url, data,
                function (result) {
                closeloader();
                    var data = jQuery.parseJSON(result);
                   if (data.IsSucess) {
                        $('#txEmail').val('');
                        $('#txtUsername').val('');
                        $('#txtboid').val('');
                        self.SelectedDp(null)
                        self.Boid_No(null)
                        Confirm('Message has been sent to your email address.Do you want to go LoginPage?', 'Confirmation Dialog', function (r) {
                            if (r) {
                                window.location = "/Modules/MainPage/Login.aspx";
                                
                            }

                        });
                    }
                    else {

                        msg(data.Message, "WARNING");
                    }
                });


//            $.ajax({
//                dataType: "json",
//                url: '/Handler/Security/EmailHandler.ashx',
//                data: { 'method': 'SendMail', 'BOID': ko.toJS(boid), 'Username': self.UserName(), 'Email': self.Email()},
//                contentType: "application/json; charset=utf-8",
//                success: function (data) {
//                    closeloader();
//                    if (data.IsSucess) {
//                        $('#txEmail').val('');
//                        $('#txtUsername').val('');
//                        $('#txtboid').val('');
//                        self.SelectedDp(null)
//                        self.Boid_No(null)
//                        Confirm('Message has been sent to your email address.Do you want to go LoginPage?', 'Confirmation Dialog', function (r) {
//                            if (r) {
//                                window.location = "/Modules/MainPage/Login.aspx";
//                                
//                            }

//                        });
//                    }
//                    else {

//                        msg(data.Message, "WARNING");
//                    }
//                },
//                error: function (err) {
//                    closeloader();
//                    msg(err.status + " - " + err.statusText, "FAILURE");
//                }
//            });
        }
    }
    self.Reset = function () {

        self.Email(null);
        self.UserName(null);
        $('#txEmail').val('');
        $('#txtUsername').val('');
        $('#txtboid').val('');
        self.SelectedDp(null)
        self.Boid_No(null)
    }
    self.Back = function () {
        window.location = "/Modules/MainPage/Login.aspx";
    }
}
$(document).ready(function () {
    ValidatePage();
    ko.applyBindings(new ForgotPasswordViewModel());
    $("#dp").select2({

    });
});