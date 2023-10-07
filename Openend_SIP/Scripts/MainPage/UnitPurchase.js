
function paymentdata(data) {
    var self = this;
    if (data != undefined) {
        self.merchantId = ko.observable(data.merchantId);
        self.appId = ko.observable(data.appId);
        self.referenceId = ko.observable(data.referenceId);
        self.txnAmt = ko.observable(data.txnAmt);
        self.token = ko.observable(data.token); 
        self.statusDesc = ko.observable(data.statusDesc);
        self.status = ko.observable(data.status); 
        self.amount = ko.observable(data.amount);
        self.idx = ko.observable(data.idx); 
        self.product_identity = ko.observable(data.product_identity);
        self.Integrationcode = ko.observable(data.Integrationcode);
        self.GatewayCode = ko.observable(data.GatewayCode);/// <reference path="UnitPurchase.js" />

        self.TranDate = ko.observable(data.TranDate);
        self.TXNID = ko.observable(data.TXNID);

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
function ChargeType(data){
    var self = this;
    if (data != undefined) {   
        self.SDescription = ko.observable(data.SDescription);
        self.SCharge_Code = ko.observable(data.SCharge_Code);
    }   
}
function bank_branch(data) {
    var self = this;
    if (data != undefined) {

        self.branch_code = ko.observable(data.branch_code);
        self.branch_address = ko.observable(data.branch_address);
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
        self.PerShVal= ko.observable(data.PerShVal);
        self.MaxKitta =ko.observable(data.MaxKitta);
        self.minkitta =ko.observable(data.Minkitta);

    }
}

function PaymentTypeList(data){
 var self = this;
    if (data != undefined) {
        self.PaymentCode = ko.observable(data.PaymentCode);
        self.PaymentMode = ko.observable(data.PaymentMode);
        self.PaymentStatus = ko.observable(data.PaymentStatus);
        self.PaymentFileName = ko.observable(data.PaymentFileName);
    }
}


var PurchaseEntryViewModel = function () {
    var self = this;
    var username = $("#username").text(); // logged in user 
    var ccode = '1000' // Distribution center id
    var scheme_code = '001'; /// company id 
    var date = $("#date").text();
    var UserId = $('#UserId').text();
    var l_company_id = '001';
     var BOID =  $('#BOID').text();

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
    self.minkitta= ko.observable();
    self.MaxKitta= ko.observable();

    //HolderDetail
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
    self.Gender= ko.observable();
     //bank branch

    self.branch_code = ko.observable();
    self.branch_address = ko.observable();
    self.telno = ko.observable();
    self.SelectedBranch = ko.observable();
    self.Branches = ko.observableArray([]);

    // bank
    self.bankcode = ko.observable();
    self.bankname = ko.observable();
    self.Banks = ko.observableArray([]);
    self.bbanks = ko.observableArray([]);
    self.SelectedBank = ko.observable();
    self.SelectedBanks = ko.observable();
    self.Bank_Account_No = ko.observable();


    self.ccode = ko.observable();
    self.REQUEST_NO = ko.observable();
    self.ShHolderNo = ko.observable();
    self.Name = ko.observable();
    self.FName = ko.observable();
    self.LName = ko.observable();
    self.MName = ko.observable();
    self.P_Mobile_no = ko.observable();
    self.P_TelNo = ko.observable();
    self.APPLY_UNIT = ko.observable();
    self.APPLY_DT = ko.observable();
    self.AMOUNT = ko.observable();
    self.P_Tel_No = ko.observable();
     self.GTotal = ko.observable();

    self.OTP  = ko.observable();
    self.ContactOTP  = ko.observable();
    self.OTPPass = ko.observable();
    self.OTPContactPass = ko.observable();
    self.OTPPassSign = ko.observable();
    self.OTPPassSignCode = ko.observable();
    self.CitizenshipNo = ko.observable()
    self.PayeeContactNo = ko.observable();
    self.payeename = ko.observable();

    self.File1 = ko.observable();
    self.File2 = ko.observable();
    self.File3 = ko.observable();

    self.ProofFileName = ko.observable();
    self.ProofFileName2 = ko.observable();
    self.ProofFileName3 = ko.observable();

    self.appno = ko.observable();
    self.remarks = ko.observable();
    self.current_nav = ko.observable();
    self.nav_date = ko.observable();
    self.entry_load = ko.observable();
    self.cal_type = ko.observable();
    self.charge_amount = ko.observable();
    self.other_charges = ko.observable();
    self.tot_with_face_value = ko.observable();
    self.tot_with_Nav_value = ko.observable();
    self.tot_reqd_amt = ko.observable();
    self.face_val = ko.observable();
    self.SEBON_Fee = ko.observable();
    //Charges
    self.ChargeTypes = ko.observableArray([]);
    self.SDescription = ko.observable();
    self.SelectedCharge = ko.observable();
    self.Flat_percent = ko.observable();
    self.rate = ko.observable();

    self.Bo_Account_No = ko.observable();
    self.BalUnit= ko.observable();
    self.Is_SIP= ko.observable();
    self.ShHolderNo= ko.observable();
    self.MName= ko.observable();
    self.LName= ko.observable();
    self.FaName= ko.observable();
    self.GFName= ko.observable();
     self.UserList  = ko.observableArray([]);
     self.Email_ID =  ko.observable();
     self.BANKCODE = ko.observable();
     self.BRANCHCODE= ko.observable();
     self.Contact_No= ko.observable();
     self.Contact_No1= ko.observable();
     self.Contact_No2= ko.observable();
     self.Contact_No3= ko.observable();
     self.Contact_No4= ko.observable();
     self.SHHOLDERNO = ko.observable();
     self.IsOnline = ko.observable();
     self.DREQUEST_NO= ko.observable();
     self.AccHolderName = ko.observable();
     self.CashAmount= ko.observable();
     self.ChequeAmount= ko.observable();
     self.cashorcheque= ko.observable();
     self.IS_UNIT_HOLDER = ko.observable();

     self.IsPosted = ko.observable();
     self.PaymentCode = ko.observable();
     self.PaymentMode = ko.observable();
     self.PaymentStatus = ko.observable();
     self.PaymentFileName = ko.observable();
     self.PaymentTypeLists = ko.observableArray([]);
     self.IsPosted= ko.observable();
    self.othersource=ko.observable();
    self.HolderType=ko.observable();
    var SHHOLDERNO = $('#SHHOLDERNO').text();
     self.Token= ko.observable();

   self.amtDetail = ko.observable();
   self.ClientName = ko.observable();

     self.Sh_File=ko.observable();
     var source;
     self.SubmitStatus= ko.observable();
     self.PayAmount= ko.observable();
     //Payment
    self.TXNID = ko.observable();
    self.idx = ko.observable();


    var PayMarchantId = $("#ContentPlaceHolder1_PayMarchantId").val();
    var PayAppIdUnitPurchase = $("#ContentPlaceHolder1_PayAppIdUnitPurchase").val();

    self.PayMarchantId=ko.observable(PayMarchantId);          
    self.PayAppId=ko.observable(PayAppIdUnitPurchase);  

    self.PayAppName=ko.observable('Unit Purchase');
    self.PayTxnDate=ko.observable();
    self.PayTxnCurency=ko.observable('NPR');
    self.PayTxnAmount=ko.observable();
    self.PayRefId=ko.observable();
    self.PayRemarks=ko.observable(" Unit Purchase");
    self.PayParticulars=ko.observable("Paid to Nibl Ace Capital");
    self.PayToken=ko.observable('TOKEN');
    self.CurrDate = ko.observable();
    var ProductIdentity ;

    //For E-Banking 
    self.BankId=ko.observable('004');                            
    self.MD = ko.observable('P');                                 
    self.CRN=ko.observable('NPR');                             
    self.CG=ko.observable('N');
    self.USER_LANG_ID=ko.observable('001');
    self.UserType=ko.observable('1');
    self.AppType=ko.observable('retail');
    self.ITC=ko.observable();                             

    var UnitPurchaseURL = $("#ContentPlaceHolder1_UnitPurchaseURL").val();
     self.TestURL = ko.observable(UnitPurchaseURL);    // To Pass URL Link of mutual fund
     self.RU =  ko.observable(self.TestURL());
 
  
    self.status = ko.observable();
    self.statusDesc = ko.observable();
    self.GatewayCode=ko.observable('001');
    self.Email_ID = ko.observable();
    self.Integrationcode = ko.observable();
    self.NavValidation=ko.observable(false);

    var resbankid = $("#ContentPlaceHolder1_resbankid").val();
    var respref = $("#ContentPlaceHolder1_respref").val();
    var resamount = $("#ContentPlaceHolder1_resamount").val();
    var resbid = $("#ContentPlaceHolder1_resbid").val();
    var rescustreftype = $("#ContentPlaceHolder1_rescustreftype").val();
    self.HasDividend = ko.observable(false);
    self.VerifyOtp = ko.observable(false);
//    self.VerifyContactNoOtp = ko.observable(false);
self.VerifyContactNoOtp = ko.observable( );



    var Khaltiref = $("#ContentPlaceHolder1_Khaltiref").val();
    var ConnectIpsiref = $("#ContentPlaceHolder1_ConnectIpsiref").val();
    var EBankingPID = $("#ContentPlaceHolder1_EBankingPID").val();
    self.PID = ko.observable(EBankingPID);  //To Pass PID
    var EBankingLoginURL = $("#ContentPlaceHolder1_EBankingLoginURL").val();
    var Esewascd = $("#ContentPlaceHolder1_Esewascd").val();
    var ESewaRef = $("#ContentPlaceHolder1_ESewaRef").val();

   

    // FOR PAYMENTTYPEELIST
    self.GetFilePathByStatusPayment = function () {
        $.ajax({
            dataType: "json",
            url: '/Handler/RequestHandling/PurchaseRequestHandler.ashx',
            async: true,
            data: { 'method': 'GetFilePathByStatusPayment' },
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                var mappedTasks = $.map(result.ResponseData, function (item) {
                    return new PaymentTypeList(item)
                });

                self.PaymentTypeLists(mappedTasks);
            },
            error: function (err) {
                waitMsg.hide();
                msg(err.status + " - " + err.statusText, "FAILURE");
            }
        });
    }
    self.GetFilePathByStatusPayment();

     self.P_Tel_No.subscribe(function(){
        self.Contact_No1(self.P_Tel_No());
        self.PayeeContactNo(self.P_Tel_No());
        });
        self.P_Mobile_no.subscribe(function(){
        self.Contact_No2(self.P_Mobile_no());
    });

    //Date 
    self.datetime =ko.observable();
    self.startdate =ko.observable();
    self.Enddate =ko.observable();
    self.date  = ko.observable();
    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = today.getFullYear();
    var datetime = today.getDate() + "-"
            + String(today.getMonth() + 1).padStart(2, '0')  + "-" 
            + today.getFullYear() + " "  
            + today.getHours() + ":"  
            + today.getMinutes() + ":" 
            + today.getSeconds();
    self.datetime(datetime);

    today = yyyy+ '-'+ mm + '-' + dd;
    paydate =dd+'-'+mm+'-'+yyyy;
    self.date(today);
    self.PayTxnDate(paydate);

    self.GetValue = function() {
    var url = '/Handler/RequestHandling/PurchaseRequestHandler.ashx';
    var data = { 'method': 'GetChargeType', 'Scheme_code':scheme_code };
    $.post(url, data,
        function (result) {
            waitMsg.hide();
            var obj = jQuery.parseJSON(result);
            var mappedTasks = $.map(obj.ResponseData, function (item) {
                return new ChargeType(item)
            });
            self.ChargeTypes(mappedTasks);
            self.SelectedCharge(self.ChargeTypes().find(x => x.SCharge_Code() == "01"));
        });
    }
 
    // self.LoadScheme = function () {
    // $.ajax({
    //            dataType: "json",
    //            url: '/Handler/Security/LoginHandler.ashx',
    //            data: { 'method': 'LoadSchemes' ,'l_company_id': l_company_id, 'ccode':ccode},
    //            contentType: "application/json; charset=utf-8",
    //            async: false,
    //            success: function (result) {
    //            var mappedTasks = $.map(result.ResponseData, function (item) {
    //            return new ParaComp(item)
    //            });
              
    //            self.Schemes(mappedTasks); 
    //            self.SelectedScheme(self.Schemes().find(x => x.scheme_code() == "001"));
    //            self.face_val(self.SelectedScheme().PerShVal());
    //            self.minkitta(self.SelectedScheme().minkitta());
    //            self.MaxKitta(self.SelectedScheme().MaxKitta());
    //            self.GetValue();
    //            },
    //            error: function (err) {
    //                waitMsg.hide();
    //                msg(err.status + " - " + err.statusText, "FAILURE");
    //            }
    //            });

    //}
    //self.LoadScheme();

    self.LoadScheme = function () {
        var url = "/Handler/Security/LoginHandler.ashx";
        var data = { 'method': 'LoadSchemes', 'l_company_id': l_company_id, 'ccode': ccode };
        $.post(url, data,
            function (result) {
                waitMsg.hide();
                var obj = jQuery.parseJSON(result);
                var mappedTasks = $.map(obj.ResponseData, function (item) {
                    return new ParaComp(item)
                });
                self.Schemes(mappedTasks);
                self.SelectedScheme(self.Schemes().find(x => x.scheme_code() == "001"));
                self.face_val(self.SelectedScheme().PerShVal());
                self.minkitta(self.SelectedScheme().minkitta());
                self.MaxKitta(self.SelectedScheme().MaxKitta());
                self.GetValue();
            });

    }
    self.LoadScheme();
   

    // FOR Depository Participants
    self.LoadDp = function () {
     $.ajax({
                dataType: "json",
                url: "/Handler/RequestHandling/PurchaseRequestHandler.ashx",
                data: { 'method': 'GetDPInfo' },
                contentType: "application/json; charset=utf-8",
                async: false,
                success: function (result) {
                var mappedTasks = $.map(result.ResponseData, function (item) {
                return new DPCharge(item)
                });
              
                self.Depo(mappedTasks); 
                },
                error: function (err) {
                    waitMsg.hide();
                    msg(err.status + " - " + err.statusText, "FAILURE");
                }
                });

    }
    self.LoadDp();

    // FOR BANK
    self.GetBank = function () {
                $.ajax({
                dataType: "json",
                url: '/Handler/RequestHandling/PurchaseRequestHandler.ashx',
                data: { 'method': 'GetBank' },
                contentType: "application/json; charset=utf-8",
                async: false,
                success: function (result) {
                var mappedTasks = $.map(result.ResponseData, function (item) {
                    return new Bank(item)

                });
                self.Banks(mappedTasks);
                } ,
                error: function (err) {
                    waitMsg.hide();
                    msg(err.status + " - " + err.statusText, "FAILURE");
                }
                });
    }
    self.GetBank();

    self.GetDataByTXNID = function(){
      $.ajax({
            dataType: "json",
            url: '/Handler/Collection/CollectionHandler.ashx',
            data: { 'method': 'GetDataByTXNID', 'GatewayCode':self.GatewayCode(), 'TXNID': self.TXNID() },
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (result) {
            var Reg_No = result.ResponseData;
            var res = Reg_No.split(" ");
            self.DREQUEST_NO(res[1]);
            self.AMOUNT(parseFloat(res[0]).toFixed(2));
            },
            error: function (err) {
                waitMsg.hide();
                msg(err.status + " - " + err.statusText, "FAILURE");
            }
            });
    }
   function validate(input) {
        if (/^\s/.test(input.value))
            input.value = '';
    }
     self.Name.subscribe(function(){
     if(self.IS_UNIT_HOLDER() =='N'){
     self.ClientName(self.Name());
     self.payeename(self.Name());

     }
    })

      $("#dp").select2({
          tags: true
        });

         $('input[name="optionsRadios"]').change(function () {
 
        if ($('#Radio3').prop('checked')) {
         $('#other').css('display','inline');   
          $('#other1').css('display','inline');   
        }
        else{
              $('#other').css('display','none');  
               $('#other1').css('display','none'); 
              self.othersource('');
        }
    });

    self.P_Tel_No.subscribe(function(){
    self.Contact_No1(self.P_Tel_No());
    });
     self.P_Mobile_no.subscribe(function(){
    self.Contact_No2(self.P_Mobile_no());
    });

     
   self.validateUserName = function () {
        if (self.UserName() != undefined) {
            $.ajax({
                dataType: "json",
                url: '/Handler/Security/EmailHandler.ashx',
                async: true,
                data: { 'method': 'validateUserName', 'UserName': ko.toJS(self.UserName()) },
                contentType: "application/json; charset=utf-8",
                async: false,
                success: function (result) {
                    var count = result.ResponseData.length;
                    if (count == 1) {
                        msg("UserName Already Exist. Please Enter New One!!!");
                        self.UserName('');

                    }
                }
            });
        }
    }
    self.validateEmailaddress = function () {
        if (self.Email_ID() != undefined) {
            $.ajax({
                dataType: "json",
                url: '/Handler/Security/EmailHandler.ashx',
                async: true,
                data: { 'method': 'validateEmailaddress', 'Email': ko.toJS(self.Email_ID()) },
                contentType: "application/json; charset=utf-8",
                async: false,
                success: function (result) {
                 
                    var count = result.ResponseData.length;
                    self.WebCheckEmail();
                        if (count >= 1) {
                            msg("Email Address already exists !!!",alert);
                            self.Email_ID('');
                        }
     
                }
            });
        }
    }


  $("#ImgFile1").on("change", function () {
      
        if (this.files[0] != undefined) {
            edocerror2 = "";
            docsize2 = "";
            docsize2 = this.files[0].size / 1024 / 1024;

            var fileInput = document.getElementById('ImgFile1');
            docname2 = fileInput.files[0].name;

            var files = !!this.files ? this.files : [];
            if (!files.length || !window.FileReader) return;

            doctype2 = files[0].type;

            var reader = new FileReader();
            reader.readAsDataURL(files[0]);


                        if (files[0].type != "image/jpeg" && files[0].type != "image/png") {
                            edocerror = 1;
                                  msg("Document format must only be jpeg, png and jpg format!!!<br>");
                            $('#ImgFile1').val("");
                            self.File1("");
                            self.ProofFileName(null);

                            return;
                        }

                        if (files[0].size > 1000000) {
                            edocerror = 2;
                            msg("Document size must be less than 1 mb !!!<br>");
                            self.File1("");
                            $('#ImgFile1').val("");
                            return;
                        }

            reader.onloadend = function (event) {
               //  self.ProofFileName(docname2);
                var dataUri = event.target.result
                 self.ProofFileName(docname2);
                docfile4 = dataUri;
                self.File1(docfile4);
               
            }
        }
        else {
            self.File1('');
        }
    });

    $("#ImgFile2").on("change", function () {

        if (this.files[0] != undefined) {
            edocerror2 = "";
            docsize2 = "";
            docsize2 = this.files[0].size / 1024 / 1024;

            var fileInput = document.getElementById('ImgFile2');
            docname2 = fileInput.files[0].name;

            var files = !!this.files ? this.files : [];
            if (!files.length || !window.FileReader) return;

            doctype2 = files[0].type;

            var reader = new FileReader();
            reader.readAsDataURL(files[0]);


            if (files[0].type != "image/jpeg" && files[0].type != "image/png") {
                edocerror = 1;
                msg("Document format must only be jpeg, png and jpg format!!!<br>");
                $('#ImgFile2').val("");
                self.File2("");
                self.ProofFileName2(null);

                return;
            }

            if (files[0].size > 1000000) {
                edocerror = 2;
                msg("Document size must be less than 1 mb !!!<br>");
                self.File2("");
                $('#ImgFile2').val("");
                return;
            }

            reader.onloadend = function (event) {
                var dataUri = event.target.result
                self.ProofFileName2(docname2);
                docfile4 = dataUri;
                self.File2(docfile4);
            }
        }
        else {
            self.File2('');
        }
    });

    $("#ImgFile3").on("change", function () {

        if (this.files[0] != undefined) {
            edocerror2 = "";
            docsize2 = "";
            docsize2 = this.files[0].size / 1024 / 1024;

            var fileInput = document.getElementById('ImgFile3');
            docname2 = fileInput.files[0].name;

            var files = !!this.files ? this.files : [];
            if (!files.length || !window.FileReader) return;

            doctype2 = files[0].type;

            var reader = new FileReader();
            reader.readAsDataURL(files[0]);


            if (files[0].type != "image/jpeg" && files[0].type != "image/png") {
                edocerror = 1;
                msg("Document format must only be jpeg, png and jpg format!!!<br>");
                $('#ImgFile3').val("");
                self.File3("");
                self.ProofFileName3(null);

                return;
            }

            if (files[0].size > 1000000) {
                edocerror = 2;
                msg("Document size must be less than 1 mb !!!<br>");
                self.File3("");
                $('#ImgFile3').val("");
                return;
            }

            reader.onloadend = function (event) {
                var dataUri = event.target.result
                self.ProofFileName3(docname2);
                docfile4 = dataUri;
                self.File3(docfile4);
            }
        }
        else {
            self.File3('');
        }
    });


    self.WebCheckEmail = function () {
      if (self.Email_ID() != undefined) {
        $.ajax({
            dataType: "json",
            url: '/Handler/Security/EmailHandler.ashx',
            async: true,
            data: { 'method': 'CheckEmail', 'Email': ko.toJS(self.Email_ID()) },
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (result) {

                if (!(result.IsSucess)) {
                    msg("Please Enter Valid Email Address", "FAILURE");
                    self.Email_ID(null);
                }
            },
            error: function (err) {
                waitMsg.hide();
                msg(err.status + " - " + err.statusText, "FAILURE");
            }
        });
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
    self.validateContact_No = function(){
        if(self.Contact_No() == self.Contact_No1() ||self.Contact_No() == self.Contact_No2()||self.Contact_No() == self.Contact_No3()|| self.Contact_No() == self.Contact_No4()){
        return true
        }
        else{
         msg("Contact No doesnt Matched.Please Update Your KYC!!!",alert);
        }
    }
    self.Paymentvalidation = function(){
        var errMsg = "";
        var objFocus = null;
        //#region Validating required fields
        if ($('#Radio3').prop('checked')) {
             if(Validate.empty(self.othersource())){
                errMsg +="Please Enter Other Source!!!<br>";
            }else{
                source =self.othersource(); 
            }
        }
        else{
            source =self.amtDetail();
        }
//        if(self.OTPPass() != self.OTP() || self.OTPPass() == undefined){
//            errMsg += "Please Verify Your OTP!!!<br/>"
//        }
        if(self.VerifyOtp() == false){
         errMsg += "Please Verify Your OTP!!!<br/>"
        }
//          if(self.VerifyContactNoOtp() == false){
//         errMsg += "Please Verify Your Contact No. OTP!!!<br/>"
//        }

        if (Validate.empty(self.Boid_No())) {
            errMsg += "Please Enter BOID!!!<br>";
        }
        if(self.Boid_No() != undefined){
            if (self.Boid_No().length < 8) {
                errMsg += "Please Enter 8-digit BOID!!!<br>";
            }
        }
        
        if (self.SelectedDp() == undefined) {
            errMsg += "Please Select Depository Participants !!!<br>";
        }
        
        if(self.amtDetail() == undefined){
            errMsg += "Please Select Source of Amount!!!<br>";
        }
       
       if (Validate.empty(self.APPLY_UNIT())) {
            errMsg += "Please Enter Apply Unit!!!<br>";
        }
       if (Validate.empty(self.APPLY_DT())) {
            errMsg += "Please Enter Apply Date!!!<br>";
        }
         if (Validate.empty(self.Email())) {
            errMsg += "Please Enter Email!!!<br>";
        }
        else if (Validate.email(self.Email())) {
            errMsg += "Please Enter Correct Email!!!<br>";
        }
        if (Validate.empty(self.P_Tel_No())) {
            errMsg += "Please Enter Contact No !!!<br>";
        }
        else if(self.P_Tel_No().length < 10){
            errMsg += "Please Enter Correct Contact No !!!<br>";
        }
        
            
        if(self.IS_UNIT_HOLDER()=='N'){
            if(Validate.empty(self.DOB())){
                errMsg += "Please Enter Date of Birth!!!<br>";
            }
            if(Validate.empty(self.CitizenshipNo())){
                errMsg += "Please Enter Citizenship No!!!<br>";
            }
            if (Validate.empty(self.HolderType())) {
                errMsg += "Please select HolderType!!!<br>";
            }

             if (self.SelectedBank() == undefined) {
                errMsg += "Please Select Bank Name!!!<br>";
            }
            if (Validate.empty(self.Bank_Account_No())) {
                errMsg += "Please Enter Bank_Account_No!!!<br>";
            }
              if (Validate.empty(self.Name())) {
                errMsg += "Please Enter Name!!!<br>";
            }
        }

       if(self.payeename() != undefined && self.payeename() != ""){
            if(self.Name() != undefined && self.Name() != ""){
                var upperPayee = self.payeename().toUpperCase();
                var uppername = self.Name().toUpperCase()
                upperPayee = upperPayee.split(/\s/).join('');
                uppername = uppername.split(/\s/).join('');
          
                if( uppername != upperPayee){
                    if (self.File1() == undefined || self.File1() == "") {
                      errMsg += "Please Enter Proof of Evidence !!!<br>";
                   }
       
               }
           }
        }else{
             errMsg += "Please Enter Payee Name !!!<br>";
        }
        //#endregion
        if (errMsg !== "") {

            msg(errMsg, "ALERT");

            return false;
        }
        else {
            return true;
        }
    }

    


    self.GetData = function(){
    var REQUEST_NO= self.DREQUEST_NO();
    if(REQUEST_NO != undefined|| REQUEST_NO!="" ){
    waitMsg.show();
     $.ajax({
                type: "GET",
                dataType: "json",
                url: '/Handler/RequestHandling/PurchaseRequestHandler.ashx',
                data: { 'method': 'GetData', 'scheme_code': scheme_code, 'ccode': ccode ,'l_company_id':l_company_id, 'REQUEST_NO':REQUEST_NO , 'Action':'R'},
                contentType: "applicaton/json; character=utf -8",
                async: false,
                success: function (data) {  
                var SHolder = data.ResponseData[0];
        
                            self.ShHolderNo(SHolder.ShHolderNo);
                            self.Name(SHolder.FName +" "+SHolder.LName);
                            self.FName(SHolder.FName);
                            self.LName(SHolder.LName);
                            self.FaName(SHolder.FaName)
                            self.LoadScheme();
                            self.Boid_No(((SHolder.Bo_Account_No).toString()).substr(8,16));
                            var dpcode = ((SHolder.Bo_Account_No).toString()).substr(0,8);
                            self.SelectedDp(self.Depo().find(x => x.DP_Id_Cds() === dpcode));
                            document.getElementById("select2-dp-container").innerHTML=ko.toJS(self.SelectedDp().DPName);
                            self.P_Tel_No(SHolder.P_Tel_No);
                            self.P_Mobile_no(SHolder.P_Mobile_no);
                            self.Bank_Account_No(SHolder.Bank_Account_No);
                            self.APPLY_UNIT(SHolder.APPLY_UNIT);
                            self.BalUnit(SHolder.TotalKitta);
                            self.IS_UNIT_HOLDER(SHolder.IS_UNIT_HOLDER);
                            self.APPLY_DT(SHolder.APPLY_DT);
                            self.DOB(SHolder.DOB)
                            self.CitizenshipNo(SHolder.Citizenship_No)
                            $('#txtapplydt').val(SHolder.APPLY_DT);
                            self.cashorcheque(SHolder.cashorcheque); 
                            self.nav_date(SHolder.nav_date);
                            self.charge_amount(SHolder.charge_amount);
                            self.remarks(SHolder.remarks);
                            self.CashAmount(SHolder.CashAmount);
                            self.ChequeAmount(SHolder.ChequeAmount);
                            self.other_charges(SHolder.other_charges);
                            self.SEBON_Fee(SHolder.SEBON_Fee);                                                        
                            var bankcode = SHolder.BankCode;
                            self.GatewayCode(SHolder.GatewayCode);
                            self.SelectedBank(self.Banks().find(x => x.bankcode() === SHolder.BankCode));
                            self.SelectedBranch(self.Branches().find(x => x.branch_code() === SHolder.Branch_code));
                            self.payeename(SHolder.payeename);
                            self.PayeeContactNo(SHolder.PayeeContactNo);
                            self.Email(SHolder.Email_ID);
                            self.File1(SHolder.File1);
                            self.File2(SHolder.File2);
                            self.File3(SHolder.File3);
                            self.ProofFileName(SHolder.FileName1);
                            self.ProofFileName2(SHolder.FileName2);
                            self.ProofFileName3(SHolder.FileName3);
                            if(self.File1() != null){
                                $('#ImgFile1').css('display','none');
                                $('#ProofFileName').css('display','inline');
                           }
                           if (self.IS_UNIT_HOLDER()=='N'){
                             $('.NoneExisting').css('display','block');
                             $('.NoneExistingHeader').css('display','block');
                           }
                           else{
                            $('.NoneExisting').css('display','block');
                            $('.NoneExistingHeader').css('display','none');
                           }
                            self.current_nav(SHolder.current_nav);
                            if(SHolder.IsInstitution ==true){
                                self.HolderType(true);
                                $('#Company').prop('checked', true);
                                self.HolderType(SHolder.IsInstitution);                               
                            }
                            else{
                                self.HolderType(false);
                                $('.NoneExistingHeader #Individual').prop('checked', false);
                                self.HolderType(SHolder.IsInstitution);
                            }

                            if(self.IS_UNIT_HOLDER() =='Y')
                            {
                               $('.NoneExistingHeader').css('display','none');
                            }
                            self.tot_with_face_value(self.APPLY_UNIT()*self.face_val());
                            var tot = parseFloat(ko.toJS(self.APPLY_UNIT())*ko.toJS(self.current_nav())).toFixed(2)
                            self.tot_with_Nav_value(tot);
                            var tot_reqd_amt = parseFloat(ko.toJS(self.tot_with_Nav_value())) + parseFloat(ko.toJS(self.charge_amount())) + parseFloat(ko.toJS(self.other_charges())) +self.SEBON_Fee();
                            self.tot_reqd_amt(parseFloat(tot_reqd_amt).toFixed(2));
                            self.amtDetail(SHolder.source);
                            if(self.amtDetail() != "Loan" && self.amtDetail() != "Salary" && self.amtDetail()!= "Assets" && self.amtDetail() != "Business" )
                            {
                             $('#Radio3').prop("checked",true);
                             $('#other').css('display','inline');   
                             $('#other1').css('display','inline'); 
                             self.othersource(ko.toJS(self.amtDetail()));
                            }
                            self.HasDividend(SHolder.HasDrep);
                            $('#HasDividend').attr('disabled','disabled')
                            if(SHolder.HasDrep == true){
                                 $('#HasDividend').css('display','block')
                            }
                            else{
                                $('#HasDividend').css('display','none')
               
                            }
                            waitMsg.hide();

                }, 
                error: function (err) {
                                        waitMsg.hide();
                                        msg(err.status + " - " + err.statusText, "FAILURE");
                                 
                            }

                });
                }
    }
   

    self.ValidateAmount = function(){  
    
    var RE =getUrlParamVal('TXNID');
      $.ajax({
              type: "GET",
                dataType: "json",
                cache: false,
                async: true,
                url: '/Handler/RequestHandling/PurchaseRequestHandler.ashx',
                data: { 'method': 'ValidateAmount', 'TXNID': self.TXNID() },
                contentType: "applicaton/json; character=utf -8",
                async: false,
                success: function (obj) {
                 var PayTxnAmount= obj.ResponseData[0].AMOUNT;
                self.PayAmount(obj.ResponseData[0].AMOUNT);
                self.DREQUEST_NO(obj.ResponseData[0].DREQUEST_NO);
                self.Bo_Account_No(obj.ResponseData[0].Bo_Account_No);
                self.GatewayCode(obj.ResponseData[0].GatewayCode);
                self.PaymentCode(obj.ResponseData[0].cashorcheque);
                self.AMOUNT(parseFloat(PayTxnAmount).toFixed(2));
                self.GTotal((parseFloat(PayTxnAmount))*100);
                }
             });
    }
 
    //Get Transaction ID in URL  with verify Connect IPS Payment Data
    if (getUrlParamVal('TXNID') != undefined && getUrlParamVal('TXNID') != "") {
        ValidatePage();
        var RE = getUrlParamVal('TXNID');
       self.TXNID(RE);
       var TXNID= sessionStorage.getItem("TXNID"); 
       if (RE==TXNID){
          waitMsg.show1();
          self.ValidateAmount();
          window.history.replaceState("object or string", "Title", self.TestURL());  
          var ValidData='MERCHANTID='+ self.PayMarchantId() +
                                                   ',APPID='+ self.PayAppId() +
                                                   ',REFERENCEID='+ RE +
                                                   ',TXNAMT='+ self.GTotal() ;
          let url = '../../Handler/Collection/CollectionHandler.ashx';
          let data = { 'method': 'GetToken', 'data': ValidData };
                                $.post(url, data, result => {
                                    var obj = JSON.parse(result);
                                       waitMsg.hide();
                                       if(obj.IsSucess){
                                          var genToken=obj.data;
                                                  var postDate={
	                                                    "merchantId":self.PayMarchantId(),
	                                                    "appId":self.PayAppId(),
	                                                    "referenceId":RE,
	                                                    "txnAmt": self.GTotal(),
	                                                    "token":genToken
                                           }

                                           
              
                                        let url = '../../Handler/Collection/CollectionHandler.ashx';
                                        let data = { 'method': 'ValidatePayment', 'data': JSON.stringify(ko.toJS(postDate)) ,'Action': 'U' ,'ReferenceID':self.Bo_Account_No(), 'AppID' :self.PayAppId(),'PayAppName': self.PayAppName(),'GatewayCode': self.GatewayCode() ,'PaymentCode':self.PaymentCode()};
                                        $.post(url, data, result => {
                                            var obj = JSON.parse(result);
                                            waitMsg.hide1();
                                            var dataObj=JSON.parse(obj.data);
                                               if(obj.IsSucess){
                                                 if (dataObj.status=="SUCCESS")
                                                 { 
                                                     sessionStorage.clear();
                                                     self.GetData();
                                                     msg(dataObj.statusDesc,alert);
                                                     self.SubmitStatus(dataObj.status);
                                                     self.AMOUNT(parseFloat(self.PayAmount()).toFixed(2));
                                                     
                                                     $('.Hidden').css('display','none');
                                                     $('.Submit').attr('disabled','disabled');
                                                     $('#btnProceed,#btnCancel').attr('disabled', true);
                                                     $('#BtnSave').attr('disabled', false);

                                                     if (self.IS_UNIT_HOLDER()=='N' && self.HolderType()==false){
                                                           $('#loginView').css('display','block');
                                                     }
                                                     waitMsg.hide1();
                                                     window.history.replaceState("object or string", "Title", self.TestURL());
                                                 }
                                                 else
                                                 {
                                                    sessionStorage.clear();
                                                    msg("TRANSACTION FAILED",alert);
                                                    self.GetData();

                                                    $('.Hidden').css('display','none');
                                                    $('.Submit').attr('disabled','disabled');
                                                    $('#BtnSave,#btnProceed').attr('disabled', true);
                                                    $('#btnCancel').attr('disabled', false);

                                                     waitMsg.hide1();
                                                    window.history.replaceState("object or string", "Title", self.TestURL());
                                                 }
                                               }
                                               else
                                               {  
                                                waitMsg.hide1();
                                                 msg(obj.Message);
                                               }

                                               setTimeout(function(){ 
                                                $('#popup_ok').removeAttr('disabled');
                                              }, 100);

                                           });
                                                }

                                   });
                }

    }

  


     self.openpage = function(){
        var objFra = window.open('../../Modules/Ebanking.aspx', '_blank');
     }
     
     
 
//To verify Khalti Payment   
function VerifyKhaltiPayment(payload) {
    waitMsg.show1();
    var paymentdata = {
        GatewayCode: self.GatewayCode(),
        TXNID:self.TXNID(),
        referenceId : self.DREQUEST_NO(),
        amount:payload.amount,
        idx:payload.idx,  //For VendorTXNID
        token: payload.token       
    }   
    var url = '../../Handler/Collection/CollectionHandler.ashx';
     var data = { 'method': 'VerifyKhaltiPayment', 'data': JSON.stringify(ko.toJS(paymentdata)) ,
                 'Action': 'U',
                 'GatewayCode': self.GatewayCode(),
                 'TXNID':self.TXNID(),
                 'PaymentCode':self.PaymentCode(),
                 'ReferenceID':ko.toJS(self.SelectedDp().DP_Id_Cds())+ko.toJS(self.Boid_No)
                  };
               
   $.post(url, data, result => {
    var obj = JSON.parse(result);
    var dataObj = JSON.parse(obj.data);
    waitMsg.hide(); 
    if (obj.IsSucess) {
        if (dataObj.state.name == "Completed") {
            sessionStorage.clear();
            $('#PaymentType').modal('hide');
            self.GetData();
            msg('Transaction has been Sucessfull', alert); 
            self.SubmitStatus(dataObj.state.name);
            self.AMOUNT(parseFloat(dataObj.amount).toFixed(2)/100);
            $('.Hidden').css('display', 'none');
            $('.Submit').attr('disabled', 'disabled');
            $('#btnProceed,#btnCancel').attr('disabled', true);
            $('#BtnSave').attr('disabled', false);
             if (self.IS_UNIT_HOLDER()=='N' && self.HolderType()==false){
                 $('#loginView').css('display','block');
            }
            waitMsg.hide1();
            window.history.replaceState("object or string", "Title", self.TestURL());
            
        }
        else {
            sessionStorage.clear();
            $('#PaymentType').modal('hide');
            msg("TRANSACTION FAILED", alert);
            self.GetData();

            $('.Hidden').css('display', 'none');
            $('.Submit').attr('disabled', 'disabled');
            $('#BtnSave,#btnProceed').attr('disabled', true);
            $('#btnCancel').attr('disabled', false);
             waitMsg.hide1();
             window.history.replaceState("object or string", "Title", self.TestURL());
        }
    }
    else {

        waitMsg.hide();
        waitMsg.hide1(); 
        msg(obj.Message);
    }

    setTimeout(function () {

        $('#popup_ok').removeAttr('disabled');

    }, 100);

  });
}


       self.UpdateToken = function(){
       
        var url = "../../Handler/RequestHandling/PurchaseRequestHandler.ashx" ;
        var data = { 'method': 'UpdateToken', 'TXNID': self.TXNID(), 'Action':'A', 'Token': self.Token() };
                            $.post(url, data,
                                function (result) {
                                });
        }


  
      //To open Khalti payment form with Config
        var config = {
            "publicKey": Khaltiref,
            "productName": "Unit Purchase",
            "productUrl": UnitPurchaseURL,
            "paymentPreference": [
                "KHALTI"
                ],
            "eventHandler": {
                onSuccess (payload) {
                  waitMsg.hide();
                    self.Token(payload.idx);
                    self.UpdateToken();
                    VerifyKhaltiPayment(payload);

                },
                onError (error) {
                  
                       waitMsg.hide();
                },
                onClose () {
                
                       waitMsg.hide();
                }
            }
        };

if( getUrlParamVal('q') != undefined && getUrlParamVal('q') != ""){
 ValidatePage();
if( getUrlParamVal('q') =="su"){
        waitMsg.show();
        self.TXNID(getUrlParamVal('oid'));
        self.ValidateAmount();
        self.Token(getUrlParamVal('refId'));
        self.UpdateToken();
        var resData = {
            PREF: getUrlParamVal('oid'),
            //AMOUNT: self.AMOUNT(),
            AMOUNT: getUrlParamVal('amt'),
            BID: getUrlParamVal('refId'),
            CustRefType: getUrlParamVal('oid'),
            scd: Esewascd 
        }
        var url = '../../Handler/Collection/CollectionHandler.ashx';
        var data = { 'method': 'VerifyEsewaTransaction', 'data': JSON.stringify(resData), 'Action': 'E', 'GatewayCode': self.GatewayCode(), 'PaymentCode': '12' };
        $.post(url, data, result => {
            waitMsg.show();
            var obj = JSON.parse(result);
            if (obj.IsSucess) {
             if(obj.data ="SUCCESS"){
                 msg('Transaction has been Sucessfull', alert);
                 self.GetData();
                 self.SubmitStatus(obj.data);
                 $('.Hidden').css('display', 'none');
                 $('.Submit').attr('disabled', 'disabled');
                 $('#btnProceed,#btnCancel').attr('disabled', true);
                 $('#BtnSave').attr('disabled', false);
                 if (self.IS_UNIT_HOLDER()=='N' && self.HolderType()==false){
                     $('#loginView').css('display','block');
                 }
                 $('#PaymentType').modal('hide');
                 waitMsg.hide();
                 window.history.replaceState("object or string", "Title", self.TestURL());
            }
          else
             {
                msg('Transaction Failure ', alert);
                self.SubmitStatus(obj.data);
                var DREQUEST_NO = sessionStorage.getItem("REQUEST_NO");
                self.DREQUEST_NO(DREQUEST_NO);
                self.GetData();
                $('.Hidden').css('display', 'none');
                $('.Submit').attr('disabled', 'disabled');
                $('#BtnSave,#btnProceed').attr('disabled', true);
                $('#btnCancel').attr('disabled', false);
                waitMsg.hide();
                window.history.replaceState("object or string", "Title", self.TestURL());
             }                
            }
            else{
                msg(obj.Message, alert);
                self.SubmitStatus(obj.data);
                var DREQUEST_NO = sessionStorage.getItem("REQUEST_NO");
                self.DREQUEST_NO(DREQUEST_NO);
                self.GetData();
                $('.Hidden').css('display', 'none');
                $('.Submit').attr('disabled', 'disabled');
                $('#BtnSave,#btnProceed').attr('disabled', true);
                $('#btnCancel').attr('disabled', false);
                waitMsg.hide();
                window.history.replaceState("object or string", "Title", self.TestURL());
            }
         });
        }
        else if( getUrlParamVal('q') =="fu"){
            msg('Failed ', alert);
            var DREQUEST_NO = sessionStorage.getItem("REQUEST_NO");
            self.DREQUEST_NO(DREQUEST_NO);
            self.GetData();
            $('.Hidden').css('display', 'none');
            $('.Submit').attr('disabled', 'disabled');
            $('#BtnSave,#btnProceed').attr('disabled', true);
            $('#btnCancel').attr('disabled', false);
            waitMsg.hide();
            window.history.replaceState("object or string", "Title", self.TestURL());
        }
    }
   
     
    //To open Ebanking Login Form 
    self.EBankingProceedToPayment = function () {
        var method = "POST";
        var form = document.createElement('form');

      var url = EBankingLoginURL;

        form._submit_function_ = form.submit;
        form.setAttribute('METHOD', method);
        form.setAttribute('ACTION', url);
        
        //--BankId --
        var BankIdData = document.createElement('INPUT');
        BankIdData.setAttribute('TYPE', 'hidden');
        BankIdData.setAttribute('NAME', 'BankId');
        BankIdData.setAttribute('value', self.BankId());
        form.appendChild(BankIdData);

        //--MD --
        var MDData = document.createElement('INPUT');
        MDData.setAttribute('TYPE', 'hidden');
        MDData.setAttribute('NAME', 'MD');
        MDData.setAttribute('VALUE', self.MD());
        form.appendChild(MDData);

        //--PID --
        var PIDData = document.createElement('INPUT');
        PIDData.setAttribute('TYPE', 'hidden');
        PIDData.setAttribute('NAME', 'PID');
        PIDData.setAttribute('VALUE', self.PID());
        form.appendChild(PIDData);

        //--CRN --
        var CRNData = document.createElement('INPUT');
        CRNData.setAttribute('TYPE', 'hidden');
        CRNData.setAttribute('NAME', 'CRN');
        CRNData.setAttribute('VALUE', self.CRN());
        form.appendChild(CRNData);

        //--RU --
        var RUData = document.createElement('INPUT');
        RUData.setAttribute('TYPE', 'hidden');
        RUData.setAttribute('NAME', 'RU');
        RUData.setAttribute('VALUE', self.RU());
        form.appendChild(RUData);

        //--CG --
        var CGData = document.createElement('INPUT');
        CGData.setAttribute('TYPE', 'hidden');
        CGData.setAttribute('NAME', 'CG');
        CGData.setAttribute('VALUE', self.CG());
        form.appendChild(CGData);

        //--USER_LANG_ID --
        var USER_LANG_IDData = document.createElement('INPUT');
        USER_LANG_IDData.setAttribute('TYPE', 'hidden');
        USER_LANG_IDData.setAttribute('NAME', 'USER_LANG_ID');
        USER_LANG_IDData.setAttribute('VALUE', self.USER_LANG_ID());
        form.appendChild(USER_LANG_IDData);

        //--UserType --
        var UserTypeData = document.createElement('INPUT');
        UserTypeData.setAttribute('TYPE', 'hidden');
        UserTypeData.setAttribute('NAME', 'UserType');
        UserTypeData.setAttribute('VALUE', self.UserType());
        form.appendChild(UserTypeData);

        //--AppType --
        var AppTypeData = document.createElement('INPUT');
        AppTypeData.setAttribute('TYPE', 'hidden');
        AppTypeData.setAttribute('NAME', 'AppType');
        AppTypeData.setAttribute('VALUE', self.AppType());
        form.appendChild(AppTypeData);

        //--PRN --
        var PRNData = document.createElement('input');
        PRNData.setAttribute('type', 'hidden');
        PRNData.setAttribute('name', 'PRN');
        PRNData.setAttribute('value', self.TXNID());
        form.appendChild(PRNData);

        //--ITC --
        var ITCData = document.createElement('input');
        ITCData.setAttribute('type', 'hidden');
        ITCData.setAttribute('name', 'ITC');
        ITCData.setAttribute('value', ko.toJS(self.SelectedDp().DP_Id_Cds()) + ko.toJS(self.Boid_No));
        form.appendChild(ITCData);

        //--AMT --
        var AMTData = document.createElement('INPUT');
        AMTData.setAttribute('TYPE', 'hidden');
        AMTData.setAttribute('NAME', 'AMT');
        AMTData.setAttribute('VALUE', self.tot_reqd_amt())
        form.appendChild(AMTData);

        document.body.appendChild(form);
        form._submit_function_();

    }


    // To Load reponse data of Ebanking and call ajax with verify data
    if (resbid !== "") {
       waitMsg("Loading.....");
        waitMsg.show();
        var resData = {
            BankId: resbankid,
            PREF: respref,
            AMOUNT: resamount,
            BID: resbid,
            CustRefType: rescustreftype
        }

        self.Token(resbid);
        self.TXNID(respref);
        self.UpdateToken();
        var url = '../../Handler/Collection/CollectionHandler.ashx';
        var data = { 'method': 'VerifyEBankingPayment', 'data': JSON.stringify(resData), 'Action': 'E', 'GatewayCode': self.GatewayCode(), 'PaymentCode': '10' };
        $.post(url, data, result => {
            var obj = JSON.parse(result);
            waitMsg.hide();
            if (obj.IsSucess) {
                var statusdata = obj.data;
                var res = statusdata.split(" ");
                self.status(res[0]);
                if (self.status() == "SUCCESS") {

                    var TXNID = sessionStorage.getItem("TXNID");
                    var DREQUEST_NO = sessionStorage.getItem("REQUEST_NO");
                    self.DREQUEST_NO(DREQUEST_NO);
                    sessionStorage.clear();
                    self.GetData();
                    msg('Transaction has been Sucessfull', alert);
                    self.SubmitStatus(self.status());                  
                    self.AMOUNT(resamount);
                    $('.Hidden').css('display', 'none');
                    $('.Submit').attr('disabled', 'disabled');
                    $('#btnProceed,#btnCancel').attr('disabled', true);
                    $('#BtnSave').attr('disabled', false);
                   if (self.IS_UNIT_HOLDER()=='N' && self.HolderType()==false){
                             $('#loginView').css('display','block');    
                    }
                    $('#PaymentType').modal('hide');                  
                    window.history.replaceState("object or string", "Title", self.TestURL());
                }
                else {                   
                    sessionStorage.clear();
                    msg("TRANSACTION FAILED", alert);                   
                    self.GetData();
                    $('.Hidden').css('display', 'none');
                    $('.Submit').attr('disabled', 'disabled');
                    $('#BtnSave,#btnProceed').attr('disabled', true);
                    $('#btnCancel').attr('disabled', false);
                    window.history.replaceState("object or string", "Title", self.TestURL());
                }
            }
            else {
                msg(obj.Message);
            }
            setTimeout(function () {
                $('#popup_ok').removeAttr('disabled');
            }, 100);
        });
    }

    
 //To open Connect IPS Login Form 
    self.ProceedToPayment  =function(){    
     self.Token(self.TXNID());
     self.UpdateToken();
     var payData='MERCHANTID='+ self.PayMarchantId() +
                    ',APPID='+ self.PayAppId() +
                    ',APPNAME='+ self.PayAppName() +
                    ',TXNID='+ self.TXNID() +
                    ',TXNDATE='+ self.PayTxnDate() +
                    ',TXNCRNCY='+ self.PayTxnCurency() +
                    ',TXNAMT='+ self.PayTxnAmount() +
                    ',REFERENCEID='+ self.PayRefId() +
                    ',REMARKS='+ ko.toJS(self.SelectedDp().DP_Id_Cds()) + ko.toJS(self.Boid_No) + self.PayRemarks() +
                    ',PARTICULARS='+ self.PayParticulars() +
                    ',TOKEN='+ self.PayToken() ;  
       
                let url = '../../Handler/Collection/CollectionHandler.ashx';
                let data = { 'method': 'GetToken', 'data': payData };
                $.post(url, data, result => {
                    var obj = JSON.parse(result);
                    waitMsg.hide();     
                var token=obj.data;
                var method ='POST';
                var form = document.createElement('form');

     
                var url = ConnectIpsiref;
                    form._submit_function_ = form.submit;
                    form.setAttribute('id', 'frmPayment');
                    form.setAttribute('method', method);
                    form.setAttribute('action', url);
                   // form.setAttribute('target', '_blank');

                    //--MERCHANTID --
                     var MarId =document.createElement('input');
                         MarId.setAttribute('type', 'hidden');
                         MarId.setAttribute('name', 'MERCHANTID');
                         MarId.setAttribute('id', 'MERCHANTID');
                         MarId.setAttribute('value',self.PayMarchantId());

                    form.appendChild(MarId);

                     //--APPID --
                     var AppId =document.createElement('input');
                         AppId.setAttribute('type', 'hidden');
                         AppId.setAttribute('name', 'APPID');
                         AppId.setAttribute('id', 'APPID');
                         AppId.setAttribute('value',self.PayAppId());
                    
                    form.appendChild(AppId);

                     //--APPNAME --
                     var AppName =document.createElement('input');
                         AppName.setAttribute('type', 'hidden');
                         AppName.setAttribute('name', 'APPNAME');
                         AppName.setAttribute('id', 'APPNAME');
                         AppName.setAttribute('value', self.PayAppName());
                    
                    form.appendChild(AppName);

                     //--TXNID --
                     var TxtnId =document.createElement('input');
                         TxtnId.setAttribute('type', 'hidden');
                         TxtnId.setAttribute('name', 'TXNID');
                         TxtnId.setAttribute('id', 'TXNID');
                         TxtnId.setAttribute('value',self.TXNID());
                    
                    form.appendChild(TxtnId);

                      //--TXNDATE --
                     var TxtnDate =document.createElement('input');
                         TxtnDate.setAttribute('type', 'hidden');
                         TxtnDate.setAttribute('name', 'TXNDATE');
                         TxtnDate.setAttribute('id', 'TXNDATE');
                         TxtnDate.setAttribute('value',self.PayTxnDate());
                    
                    form.appendChild(TxtnDate);
                  
                   //--TXNCRNCY --
                     var TxtnCrncy =document.createElement('input');
                         TxtnCrncy.setAttribute('type', 'hidden');
                         TxtnCrncy.setAttribute('name', 'TXNCRNCY');
                         TxtnCrncy.setAttribute('id', 'TXNCRNCY');
                         TxtnCrncy.setAttribute('value',self.PayTxnCurency());
                    
                    form.appendChild(TxtnCrncy);

                     //--TXNAMT --
                     var TxtnAmt =document.createElement('input');
                         TxtnAmt.setAttribute('type', 'hidden');
                         TxtnAmt.setAttribute('name', 'TXNAMT');
                         TxtnAmt.setAttribute('id', 'TXNAMT');
                         TxtnAmt.setAttribute('value',self.PayTxnAmount());
                    
                    form.appendChild(TxtnAmt);

                     //--REFERENCEID --
                     var RefId =document.createElement('input');
                         RefId.setAttribute('type', 'hidden');
                         RefId.setAttribute('name', 'REFERENCEID');
                         RefId.setAttribute('id', 'REFERENCEID');
                         RefId.setAttribute('value',self.PayRefId());
                    
                    form.appendChild(RefId);

                    
                     //--REMARKS --
                     var RefId =document.createElement('input');
                         RefId.setAttribute('type', 'hidden');
                         RefId.setAttribute('name', 'REMARKS');
                         RefId.setAttribute('id', 'REMARKS');
                         RefId.setAttribute('value',ko.toJS(self.SelectedDp().DP_Id_Cds()) + ko.toJS(self.Boid_No) + self.PayRemarks());
                    
                    form.appendChild(RefId);

                     //--PARTICULARS --
                     var Particulars =document.createElement('input');
                         Particulars.setAttribute('type', 'hidden');
                         Particulars.setAttribute('name', 'PARTICULARS');
                         Particulars.setAttribute('id', 'PARTICULARS');
                         Particulars.setAttribute('value',self.PayParticulars());
                    
                    form.appendChild(Particulars);

                     //--TOKEN --
                     var Token =document.createElement('input');
                         Token.setAttribute('type', 'hidden');
                         Token.setAttribute('name', 'TOKEN');
                         Token.setAttribute('id', 'TOKEN');
                         Token.setAttribute('value',token);
                    
                    form.appendChild(Token);
           
                
                    document.body.appendChild(form);
                  form._submit_function_(); 
                   
           
        }); 
     }



      self.ESewaProceedToPayment= function(){
                var method ='POST';
                var form = document.createElement('form');
                var url = ESewaRef;
                    form._submit_function_ = form.submit;
                    form.setAttribute('id', 'frmPayment');
                    form.setAttribute('method', method);
                    form.setAttribute('action', url);
                   // form.setAttribute('target', '_blank');
                   

                   //--TXNAMT --
                     var tAmt =document.createElement('input');
                         tAmt.setAttribute('type', 'hidden');
                         tAmt.setAttribute('name', 'tAmt');
                         tAmt.setAttribute('id', 'tAmt');
                         tAmt.setAttribute('value',(parseFloat(self.tot_reqd_amt())));
                    
                    form.appendChild(tAmt);

                     //--amt --
                     var amt =document.createElement('input');
                         amt.setAttribute('type', 'hidden');
                         amt.setAttribute('name', 'amt');
                         amt.setAttribute('id', 'amt');
                         amt.setAttribute('value',(parseFloat(self.tot_reqd_amt())));
                    
                    form.appendChild(amt);

                     //--txAmt --
                     var txAmt =document.createElement('input');
                         txAmt.setAttribute('type', 'hidden');
                         txAmt.setAttribute('name', 'txAmt');
                         txAmt.setAttribute('id', 'txAmt');
                         txAmt.setAttribute('value', '0');
                    
                    form.appendChild(txAmt);

                     //--psc --
                     var psc =document.createElement('input');
                         psc.setAttribute('type', 'hidden');
                         psc.setAttribute('name', 'psc');
                         psc.setAttribute('id', 'psc');
                         psc.setAttribute('value','0');
                    
                    form.appendChild(psc);

                      //--pdc --
                     var pdc =document.createElement('input');
                         pdc.setAttribute('type', 'hidden');
                         pdc.setAttribute('name', 'pdc');
                         pdc.setAttribute('id', 'pdc');
                         pdc.setAttribute('value','0');
                    
                    form.appendChild(pdc);
                  
                   //--scd --
                     var scd =document.createElement('input');
                         scd.setAttribute('type', 'hidden');
                         scd.setAttribute('name', 'scd');
                         scd.setAttribute('id', 'scd');
                         scd.setAttribute('value', Esewascd);
                    form.appendChild(scd);

                     //--pid --
                     var pid =document.createElement('input');
                         pid.setAttribute('type', 'hidden');
                         pid.setAttribute('name', 'pid');
                         pid.setAttribute('id', 'pid');
                         pid.setAttribute('value',self.TXNID());
                    
                    form.appendChild(pid);

                    
                     //--su --
                     var su =document.createElement('input');
                         su.setAttribute('type', 'hidden');
                         su.setAttribute('name', 'su');
                         su.setAttribute('id', 'su');
                         su.setAttribute('value', UnitPurchaseURL+'?q=su');
                    
                    form.appendChild(su);

                     //--fu --
                     var fu =document.createElement('input');
                         fu.setAttribute('type', 'hidden');
                         fu.setAttribute('name', 'fu');
                         fu.setAttribute('id', 'fu');
                         fu.setAttribute('value',UnitPurchaseURL+'?q=fu');
                    
                  form.appendChild(fu);
                  document.body.appendChild(form);
                  form._submit_function_(); 
     }
    var countSavedata = 0;
    self.SaveData = function(PaymentCode) {
    self.PaymentCode(PaymentCode);
    var Boid =ko.toJS(self.SelectedDp().DP_Id_Cds())+ko.toJS(self.Boid_No);
    ProductIdentity =Boid.toString();
    if(self.SelectedBank() != undefined){
             var bankcode=self.SelectedBank().bankcode();
           }
          else{
              bankcode= self.BANKCODE();
          }
        if(self.SelectedBranch() != undefined){
            var SelectedBranch=self.SelectedBranch().branch_code();
        }
        else{
            SelectedBranch= self.BRANCHCODE();
        }
      
                       $('.Submit').attr('disabled',true);
                       $('#btnProceed').attr('disabled',true);
                    var args = {
                                l_company_id:l_company_id,
                                Scheme_code:scheme_code,
                                ccode: ccode,
                                REQUEST_NO: null,
                                DREQUEST_NO:self.DREQUEST_NO(),
                                ShHolderNo: self.ShHolderNo(),
                                FName: self.Name(),
                                LName: self.LName(),
                                FaName: self.FaName(),
                                GFName: self.GFName(),
                                address: null,
                                Email_ID:self.Email(),
                                P_Tel_No: self.P_Tel_No(),
                                P_Mobile_no:self.P_Mobile_no(),
                                BankCode: bankcode,
                                Branch_code: SelectedBranch,
                                Bo_Account_No: ko.toJS(self.SelectedDp().DP_Id_Cds())+ko.toJS(self.Boid_No),
                                Bank_Account_No: self.Bank_Account_No(),
                                PAN_No: null,
                                Citizenship_No: null,
                                APPLY_UNIT: self.APPLY_UNIT(),
                                APPLY_DT: $('#txtapplydt').val(),
                                AMOUNT: self.tot_reqd_amt(),
                                CHK_NO: null,
                                remarks: 'Online Client',
                                appno: null,
                                bcode_cheque:null,
                                current_nav: self.current_nav(),
                                charge_amount: self.charge_amount(),
                                ENTRY_BY: 'Online Request',
                                ENTRY_DT: today,
                                APPSTATUS: "INITIAL",
                                IS_UNIT_HOLDER: self.IS_UNIT_HOLDER(),
                                IsInstitution:self.HolderType(),
                                nav_date: self.nav_date(),
                                cashorcheque: self.PaymentCode(),
                                APPROVED: "N",
                                other_charges: self.other_charges(),
                                SEBON_Fee: self.SEBON_Fee(),
                                SCharge_Code:'01',
                                Action: 'I',  
                                cname:null,
                                IsChequeClear:null,
                                ClearedDate:null,
                                ChequeCheckedBy:null,
                                CashAmount: self.tot_reqd_amt(),
                                ChequeAmount: self.tot_reqd_amt(),
                                Is_SIP:'false',
                                TranType:'02',
                                Status:'1',
                                source : source,
                                File1:self.File1(),
                                File2:self.File2(),
                                File3:self.File3(),
                                PayeeContactNo : self.PayeeContactNo(),
                                payeename : self.payeename(),
                                FileName1: self.ProofFileName(),
                                FileName2: self.ProofFileName2(),
                                FileName3: self.ProofFileName3(),
                                DOB : self.DOB(),
                                Citizenship_No : self.CitizenshipNo(),
                                GatewayCode: self.GatewayCode(),
                                HasDrep : self.HasDividend(),
                                OTP:self.OTPPass(),
                                OTPContact:self.OTPContactPass()

                            };
                            var url = "../../Handler/RequestHandling/PurchaseRequestHandler.ashx" ;
                            var data = { 'method': 'SavePurchaseEntry', 'args': JSON.stringify(ko.toJS((args))) };
                        
                            $.post(url, data,
                                function (result) {
                                 var obj = jQuery.parseJSON(result);
                                      if(obj.IsSucess){
                                    
                                      $('#btnProceed').attr('disabled',true);
                                      var DREQUEST_NO = obj.ResponseData;
                                      var res = DREQUEST_NO.split(" ");
                                      self.DREQUEST_NO(res[0]);
                                      self.TXNID(res[1]);
                                      self.PayTxnAmount((parseFloat(self.tot_reqd_amt()))*100);
                                      self.PayRefId(Boid);
                                      self.DREQUEST_NO(res[0]);
                                     
                                      sessionStorage.setItem("REQUEST_NO", self.DREQUEST_NO());
                                      sessionStorage.setItem("TXNID", self.TXNID());
                                      sessionStorage.setItem("ProofFileName", self.ProofFileName());
                                      if(self.PaymentCode() == '07') {
                                        //ConnectIPS
                                        self.ProceedToPayment();
                                        }                                       
                                       else if (self.PaymentCode() == '10') {
                                          self.EBankingProceedToPayment();
                                       }
                                       else if (self.PaymentCode() == '12') {
                                          self.ESewaProceedToPayment();
                                       }
                                      }
                                      else{
                                       self.ClearControls();
                                       msg("Not Responding Please Try Later", alert);
                                       self.ClearControls();
                                      }
                                });
                             
  
    }

      var checkout = new KhaltiCheckout(config);
 
    $(document).on('click', '#payment-button', function () {
        self.PaymentCode('09');
        waitMsg.show();
       self.Integrationcode('09');  

        var Boid = ko.toJS(self.SelectedDp().DP_Id_Cds()) + ko.toJS(self.Boid_No);
        ProductIdentity = Boid.toString();
        if (self.SelectedBank() != undefined) {
            var bankcode = self.SelectedBank().bankcode();
        }
        else {
            bankcode = self.BANKCODE();
        }
        if (self.SelectedBranch() != undefined) {
            var SelectedBranch = self.SelectedBranch().branch_code();
        }
        else {
            SelectedBranch = self.BRANCHCODE();
        }

        $('.Submit').attr('disabled', true);
        $('#btnProceed').attr('disabled', true);
        var args = {
            l_company_id: l_company_id,
            Scheme_code: scheme_code,
            ccode: ccode,
            REQUEST_NO: null,
            DREQUEST_NO: self.DREQUEST_NO(),
            ShHolderNo: self.ShHolderNo(),
            FName: self.Name(),
            LName: self.LName(),
            FaName: self.FaName(),
            GFName: self.GFName(),
            address: null,
            Email_ID: self.Email(),
            P_Tel_No: self.P_Tel_No(),
            P_Mobile_no: self.P_Mobile_no(),
            BankCode: bankcode,
            Branch_code: SelectedBranch,
            Bo_Account_No: ko.toJS(self.SelectedDp().DP_Id_Cds()) + ko.toJS(self.Boid_No),
            Bank_Account_No: self.Bank_Account_No(),
            PAN_No: null,
            Citizenship_No: null,
            APPLY_UNIT: self.APPLY_UNIT(),
            APPLY_DT: $('#txtapplydt').val(),
            AMOUNT: self.tot_reqd_amt(),
            CHK_NO: null,
            remarks: 'Online Client',
            appno: null,
            bcode_cheque: null,
            current_nav: self.current_nav(),
            charge_amount: self.charge_amount(),
            ENTRY_BY: 'Online Request',
            ENTRY_DT: today,
            APPSTATUS: "INITIAL",
            IS_UNIT_HOLDER: self.IS_UNIT_HOLDER(),
            IsInstitution: self.HolderType(),
            nav_date: self.nav_date(),
            cashorcheque: self.PaymentCode(),
            APPROVED: "N",
            other_charges: self.other_charges(),
            SEBON_Fee: self.SEBON_Fee(),
            SCharge_Code: '01',
            Action: 'I',
            cname: null,
            IsChequeClear: null,
            ClearedDate: null,
            ChequeCheckedBy: null,
            CashAmount: self.tot_reqd_amt(),
            ChequeAmount: self.tot_reqd_amt(),
            Is_SIP: 'false',
            TranType: '02',
            Status: '1',
            source: source,
            File1: self.File1(),
            File2: self.File2(),
            File3: self.File3(),
            PayeeContactNo: self.PayeeContactNo(),
            payeename: self.payeename(),
            FileName1: self.ProofFileName(),
            FileName2: self.ProofFileName2(),
            FileName3: self.ProofFileName3(),
            DOB: self.DOB(),
            Citizenship_No: self.CitizenshipNo(),
            GatewayCode: self.GatewayCode(),
            HasDrep : self.HasDividend(),
            OTP:self.OTPPass(),
            OTPContact:self.OTPContactPass()

        };

        var url = "../../Handler/RequestHandling/PurchaseRequestHandler.ashx";
        var data = { 'method': 'SavePurchaseEntry', 'args': JSON.stringify(ko.toJS((args))) };

        $.post(url, data,
            function (result) {
                var obj = jQuery.parseJSON(result);
                waitMsg.hide();
                if (obj.IsSucess) {

                    $('#btnProceed').attr('disabled', true);
                    var DREQUEST_NO = obj.ResponseData;
                    var res = DREQUEST_NO.split(" ");
                    self.DREQUEST_NO(res[0]);
                    self.TXNID(res[1]);
                    self.PayTxnAmount((parseFloat(self.tot_reqd_amt())) * 100);
                    self.PayRefId(Boid);
                    self.DREQUEST_NO(res[0]);
                    sessionStorage.setItem("REQUEST_NO", self.DREQUEST_NO());
                    sessionStorage.setItem("TXNID", self.TXNID());
                    sessionStorage.setItem("ProofFileName", self.ProofFileName());
                    sessionStorage.setItem("ProofFileName2", self.ProofFileName2());
                    sessionStorage.setItem("ProofFileName3", self.ProofFileName3());

                    var amt = ((parseFloat(self.tot_reqd_amt())) * 100);
                    checkout._config.productIdentity = ProductIdentity;
                    // minimum transaction amount must be 10, i.e 1000 in paisa.
                    checkout.show({ amount: amt });
                }
                else {
                  
                    msg(obj.Message, alert);
                    self.ClearControls();
                }
            });



    });

     self.ValidateNAV = function () {
            var url ="../../Handler/RequestHandling/PurchaseRequestHandler.ashx";
            var data = { 'method': 'ValidateNAV', 'APPLY_DT': $('#txtapplydt').val(),'Amount':ko.toJS(self.tot_reqd_amt()),'APPLY_UNIT': ko.toJS(self.APPLY_UNIT())};
            $.post(url, data,
                function (result) {
                var obj = jQuery.parseJSON(result);
                if(obj.IsSucess){
               
                self.NavValidation(obj.IsSucess);
                 return true;
                    
               }  
                else{
                 self.NavValidation(obj.IsSucess);
                  return false;
                }
           });
    }



    self.DispalyPaymentOptions= function(){
         if(self.Paymentvalidation()){
         self.ValidateNAV();
            if(self.NavValidation()==true){
                 $('#PaymentType').modal('show'); 
            }
            else{
                msg("Oops! Something went wrong. Please try again later","ALERT") 
           }
         }
                           
     }

         self.ViewFile = function (value) {
         
                self.Sh_File(null);
                self.Sh_File("data:image/jpeg;base64," + ko.toJS(value.File1));
                $("#ViewSign").modal('show');
            }
        self.SignUpValidation = function () {
      
        var errMsg = "";
        var objFocus = null;
        //#region Validating required fields
        if(self.IsOnline()==true){
            
            var testname = /^[\w@#$.&]+$/;
            //#region Validating required fields
                      
            if (Validate.empty(self.UserName())) {
                errMsg += "Please Enter UserName!!!<br>";
            }
            else if (testname.test((self.UserName()).trim()) != true) {
                errMsg += "The username must only contain a-z,A-Z,0-9 and _@#$.& \n";
		    } 
        }
        //#endregion
     
        if (errMsg !== "") {
            return false;
            self.UserName(null);
        }
        else {
            return true;
        }

    }
 
   
   self.openpdfe= function(){
   var objFra = window.open('../../Styles/Form_Login Registration.pdf', '_blank');
    }
    self.Validation = function(){
     var errMsg = "";
        var objFocus = null;
      
      if(self.IsOnline()==true){
            
            var testname = /^[\w@#$.&]+$/;
            //#region Validating required fields
                      
            if (Validate.empty(self.UserName())) {
                errMsg += "Please Enter UserName!!!<br>";
            }
            else if (testname.test((self.UserName()).trim()) != true) {
                errMsg += "The username must only contain a-z,A-Z,0-9 and _@#$.& \n";
		    } 
        }
      if ($('#Radio3').prop('checked')) {
             if(Validate.empty(self.othersource())){
                errMsg +="Please Enter Other Source!!!<br>";
            }else{
                source =self.othersource(); 
            }
       }
      else{
            source =self.amtDetail();
        }
      if (Validate.empty(self.Boid_No())) {
            errMsg += "Please Enter BOID!!!<br>";
        }
        if(self.Boid_No() != undefined){
            if (self.Boid_No().length < 8) {
                errMsg += "Please Enter 8-digit BOID!!!<br>";
            }
        }
        if (self.SelectedDp() == undefined) {
            errMsg += "Please Select Depository Participants!!!<br>";
        }
        
        if(self.amtDetail() == undefined){
            errMsg += "Please Select Source of Amount!!!<br>";
        }

        if (Validate.empty(self.Name())) {
            errMsg += "Please Enter Name!!!<br>";
        }
       if (Validate.empty(self.APPLY_UNIT())) {
            errMsg += "Please Enter Apply Unit!!!<br>";
        }
       if (Validate.empty(self.APPLY_DT())) {
            errMsg += "Please Enter Apply Date!!!<br>";
        }
       if (Validate.empty(self.P_Tel_No())) {
                errMsg += "Please Enter Phone No 1 !!!<br>";
       }else if(self.P_Tel_No().length < 10){
            errMsg += "Please Enter Correct Contact No !!!<br>";
       }
       if( self.IS_UNIT_HOLDER()=='N'){
             if (Validate.empty(self.HolderType())) {
                errMsg += "Please select HolderType!!!<br>";
             }
            if (Validate.empty(self.Bank_Account_No())) {
                errMsg += "Please Enter BankAccount No!!!<br>";
            }
            if (self.SelectedBank() == undefined) {
                errMsg += "Please Select Bank Name!!!<br>";
            }
       }
   
        //#endregion
      if (errMsg !== "") {
            msg(errMsg, "ALERT");

            return false;
            count=0;
        }
        else {
            return true;
        }
     
     }
     self.SignUp =ko.observable();

     self.SaveSignUp = function(){
     self.SignUp([]);
     }

     self.SubmitSignUp = function(){
     if(self.SignUpValidation ()){
     if(self.IsOnline()==true){
     var args = {
                        scheme_code: scheme_code,
                        l_company_id: l_company_id,
                        Name: self.Name(),
                        DOB: self.DOB(),
                        BOID: ko.toJS(self.SelectedDp().DP_Id_Cds) + ko.toJS(self.Boid_No()),
                        Email: self.Email(),
                        UserName: self.UserName().trim(),
                        Password: self.Password(),
                        Contact_No: self.P_Tel_No(),
                        Contact_No2:self.P_Mobile_no(),
                        UploadFile: self.UploadFile(),
                        Signature1: self.Signature1(),
                        IS_UNIT_HOLDER: self.IS_UNIT_HOLDER(),
                        Gender: self.Gender(),
                        Origin: 'UNIT PURCHASE',
                        SHHOLDERNO:self.ShHolderNo(),
                        Citizenship_No : self.CitizenshipNo(),
                        Gatewaycode :'001'

                    };
                    self.SignUp(args);
                    var url = "/Handler/Security/UserHandler.ashx"; ;
                    var data = { 'method': 'SaveWebUser', 'args': JSON.stringify(ko.toJS((self.SignUp))) };
                    $.post(url, data,
                                function (result) {
                                    waitMsg.hide();
                                    var data = jQuery.parseJSON(result);
                                    if (data.IsSucess) {
                                         self.CancelSignUp();
                                    }
                   });
                    
           }
           }
     }
   var count =0;  
 self.SavePurchaseEntry = function(){

 if( self.SubmitStatus()  =="SUCCESS" || self.SubmitStatus()  =="Completed" || self.SubmitStatus()  =="Success" ) {

     if( self.Validation()){
       
         if(self.SelectedBank() != undefined){
             var bankcode=self.SelectedBank().bankcode();
           }
          else{
              bankcode= self.BANKCODE();
          }
        if(self.SelectedBranch() != undefined){
            var SelectedBranch=self.SelectedBranch().branch_code();
        }
        else{
            SelectedBranch= self.BRANCHCODE();
        }

       Confirm("Do you want to continue?", 'Confirmation Dialog', function (r) {
                        if (r) {
                                waitMsg.show1();
                                var args = {
                                l_company_id:l_company_id,
                                scheme_code:scheme_code,
                                ccode: ccode,
                                DREQUEST_NO:self.DREQUEST_NO(),
                                ShHolderNo: self.ShHolderNo(),
                                FName: self.Name(),
                                LName: self.LName(),
                                FaName: self.FaName(),
                                GFName: self.GFName(),
                                address: null,
                                Email_ID:self.Email(),
                                P_Tel_No: self.P_Tel_No(),
                                P_Mobile_no:self.P_Mobile_no(),
                                BankCode: bankcode,
                                Branch_code: SelectedBranch,
                                Bo_Account_No: ko.toJS(self.SelectedDp().DP_Id_Cds())+ko.toJS(self.Boid_No),
                                Bank_Account_No: self.Bank_Account_No(),
                                PAN_No: null,
                                Citizenship_No: null,
                                APPLY_UNIT: self.APPLY_UNIT(),
                                APPLY_DT: $('#txtapplydt').val(),
                                AMOUNT: self.tot_reqd_amt(),
                                CHK_NO: null,
                                remarks: 'Online Client',
                                appno: null,
                                bcode_cheque:null,
                                current_nav: self.current_nav(),
                                charge_amount: self.charge_amount(),
                                ENTRY_BY: 'Online Request',
                                ENTRY_DT: today,
                                APPSTATUS: "UNPOSTED",
                                IS_UNIT_HOLDER: self.IS_UNIT_HOLDER(),
                                IsInstitution:self.HolderType(),
                                nav_date: self.nav_date(),
                                 //cashorcheque: '07',
                                cashorcheque:self.cashorcheque(),
                                APPROVED: "N",
                                other_charges: self.other_charges(),
                                SEBON_Fee: self.SEBON_Fee(),
                                SCharge_Code:'01',
                                Action: 'A',  
                                cname:null,
                                IsChequeClear:null,
                                ClearedDate:null,
                                ChequeCheckedBy:null,
                                CashAmount:self.AMOUNT(),
                                ChequeAmount:self.AMOUNT(),
                                Is_SIP:'false',
                                TranType:'02',
                                Status:'0',
                                source : source,
                                File1:"data:image/jpeg;base64," + ko.toJS(self.File1()),
                                File2:"data:image/jpeg;base64," + ko.toJS(self.File2()),
                                File3:"data:image/jpeg;base64," + ko.toJS(self.File3()),
                                PayeeContactNo : self.PayeeContactNo(),
                                payeename : self.payeename(),
                                GatewayCode: self.GatewayCode(),
                                HasDrep : self.HasDividend()
                            };
                               var url = "../../Handler/RequestHandling/PurchaseRequestHandler.ashx" ;
                                var data = { 'method': 'SavePurchaseEntry', 'args': JSON.stringify(ko.toJS((args))) };
                               
                                $.post(url, data,
                                    function (result) {
                                    var obj = jQuery.parseJSON(result);
                                      if(obj.IsSucess){
                                       if($('#chklogin').prop('checked')){
                                            self.SubmitSignUp();
                                       }
                                        waitMsg.hide1();
//                                        msg("Request Sent Successfully", alert);
                                        Confirm("Request Sent Successfully", 'Confirmation Dialog', function (r) {
                                        if (r) {
                                         window.history.pushState("object or string", "Title", self.TestURL());
                                        self.PrintPurchasenEntry(args)
                                        self.ClearControls();   
                                        }
                                        });                                                               
                                    }
                                    else{
                                    alert(obj.Message, alert);
                                    }
                                 });
                        }
                    });
     }
    }
   }
   function downloadURI(uri, name) {
    var link = document.createElement("a");
    link.download = name;
    link.href = uri;
    link.click();
    }
     self.PrintPurchasenEntry = function () {
       var data={
       l_company_id:l_company_id,
       Scheme_code:scheme_code,
       ccode:ccode,
       cname:"Online Client",
       REQUEST_NO:self.DREQUEST_NO()
       }
       
        $.ajax({
            dataType: "json",
            url: '/Handler/RequestHandling/OnlinePurchaseReceipt.ashx',
            data: { 'method': 'CreatePurchasePdfReceipt', 'args': ko.toJSON(data) },
            contentType: "application/json; charset=utf-8",
            async: false,
            success: function (data) {
                waitMsg.hide();
                var obj = JSON.parse(JSON.stringify(data));
                      var objFra ='/Reports/' + obj.ResponseData;
                      downloadURI(objFra, "Unit Purchase Receipt");
                      deleteFile(objFra);

            },
            error: function (err) {
                waitMsg.hide();
            }
        });
     
    }

     self.ClearSignUp = function () {
        self.ClientName(null);
        self.DOB(null);
        self.UserName(null);
        self.Password(null);
        self.Contact_No1(null);
        self.Contact_No2(null);
        self.Signature1(null);
        self.UploadFile(null);
        $('#txtUploadFile').val("");
        $('#txtSign').val("");
        self.Gender(null);
        self.IsOnline(false);
        self.CitizenshipNo(null);
        self.OTPPassSign(null)
        self.Email_ID(null)
         $("#modalShHolder").modal('show');
    }
    $("#txtUploadFile").on("change", function () {
       
        if (this.files[0] != undefined) {
            edocerror2 = "";
            docsize2 = "";
            docsize2 = this.files[0].size / 1024 / 1024;

            var fileInput = document.getElementById('txtUploadFile');
            docname2 = fileInput.files[0].name;

            var files = !!this.files ? this.files : [];
            if (!files.length || !window.FileReader) return;

            doctype2 = files[0].type;

            var reader = new FileReader();
            reader.readAsDataURL(files[0]);
            if (files[0].type != "image/jpeg" && files[0].type != "image/png" ) {
                edocerror = 1;
                msg("Document format must only be jpeg, png and jpg format!!!<br>");
                $("#txtUploadFile").val("");
                self.UploadFile("");
                self.FileName("");

                return;
            }

            if (files[0].size > 1000000) {
                edocerror = 2;
                msg("Document size must be less than 1 mb !!!<br>");
                $("#txtUploadFile").val("");
                self.UploadFile("");
                self.FileName("");
                return;
            }

            reader.onloadend = function (event) {

                var dataUri = event.target.result
                docfile4 = dataUri;
                //self.StampFileName(docfile4);
                // self.FileUpload1(docname4);
                self.UploadFile(docfile4);
            }
        }
        else {
            self.UploadFile('');
        }
    });
    $("#txtSign").on("change", function () {
       
        if (this.files[0] != undefined) {
            edocerror2 = "";
            docsize2 = "";
            docsize2 = this.files[0].size / 1024 / 1024;

            var fileInput = document.getElementById('txtUploadFile');
            docname2 = fileInput.files[0].name;

            var files = !!this.files ? this.files : [];
            if (!files.length || !window.FileReader) return;

            doctype2 = files[0].type;

            var reader = new FileReader();
            reader.readAsDataURL(files[0]);
            if (files[0].type != "image/jpeg" && files[0].type != "image/png") {
                edocerror = 1;
                      msg("Document format must only be jpeg, png and jpg format!!!<br>");
                self.Signature1("");
                  $("#txtSign").val("");
                //self.SignName("");

                return;
            }

            if (files[0].size > 1000000) {
                edocerror = 2;
                msg("Document size must be less than 1 mb !!!<br>");
                self.Signature1("");
               $("#txtSign").val("");
                return;
            }

            reader.onloadend = function (event) {

                var dataUri = event.target.result
                docfile4 = dataUri;
                //self.StampFileName(docfile4);
                // self.FileUpload1(docname4);
                self.Signature1(docfile4);
            }
        }
        else {
            self.Signature1('');
        }
    });
    self.GenerateRandomPassword = function () {
        //  #region To Create Random Characters for Agreement
        var len = 8;
        var code = "";
        var charset = "abcdefghijklmnopqrstuvwxyz0123456789";

        for (var i = 0; i < len; i++){
            code += charset.charAt(Math.floor(Math.random() * charset.length));
        }
        
        self.Password(code);
       
        //#endregion of Agreement code generation
    }
    self.GenerateRandomPassword()

    self.GenerateOTP = function () {

        //  #region To Create Random Characters for Agreement
        if(self.Email() && !Validate.email(self.Email())){
             var url = "../../Handler/Security/EmailHandler.ashx" ;
            var data = { 'method': 'SendMailForOTP',  'Email': ko.toJS(self.Email()), 'ContactNumber':ko.toJS(self.P_Tel_No())};
            $.post(url, data,
                function (result) {
              
                var obj = jQuery.parseJSON(result);
                if(obj.IsSucess){
                    msg("OTP Send To Your Mail and ContactNumber . Please enter OTP and click on 'Verify OTP' button to verify your OTP.","ALERT")   
                    $('#Verifyotp').css('display', 'inline');          
                }  
           });
        }
        if(Validate.empty(self.Email())){
         msg("Please Enter Email Address","ALTER")
        }
       if(Validate.empty(self.P_Tel_No())){
         msg("Please Enter Contact Number","ALTER")
        }
        else if(Validate.email(self.Email())){
            msg("Please Enter Correct Email Address","ALTER")
            
        }
        
        //#endregion of Agreement code generation
    }

    //Start OTP for Contact Number

    self.GenerateContactNoOTP = function () {

        //  #region To Create Random Characters for Agreement
        if(self.P_Tel_No() && !Validate.empty(self.P_Tel_No())){
             var url = "../../Handler/Security/SMSHandler.ashx" ;
            var data = { 'method': 'SENDSMS',  'ContactNumber': ko.toJS(self.P_Tel_No()) };
            $.post(url, data,
                function (result) {
              
                var obj = jQuery.parseJSON(result);
                if(obj.IsSucess){
                    msg("OTP Send To Your Contact Number. Please enter OTP and click on 'Verify OTP' button to verify your OTP.","ALERT")   
                    $('#VerifyContactotp').css('display', 'inline');          
                }  
           });
        }
        if(Validate.empty(self.P_Tel_No())){
         msg("Please Enter Contact Number","ALTER")
        }
        else if(Validate.empty(self.P_Tel_No())){
            msg("Please Enter Correct Contact Number","ALTER")
            
        }
        
        //#endregion of Agreement code generation
    }

      //End OTP for Contact Number



    
    self.CHECKOTP = function () {
        if(self.OTPPass() && !Validate.empty(self.OTPPass())){
       
            var url = "../../Handler/Security/EmailHandler.ashx";
            var data = { 'method': 'CHECKOTP',  'Email': ko.toJS(self.Email()),'OTP':ko.toJS(self.OTPPass()) };
            $.post(url, data,
                function (result) {
                var obj = jQuery.parseJSON(result);
                if(obj.IsSucess){
                    msg("OTP Verified Successfully","ALERT")   
                   $('#Verifyotp').css('display', 'none');   
                   $('#txtotp,#txtemail,#txttelno').attr('disabled',true);   
                   self.VerifyOtp(obj.IsSucess);    
                }  
                else{
                 msg("You have entered wrong OTP or the OTP time has expired. PLease Re-Generate the OTP and verify the OTP.","ALERT") 
                  $('#Verifyotp').css('display', 'inline');   
                 $('#txtotp').attr('disabled',false);    
                 self.VerifyOtp(obj.IsSucess);
                }
           });
        }
        if(Validate.empty(self.OTPPass())){
         msg("Please Enter OTP","ALTER")
        }
    }

    //Start verify contact number from OTP
//      self.CheckContactNoOTP = function () {
//        if(self.OTPContactPass() && !Validate.empty(self.OTPContactPass())){
//       
//            var url = "../../Handler/Security/SMSHandler.ashx";
//            var data = { 'method': 'CHECKContactNoOTP',  'ContactNo': ko.toJS(self.P_Tel_No()),'ContatNoOTP':ko.toJS(self.OTPContactPass()) };
//            $.post(url, data,
//                function (result) {
//                var obj = jQuery.parseJSON(result);
//                if(obj.IsSucess){
//                    msg("OTP Verified Successfully","ALERT")   
//                   $('#VerifyContactotp').css('display', 'none');   
//                   $('#txtContactOTP,#txttelno').attr('disabled',true);   
//                   self.VerifyContactNoOtp(obj.IsSucess);    
//                }  
//                else{
//                 msg("You have entered wrong OTP or the OTP time has expired. PLease Re-Generate the OTP and verify the OTP.","ALERT") 
//                  $('#VerifyContactotp').css('display', 'inline');   
//                 $('#txtContactOTP').attr('disabled',false);    
//                 self.VerifyContactNoOtp(obj.IsSucess);
//                }
//           });
//        }
//        if(Validate.empty(self.OTPContactPass())){
//         msg("Please Enter OTP","ALTER")
//        }
//    }

     //End verify contact number from OTP

    self.GenerateOTPSign = function () {
        //  #region To Create Random Characters for Agreement
        if(self.Email_ID()){
            var len = 4;
            var code = "";
            var charset = "0123456789";

            for (var i = 0; i < len; i++){
                code += charset.charAt(Math.floor(Math.random() * charset.length));
            }
        
            self.OTPPassSignCode(code);
          
            var url = "../../Handler/Security/EmailHandler.ashx" ;
            var data = { 'method': 'SendMailForOTP', 'otp': ko.toJS(self.OTPPassSignCode()) ,'Email': ko.toJS(self.Email_ID()) };
            $.post(url, data,
                function (result) {
              
                var obj = jQuery.parseJSON(result);
                if(obj.IsSucess){
                    msg("OTP Send To Your Mail","ALERT")                   
                }  
           });
        }else{
            msg("Please Enter Email Address","ALTER")
            
        }
        //#endregion of Agreement code generation
    }

    self.CancelSignUp = function(){
        
        self.DOB(null);
        self.UserName(null);
        self.Password(null);
        self.Contact_No(null);
        self.Signature1(null);
        self.UploadFile(null);
        self.OTPPassSign(null);
        self.CitizenshipNo(null);
        self.Email_ID(null);
        
    }


    self.ClearControls=function(){
    self.payeename(null);
    sessionStorage.setItem("REQUEST_NO", "");
    sessionStorage.setItem("TXNID", "");
    sessionStorage.setItem("ProofFileName", "");
    self.ProofFileName(null);
    self.ProofFileName2(null)
    self.ProofFileName3(null)
    self.Email_ID(null);
    self.UserList([]); 
    self.SelectedCharge(null);
    self.nav_date(null);
    self.face_val(null);
    self.APPLY_DT(null);
    self.current_nav(null);
    self.P_Tel_No(null);
    self.P_Mobile_no(null);
    self.SelectedBank(null);
    self.Bank_Account_No(null);
    self.SelectedDp(null);
    self.Boid_No(null);
    self.Name(null);
    self.APPLY_UNIT(null);
    self.tot_with_face_value(null);
    self.other_charges(null);
    self.SEBON_Fee(null);
    self.charge_amount(null);
    self.tot_with_Nav_value(null);
    self.tot_reqd_amt(null);
    self.AMOUNT(null);
    self.IsOnline(null);
    self.Email(null);
    self.DOB(null);
    self.UserName(null);
    self.Password(null);
    self.Contact_No(null);
    self.Signature1(null);
    self.UploadFile(null);
    self.LoadScheme();
    self.othersource(null);
    self.OTPPass(null);
    self.OTPContactPass(null);
    self.HolderType(null);
    $('#other').css('display','none');  
    $('#Verifyotp').css('display','none');  
    $('#VerifyContactotp').css('display','none');  
    $('.NoneExisting').css('display','none');
    $('.NoneExistingHeader').css('display','none');
    $('#btnProceed,#btnCancel').attr('disabled',false);
    $('#BtnSave').attr('disabled',true);
    $('.Existing').attr('disabled',false);
    $('#txtotp,#txtemail,#txttelno').attr('disabled',false);  
    $('#txtContactOTP,#txttelno').attr('disabled',false);  
    $('#ImgFile1').val(null)
    self.File1(null);
    self.File2(null);   
    self.File3(null);
    self.amtDetail(null);
    self.PayeeContactNo(null);
    self.NavValidation(false);
    sessionStorage.clear();
   
    $('.Submit').attr('disabled',false);
    $('#loginView').css('display','none');
    self.OTPPass(null)
    self.OTPContactPass(null)


    self.OTP(null)
    self.ContactOTP(null)
    self.OTPPassSign(null)
    $('#ProofFileName').css('display', 'none');
    $('#ImgFile1, .Hidden').css('display', 'inline');
     window.history.replaceState("object or string", "Title", self.TestURL());
    location.reload();

    }
    checkDate = function(){
    }
 


 self.CurrentDate = function(){
   $.ajax({
                type: "GET",
                dataType: "json",
                cache: false,
                async: true,
                url: '/Handler/Collection/DateHandler.ashx',
                data: { 'method': 'GetCurrentDate' },
                contentType: "applicaton/json; character=utf -8",
                 async: false,
                success: function (data) {
              
                var result =data.ResponseData;
                var date = data.ResponseData.split(" "); 
                self.CurrDate(result);
             //  return result;

                },
                error: function (err) {
                    msg(err.status + " - " + err.statusText, "WARNING");
                }
                });

 }
 //self.CurrentDate();
  self.GetNavValue = function () {
        if (self.APPLY_DT() != undefined && self.APPLY_DT() != "") {
         var GivenDate = self.APPLY_DT();
         self.CurrentDate();
         var CurrentDate = self.CurrDate().split(" ")[0];


           var today = new Date();
         var applydate = self.APPLY_DT()+" "+ today.getHours() + ":"  
            + String(today.getMinutes()).padStart(2, '0')+ ":" 
            + String(today.getSeconds()).padStart(2, '0');
        var day =today.getDay();
          var startdate = CurrentDate+ " "
            + 11 + ":"  
            + '00' + ":" 
            + '00';
     self.startdate(startdate);
     var day = today.getDay();
     var Enddate =  CurrentDate+ " "
            + 15 + ":"  
            + '00' + ":" 
            + '00';
    self.Enddate(Enddate);
         if(GivenDate >= CurrentDate){ 
            $.ajax({
                type: "GET",
                dataType: "json",
                cache: false,
                async: true,
                url: '/Handler/RequestHandling/PurchaseRequestHandler.ashx',
                data: { 'method': 'GetNAV', 'ApplyDate': self.APPLY_DT(), 'Scheme_code': scheme_code },
                contentType: "applicaton/json; character=utf -8",
                 async: false,
                success: function (data) {
                    if (data.ResponseData.length > 0) {
                 //   if (self.CurrDate() >= self.startdate() && self.CurrDate() <= self.Enddate()  && day != 5 && day != 6){
                        self.current_nav(data.ResponseData[0].nav_value);
                        self.nav_date(data.ResponseData[0].nav_date);
                        self.GetServiceChargeAmt();
//                       }     
//                       else
//                      {
//                           var msg1= '<u><b>Unit Purchase Session Open Time:</b></u><br/>'
//                            msg1 +='Sunday to Thursday 11 AM to 3 PM<br/>';
//                            msg1 += '<span style="color:red">*</span>Session Shall be remain closed on Friday, Saturday and all public holidays.<br>' 
//                            msg(msg1, alert);
//                          
//                            self.APPLY_DT(null);
//                            self.current_nav('');
//                        }

                    }
                    else {
                        msg("Nav Value for date:" + self.APPLY_DT() + " not defined yet", alert);
                        $('#txtapplydt').val('');
                        self.current_nav('');
                        self.APPLY_DT(null);
                    }
                },
                error: function (err) {
                    msg(err.status + " - " + err.statusText, "WARNING");
                }
            });
            }
            else{
            msg("Please Enter Valid Date", alert);
            self.APPLY_DT(null);
            self.current_nav('');
         }
        
        }
        else {
            msg("Please Choose Apply Date!!!", alert);

        }
    }
    self.GetServiceChargeAmt = function () {

        $.ajax({
            type: "GET",
            dataType: "json",
            cache: false,
            async: true,
            url: '/Handler/RequestHandling/PurchaseRequestHandler.ashx',
            data: { 'method': 'GetServiceChargeAmt', 'ApplyDate': $('#txtapplydt').val(), 'Scheme_code': scheme_code, 'NAV_Date': self.nav_date(), 'SCharge_Code': '01' },
            contentType: "applicaton/json; character=utf -8",
             async: false,
            success: function (data) {
                if (data.ResponseData.length > 0) {
                    self.Flat_percent(data.ResponseData[0].Flat_percent);
                    self.rate(data.ResponseData[0].rate);

                }
            },
            error: function (err) {
                waitMsg.hide();
                msg(err.status + " - " + err.statusText, "WARNING");
            }
        })
    }
 
    
    self.BOIDValidation = function () {
        var errMsg = "";
        var objFocus = null;
        //#region Validating required fields

        if (Validate.empty(self.Boid_No())) {
            errMsg += "Please Enter BOID!!!<br>";
        }
        else if (self.Boid_No().length < 8) {
            errMsg += "Please Enter 8-digit BOID!!!<br>";
        }
        if (self.SelectedDp() == undefined) {
            errMsg += "Please Select Depository Participants!!!<br>";
        }
        

        //#endregion
        if (errMsg !== "") {

            msg(errMsg, "ALERT");

            return false;
        }
        else {
            return true;
        }
    }

    self.OpenModal= function() {
        if($('#chklogin').prop('checked') && self.IS_UNIT_HOLDER() =='N'){  
          $('#Username').css('display','block');
        }
        else{
        $('#Username').css('display','None');
        }
    }

     self.Is_SIP(false);
       self.ClearApplicationDetail= function(){
       self.APPLY_UNIT(null);
       self.tot_with_face_value(null);
       self.other_charges(null);
       self.SEBON_Fee(null);
       self.charge_amount(null);
       self.tot_with_Nav_value(null);
        self.tot_reqd_amt(null);
       }
    self.ExistingContactNo1 = ko.observable();
    self.ExistingContactNo2 = ko.observable();


   
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
    self.CheckSHolders= function () {
    if (self.BOIDValidation()) {
            var Bo_Account_No = self.SelectedDp().DP_Id_Cds() + self.Boid_No();
            self.Bo_Account_No(Bo_Account_No);
            var url = "/Handler/RequestHandling/ShHolderHandler.ashx";
            var data = { 'method': 'CheckSHolders', 'scheme_code': scheme_code, 'l_company_id': l_company_id, 'Bo_Account_No': self.Bo_Account_No() };
            $.post(url, data,
            function (result) {
            
              waitMsg.hide();
              var data = jQuery.parseJSON(result);
              if(data.IsSucess){
                  if(data.ResponseData.length >0){
                      var SHolder = data.ResponseData[0];
                      self.IS_UNIT_HOLDER(SHolder.IS_UNIT_HOLDER);
                      self.BalUnit(SHolder.BalUnit);
                      self.HasDividend(SHolder.HasDrep);
                      if(SHolder.IS_UNIT_HOLDER =="Y"){
                           $('.Existing').attr("disabled", true);
                           $('.NoneExisting').css('display','block');
                           $('.NoneExistingHeader').css('display','none');
                           if(SHolder.HasDrep == true){   
                                 $('#HasDividend').css('display','none')
                            }
                            else{

                             self.CheckPosted();             
                           }
                       }
                        if(SHolder.IS_UNIT_HOLDER =="N"){
                            $('.Existing').attr("disabled", false);
                            $('.NoneExisting').css('display','block');
                            $('.NoneExistingHeader').css('display','block');
                            document.getElementById("txtfname").focus();
                            $('#HasDividend').css('display','block')
                            
                        }
                   }
               }
              });
        }
    }
//    self.CheckSHolders = function () {
//        if (self.BOIDValidation()) {
//            var Bo_Account_No = self.SelectedDp().DP_Id_Cds() + self.Boid_No();
//            self.Bo_Account_No(Bo_Account_No);

//            var url = "/Handler/RequestHandling/ShHolderHandler.ashx";
//            var data = { 'method': 'GetSHolders', 'scheme_code': scheme_code, 'l_company_id': l_company_id, 'Bo_Account_No': self.Bo_Account_No(), 'ccode': ccode, 'SHHOLDERNO': null };
//            $.post(url, data,
//              function (result) {
//              waitMsg.hide();
//                  var data = jQuery.parseJSON(result);

//                 if(data.IsSucess){
//                  if(data.ResponseData.length >0){
//                      var SHolder = data.ResponseData[0];
//                       $('.Existing').attr("disabled", true);
//                       self.IS_UNIT_HOLDER('Y');
//                        self.Name(SHolder.FName + " " + SHolder.MName + " " + SHolder.LName);
//                        self.MName(SHolder.MName);
//                        self.LName(SHolder.LName);
//                        self.FaName(SHolder.FaName);
//                        self.GFName(SHolder.GFName);
//                   
//                        self.HolderType(SHolder.IsInstitution);
//                        self.ExistingContactNo1(SHolder.P_Tel_No);
//                        self.ExistingContactNo2(SHolder.P_Mobile_no);
//                        self.BalUnit(SHolder.BalUnit);
//                        self.ShHolderNo(SHolder.ShHolderNo);
//                        self.Bank_Account_No(SHolder.Bank_Account_No);
//                        self.BANKCODE(SHolder.BankCode);
//                        self.BRANCHCODE(SHolder.Branch_code);
//                        self.SelectedBank(self.Banks().find(x => x.bankcode() === SHolder.BankCode));
//                        self.SelectedBranch(self.Branches().find(x => x.branch_code() === SHolder.Branch_code));
//                        self.Email_ID(SHolder.Email_ID);
//                        $('.NoneExisting').css('display','block');
//                        $('.NoneExistingHeader').css('display','none');
//                        self.CitizenshipNo(SHolder.Citizenship_No)
//                        self.DOB(SHolder.Eng_DOB)
//                        //self.HasDividend(SHolder.HasDrep);       
//                        if(SHolder.HasDrep == true){   
//                             $('#HasDividend').css('display','none')
//                        }
//                        else{

//                         self.CheckPosted();
//                                       
//                       }
//                  }
//                  else {
//           
//                   $('.Existing').attr("disabled", false);
//                     self.IS_UNIT_HOLDER('N');
//                     self.BalUnit(0);
//                        $('.NoneExisting').css('display','block');
//                        $('.NoneExistingHeader').css('display','block');
//                        document.getElementById("txtfname").focus();
//                        $('#HasDividend').css('display','block')
//                        self.HasDividend(false)
//                  }
//                 
//                  $('.Clicklogin').attr("disabled", false);
//                  }
//                  else
//                  {
//                     msg("Error Occur, Please Try Later !!", "WARNING");
//                     self.SelectedDp(null);
//                     self.Boid_No(null);
//                  }
//              });
//              
//        }
//      }
     
    self.SelectedBank.subscribe(function () {
        if (self.SelectedBank() != undefined) {
            bankcode = ko.toJS(self.SelectedBank().bankcode);
            $('#ddlBankName').css('border-color', '#cccbcb');


            var url = "/Handler/RequestHandling/PurchaseRequestHandler.ashx";
            var data = { 'method': 'GetBranch', 'bankcode': bankcode };
            $.post(url, data,
                function (result) {

                    waitMsg.hide();
                    var obj = jQuery.parseJSON(result);
                    var mappedTasks = $.map(obj.ResponseData, function (item) {
                        return new bank_branch(item)

                    });
                    self.Branches(mappedTasks);
                });
        }
        else{
            self.Branches([]);
        }
    });
     

      self.LoadValue = function () {
  
      self.Is_SIP(false);
       if (self.APPLY_UNIT() != undefined) {
      if(self.AppliedUnitvalidation()){
        

//          if (self.APPLY_UNIT() != undefined) {

              self.other_charges('');
              self.SEBON_Fee('');
              if (self.APPLY_DT() != undefined) {
               
                  var P_Kitta = self.MaxKitta() - self.BalUnit();
                  if (self.Is_SIP() == false) {
                      if (self.APPLY_UNIT() <= P_Kitta) {
                          if (self.APPLY_UNIT() <= self.MaxKitta() && self.APPLY_UNIT() >= self.minkitta()) {
                              self.calculatedata();
                               //document.getElementById("myAnchor").focus();
                          
                            
                          }
                          else {
                              msg("Applied Unit must be less than Max Kitta and greater than Min Kitta", "ALERT");
                              self.ClearApplicationDetail();

                          }
                      }
                      else {
                          msg("Maximum Kitta Exceeded", "ALERT");
                          self.ClearApplicationDetail();

                      }
                  }
                  else {
                      self.calculatedata();
                  }

             }
//              else {
//                  msg("Please Choose Apply Date and Charge Type", "ALERT");
//                  self.ClearApplicationDetail();
//              }
          }
          else{
          self.APPLY_UNIT(null);
          }
          }
      };

     

   Number.prototype.round = function(places) {
  return +(Math.round(this + "e+" + places)  + "e-" + places);
}
    self.calculatedata = function(){
                         var tot_with_face_value = ko.toJS(self.APPLY_UNIT()) * self.face_val();

                        self.tot_with_face_value(parseFloat(tot_with_face_value).toFixed(2));
                            
                        var tot_with_Nav_value =  parseFloat(((ko.toJS(self.APPLY_UNIT()) * self.current_nav())).toFixed(4));
                       
                        self.tot_with_Nav_value(tot_with_Nav_value.round(2));
                        if(self.Flat_percent() =='F')
                        {
                            self.charge_amount(self.rate());
                        }
                        else if(self.Flat_percent() =='P')
                        {
                            var charge_amount = (self.tot_with_Nav_value()) * ((self.rate()) / 100);
                            self.charge_amount(parseFloat(charge_amount).toFixed(2));
                        }
                        self.LoadTotalAmount();
    }

     self.AppliedUnitvalidation = function(){
        var errMsg = "";
        var objFocus = null;
      if (Validate.empty(self.APPLY_DT())) {
            errMsg += "Please Enter Apply Date!!!<br>";
        }
         if(self.Boid_No() != undefined){
            if (self.Boid_No().length < 8) {
                errMsg += "Please Enter 8-digit BOID!!!<br>";
            }
        }
         if (self.SelectedDp() == undefined) {
            errMsg += "Please Select Dp !!!<br>";
        }
        if (Validate.empty(self.Boid_No())) {
            errMsg += "Please Enter BOID!!!<br>";
        }
        if (errMsg !== "") {

            msg(errMsg, "ALERT");

            return false;
        }
        else {
            return true;
        }
      }


    self.LoadTotalAmount = function () {
    if (isNaN(parseFloat(ko.toJS(self.other_charges())))) {
        self.other_charges(25);
    }
    if (isNaN(parseFloat(ko.toJS(self.SEBON_Fee())))) {
        var SEBON_Fee=ko.toJS((0/100)) * self.tot_with_Nav_value();
    self.SEBON_Fee(parseFloat(SEBON_Fee).toFixed(2));
    }
    var tot_reqd_amt = parseFloat(ko.toJS(self.tot_with_Nav_value())) + parseFloat(ko.toJS(self.charge_amount())) + parseFloat(ko.toJS(self.other_charges()))+ parseFloat(ko.toJS(self.SEBON_Fee()));
    self.tot_reqd_amt(parseFloat(tot_reqd_amt).toFixed(2));


}
 self.Close= function(){
         $("#chklogin").prop("checked", false);
  
    }

}
$(document).ready(function () {
    if ($('#BOID').text() != null && $('#BOID').text() != "") {
        ValidateSession();
        ko.applyBindings(new PurchaseEntryViewModel());
    }
    else { ko.applyBindings(new PurchaseEntryViewModel()); }
    ValidatePage();
    var now = new Date();
     maxDate = now.toISOString().substring(0,10);
     $('#Date2').prop('max', maxDate);
     $('#txtapplydt').prop('max', maxDate);
     
   
});
