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

        self.Citizenship_No = ko.observable(data.Citizenship_No);
        self.PAN_No = ko.observable(data.PAN_No);
        self.bankname = ko.observable(data.bankname);
        self.Bank_Account_No = ko.observable(data.Bank_Account_No);
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
    var name = $("#Name").text(); // logged in user 
    // var username = $("#username").text();

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

    var username = $("#UserName").text(); // logged in user 
    var ccode = '1000' // Distribution center id
    var scheme_code = '001'; /// company id 
    var date = $("#date").text();
    var UserId = $('#UserId').text();
    var l_company_id = '001';
    var BOID = $('#BOID').text();
    var Name = $('#Name').text();
    var SHHOLDERNO = $('#SHHOLDERNO').text();
    self.DP_NAME = ko.observable();
    self.Name = ko.observable();
    self.Bo_Account_No = ko.observable();
    self.ActiveStatus = ko.observable();
    self.Gender = ko.observable();
    self.DOB = ko.observable();
    self.CreatedDate = ko.observable();
    self.Contact_No = ko.observable();
    self.Email = ko.observable();
    self.bankname = ko.observable();
    self.Bank_Account_No = ko.observable();
    self.Citizenship_No = ko.observable();
    self.PAN_No = ko.observable();
 




    self.Validation = function () {


        var errMsg = "";
        var objFocus = null;

        if (Validate.empty(self.OldPass())) {
            errMsg += "Please Enter Password !!!<br>";
        } 
        if (Validate.empty(self.Password())) {
            errMsg += "Please Enter New Password !!!<br>";
        } else {
            value = ko.toJS(self.Password())
            var pattern = new RegExp(/^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$/gm);
            if (!pattern.test(value)) {
                errMsg += "Password must Match Our Policy !!!<br>";
            }
        }
        if (Validate.empty(self.ReNewPass())) {
            errMsg += "Please Confirm New Password !!!<br>";
        }
        if (ko.toJS(self.Password()) != ko.toJS(self.ReNewPass()) || ko.toJS(self.Password()) === undefined) {
            errMsg += 'New Password and Confirm New Password must be same !!!<br>';

        }
        if (errMsg !== "") {
            self.Password('');
            self.ReNewPass('');
            self.OldPass(null)
            msg(errMsg, "ALERT");

            return false;
        }
        else {
            return true;
        }

    }

    self.CheckAndChangeOldPass = function () {
        if (self.Validation()) {
            $.ajax({
                type: "GET",
                dataType: "json",
                cache: false,
                async: true,
                url: '/Handler/Security/UserHandler.ashx',
                data: { 'method': 'CheckAndChangePass', 'UserName': username, 'OldPass': self.OldPass(), 'NewPass': self.Password() },
                contentType: "applicaton/json; character=utf -8",
                success: function (data) {

                    if (data.IsSucess) {
                        msg(data.Message, "ALERT");   
                        self.ClearControls();
                    }

                }
            });

        }
    }



    self.ClearControls = function () {
        self.OldPass('');
        self.Password('');
        self.ReNewPass('');
    }


//    self.UpdateProfile = function () {

//        Confirm("Do you want to Update Profile Detail? ", 'Confirmation Dialog', function (r) {
//            if (r) {

//                var args = {
//                    UserId: UserId,
//                    Name: self.Name(),
//                    DOB: self.DOB(),
//                    Contact_No: self.Contact_No(),
//                    Email: self.Email()
//                }

//                console.log(args);
//                var url = "/Handler/Security/UserHandler.ashx"; ;
//                var data = { 'method': 'UpdateWebUser', 'args': JSON.stringify(ko.toJS(args)) };

//                $.post(url, data, function (result) {
//                    //JSON.parse() takes a JSON string and then transforms it into a JavaScript object.
//                    var obj = jQuery.parseJSON(result);

//                    if (obj.IsSucess) {
//                        msg(" User Profile Update Sucessfully");
//                    }

//                });
//            }
//        });
//    }

}

$(document).ready(function () {
    ValidateSession();
    ko.applyBindings(new ChangePasswordViewModel());
});