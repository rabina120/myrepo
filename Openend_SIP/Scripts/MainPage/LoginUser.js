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
var LoginViewModel = function () {
    var self = this;
    //DP
    self.Depo = ko.observable();
    self.DPName = ko.observable();
    self.SelectedDp = ko.observable();
    self.DP_Id_Cds = ko.observable();
    self.Boid_No = ko.observable();

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
    self.NewPass = ko.observable();
    self.ReNewPass = ko.observable();


    self.Validation = function () {


        var errMsg = "";
        var objFocus = null;

        if (Validate.empty(self.UserName())) {
            errMsg += "Please Enter Username !!!<br>";
        }
        if (Validate.empty(self.Password())) {
            errMsg += "Please Enter Password !!!<br>";
        }

        if (errMsg !== "") {

            msg(errMsg, "ALERT");

            return false;
        }
        else {
            return true;
        }

    }
    self.LoginUser = function () {
        if (self.Validation()) {
            openloader();
            var args = {
                UserName: self.UserName(),
                Password: self.Password(),
                Email: self.UserName()

            };
            store(self.UserName(), self.Password());
            var url = "/Handler/Security/LoginHandler.ashx";
            var data = { 'method': 'LoginUser', 'args': JSON.stringify(ko.toJS((args))) };
            $.post(url, data,
                function (data) {
                    var result = jQuery.parseJSON(data);
                    closeloader();
                    if (result.IsSucess) {
                        if (result.ResponseData.Counter == "0") {
                            Confirm('Please change your password !!!', 'Confirmation Dialog', function (r) {
                                if (r) {
                                    window.location = "/Modules/MainPage/ChangePassword.aspx";
                                }
                            })
                        }
                        else {
                            window.location = "/Modules/DashBoard.aspx";

                        }
                    }
                    else {

                        msg(result.Message, "WARNING");
                    }
                   

                });
//            $.ajax({
//                dataType: "json",
//                type:'post',
//                cache: false,
//                url: '/Handler/Security/LoginHandler.ashx',
//                data: { 'method': 'LoginUser', 'args': JSON.stringify(ko.toJS((args))) },
//                contentType: "application/json; charset=utf-8",
//                success: function (result) {
//                    closeloader();
//                    if (result.IsSucess) {
//                        if (result.ResponseData.Counter == "0") {
//                            Confirm('Please change your password !!!', 'Confirmation Dialog', function (r) {
//                                if (r) {
//                                    window.location = "/Modules/MainPage/ChangePassword.aspx";
//                                }
//                            })
//                        }
//                        else {
//                            window.location = "/Modules/DashBoard.aspx";

//                        }
//                    }
//                    else {
//                        msg(result.Message, "WARNING");
//                    }
//                },
//                error: function (error) {
//                    msg(error.Message, "ERROR");
//                    closeloader();
//                }
//            });
        }
    };
    self.Reset = function () {
        self.UserName(null);
        self.Password(null);
        $('#txtPassword').val('');
        $('#txtUsername').val('');
    }

}

$(document).ready(function () {
    ValidatePage();
    ko.applyBindings(new LoginViewModel());
});
