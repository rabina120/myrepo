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

function ShHolder(data) {
    var self = this;
    if (data != undefined) {
        self.scheme_code = ko.observable(data.scheme_code);
        self.l_company_id = ko.observable(data.l_company_id);
        self.ccode = ko.observable(data.ccode);
        self.Interval_Seq_No = ko.observable(data.Interval_Seq_No);
        self.ShHolderNo = ko.observable(data.ShHolderNo);
        self.Sip_amt = ko.observable(data.Sip_amt);
        self.Action_Date = ko.observable(data.Action_Date);
        self.SIP_Reg_No = ko.observable(data.SIP_Reg_No);
        self.Name=ko.observable(data.Name);
        self.Contact2=ko.observable(data.Contact2);
        self.Contact1=ko.observable(data.Contact1);
        self.ReceivedAmt=ko.observable(data.Received_Amount);
        self.BalanceAmt=ko.observable(data.BalanceAmt);
        self.SIP_Due_Day=ko.observable(data.SIP_DueDay);
        self.boid=ko.observable(data.boid);
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

var SipPaymentViewModel = function () {
    var self = this;

     self.scheme_code = ko.observable();
    self.l_company_id = ko.observable();
    self.ccode = ko.observable();
    self.Interval_Seq_No = ko.observable();
    self.ShHolderNo = ko.observable();
    self.Sip_amt = ko.observable();
    self.SIP_Reg_No = ko.observable();
    self.Name=ko.observable();

    self.PaymentCode=ko.observable();
    self.PaymentMode = ko.observable();
    self.PaymentStatus = ko.observable();
    self.PaymentFileName = ko.observable();
    self.PaymentTypeLists = ko.observableArray([]);

    self.BalanceAmt=ko.observable();
    self.SIP_Due_Day=ko.observable();
    self.ShHolderNo=ko.observable();
    self.ReceivedAmt=ko.observable();
    self.Contact2=ko.observable();
    self.Contact1=ko.observable();
    self.UserList=ko.observableArray([]);
    self.ShHolders= ko.observableArray([]);
    //For DP

    self.Depo = ko.observableArray([]);
    self.DPName = ko.observable();
    self.SelectedDp = ko.observable();
    self.Depo = ko.observable();
    self.DP_Id_Cds = ko.observable();
    self.Boid_No= ko.observable();
     //Scheme
    self.scheme_code = ko.observable();
    self.SchemeEnName = ko.observable();
    self.SelectedScheme = ko.observable();
    self.Schemes = ko.observableArray();

    self.BOID = ko.observable();
    self.boid = ko.observable();
    self.Bo_Account_No = ko.observable();
    self.InstallDate = ko.observable();
    self.Action = ko.observable();
    self.GTotal= ko.observable();
    self.date = ko.observable();
    self.PaymentCode=ko.observable();
    self.idx = ko.observable();
    self.GatewayCode=ko.observable('006');
   
   var username = $("#username").text(); // logged in user 
    var ccode = '1000' // Distribution center id
    var scheme_code = '001'; /// company id 
    var date = $("#date").text();
    var UserId = $('#UserId').text();
    var l_company_id = '001';
    var BOID =  $('#BOID').text();
    var Contact_No =  $("#Contact_No").text();          
    var Contact_No2 = $("#Contact_No2").text();
    var ProductIdentity=  BOID.toString();   
    var Name = $("#Name").text();
    self.Name= ko.observable();
    self.Name(Name);
    self.TXNID = ko.observable();
    self.TotalAmount=ko.observable();

    var PayMarchantId = $("#ContentPlaceHolder1_PayMarchantId").val();
    var PayAppIdLoginSIPPayment = $("#ContentPlaceHolder1_PayAppIdLoginSIPPayment").val();
    self.PayMarchantId=ko.observable(PayMarchantId);         
    self.PayAppId=ko.observable(PayAppIdLoginSIPPayment);  

    self.PayAppName=ko.observable('SIP Payment By Login');
    self.PayTxnDate=ko.observable();
    self.PayTxnCurency=ko.observable('NPR');
    self.PayTxnAmount=ko.observable();
    self.PayRefId=ko.observable();
    self.PayRemarks=ko.observable(" SIP Payment");
    self.PayParticulars=ko.observable("Paid to Nibl Ace Capital");
    self.PayToken=ko.observable('TOKEN');
    self.trans_no=ko.observable();
    self.SubmitStatus=ko.observable();
    self.AMOUNT=ko.observable();
    
    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = today.getFullYear();

     today = yyyy+ '-'+ mm + '-' + dd;
    paydate =dd+'-'+mm+'-'+yyyy;
    self.date(today);
    self.PayTxnDate(paydate);
    self.Token= ko.observable();

    //For E-Banking 
    
    self.BankId = ko.observable('004');                             
    self.MD = ko.observable('P');   
    self.CRN = ko.observable('NPR');                           
    self.CG = ko.observable('N');
    self.USER_LANG_ID = ko.observable('001');
    self.UserType = ko.observable('1');
    self.AppType = ko.observable('retail');
    self.ITC = ko.observable();    

    var LoginSIPPaymentURL = $("#ContentPlaceHolder1_LoginSIPPaymentURL").val();
    self.TestURL =  ko.observable(LoginSIPPaymentURL); // To Pass URL Link of mutual fund
    self.RU =  ko.observable(self.TestURL());


    self.status = ko.observable();
    self.statusDesc = ko.observable();

    var resbankid = $("#ContentPlaceHolder1_resbankid").val();
    var respref = $("#ContentPlaceHolder1_respref").val();
    var resamount = $("#ContentPlaceHolder1_resamount").val();
    var resbid = $("#ContentPlaceHolder1_resbid").val();
    var rescustreftype = $("#ContentPlaceHolder1_rescustreftype").val();

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
                },
                error: function (err) {
                    waitMsg.hide();
                    msg(err.status + " - " + err.statusText, "FAILURE");
                }
                });

    }
    self.LoadScheme();
        self.LoadDp = function () {
     $.ajax({
                dataType: "json",
                url: "/Handler/RequestHandling/PurchaseRequestHandler.ashx",
                async: true,
                data: { 'method': 'GetDPInfo' },
                contentType: "application/json; charset=utf-8",
                async: false,
                success: function (result) {
                var mappedTasks = $.map(result.ResponseData, function (item) {
                return new DPCharge(item)
                });
              
                self.Depo(mappedTasks); 
                 if($('#BOID').text() != undefined &&$('#BOID').text() != ""){
                     self.Boid_No(($('#BOID').text()).substr(8,16));
                    var dpcode = ($('#BOID').text()).substr(0,8);
                   
                    self.SelectedDp(self.Depo().find(x => x.DP_Id_Cds() === dpcode));
                    //document.getElementById("select2-dp-container").innerHTML=ko.toJS(self.SelectedDp().DPName);
                    }
                },
                error: function (err) {
                    waitMsg.hide();
                    msg(err.status + " - " + err.statusText, "FAILURE");
                }
                });

    }
    self.LoadDp();
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
        if (self.BOID() != undefined) {
            if (self.BOID().length < 8) {
                errMsg += "Please Enter 8-digit BOID!!!<br>";
            }
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
     var Sum =0;
    
   var Sum =0;
    
   self.CheckSHolders = function () {
  self.ShHolders([]);
   self.TotalAmount(null);
    Sum=0;
      if (self.BOIDValidation()) {
            var Bo_Account_No = BOID;
            self.Bo_Account_No(Bo_Account_No);
            var url = "../../Handler/SIPHandling/SIPPayment.ashx";
            var data = { 'method': 'GetActionDate', 'BOID': self.Bo_Account_No() };
            $.post(url, data,
              function (result) {
                $('#tblfund').DataTable().destroy();
                   $('#tblfund tbody').empty();
                  var data = jQuery.parseJSON(result);
                  if (data.ResponseData.length > 0) {
                     
                      var SHolder = data.ResponseData[0];
                      self.scheme_code(SHolder.scheme_code);
                      self.l_company_id(SHolder.l_company_id);
                      self.Name(SHolder.Name);
                      self.ccode(SHolder.ccode);
                    
                      self.ShHolderNo(SHolder.ShHolderNo);
                      self.SIP_Reg_No(SHolder.SIP_Reg_No);
                      self.Contact2(SHolder.Contact2);
                       self.Contact1(SHolder.Contact1);
                      var mappedTasks = $.map(data.ResponseData, function (item) {
                       return new ShHolder(item)

                      });
                      self.ShHolders(mappedTasks); 
                          $('#tblfund').DataTable({
                                 responsive: true
                             });
                 
                      $('#txtBOID').attr('disabled', true);
                      $('#dp').attr('disabled', true);
                     

                  }
                  else {
                      msg('You have no pending SIP installment right now', alert);
                   
                  }

              });
        }
    }

   // self.CheckSHolders()
    self.checkValidation = function(data){
    
    self.TotalAmount(null);
    var context = ko.contextFor(event.target);
        var index = context.$index();
              var Check =($($('#tblfund').DataTable().row(index).nodes()).find('input').prop('checked'))
                if (Check != undefined && Check != "" && Check != false) {
                Sum = Sum+parseInt($('#tblfund').DataTable().row(index).data()[4]); 
        }
        else
                {
                Sum = Sum-parseInt($('#tblfund').DataTable().row(index).data()[4]);

                }

                self.TotalAmount(Sum);
    }

    self.PaymentValidation = function () {
  
        var errMsg = "";
        var objFocus = null;
        //#region Validating required fields

        if (Validate.empty(self.Boid_No())) {
            errMsg += "Please Enter BOID!!!<br>";
        }
      
        if (self.SelectedDp() == undefined) {
            errMsg += "Please Select Depository Participants!!!<br>";
        }
        if (self.Boid_No() != undefined) {
            if (self.Boid_No().length < 8) {
                errMsg += "Please Enter 8-digit BOID!!!<br>";
            }
        }

         for (var i = 0; i < self.ShHolders().length; i++) {
                var x = i + 1;
                 var Check = $($('#tblfund').DataTable().row(i).nodes()).find('input').prop('checked')
             //   var Check = $(tblfund.rows.item(x).cells[0]).find('input:checkbox').prop("checked");
                if ( Check == true) {
                        flag += "true";
                }
            }
            if (flag == "") {
            errMsg += "Please Select Any Row To be Proceed!!!<br/>";       
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
     self.openpage = function(){
        var objFra = window.open('../../Modules/Ebanking.aspx', '_blank');
     }

      self.DispalyPaymentOptions= function(){
            if(self.PaymentValidation()){
                $('#PaymentType').modal('show'); 
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
                         tAmt.setAttribute('value',(parseFloat(self.TotalAmount())));
                    
                    form.appendChild(tAmt);

                     //--amt --
                     var amt =document.createElement('input');
                         amt.setAttribute('type', 'hidden');
                         amt.setAttribute('name', 'amt');
                         amt.setAttribute('id', 'amt');
                         amt.setAttribute('value',(parseFloat(self.TotalAmount())));
                    
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
                         su.setAttribute('value', LoginSIPPaymentURL+'?q=su');
                    
                    form.appendChild(su);

                     //--fu --
                     var fu =document.createElement('input');
                         fu.setAttribute('type', 'hidden');
                         fu.setAttribute('name', 'fu');
                         fu.setAttribute('id', 'fu');
                         fu.setAttribute('value',LoginSIPPaymentURL+'?q=fu');
                    
                  form.appendChild(fu);
                  document.body.appendChild(form);
                 form._submit_function_(); 
     }

    self.SavePayment = function (paymentcode) {
      self.PaymentCode(paymentcode);
      self.UserList([]);   
      for (var i = 0; i < self.ShHolders().length; i++) {
            var x = i + 1;
            var Check =  $($('#tblfund').DataTable().row(i).nodes()).find('input').prop('checked');
            if (Check != undefined && Check != "" && Check != false) {
                 var DIS = {
                    l_company_id:$('#tblfund').DataTable().row(i).data()[9],
                    SIP_Reg_No: $('#tblfund').DataTable().row(i).data()[2],
                    scheme_code: $('#tblfund').DataTable().row(i).data()[9],
                    ccode: '1000',
                    entry_user: 'Online User',
                    entry_dt: today,
                    Received_Amount:$('#tblfund').DataTable().row(i).data()[4],
                    Interval_Seq_No:$('#tblfund').DataTable().row(i).data()[1],
                    ShHolderNo:$('#tblfund').DataTable().row(i).data()[8],
                    Sip_amt:$('#tblfund').DataTable().row(i).data()[3],
                    GatewayCode: self.GatewayCode(),
                    Integrationcode:self.PaymentCode(),
                    TotalAmount:self.TotalAmount()
                }
                self.UserList.push(DIS);  
             }
          }
            var url = "../../Handler/SIPHandling/SIPPayment.ashx";
            var data = { 'method': 'InsertSipPayment', 'args': JSON.stringify(ko.toJS((self.UserList()))) };
            $.post(url, data,
                        function (result) {
                            var obj = jQuery.parseJSON(result);
                            if (obj.IsSucess) {
                                var SIP_Reg_No = obj.ResponseData;
                                var res = SIP_Reg_No.split(" ");
                                self.TXNID(res[1]);
                                self.trans_no(res[0]);
                                self.PayTxnAmount((parseFloat(self.TotalAmount()))*100);
                                self.PayRefId(self.Bo_Account_No());
                                sessionStorage.setItem("PaymentCode", self.PaymentCode());
                                sessionStorage.setItem("SIP_Reg_No", self.SIP_Reg_No());
                                sessionStorage.setItem("TXNID", self.TXNID());
                                sessionStorage.setItem("PayTxnAmount", self.PayTxnAmount());
                                    if(self.PaymentCode() == '07') {
                                    //ConnectIPS
                                    self.ProceedToPayment();
                                    }

                                    else if(self.PaymentCode() == '10') {
                                    self.EBankingProceedToPayment();
                                    }
                                    else if(self.PaymentCode() == '12') {
                                    self.ESewaProceedToPayment();
                                    }
                            }
                            else {
                               
                                msg('FAILURE', alert);
                            }

                        });
       // }
       
     }
                   //To open Khalti payment form with Config
        var config = {
            "publicKey": Khaltiref,
            "productName": "SIP Payment By login",
            "productUrl": LoginSIPPaymentURL,
            "paymentPreference": [
                "KHALTI"
                ],
            "eventHandler": {
                onSuccess (payload) {
                    // hit merchant api for initiating verfication
                  
                  self.Token(payload.idx);
                    self.UpdateToken();
                    VerifyKhaltiPayment(payload);

                },
                onError (error) {      
                },
                onClose () {
                   waitMsg.hide();
                }
            }
        };

        var checkout = new KhaltiCheckout(config);

    $(document).on('click', '#payment-button', function () {
        self.PaymentCode('09');
         self.UserList([]);   
     for (var i = 0; i < self.ShHolders().length; i++) {
            var x = i + 1;
            var Check =  $($('#tblfund').DataTable().row(i).nodes()).find('input').prop('checked');
            if (Check != undefined && Check != "" && Check != false) {
                 var DIS = {
                    l_company_id:$('#tblfund').DataTable().row(i).data()[9],
                    SIP_Reg_No: $('#tblfund').DataTable().row(i).data()[2],
                    scheme_code: $('#tblfund').DataTable().row(i).data()[9],
                    ccode: '1000',
                    entry_user: 'Online User',
                    entry_dt: today,
                    Received_Amount:$('#tblfund').DataTable().row(i).data()[4],
                    Interval_Seq_No:$('#tblfund').DataTable().row(i).data()[1],
                    ShHolderNo:$('#tblfund').DataTable().row(i).data()[8],
                    Sip_amt:$('#tblfund').DataTable().row(i).data()[3],
                    GatewayCode: self.GatewayCode(),
                    Integrationcode:self.PaymentCode(),
                    TotalAmount:self.TotalAmount()
                }
                self.UserList.push(DIS);                        
             }
          }

            var url = "../../Handler/SIPHandling/SIPPayment.ashx";
            var data = { 'method': 'InsertSipPayment', 'args': JSON.stringify(self.UserList())  };
            $.post(url, data,
                        function (result) {
                   
                            var obj = jQuery.parseJSON(result);
                            if (obj.IsSucess) { 
                               self.UserList([]);   
                                var SIP_Reg_No = obj.ResponseData;
                                var res = SIP_Reg_No.split(" ");
                                self.TXNID(res[1]);
                                self.PayTxnAmount((parseFloat(self.TotalAmount()))*100);
                                self.PayRefId(self.Bo_Account_No());
                                    var amt=((parseFloat(self.TotalAmount()))*100);
                                    checkout._config.productIdentity =ProductIdentity;
                                    checkout.show({amount: amt});

                                 

                                }
                                else {
                               
                                msg('FAILURE', alert);
                            }
                        });
                      
    });

 self.SuccessData = function(dataObj){
            self.GetTXNData();
            sessionStorage.clear();
            msg(dataObj.statusDesc,alert);
            self.IntervalStatus();
            self.SubmitStatus(dataObj.status);
            $('.Submit').attr('disabled','disabled');
            $('#btnProceed,#btnCancel').attr('disabled', true);
            $('#BtnSubmit').attr('disabled', false);
                waitMsg.hide1();
            window.history.replaceState("object or string", "Title",  self.TestURL());
     }

     self.failureData = function(dataObj){

       sessionStorage.clear();
         self.GetTXNData();
        msg(dataObj.statusDesc,alert);
        $('.Submit').attr('disabled','disabled');
        $('#BtnSubmit,#btnProceed').attr('disabled', true);
        $('#btnCancel').attr('disabled', false);
        waitMsg.hide1();                                           
        window.history.replaceState("object or string", "Title",  self.TestURL());
     }


//To verify Khalti Payment 
 function VerifyKhaltiPayment(payload) {
  
    waitMsg("Loading.....");
    waitMsg.show();
    //self.GetTXNData();
    var paymentdata = {
        GatewayCode: self.GatewayCode(),
        TXNID:self.TXNID(),
        referenceId : self.SIP_Reg_No(),
        amount: payload.amount,
        idx:payload.idx,  //For VendorTXNID
        token: payload.token,
        Action:'SIPPAY'      
    }
 
    var url = '../../Handler/Collection/CollectionHandler.ashx';
     var data = { 'method': 'VerifyKhaltiPayment', 'data': JSON.stringify(ko.toJS(paymentdata)) ,
                 'Action': 'U',
                 'GatewayCode': self.GatewayCode(),
                 'TXNID':self.TXNID(),
                 'ReferenceID':self.Bo_Account_No()                                                                                                                                                                                                                                                                                                                                                                                                 ,
                  'PaymentCode':self.PaymentCode()
                  };         
   $.post(url, data, result => {

    var obj = JSON.parse(result);

    var dataObj = JSON.parse(obj.data);
    waitMsg.hide();

    if (obj.IsSucess) {
        if (dataObj.state.name == "Completed") {
        sessionStorage.clear(); 
        $('#PaymentType').modal('hide');
        msg('Transaction has been Sucessfull', alert);
        self.GetTXNData();
        self.IntervalStatus();
        self.SubmitStatus(dataObj.state.name); 
        $('.Submit').attr('disabled', 'disabled');
        $('#btnProceed,#btnCancel').attr('disabled', true);
        $('#BtnSubmit').attr('disabled', false);
        $('#PaymentType').modal('hide');                                   
        window.history.replaceState("object or string", "Title", self.TestURL());
            
        }
        else {
        sessionStorage.clear();
        $('#PaymentType').modal('hide');
        msg("TRANSACTION FAILED", alert);
        $('.Submit').attr('disabled', 'disabled');
        $('#BtnSubmit,#btnProceed').attr('disabled', true);
        $('#btnCancel').attr('disabled', false);
        $('#PaymentType').modal('hide');
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

    self.UpdateToken = function(){
        var url = "../../Handler/RequestHandling/PurchaseRequestHandler.ashx" ;
        var data = { 'method': 'UpdateToken', 'TXNID': self.TXNID(), 'Action':'C', 'Token': self.Token() };
                            $.post(url, data,
                                function (result) {
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
                   

                waitMsg('Loading...');
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
                         RefId.setAttribute('value', ko.toJS(self.SelectedDp().DP_Id_Cds()) + ko.toJS(self.Boid_No) + self.PayRemarks());
                    
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
        AMTData.setAttribute('VALUE', self.TotalAmount());            
        form.appendChild(AMTData);

        document.body.appendChild(form);
        form._submit_function_();

    }

    function downloadURI(uri, name) {
    var link = document.createElement("a");
    link.download = name;
    link.href = uri;
    link.click();
    }
    var pdf = "";

    self.createPdfAndsendMail = function () {
 
        $.ajax({

            url: "../../Handler/SIPHandling/CreateSipPayment.ashx",
            type: 'POST',
            data: { 'method': 'CreateSipPaymentReceipt', 'TXNID': self.TXNID(), 'l_company': self.l_company_id() },
            success: function (data) {
                var obj = JSON.parse((data));
                      var objFra ='/Reports/Registration/' + obj.ResponseData;
                       downloadURI(objFra, "SIP PAYMENT RECEIPT");
                      deleteFile(objFra);
            },
            error: function (errorText) {
              
            }
        });
      
    }
    //
       self.GetTXNData = function()  {

          if(self.PaymentCode() =='09')
         {
                $('#tblfund').DataTable().destroy();
                $('#tblfund tbody').empty(); 
                self.ShHolders([]);
         }
          else
         {
               self.ShHolders([]);
         }

         $.ajax({
              type: "GET",
                dataType: "json",
                cache: false,
                async: true,
                url: '../../Handler/SIPHandling/SIPPayment.ashx',
                data: { 'method': 'GetTXNData', 'TXNID':self.TXNID()},
                contentType: "applicaton/json; character=utf -8",
                async: false,
                success: function (obj) {

                      $('#txtBOID').attr('disabled', true);
                      $('#dp').attr('disabled', true);
                      var SHolder = obj.ResponseData[0];
                     
                         var mappedTasks = $.map(obj.ResponseData, function (item) {
                            return new ShHolder(item)

                        });
                      
                      self.ShHolders(mappedTasks); 
                      self.trans_no(SHolder.trans_no);
                      self.Name(SHolder.Name);
                      self.Contact1(SHolder.Contact1);
                      self.Contact2(SHolder.Contact1);
                      self.SIP_Reg_No(SHolder.SIP_Reg_No);
                      self.boid(SHolder.boid);
                      var dpcode = ((SHolder.boid).toString()).substr(0,8);
                      self.SelectedDp(self.Depo().find(x => x.DP_Id_Cds() === dpcode));
                      self.BOID(((SHolder.boid).toString()).substr(8,16));
                      $('.checkboxselect').css('display', 'none');
                      $('#LOAD').css('display', 'none');
                      Sum=0;
                        for (var i = 0; i < self.ShHolders().length; i++) {
                      var x = i + 1;
                                  Sum = Sum+parseInt(self.ShHolders()[i].ReceivedAmt());
                      }
                      self.TotalAmount(Sum);
                      self.GTotal((parseFloat(self.TotalAmount()))*100);
                      
                      self.l_company_id(SHolder.l_company_id);
                      self.scheme_code(SHolder.scheme_code);
                      self.Interval_Seq_No(SHolder.Interval_Seq_No);
                      self.ShHolderNo(SHolder.ShHolderNo);
                   
                }
               
             });
               
     }



    self.IntervalStatus = function(){  
       for (var i = 0; i < self.ShHolders().length; i++) {
            var url = "../../Handler/SIPHandling/SIPPayment.ashx";
            var data = { 'method': 'IntervalStatus', 'SIP_Reg_No':self.SIP_Reg_No(),'Interval_Seq_No':self.ShHolders()[i].Interval_Seq_No(),'ShHolderNo':self.ShHolderNo(), 'scheme_code':'001' };
            $.post(url, data,
                        function (result) {
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
                url: "../../Handler/SIPHandling/SIP_RegistrationHandler.ashx" ,
                data: { 'method': 'ValidateSIPAmount', 'TXNID': RE, 'Action':'SIPPAY' },
                contentType: "applicaton/json; character=utf -8",
                async: false,
                success: function (obj) {
                    var PayTxnAmount= obj.ResponseData[0].Sip_amt;
                    self.GTotal((parseFloat(PayTxnAmount))*100);
                    self.AMOUNT(parseFloat(PayTxnAmount));
                    self.SIP_Reg_No(obj.ResponseData[0].SIP_Reg_No);
                }
                });
    }
      //Get Transaction ID in URL  with verify Connect IPS Payment Data

     if( getUrlParamVal('TXNID') != undefined && getUrlParamVal('TXNID') !=""){
         ValidatePage();
      var RE =getUrlParamVal('TXNID');
      var TXNID= sessionStorage.getItem("TXNID"); 
      var PaymentCode = sessionStorage.getItem("PaymentCode");  
      var SIP_Reg_No = sessionStorage.getItem("SIP_Reg_No"); 
      self.SIP_Reg_No(SIP_Reg_No); 
      self.PaymentCode(PaymentCode);
      if (RE==TXNID){        
         self.TXNID(RE);
         self.ValidateAmount();
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
                                                //waitMsg('Loading...');
                                                waitMsg.show();
                                                  var postDate={
	                                                    "merchantId":self.PayMarchantId(),
	                                                    "appId":self.PayAppId(),
	                                                    "referenceId":RE,
	                                                    "txnAmt": self.GTotal(),
	                                                    "token":genToken,
                                                        "Action":'SIPPAY'
                                                }
                                        let url = '../../Handler/Collection/CollectionHandler.ashx';
                                        let data = { 'method': 'ValidatePayment', 
                                        'data': JSON.stringify(ko.toJS(postDate)) ,'Action': 'U' ,'ReferenceID': self.SIP_Reg_No(),'AppID' :self.PayAppId(),'PayAppName': self.PayAppName(),'GatewayCode': self.GatewayCode() ,'PaymentCode':self.PaymentCode()}; 
                                        $.post(url, data, result => {
                                            var obj = JSON.parse(result);
                            
                                            var dataObj=JSON.parse(obj.data);
                                               waitMsg.hide();
                                              
                                               if(obj.IsSucess){
                                              if (dataObj.status=="SUCCESS")
                                                 {
                                                     self.SuccessData(dataObj);
                                                 }
                                                 else
                                                 {
                                                    self.failureData(dataObj);
                                                 }
                                               }
                                               else
                                               {
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

    // To Load reponse data of Ebanking and call ajax with verify data
    if (resbid !== "") {
        waitMsg.show();
        var resData = {
            BankId: resbankid,
            PREF: respref,
            AMOUNT: resamount,
            BID: resbid,
            CustRefType: rescustreftype
        }
        self.Token(resbid);
        var TXNID = sessionStorage.getItem("TXNID");
        self.TXNID(TXNID);
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
                      var DSIP_Reg_No = sessionStorage.getItem("SIP_Reg_No");
                     self.SIP_Reg_No(DSIP_Reg_No);
                      self.GetTXNData();
                      sessionStorage.clear();      
                      msg('Transaction has been Sucessfull', alert);
                      self.IntervalStatus();
                      self.SubmitStatus(self.status()) ;
                        $('.Submit').attr('disabled','disabled');
                        $('#btnProceed,#btnCancel').attr('disabled', true);
                       $('#BtnSubmit').attr('disabled', false);                   
                       $('#PaymentType').modal('hide');
                       window.history.replaceState("object or string", "Title", self.TestURL());
                  }
                else {
                    sessionStorage.clear();
                    msg("TRANSACTION FAILED", alert);               
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

    if (getUrlParamVal('q') != undefined && getUrlParamVal('q') != "") {
        ValidatePage();
if( getUrlParamVal('q') =="su"){
        self.TXNID(getUrlParamVal('oid'));
        self.ValidateAmount();
        self.Token(getUrlParamVal('refId'));
        self.UpdateToken();
        var resData = {
            PREF: getUrlParamVal('oid'),
            AMOUNT: getUrlParamVal('amt'),
            BID: getUrlParamVal('refId'),
            CustRefType: getUrlParamVal('oid'),
            scd: Esewascd,
            Action:'SIPPAY'
        }
        var url = '../../Handler/Collection/CollectionHandler.ashx';
        var data = { 'method': 'VerifyEsewaTransaction', 'data': JSON.stringify(resData), 'Action': 'E', 'GatewayCode': self.GatewayCode(), 'PaymentCode': '12' };
    $.post(url, data, result => {
        waitMsg.show();
            var obj = JSON.parse(result);
            if (obj.IsSucess) {
            if(obj.data == "SUCCESS"){
                self.GetTXNData();
                sessionStorage.clear();      
                msg('Transaction has been Sucessfull', alert);
                self.IntervalStatus();
                self.SubmitStatus(obj.data) ;
                $('.Submit').attr('disabled','disabled');
                $('#btnProceed,#btnCancel').attr('disabled', true);
                $('#BtnSubmit').attr('disabled', false);                   
                $('#PaymentType').modal('hide');
                waitMsg.hide();
                window.history.replaceState("object or string", "Title", self.TestURL());
          }
          else
             {
                sessionStorage.clear();
                msg("TRANSACTION FAILED", alert);
                var TXNID = sessionStorage.getItem("TXNID");
                self.TXNID(TXNID);
                self.GetTXNData();
                $('.Submit').attr('disabled', 'disabled');
                $('#BtnSubmit,#btnProceed').attr('disabled', true);
                $('#btnCancel').attr('disabled', false);
                $('#PaymentType').modal('hide');
                waitMsg.hide();
                window.history.replaceState("object or string", "Title", self.TestURL());
             }                
            }
            else{
                msg(obj.Message, alert);
                self.SubmitStatus(obj.data);
                var TXNID = sessionStorage.getItem("TXNID");
                self.TXNID(TXNID);
                self.GetTXNData();
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
            var TXNID = sessionStorage.getItem("TXNID");
            self.TXNID(TXNID);
            self.GetTXNData();
            $('.Hidden').css('display', 'none');
            $('.Submit').attr('disabled', 'disabled');
            $('#BtnSave,#btnProceed').attr('disabled', true);
            $('#btnCancel').attr('disabled', false);
            waitMsg.hide();
           window.history.replaceState("object or string", "Title", self.TestURL());
        }
    }
    self.SubmitPayment = function () {
    if(self.SubmitStatus()=="SUCCESS" || self.SubmitStatus()  =="Completed"){
        var DIS = {
            l_company_id: self.l_company_id(),
            scheme_code: self.scheme_code(),
            ccode: '1000',
            SIP_Reg_No: self.SIP_Reg_No(),
            Interval_Seq_no: self.Interval_Seq_No(),
            ShHolderNo: self.ShHolderNo(),
            trans_no:  self.TXNID(),
            GatewayCode: self.GatewayCode(),
            Name:$("#Name").text()
        }
        var url = "../../Handler/SIPHandling/SIPPayment.ashx";
        var data = { 'method': 'SubmitSipPayment', 'args': JSON.stringify(ko.toJS((DIS))) };
        $.post(url, data,
                        function (result) {
                            var obj = jQuery.parseJSON(result);
                            if (obj.IsSucess) {
                                self.createPdfAndsendMail();

//                                $.ajax({
//                                    url: "../../Handler/SIPHandling/CreateSipPayment.ashx",
//                                    type: 'POST',
//                                    data: { 'method': 'CreateSipPaymentReceipt', 'args': JSON.stringify(ko.toJS(self.ShHolders())), 'l_company': self.l_company_id() },
//                                    success: function (data) {

//                                        var obj = jQuery.parseJSON((data));
//                                              var objFra ='/Reports/Registration' + obj.ResponseData;
//                                              downloadURI(objFra, objFra);
//                                    },
//                                    error: function (errorText) {
//                                       // alert("Wwoops something went wrong !");
//                                    }
//                                });

                                msg(obj.ResponseData, alert);
                                $('#btnSave,#btnCancel').attr('disabled', false);
                                $('#btnProceed,#BtnSubmit').attr('disabled', true);
                               
                            }
                            else {
                              
                                msg('FAILURE', alert);
                            }

                        });
 
        self.Clearcontrol();
        }
    }
  

    self.Clearcontrol = function () {
        sessionStorage.clear();
        sessionStorage.setItem("REQUEST_NO", "");
        sessionStorage.setItem("TXNID", "");
        sessionStorage.setItem("ProofFileName", "");                                     
        if($('#BOID').text() != undefined &&$('#BOID').text() != ""){
        self.Boid_No(($('#BOID').text()).substr(8,16));
        var dpcode = ($('#BOID').text()).substr(0,8);
        self.SelectedDp(self.Depo().find(x => x.DP_Id_Cds() === dpcode));
        $('#Name,#Contact1,#Contact2,#TotalAmount').attr('disabled', true);
        $('#btnProceed,#btnCancel').attr('disabled', false);
        $('#BtnSubmit').attr('disabled', true);
         self.ShHolders([]);
         window.history.replaceState("object or string", "Title", self.TestURL());
        location.reload();
            
      }
    }
} //End of SipPaymentViewModel


$(document).ready(function () {
   validLoginUser();
   ValidateSession();
   ko.applyBindings(new SipPaymentViewModel());
});