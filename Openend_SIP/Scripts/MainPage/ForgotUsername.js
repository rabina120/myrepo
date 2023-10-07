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
var ForgotUserNameViewModel = function () {
    var self = this;
    //DP
    self.Depo = ko.observable();
    self.DPName = ko.observable();
    self.SelectedDp = ko.observable();
    self.DP_Id_Cds = ko.observable();
    self.Boid_No = ko.observable();

    self.BOID = ko.observable();
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
//    const lockModal = $("#lock-modal");
//    const loadingCircle = $("#loading-circle");
    $("#dp").select2({
        tags: true,
        
    });

    self.ValidateEmailAddresses = function () {
        if (self.Email() != undefined) {
            $.ajax({
                dataType: "json",
                url: '/Handler/Security/EmailHandler.ashx',
                async: true,
                data: { 'method': 'validateEmailaddress', 'Email': ko.toJS(self.Email()) },
                contentType: "application/json; charset=utf-8",
                async: false,
                success: function (result) {


                    if (result.ResponseData != null && result.ResponseData.length != 0) {
                        var email = result.ResponseData[0].Email
                        var username = result.ResponseData[0].UserName
                        self.UserName(username)
                        self.Email(email)

                    }
                    else {
                        msg("Sorry the email address entered doesn't match \n with the registered email address!!!", "WARNING", "Warning", callback);
                        self.Email('');
                    }
                }
            });

            var callback = null;
            if (self.Reg_email_address() === self.Email()) {
                return true;
            }
            else {
                if (focus) {

                    callback = function () {
                        self.Email(null);
                    }
                }
                //this.focus();
            }
        }
    }
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
        if(Validate.empty(self.SelectedDp())){
            errMsg += "Please Select DP !!!<br>";
        }
        if (Validate.empty(self.Boid_No())) {
            errMsg += "Please Enter BOID !!!<br>";
        }
        else if (self.Boid_No().length < 8) {
            errMsg += "Please Enter 8 Digit BOID !!!<br>";
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
    self.CheckEmail = function () {
        if (self.Email() != undefined) {
            $.ajax({
                dataType: "json",
                url: '/Handler/Security/EmailHandler.ashx',
                async: true,
                data: { 'method': 'CheckEmail', 'Email': ko.toJS(self.Email()) },
                contentType: "application/json; charset=utf-8",
                async: false,
                success: function (result) {

                    if (!(result.IsSucess)) {
                        msg("Please Enter Valid Email Address", "FAILURE");
                        self.Email(null);
                    }
                },
                error: function (err) {
                    waitMsg.hide();
                    msg(err.status + " - " + err.statusText, "FAILURE");
                }
            });
        }
    }

    //self.SendEmail = function (username, email, boid) {
    //        $.ajax({
    //        dataType: "json",
    //        url: '/Handler/Security/EmailHandler.ashx',
    //        data: { 'method': 'SendMailForUserName', 'Username': self.UserName(), 'Email': self.Email(), 'BOID':  self.BOID() },
    //        contentType: "application/json; charset=utf-8",
    //        success: function (data) {
    //           closeloader();
    //            if (data.IsSucess) {             
    //                Confirm('Message has been sent to your email address.Do you want to go LoginPage?', 'Confirmation Dialog', function (r) {
    //                    if (r) {
    //                        window.location = "/Modules/MainPage/Login.aspx";
    //                        self.Reset();
    //                    }
    //                });
    //            }
    //            else {            
    //                msg("Failure!!!", "WARNING");
    //                self.Reset()
    //            }
    //        },
    //        error: function (err) {
    //            closeloader();         
    //            msg(err.status + " - " + err.statusText, "FAILURE");
    //            self.Reset()
    //        }
    //    });
    //}

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
   

self.GetUsername = function () {

        if (self.Validation()) {
           openloader();
           var boid = ko.toJS(self.SelectedDp().DP_Id_Cds()) + ko.toJS(self.Boid_No)
            var url = "/Handler/Security/EmailHandler.ashx";
            var data = { 'method': 'SendMailForUserName', 'Email': ko.toJS(self.Email()), 'BOID': boid };
                $.post(url, data,
                function (result1) {
                    closeloader();
                    var result = jQuery.parseJSON(result1);
                   if (result.ResponseData != null && result.ResponseData.length != 0) {
                        msg("User Name Send To your Mail");
                    }
                    else {
                        msg(result.Message == null ?
                            "Sorry the Details entered doesn't match \n with the registered  Details!!!":
                            result.Message, "WARNING", "Warning", callback);
                        self.Reset()

                    }
                });

         
            var callback = null;
            if (self.Reg_email_address() === self.Email()) {
                return true;
            }
            else {
                if (focus) {

                    callback = function () {
                        self.Email(null);
                    }
                }
            }
           
       }
       
      
    }


    self.Reset = function () {
        self.Boid_No(null)
        self.Email(null);
        self.UserName(null);
        $('#txEmail').val('');
        $('#txtUsername').val('');
        $('#txtboid').val('');
        self.SelectedDp(null)
    }
    self.Back = function () {
        window.location = "/Modules/MainPage/Login.aspx";
    }
}
$(document).ready(function () {
   ValidatePage();
    ko.applyBindings(new ForgotUserNameViewModel());
});