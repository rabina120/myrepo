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

function Role(data) {
    var self = this;
    if (data != undefined) {
        self.RoleId = ko.observable(data.RoleId);
        self.RoleName = ko.observable(data.RoleName);
        self.Menu = ko.observable(data.Menu);
        self.IsActive = ko.observable(data.IsActive);
    }
}

var ChangePasswordViewModel = function () {
    var self = this;

    //For User
    self.UserId = ko.observable();
    self.UserName = ko.observable();
    self.Password = ko.observable();
    self.RoleId = ko.observable();
    self.UserType = ko.observable();
    self.IsActive = ko.observable(true);
    self.LockUnlock = ko.observable(false);
    self.CreatedDate = ko.observable();
    self.CreatedBy = ko.observable();
    self.ExpiryDate = ko.observable();
    self.Remarks = ko.observable();
    //For Role
    self.RoleId = ko.observable();
    self.RoleName = ko.observable();
    self.Menu = ko.observable();
    self.IsActive = ko.observable();
    self.Roles = ko.observable();
    self.SelectedRole = ko.observable();
    //others
    self.OldPass = ko.observable();
    self.ReNewPass = ko.observable();
    self.validatePassword = function () { }

    self.Validation = function () {


        var errMsg = "";
        var objFocus = null;

        if (Validate.empty(self.UserName())) {
            errMsg += "Please Enter Username !!!<br>";
        }
        if (Validate.empty(self.Password())) {
            errMsg += "Please Enter New Password !!!<br>";
        }
        else {
            value = ko.toJS(self.Password())
            var pattern = new RegExp(/^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$/gm);
            if (!pattern.test(value)) {
                errMsg += "Password must Match Our Policy !!!<br>";
                // document.getElementById("passwordPolicy").innerHTML = "Password Must Contain at least eight characters, at least one number and both lower and uppercase letters and special characters`@#$`";
            }

        }
        if (Validate.empty(self.OldPass())) {
            errMsg += "Please Enter Old Password !!!<br>";
        }
        if (Validate.empty(self.ReNewPass())) {
            errMsg += "Please Retype Password !!!<br>";
        }
        if (self.ReNewPass() != self.Password()) {
            errMsg += "Please Match New Password and Retype Password !!!<br>";
        }
        if (errMsg !== "") {

            msg(errMsg, "ALERT");

            return false;
        }
        else {
            return true;
        }

    }

    self.ChangePassword = function () {
        if (self.Validation()) {
            openloader();

            var url = "/Handler/Security/UserHandler.ashx";
            var data = { 'method': 'CheckAndChangePass', 'UserName': self.UserName(), 'OldPass': self.OldPass(), 'NewPass': self.Password() }
            $.post(url, data,
                function (result) {
                    var data = jQuery.parseJSON(result);
                    if (data.IsSucess) {
                        closeloader();
                        ClearSession();
                        msg(data.Message, "ALERT");
                        window.location = "/Modules/MainPage/Login.aspx";
                        self.ClearControls();
                    }
                    else {
                        closeloader();
                        msg(data.Message, "ALERT");
                    }
                });
        }
    }
    self.ClearControls = function () {
        self.Username('');
        self.OldPass('');
        self.Password('');
        self.ReNewPass('');
    }

}

$(document).ready(function () {
    ValidateSession();
    ko.applyBindings(new ChangePasswordViewModel());
});