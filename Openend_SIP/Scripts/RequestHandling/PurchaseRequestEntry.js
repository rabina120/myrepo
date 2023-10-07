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
        self.GatewayCode = ko.observable(data.GatewayCode);
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

function PaymentTypeList(data) {
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
    var Contact_No =  $("#Contact_No").text();
    var ProductIdentity=  BOID.toString();      
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
    self.APPLY_UNIT = ko.observable();
    self.APPLY_DT = ko.observable();
    self.AMOUNT = ko.observable();
    self.P_Tel_No = ko.observable();
    self.HolderType= ko.observable();
    self.Email_ID =  ko.observable();
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
    self.IsPosted = ko.observable();
    //Charges
    self.ChargeTypes = ko.observableArray([]);
    self.SDescription = ko.observable();
    self.SelectedCharge = ko.observable();
    self.Flat_percent = ko.observable();
    self.rate = ko.observable();
    self.Bo_Account_No = ko.observable();
    self.minkitta= ko.observable();
    self.MaxKitta= ko.observable();
    self.IS_UNIT_HOLDER= ko.observable();
    self.BalUnit= ko.observable();
    self.Is_SIP= ko.observable();
    self.ShHolderNo= ko.observable();
    self.MName= ko.observable();
    self.LName= ko.observable();
    self.FaName= ko.observable();
    self.GFName= ko.observable();
     self.UserList  = ko.observableArray([]);
     self.cashorcheque= ko.observable();
     self.BANKCODE = ko.observable();
     self.BRANCHCODE= ko.observable();
     self.Token= ko.observable()

    self.PaymentCode = ko.observable();
    self.PaymentMode = ko.observable();
    self.PaymentStatus = ko.observable();
    self.PaymentFileName = ko.observable();
    self.PaymentTypeLists = ko.observableArray([]);


    self.File1 = ko.observable();
    self.UploadFile = ko.observable();
    self.amtDetail = ko.observable();
    self.othersource=ko.observable();
 
    self.othersource=ko.observable();
    var source;
    self.DREQUEST_NO=ko.observable();
    var SHHOLDERNO = $('#SHHOLDERNO').text();


    self.date  = ko.observable();
    self.CurrDate = ko.observable();

    self.Sh_File=ko.observable();
    self.SubmitStatus= ko.observable();
    self.PayAmount= ko.observable();
     //Payment
    self.TXNID = ko.observable();
    self.Token= ko.observable();
 
     self.idx = ko.observable();
     self.GatewayCode=ko.observable('004');
     self.Integrationcode = ko.observable();

    var PayMarchantId = $("#ContentPlaceHolder1_PayMarchantId").val();
    var PayAppIdLoginUnitPurchase = $("#ContentPlaceHolder1_PayAppIdLoginUnitPurchase").val();

    self.PayMarchantId=ko.observable(PayMarchantId);         
    self.PayAppId=ko.observable(PayAppIdLoginUnitPurchase);  

    self.PayAppName=ko.observable('Purchase Req Entry');
    self.PayTxnDate=ko.observable();
    self.PayTxnCurency=ko.observable('NPR');
    self.PayTxnAmount=ko.observable();
    self.PayRefId=ko.observable();
    self.PayRemarks=ko.observable(" Unit Purchase");
    self.PayParticulars=ko.observable("Paid to Nibl Ace Capital");
    self.PayToken=ko.observable('TOKEN');
    self.ProofFileName = ko.observable();

    //For E-Banking 
    self.BankId = ko.observable('004');                            
    self.MD = ko.observable('P');    
    self.CRN = ko.observable('NPR');                             
    self.CG = ko.observable('N');
    self.USER_LANG_ID = ko.observable('001');
    self.UserType = ko.observable('1');
    self.AppType = ko.observable('retail');
    self.ITC = ko.observable();
    self.NavValidation=ko.observable(false);

 
    var LoginUnitPurchaseURL = $("#ContentPlaceHolder1_LoginUnitPurchaseURL").val(); // To Pass URL Link of mutual fund
    self.TestURL = ko.observable(LoginUnitPurchaseURL);    // To Pass URL Link of mutual fund
    self.RU = ko.observable(self.TestURL());
 

    self.status = ko.observable();
    self.statusDesc = ko.observable();

    var resbankid = $("#ContentPlaceHolder1_resbankid").val();
    var respref = $("#ContentPlaceHolder1_respref").val();
    var resamount = $("#ContentPlaceHolder1_resamount").val();
    var resbid = $("#ContentPlaceHolder1_resbid").val();
    var rescustreftype = $("#ContentPlaceHolder1_rescustreftype").val();

    self.HasDividend = ko.observable(false)
    $('#HasDividend').css("display", 'block')

    var Khaltiref = $("#ContentPlaceHolder1_Khaltiref").val();
    var ConnectIpsiref = $("#ContentPlaceHolder1_ConnectIpsiref").val();
    var EBankingPID = $("#ContentPlaceHolder1_EBankingPID").val();
    self.PID = ko.observable(EBankingPID);   //To Pass PID
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
            async: false,
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

   $('input[name="optionsRadios"]').change(function () {
   
        if ($('#Radio7').prop('checked')) {
         $('#other').css('display','inline');   
          $('#other1').css('display','inline');   
        }
        else{
              $('#other').css('display','none');  
              self.othersource('');
               $('#other1').css('display','none');   
        }
    });
    
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
    self.LoadScheme = function () {
     $.ajax({
                dataType: "json",
                url: '/Handler/Security/LoginHandler.ashx',
                async: true,
                data: { 'method': 'LoadSchemes' ,'l_company_id': l_company_id, 'ccode':ccode},
                contentType: "application/json; charset=utf-8",
                async: false,
                success: function (result) {
                var mappedTasks = $.map(result.ResponseData, function (item) {
                return new ParaComp(item)
                });
              
                self.Schemes(mappedTasks); 
                self.SelectedScheme(self.Schemes().find(x => x.scheme_code() == "001"));
                self.face_val(self.SelectedScheme().PerShVal());
                self.minkitta(self.SelectedScheme().minkitta());
                self.MaxKitta(self.SelectedScheme().MaxKitta());
                self.GetValue();
                },
                error: function (err) {
                    waitMsg.hide();
                    msg(err.status + " - " + err.statusText, "FAILURE");
                }
                });

    }
    self.LoadScheme();
      
    
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

 
      self.GetBank = function () {
        var url = "/Handler/RequestHandling/PurchaseRequestHandler.ashx";
        var data = { 'method': 'GetBank' };
        $.post(url, data,
            function (result) {
                waitMsg.hide();
                var obj = jQuery.parseJSON(result);
               
                var mappedTasks = $.map(obj.ResponseData, function (item) {
                    return new Bank(item)

                });
                self.Banks(mappedTasks);

            });

    }
    self.GetBank();
    self.LoadDp = function () {

        var url = "/Handler/RequestHandling/PurchaseRequestHandler.ashx";
        var data = { 'method': 'GetDPInfo' };
        $.post(url, data,
            function (result) {
                waitMsg.hide();
                var obj = jQuery.parseJSON(result);
                var mappedTasks = $.map(obj.ResponseData, function (item) {
                    return new DPCharge(item)
                });

                self.Depo(mappedTasks);
                 if($('#BOID').text() != undefined &&$('#BOID').text() != ""){
                     self.Boid_No(($('#BOID').text()).substr(8,16));
                    var dpcode = ($('#BOID').text()).substr(0,8);
                    self.SelectedDp(self.Depo().find(x => x.DP_Id_Cds() === dpcode));
                    }

            });

    }
    self.LoadDp();
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
                        msg("UserName Address already exists !!!");
                        self.UserName('');

                    }
                }
            });
        }
    }
    self.validateEmailaddress = function () {
        if (self.Email() != undefined) {
            $.ajax({
                dataType: "json",
                url: '/Handler/Security/EmailHandler.ashx',
                async: true,
                data: { 'method': 'validateEmailaddress', 'Email': ko.toJS(self.Email()) },
                contentType: "application/json; charset=utf-8",
                async: false,
                success: function (result) {
                
                    var count = result.ResponseData.length;
                    self.CheckEmail();
                    if (count == 1) {
                        msg("Email Address already exists !!!");
                        self.Email('');

                    }
                }
            });
        }
    }
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

    self.CheckEmail = function () {
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
    self.Paymentvalidation = function(){
        var errMsg = "";
        var objFocus = null;
        //#region Validating required fields
        if ($('#Radio7').prop('checked')) {
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
        
        if (Validate.empty(self.Name())) {
            errMsg += "Please Enter Name!!!<br>";
        }
       if (Validate.empty(self.APPLY_UNIT())) {
            errMsg += "Please Enter Apply Unit!!!<br>";
        }
         if (Validate.empty(self.amtDetail())) {
            errMsg += "Please Choose Source Amount!!!<br>";
        }
        if (Validate.empty(self.APPLY_DT())) {
            errMsg += "Please Enter Apply Date!!!<br>";
        }
//         if(self.payeename() != undefined && self.payeename() != ""){
//            if(self.Name() != undefined && self.Name() != ""){
//                var upperPayee = self.payeename().toUpperCase();
//                var uppername = self.Name().toUpperCase()
//                upperPayee = upperPayee.split(/\s/).join('');
//                uppername = uppername.split(/\s/).join('');
//          
//                if( uppername != upperPayee){
//                    if (self.File1() == undefined || self.File1() == "") {
//                      errMsg += "Please Enter Proof of Evidence !!!<br>";
//                   }
//       
//               }
//           }
//        }else{
//             errMsg += "Please Enter Payee Name !!!<br>";
//        }
        //#endregion
        if (errMsg !== "") {

            msg(errMsg, "ALERT");

            return false;
        }
        else {
            return true;
        }
    }
     self.HolderCollection= function(){
     msg("Payment Success", alert);
       self.AMOUNT(self.tot_reqd_amt());
     $("#tblpaymentmode").modal('hide');
     $('.Submit').attr('disabled',true);
     $('#loginView').css('display','inline');  
  $('#BtnSave').attr('disabled',false);
     
    }
    self.openpage = function(){
        var objFra = window.open('../../Modules/Ebanking.aspx', '_blank');
     }
     self.ViewFile = function (value) {
            
                self.Sh_File(null);
                self.Sh_File("data:image/jpeg;base64," + ko.toJS(value.File1));
                $("#ViewSign").modal('show');
            }

     self.ValidateNAV = function () {
     var url ="../../Handler/RequestHandling/PurchaseRequestHandler.ashx";
     var data = { 'method': 'ValidateNAV', 'APPLY_DT': $('#txtapplydt').val(),'Amount':ko.toJS(self.tot_reqd_amt()),'APPLY_UNIT': ko.toJS(self.APPLY_UNIT())};
     $.post(url, data,
         function (result) {
         var obj = jQuery.parseJSON(result);
         if(obj.IsSucess){
         self.NavValidation(obj.IsSucess);
            // msg("OTP Verified Successfully","ALERT")   
        }  
         else{
          self.NavValidation(obj.IsSucess);
          //msg("Oops! Something went wrong. Please try again later","ALERT") 
          
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
                         su.setAttribute('value', LoginUnitPurchaseURL+'?q=su');
                    
                    form.appendChild(su);

                     //--fu --
                     var fu =document.createElement('input');
                         fu.setAttribute('type', 'hidden');
                         fu.setAttribute('name', 'fu');
                         fu.setAttribute('id', 'fu');
                         fu.setAttribute('value',LoginUnitPurchaseURL+'?q=fu');
                    
                  form.appendChild(fu);
                  document.body.appendChild(form);
                  form._submit_function_(); 
     }
var countsavedata =0;
    self.SaveData= function(PaymentCode){
      waitMsg.show();
      self.PaymentCode(PaymentCode);
    var Boid =ko.toJS(self.SelectedDp().DP_Id_Cds())+ko.toJS(self.Boid_No);
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
                                Email_ID:$('#Email').text(),
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
                                CashAmount:self.tot_reqd_amt(),
                                ChequeAmount:self.tot_reqd_amt(),
                                Is_SIP:'false',
                                TranType:'02',
                                Status:'1',
                                source : source,
                                File1:self.File1(),
                                FileName1: self.ProofFileName(),
                                GatewayCode: self.GatewayCode(),
                                HasDrep : self.HasDividend()

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
                                      sessionStorage.setItem("prooffilename", self.ProofFileName());

                                      localStorage.setItem("REQUEST_NO", self.DREQUEST_NO());
                                      localStorage.setItem("TXNID", self.TXNID());
                                      localStorage.setItem("ProofFileName", self.ProofFileName());
 
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
                                   
                                });    
         
     }




  self.UpdateToken = function(payload){
        var url = "../../Handler/RequestHandling/PurchaseRequestHandler.ashx" ;
        var data = { 'method': 'UpdateToken', 'TXNID': self.TXNID(), 'Action':'A', 'Token': self.Token() };
                            $.post(url, data,
                                function (result) {
                        });
   }


      //To open Khalti payment form with Config
 var config = {
            "publicKey": Khaltiref,
            "productName": "Unit Purchase by login",
            "productUrl": LoginUnitPurchaseURL,
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

    
     var checkout = new KhaltiCheckout(config);
    
    $(document).on('click', '#payment-button', function () {
      
        self.PaymentCode('09');
        waitMsg.show();
       self.Integrationcode('09');   
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
                                Email_ID:$('#Email').text(),
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
                                CashAmount:self.tot_reqd_amt(),
                                ChequeAmount:self.tot_reqd_amt(),
                                Is_SIP:'false',
                                TranType:'02',
                                Status:'1',
                                source : source,
                                File1:self.File1(),
                                FileName1: self.ProofFileName(),
                                GatewayCode: self.GatewayCode(),
                                HasDrep : self.HasDividend()

                            };
                             var url = "../../Handler/RequestHandling/PurchaseRequestHandler.ashx" ;
                            var data = { 'method': 'SavePurchaseEntry', 'args': JSON.stringify(ko.toJS((args))) };
                            $.post(url, data,
                                function (result) {
                                 var obj = jQuery.parseJSON(result);
                                   waitMsg.hide();
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
                                      sessionStorage.setItem("prooffilename", self.ProofFileName());

                                      localStorage.setItem("REQUEST_NO", self.DREQUEST_NO());
                                      localStorage.setItem("TXNID", self.TXNID());
                                      localStorage.setItem("ProofFileName", self.ProofFileName());

                                      var amt=((parseFloat(self.tot_reqd_amt()))*100);
                                      checkout._config.productIdentity =ProductIdentity;
                                      // minimum transaction amount must be 10, i.e 1000 in paisa.
                                       checkout.show({amount: amt});
                                      }
                                      else{
                                       self.ClearControls();
                                       msg("Not Responding Please Try Later", alert);
                                       self.ClearControls();
                                      }
                                });

    });
    
//To verify Khalti Payment
 function VerifyKhaltiPayment(payload) {
    waitMsg.show();
    var paymentdata = {
        GatewayCode: self.GatewayCode(),
        TXNID:self.TXNID(),
        referenceId : self.DREQUEST_NO(),
        amount: payload.amount,
        idx:payload.idx,  //For VendorTXNID
        token: payload.token         
    }

     
    var url = '../../Handler/Collection/CollectionHandler.ashx';
     var data = { 'method': 'VerifyKhaltiPayment', 'data': JSON.stringify(ko.toJS(paymentdata)) ,
                 'Action': 'U',
                 'GatewayCode': self.GatewayCode(),
                 'TXNID':self.TXNID(),
                 'ReferenceID':ko.toJS(self.SelectedDp().DP_Id_Cds())+ko.toJS(self.Boid_No),
                 'IntegrationCode':self.PaymentCode(),
                  'PaymentCode':self.PaymentCode(),
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
            $('#PaymentType').modal('hide'); 
            waitMsg.hide1(); 
            waitMsg.hide();          
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
                    ',REMARKS='+  ko.toJS(self.SelectedDp().DP_Id_Cds()) + ko.toJS(self.Boid_No) + self.PayRemarks() +
                    ',PARTICULARS='+ self.PayParticulars() +
                    ',TOKEN='+ self.PayToken() ;
                   

                
                waitMsg.show();
                let url = '../../Handler/Collection/CollectionHandler.ashx';
                let data = { 'method': 'GetToken', 'data': payData };
                $.post(url, data, result => {
                    var obj = JSON.parse(result);
                    waitMsg.hide();
                     
               
                var token=obj.data;
                var method ='POST';
                var form = document.createElement('form');

               var url=ConnectIpsiref;
               
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

   



    self.Validation = function(){
     var errMsg = "";
     var objFocus = null;
     if ($('#Radio7').prop('checked')) {
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
        
        if (Validate.empty(self.Name())) {
            errMsg += "Please Enter Name!!!<br>";
        }
       if (Validate.empty(self.APPLY_UNIT())) {
            errMsg += "Please Enter Apply Unit!!!<br>";
        }
       if (Validate.empty(self.APPLY_DT())) {
            errMsg += "Please Enter Apply Date!!!<br>";
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
  var count = 0;
   self.SavePurchaseEntry = function(){
   if( self.SubmitStatus()  == "SUCCESS" || self.SubmitStatus()  == "Completed" ) {
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
       Confirm("Do you want to submit your request ?", 'Confirmation Dialog', function (r) {
                        if (r) {
                         waitMsg.show1();
                                var args = {
                                l_company_id:l_company_id,
                                scheme_code:scheme_code,
                                ccode: ccode,
                                REQUEST_NO: self.REQUEST_NO(),
                                DREQUEST_NO:self.DREQUEST_NO(),
                                Email_ID:self.Email_ID(),
                                ShHolderNo: self.ShHolderNo(),
                                FName: self.Name(),
                                LName: self.LName(),
                                FaName: self.FaName(),
                                GFName: self.GFName(),
                                address: null,
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
                                cashorcheque:self.cashorcheque(),
                                APPROVED: "N",
                                other_charges: self.other_charges(),
                                SEBON_Fee: self.SEBON_Fee(),
                                SCharge_Code:self.SelectedCharge().SCharge_Code(),
                                Action: 'A',  
                                cname:null,
                                IsChequeClear:null,
                                ClearedDate:null,
                                ChequeCheckedBy:null,
                                CashAmount:self.AMOUNT(),
                                ChequeAmount:self.AMOUNT(),
                                Is_SIP:'false',
                                TranType:'02',
                                status:'1',
                                source : self.amtDetail(),
                                File1:"data:image/jpeg;base64," + ko.toJS(self.File1()),
                                GatewayCode: self.GatewayCode(),
                                HasDrep : self.HasDividend()
                            };

                            //self.UserList.push(args);
                            $.ajax({
                                    dataType: "json",
                                    url: "../../Handler/RequestHandling/PurchaseRequestHandler.ashx",
                                    async: true,
                                    data: { 'method': 'SavePurchaseEntry', 'args': JSON.stringify(args)  },
                                    contentType: "application/json; charset=utf-8",
                                    async: false,
                                    success: function (result) {
                                        if ((result.IsSucess)) {
                                           waitMsg.hide1();
                                             // waitMsg.hide();
                                            msg("Request Sent Successfully", alert);
                                            self.PrintPurchasenEntry(args)
                                           self.UserList([]);
                                         
                                           self.ClearControls();
                                        }
                                    },
                                    error: function (err) {
                                        waitMsg.hide1();
                                        waitMsg.hide();
                                        msg(err.status + " - " + err.statusText, "FAILURE");
                                        self.UserList([]);
                                        self.ClearControls();
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
    self.PrintPurchasenEntry = function (data) {
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



    self.ClearControls=function(){
    self.amtDetail(null);
    self.HolderType(null);
    self.APPLY_DT('');
    self.current_nav(null);
    self.APPLY_UNIT('');
    self.tot_with_face_value(null);
    self.other_charges(null);
    self.SEBON_Fee(null);
    self.charge_amount(null);
    self.tot_with_Nav_value(null);
    self.tot_reqd_amt(null);
    self.AMOUNT(null);
    self.othersource(null);
    self.amtDetail(null);
    sessionStorage.clear();
    self.NavValidation(false);
    self.ProofFileName(null);
    self.File1(null);
    $('#other, #other1').css('display','none');  
    $('#btnProceed,#btnCancel, .Submit').attr('disabled', false);
    $('#BtnSave').attr('disabled', true);
     $('#ProofFileName').css('display', 'none');
    $('#ImgFile1').css('display', 'inline');
    window.history.replaceState("object or string", "Title", self.TestURL());
    location.reload();
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

                       // if (self.CurrDate() >= self.startdate() && self.CurrDate() <= self.Enddate() && day != 5 && day != 6){
                        self.current_nav(data.ResponseData[0].nav_value);
                        self.nav_date(data.ResponseData[0].nav_date);
                        self.GetServiceChargeAmt();
//                        }
//                        else
//                        {
//                            var msg1= '<u><b>Unit Purchase Session Open Time:</b></u><br/>'
//                            msg1 +='Sunday to Thursday 11 AM to 3 PM<br/>';
//                            msg1 += '<span style="color:red">*</span>Session Shall be remain closed on Friday, Saturday and all public holidays.<br>' 
//                            msg(msg1, alert);
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
            data: { 'method': 'GetServiceChargeAmt', 'ApplyDate': self.APPLY_DT(), 'Scheme_code': scheme_code, 'NAV_Date': self.nav_date(), 'SCharge_Code': '01' },
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
        }
        else {
            return true;
        }
    }

    self.OpenModal= function(){
        if($('#chklogin').prop('checked')){
             $("#modalShHolder").modal('show');
        }
    }

    self.ClearApplicationDetail= function(){
       self.APPLY_UNIT(null);
       self.tot_with_face_value(null);
       self.other_charges(null);
       self.SEBON_Fee(null);
       self.charge_amount(null);
       self.tot_with_Nav_value(null);
        self.tot_reqd_amt(null);
        
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
                    if (CheckBoid.Status == "UNPOSTED"){
                        self.IsPosted("UNPOSTED");
                        $('#HasDividend').css('display','none') 
                    }
                    else{
                       $('#HasDividend').css('display','block') 
                    }
            } 
            else {
            }
        });
    }

        if (self.BOIDValidation()) {
            var Bo_Account_No = self.SelectedDp().DP_Id_Cds() + self.Boid_No();
            self.Bo_Account_No(Bo_Account_No);
            var url = "/Handler/RequestHandling/ShHolderHandler.ashx";
            var data = { 'method': 'GetSHolders', 'scheme_code': scheme_code, 'l_company_id': l_company_id, 'Bo_Account_No': self.Bo_Account_No(), 'ccode': ccode, 'SHHOLDERNO': null };
            $.post(url, data,
              function (result) {
            
                  var data = jQuery.parseJSON(result);
                   if(data.IsSucess){
                  if(data.ResponseData.length >0){
                      var SHolder = data.ResponseData[0];
                      $('.Existing').attr("disabled", true);
                        self.Name(SHolder.FName + " " + SHolder.MName + " " + SHolder.LName);
                        self.MName(SHolder.MName);
                        self.LName(SHolder.LName);
                        self.FaName(SHolder.FaName);
                        self.GFName(SHolder.GFName);
                        self.P_Tel_No($("#Contact_No").text());
                        self.P_Mobile_no($("#Contact_No2").text());
                        self.IS_UNIT_HOLDER('Y');
                        self.BalUnit(SHolder.BalUnit);
                        self.ShHolderNo(SHolder.ShHolderNo);
                        self.Bank_Account_No(SHolder.Bank_Account_No);
                        self.BANKCODE(SHolder.BankCode);
                        self.Email_ID(SHolder.Email_ID);
                        self.BRANCHCODE(SHolder.Branch_code);
                        self.HolderType(SHolder.IsInstitution);
                        self.SelectedBank(self.Banks().find(x => x.bankcode() === SHolder.BankCode));
                        self.SelectedBranch(self.Branches().find(x => x.branch_code() === SHolder.Branch_code));
                       // self.HasDividend(SHolder.HasDrep);
                        if(SHolder.HasDrep == true){
                              $('#HasDividend').css('display','none')
                        }
                        else{
                            self.CheckPosted();
                            
                                            
                      }
                  }
                  else {
                     $('.Existing').attr("disabled", false);
                     self.IS_UNIT_HOLDER('N');
                     self.BalUnit(0);
                     $('#HasDividend').css('display','block')
                     self.HasDividend(false)
                                            
                       
                  }
                  }
                  else
                  {
                     msg("Error Occur, Please Try Later !!", "WARNING");
                    self.APPLY_UNIT(null);
                      //for clear
                      self.ClearApplicationDetail();
                  }
              });
        }
   self.GetData = function(){
    var REQUEST_NO= self.DREQUEST_NO();
    if(REQUEST_NO != undefined || REQUEST_NO!="" ){
        waitMsg.show();
     $.ajax({
                type: "GET",
                dataType: "json",
                cache: false,
                async: true,
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
                            self.Bank_Account_No(SHolder.Bank_Account_No);
                            self.APPLY_UNIT(SHolder.APPLY_UNIT);
                            self.BalUnit(SHolder.TotalKitta);
                            self.IS_UNIT_HOLDER(SHolder.IS_UNIT_HOLDER);
                            self.APPLY_DT(SHolder.APPLY_DT);
                            self.GetNavValue();

                            $('#txtapplydt').val(SHolder.APPLY_DT);
                            self.cashorcheque(SHolder.cashorcheque); 
                            self.nav_date(SHolder.nav_date);
                            self.charge_amount(SHolder.charge_amount);
                            self.remarks(SHolder.remarks);

                            self.other_charges(SHolder.other_charges);
                            self.SEBON_Fee(SHolder.SEBON_Fee);                                                        
                            var bankcode = SHolder.BankCode;
                            self.SelectedBank(self.Banks().find(x => x.bankcode() === SHolder.BankCode));
                            self.SelectedBranch(self.Branches().find(x => x.branch_code() === SHolder.Branch_code));
                            self.Email(SHolder.Email_ID);
                            self.File1(SHolder.File1);
                            self.ProofFileName(SHolder.FileName1);
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


                            }
                            else{
                                self.HolderType(false);
                                $('#Individual').prop('checked', true);
                            }
                            if(self.IS_UNIT_HOLDER() =='Y')
                            {
                               $('.NoneExistingHeader').css('display','none');
                            }
                            self.tot_with_face_value(self.APPLY_UNIT()*self.face_val());
                            self.tot_with_Nav_value(self.APPLY_UNIT()*self.current_nav());
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


     self.GTotal = ko.observable();
    self.ValidateAmount = function () {
        ValidatePage();
    var RE =getUrlParamVal('TXNID');
     $.ajax({
              type: "GET",
                dataType: "json",
                cache: false,
                async: true,
                url: '/Handler/RequestHandling/PurchaseRequestHandler.ashx',
                data: { 'method': 'ValidateAmount', 'TXNID': self.TXNID()},
                contentType: "applicaton/json; character=utf -8",
                async: false,
                success: function (obj) {
                 var PayTxnAmount= obj.ResponseData[0].AMOUNT;
                self.PayAmount(obj.ResponseData[0].AMOUNT);
                self.DREQUEST_NO(obj.ResponseData[0].DREQUEST_NO);
                self.Bo_Account_No(obj.ResponseData[0].Bo_Account_No);
                self.GatewayCode(obj.ResponseData[0].GatewayCode);
                self.PaymentCode(obj.ResponseData[0].cashorcheque);
                self.GTotal((parseFloat(PayTxnAmount))*100);
                self.AMOUNT(parseFloat(PayTxnAmount).toFixed(2));
                }
            });
    }

     //Get Transaction ID in URL  with verify Connect IPS Payment Data
    if( getUrlParamVal('TXNID') != undefined && getUrlParamVal('TXNID') !=""){
      var RE =getUrlParamVal('TXNID');
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
                            
                                            var dataObj=JSON.parse(obj.data);
                                               waitMsg.hide();
                                              
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
                                                     $('#loginView').css('display','block');
                                                     waitMsg.hide1();
                                                     window.history.replaceState("object or string", "Title", self.TestURL());                                                    
                                                 }
                                                 else
                                                 {

                                                    sessionStorage.clear();
                                                     
                                                  msg(dataObj.statusDesc,alert);
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
                                                 msg(obj.Message);
                                                 waitMsg.hide1();
                                               }

                                                 setTimeout(function(){ 
              
                                                  $('#popup_ok').removeAttr('disabled');
                                                 
                                                 }, 100);

                                           });
                                                }

                                   });
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
        //  form.appendChild(br.cloneNode());  
  
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
        // AMTData.setAttribute('VALUE',self.PayTxnAmount());
        AMTData.setAttribute('VALUE', self.tot_reqd_amt())
        form.appendChild(AMTData);

        document.body.appendChild(form);
        form._submit_function_();

    }
    if (getUrlParamVal('q') != undefined && getUrlParamVal('q') != "") {
        ValidatePage();
if( getUrlParamVal('q') =="su"){
        waitMsg.show();
        self.TXNID(getUrlParamVal('oid'));
        self.ValidateAmount();
        self.Token(getUrlParamVal('refId'));
        self.UpdateToken();
        var resData = {
            PREF: getUrlParamVal('oid'),
           // AMOUNT: self.AMOUNT(),
            AMOUNT: getUrlParamVal('amt'),
            BID: getUrlParamVal('refId'),
            CustRefType: getUrlParamVal('oid'),
            scd: Esewascd 
        }
        var url = '../../Handler/Collection/CollectionHandler.ashx';
        var data = { 'method': 'VerifyEsewaTransaction', 'data': JSON.stringify(resData), 'Action': 'E', 'GatewayCode': self.GatewayCode(), 'PaymentCode': '12' };
        $.post(url, data, result => {
            var obj = JSON.parse(result);
            if (obj.IsSucess) {
             if(obj.data =="SUCCESS"){
                 msg('Transaction has been Sucessfull', alert);
                 self.GetData();
                 self.SubmitStatus(obj.data);
                 waitMsg.hide();
                 $('.Hidden').css('display', 'none');
                 $('.Submit').attr('disabled', 'disabled');
                 $('#btnProceed,#btnCancel').attr('disabled', true);
                 $('#BtnSave').attr('disabled', false);
                 if(self.IS_UNIT_HOLDER()=='N'){
                     $('#loginView').css('display','block');
                 }
                 $('#PaymentType').modal('hide');                  
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

                    var TXNID = localStorage.getItem("TXNID") ? sessionStorage.getItem("TXNID") : localStorage.getItem("TXNID");
                    var DREQUEST_NO = localStorage.getItem("REQUEST_NO") ? sessionStorage.getItem("REQUEST_NO") : localStorage.getItem("REQUEST_NO");
                    self.DREQUEST_NO(DREQUEST_NO);     
                    self.GetData();
                    msg('Transaction has been Sucessfull', alert);
                    self.SubmitStatus(self.status());               
                    self.AMOUNT(resamount);
                    $('.Hidden').css('display', 'none');
                    $('.Submit').attr('disabled', 'disabled');
                    $('#btnProceed,#btnCancel').attr('disabled', true);
                    $('#BtnSave').attr('disabled', false);
                    $('#loginView').css('display', 'block');
                    $('#PaymentType').modal('hide');
                    window.history.replaceState("object or string", "Title", self.TestURL());
                }
                else {

                    var TXNID = sessionStorage.getItem("TXNID");
                    var DREQUEST_NO = sessionStorage.getItem("DREQUEST_NO");
                    self.DREQUEST_NO(DREQUEST_NO);
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
      self.Is_SIP(false);
       
      self.LoadValue = function () {
           self.Is_SIP(false);
      if(self.AppliedUnitvalidation()){
              self.other_charges('');
              self.SEBON_Fee('');
              if (self.APPLY_DT() != undefined) {
               
                  var P_Kitta = self.MaxKitta() - self.BalUnit();
                  if (self.Is_SIP() == false) {
                      if (self.APPLY_UNIT() <= P_Kitta) {
                          if (self.APPLY_UNIT() <= self.MaxKitta() && self.APPLY_UNIT() >= self.minkitta()) {
                              self.calculatedata();
                          }
                          else {
                              msg("Applied Unit must be less than Max Kitta and greater than Min Kitta", "ALERT");
                              self.APPLY_UNIT(null)
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
          }
          else{
          self.APPLY_UNIT(null);
          }
      };

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
  
}

$(document).ready(function () {
           
           validLoginUser();
           ValidateSession();          
           ko.applyBindings(new PurchaseEntryViewModel());

     var now = new Date();
     maxDate = now.toISOString().substring(0,10);
     $('#txtapplydt').prop('max', maxDate);       
});
