function CollCenter(data) {
    var self = this;
    if (data != undefined) {
        self.ccode = ko.observable(data.ccode);
        self.cname = ko.observable(data.cname);

    }
}

function ParaComp(data) {
    var self = this;
    if (data != undefined) {
        self.scheme_code = ko.observable(data.scheme_code);
        self.SchemeEnName = ko.observable(data.SchemeEnName);

    }
}
function SIPHolder(data){
var self = this;
    if (data != undefined) {
       self.scheme_code = ko.observable(data.scheme_code);
       self.ccode = ko.observable(data.ccode);
       self.SIP_Reg_No = ko.observable(data.SIP_Reg_No);
       self.ShHolderNo = ko.observable(data.ShHolderNo);
       self.Email = ko.observable(data.Email);
       self.NewEmail=ko.observable(data.NewEmail);
       self.boid = ko.observable(data.boid);
       self.Name = ko.observable(data.Name);
       self.SIP_DT = ko.observable(data.SIP_DT);
       self.Effective_Dt=ko.observable(data.Effective_Dt);
       self.Sip_amt = ko.observable(data.Sip_amt);
       self.Model_of_Sip = ko.observable(data.Model_of_Sip);
       self.Last_Date = ko.observable(data.Last_Date);
       self.Online = ko.observable(data.Online);
       self.IsApproved = ko.observable(data.IsApproved);
       self.remarks = ko.observable(data.remarks);
       self.Address = ko.observable(data.Address);
       self.Contact1 = ko.observable(data.Contact1);
       self.Contact2 = ko.observable(data.Contact2);
       self.PayeeName = ko.observable(data.PayeeName);
       self.Introducer = ko.observable(data.Introducer);
       self.HolderTypeNo = ko.observable(data.HolderTypeNo);
       self.HolderType = ko.observable(data.HolderType);
       self.Sip_code = ko.observable(data.Sip_code);
       self.SIP_Interval = ko.observable(data.SIP_Interval);
       self.ENTRY_BY = ko.observable(data.ENTRY_BY);
       self.Holder_Type_No = ko.observable(data.Holder_Type_No);
       self.BankInfo = ko.observable(data.BankInfo);
//       self.Bo_Account_No=ko.observable(data.boid);
       self.File1=ko.observable(data.File1);
       self.File2=ko.observable(data.File2);
       self.Is_Unit_Holder=ko.observable(data.Is_Unit_Holder);
       self.Amdnt_No=ko.observable(data.Amdnt_No);
       self.SchemeEnName=ko.observable(data.SchemeEnName);
       self.cname=ko.observable(data.cname);
       
             
    }
}
function ListedCompany(data) {
    var self = this;
    if (data != undefined) {
        self.Comp_Id = ko.observable(data.Comp_Id);
        self.Name = ko.observable(data.Name);

    }
}


function HolderType(data) {
    var self = this;
    if (data != undefined) {
        self.HolderTypeNo = ko.observable(data.HolderTypeNo);
        self.HolderType = ko.observable(data.HolderType);
    }
}
function HolderInfo(data) {
    var self = this;
    if (data != undefined) {
        self.HolderTypeNo = ko.observable(data.HolderTypeNo);
        self.HolderType = ko.observable(data.HolderType);
    }
}
function Interval(data){
    var self = this;
    if(data != undefined){
        self.Sip_code = ko.observable(data.Sip_code.trim());
        self.SIP_Interval = ko.observable(data.SIP_Interval);
        self.No_of_Months = ko.observable(data.No_of_Months);
    }
}

function NewInterval(data){
    var self = this;
    if(data != undefined){
        self.NewSip_code = ko.observable(data.Sip_code.trim());
        self.NewSIP_Interval = ko.observable(data.SIP_Interval);
        self.NewNo_of_Months = ko.observable(data.No_of_Months);
    }
}


function DPCharge(data) {
    var self = this;
    if (data != undefined) {
        self.Depo = ko.observable(data.Depo);
        self.DPName = ko.observable(data.DPName);
        self.DP_Id_Cds =ko.observable(data.DP_Id_Cds);
    }
}
function PaymentModeList(data){
    var self = this;
    if(data != undefined){
        self.PaymentCode = ko.observable(data.PaymentCode);
        self.PaymentMode = ko.observable(data.PaymentMode);
    }
}
function NewPaymentModeList(data){
    var self = this;
    if(data != undefined){
        self.NewPaymentCode = ko.observable(data.PaymentCode);
        self.NewPaymentMode = ko.observable(data.PaymentMode);
    }
}

function Bank(data) {
    var self = this;
    if (data != undefined) {
        self.bankcode = ko.observable(data.bankcode);
        self.bankname = ko.observable(data.bankname);
    }
}

function NewBank(data) {
    var self = this;
    if (data != undefined) {
        self.Newbankcode = ko.observable(data.bankcode);
        self.Newbankname = ko.observable(data.bankname);
    }
}

function BankInfo(data){
var self = this;
    if (data != undefined) {
        self.scheme_code = ko.observable(data.scheme_code);
        self.ccode = ko.observable(data.ccode);
        self.SIP_Reg_No = ko.observable(data.SIP_Reg_No);
        self.BankCode = ko.observable(data.BankCode);
        self.BranchNo = ko.observable(data.BranchNo);
        self.BankName = ko.observable(data.BankName);
    }   self.Bank_Account_No = ko.observable(data.Bank_Account_No);
}
var AmendmentRequestViewModel = function () {
  var self = this;
 var username = $("#username").text(); // logged in user 
    var ccode = '1000' // Distribution center id
    var scheme_code = '001'; /// company id 
    var date = $("#date").text();
    var UserId = $('#UserId').text();
    var l_company_id = '001';
    var SHHOLDERNO = $('#SHHOLDERNO').text();
    var EmailUser = $("#Email").text();
     var BOID =  $('#BOID').text();
    var Contact_No =  $("#Contact_No").text();

    self.scheme_code = ko.observable();
    
    //distribution center
    self.ccode = ko.observable();
    self.cname = ko.observable();
    self.CCenters = ko.observableArray([]);
    self.SelectedCC = ko.observable();
    self.SelectedHolder= ko.observable(); 
      
    //For Company 
    self.scheme_code = ko.observable();
    self.CompEnName = ko.observable();
    self.Companies = ko.observableArray([]);
    self.SelectedComp = ko.observable();

    //For Scheme 
    self.SchemeCode = ko.observable();
    self.SchemeEnName = ko.observable();
    self.Schemes = ko.observableArray([]);
    self.SelectedScheme = ko.observable();

    //For DP
     self.BOID= ko.observable();
     self.Depo= ko.observableArray([]);
     self.DPName = ko.observable();
     self.SelectedDp= ko.observable();
     //self.Depo = ko.observable();
     self.DP_Id_Cds =ko.observable();
//     self.Bo_Account_No=ko.observable();
     self.Depos = ko.observableArray([]);
     self.SelectedDps= ko.observable();
     self.BOIDNO=ko.observable();
      self.Count=ko.observable();

     self.SchemeEnName=ko.observable();
     self.cname=ko.observable();
     self.Amdnt_No = ko.observable();
    self.SIP_Reg_No= ko.observable();
    self.Name = ko.observable();
    //self.Bo_Account_No= ko.observable();
    self.ShHolderNo = ko.observable();
    self.Holders = ko.observableArray([]);
    self.SelectedHolder = ko.observable();
    self.Intervals =ko.observableArray([]);
    self.SelectedInterval = ko.observable();
    self.SelectedModel =ko.observable();
    self.Online = ko.observable(false);
    self.Last_Dt=ko.observable();
    self.SIP_DT = ko.observable();
    self.Name  =ko.observable();
    self.Email=ko.observable();
    self.NewEmail=ko.observable();
    //self.BOID=ko.observable();
    self.Sip_amt=ko.observable();
    self.acc_no =ko.observable();
    self.Reg_no =ko.observable();
    self.Contact1=ko.observable();
    self.Contact2=ko.observable();
    self.Address=ko.observable();
    self.payeename=ko.observable();
    self.Introducer=ko.observable();
    self.Approved_By=ko.observable();
    self.remarks=ko.observable();
    self.Action=ko.observable();
    self.ShHolders = ko.observableArray([]);
    self.Holder_Types = ko.observableArray([]);
    self.selholder_type =ko.observable();
    self.SipModel = ko.observableArray(['Limited','Unlimited']);

    self.amntscheme_code = ko.observable();
    self.amntccode = ko.observable();
   
    self.Sip_Reg_No=ko.observable();
    self.BanksInfo= ko.observableArray([]);
    self.Banks = ko.observableArray([]);
    self.bankcode = ko.observable();
    self.SelectedBank = ko.observable();
    self.bankname = ko.observable();
    self.selectedItem= ko.observable();
    self.day_start_date = ko.observable(); 
    self.Effective_Dt=ko.observable();
    self.Approved_By=ko.observable();
    self.remarks=ko.observable();
    self.Action=ko.observable();
    self.File1=ko.observable();
    self.File2=ko.observable();
    self.PayeeContactNo =ko.observable();
    self.PaymentLists = ko.observableArray([]);
    self.SelPayments =ko.observable();
    self.termno =ko.observable();
    self.Holders  = ko.observableArray([]);
    self.UserCenters   = ko.observableArray([]);
    self.Selterm  =ko.observable();
    self.Action_Date =ko.observable();
    self.SI_BankAcc_no = ko.observable();
    self.PayeeContactNo  = ko.observable();
    self.IntroducerRem = ko.observable();
    self.Selterm  =ko.observable();
    self.StandingBanks   =ko.observableArray([]);
    self.SelStandingBanks   = ko.observableArray([]);
    self.New_Action_Date=ko.observable();
    self.Action =ko.observable();
    self.Is_Unit_Holder=ko.observable();
    self.IntroducerRem = ko.observable();
    self.checkRptTyp = ko.observable();
    self.IsApproved= ko.observable();
    self.APPSTATUS= ko.observable();

      var TermType = function(TermTypeCode, TermTypeName) {
        this.TermTypeCode = TermTypeCode;
        this.TermTypeName = TermTypeName;
    };
    self.TermTypes = ko.observableArray([
       // new TermType("01","Week"),
        new TermType("01", "Month"),
        new TermType("02", "Year")
    ]);

    //new data
    self.NewContact1=ko.observable();
    self.NewContact2=ko.observable();
    self.Newpayeename=ko.observable();
    self.NewPayeeContactNo=ko.observable();
    self.NewSip_amt=ko.observable();
    self.NewEffective_Dt=ko.observable();
    self.NewIntroducer=ko.observable();
    self.NewLast_Dt=ko.observable();
    self.NewSI_BankAcc_no=ko.observable();
    self.Newacc_no=ko.observable();

    self.NewIntervals=ko.observableArray([]);
    self.NewSIP_Interval=ko.observable();
    self.NewSelectedInterval=ko.observable();
    self.NewPaymentLists=ko.observableArray([]);
    self.NewPaymentMode=ko.observable();
    self.NewSelPayments=ko.observable();
    self.NewSipModel = ko.observableArray(['Limited','Unlimited']);
    self.Newtermno=ko.observable();
     var NewTermType = function(NewTermTypeCode, NewTermTypeName) {
        this.NewTermTypeCode = NewTermTypeCode;
        this.NewTermTypeName = NewTermTypeName;
    };
      self.NewTermTypes = ko.observableArray([
        //new NewTermType("01","Week"),
        new NewTermType("01", "Month"),
        new NewTermType("02", "Year")
    ]);
    self.NewTermTypeName=ko.observable();
    self.NewSelterm=ko.observable();
    self.NewSelectedModel =ko.observable();
    self.NewStandingBanks=ko.observableArray([]);
    self.Newbankname=ko.observable();
    self.NewSelStandingBanks=ko.observable();
    self.NewBanks=ko.observableArray([]);
    self.Newbankname=ko.observable();
    self.NewSelectedBank=ko.observable();
    //self.checkRptTyp('S');

     self.date  = ko.observable();
    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = today.getFullYear();

    today = yyyy+ '-'+ mm + '-' + dd;
    paydate =dd+'-'+mm+'-'+yyyy;
    self.date(today);


     self.SelectedDps.subscribe(function(){
      if(self.SelectedDps() != undefined){
        $('#txtBOIDNO').attr('disabled', false);
      }
      else{
        $('#txtBOIDNO').attr('disabled', true);

      }
    });
    

    self.AddBank= function(){}
    self.CheckSHolders  = function(){
    }

    self.day_start_date= ko.observable();

    

    self.LoadPaymentMode = function () {
    
        var url = "../../Handler/SIPHandling/SIP_RegistrationHandler.ashx" ;
        var data = { 'method': 'LoadPaymentModeforAmend' };
        $.post(url, data,
            function (result) {            
                waitMsg.hide();
                var obj = jQuery.parseJSON(result);
                var mappedTasks = $.map(obj.ResponseData, function (item) {
                    return new PaymentModeList(item)
                });

                self.PaymentLists(mappedTasks);
                
            });

    }
    self.LoadPaymentMode();

    self.LoadNewPaymentMode = function () {
    
        var url = "../../Handler/SIPHandling/SIP_RegistrationHandler.ashx" ;
        var data = { 'method': 'LoadPaymentModeforAmend' };
        $.post(url, data,
            function (result) {            
                waitMsg.hide();
                var obj = jQuery.parseJSON(result);
                var mappedTasks = $.map(obj.ResponseData, function (item) {
                    return new NewPaymentModeList(item)
                });

                self.NewPaymentLists(mappedTasks);
                
            });

    }
    self.LoadNewPaymentMode();

    self.termno('1');

    function convert(str) {
      var date = new Date(str),
        mnth = ("0" + (date.getMonth() + 1)).slice(-2),
        day = ("0" + date.getDate()).slice(-2);
      return [date.getFullYear(), mnth, day].join("-");
    }

    self.EffDateValidation = function(){
     
    var errMsg = "";
        var objFocus = null;
        //#region Validating required fields
//        if (self.SelectedInterval() == undefined) {
//            errMsg += "Please Select SIP Interval[!!!<br>"
//        }

        if (Validate.empty(self.NewEffective_Dt())) {
            self.Newtermno('');
            self.NewSelterm(null);
            self.NewLast_Dt('');
            self.NewSelectedModel(null);
            $('#newtxtlstdt,#newterm,#newtxttermtype').css("display","none");
            errMsg += "Please Enter New Effective Date !!!<br>";
            
           

        }
      
        //#endregion

        if (errMsg !== "") {

            msg(errMsg, "ALERT");
//            self.termno(null);
//            self.Selterm(null);
            return false;
        }
        else {
            return true;
        }
    }

    self.ClearTermType =function(){
        if( self.EffDateValidation()){
            if(self.NewSelterm != undefined){
            self.NewSelterm(null);
            self.NewLast_Dt('');
            }
            else{
            }
        }
    } 
   self.LoadLastDate = function(){

    if (self.Selterm() != undefined && self.Selterm() != null){
        var startDate = self.SIP_DT();
        var term = self.termno();
        var termtype =self.Selterm().TermTypeName;
        var endDateMoment = moment(startDate); // moment(...) can also be used to parse dates in string format
        endDateMoment.add(term, termtype);
        var last_Date = convert(endDateMoment._d);
        self.Last_Dt(last_Date);
        }
        else{
        }
    }
//    s
    self.LoadBanks = function () {
   
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: false,
            //async: true,
            async:false,
            url: "../../Handler/SIPHandling/SIP_RegistrationHandler.ashx",
            data: { 'method': 'GetBankName' },
            contentType: "applicaton/json; character=utf -8",
            success: function (data) {
          
                var mappedTasks = $.map(data.ResponseData, function (item) {
                    return new Bank(item)
                });
                self.Banks(mappedTasks);

            },
            error: function (err) {
                waitMsg.hide();
               
            }
        });
    }
    self.LoadBanks();

    self.LoadNewBanks = function () {
   
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: false,
            //async: true,
            async:false,
            url: "../../Handler/SIPHandling/SIP_RegistrationHandler.ashx",
            data: { 'method': 'GetBankName' },
            contentType: "applicaton/json; character=utf -8",
            success: function (data) {
          
                var mappedTasks = $.map(data.ResponseData, function (item) {
                    return new NewBank(item)
                });
                self.NewBanks(mappedTasks);

            },
            error: function (err) {
                waitMsg.hide();
               
            }
        });
    }
    self.LoadNewBanks();

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
                     self.BOID(($('#BOID').text()).substr(8,16));
                    var dpcode = ($('#BOID').text()).substr(0,8);
                    self.SelectedDp(self.Depo().find(x => x.DP_Id_Cds() === dpcode));
                  //  document.getElementById("select2-dp-container").innerHTML=ko.toJS(self.SelectedDp().DPName);
                    }
            });

    }
    self.LoadDp();

     self.LoadDps = function () {
    
        var url = "/Handler/SIPHandling/AmountCollectionHandler.ashx" ;
        var data = { 'method': 'GetDPDetail' };
        $.post(url, data,
            function (result) {            
                waitMsg.hide();
                var obj = jQuery.parseJSON(result);
                var mappedTasks = $.map(obj.ResponseData, function (item) {
                    return new DPCharge(item)
                });

                self.Depos(mappedTasks);
                
            });

    }
    self.LoadDps();
    self.LoadSIPIntervals = function () {
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: false,
            //async: true,
            async:false,
            url: "../../Handler/SIPHandling/SIP_RegistrationHandler.ashx",
            data: { 'method': 'GetSipIntervals' },
            contentType: "applicaton/json; character=utf -8",
            success: function (data) {
   
                var mappedTasks = $.map(data.ResponseData, function (item) {
                    return new Interval(item)
                });
                self.Intervals(mappedTasks);
              
            },
            error: function (err) {
                waitMsg.hide();
               
            }
        });
    }
    self.LoadSIPIntervals();

    self.LoadNewSIPIntervals = function () {
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: false,
            async:false,
            //async: true,
            url: "../../Handler/SIPHandling/SIP_RegistrationHandler.ashx",
            data: { 'method': 'GetSipIntervals' },
            contentType: "applicaton/json; character=utf -8",
            success: function (data) {
   
                var mappedTasks = $.map(data.ResponseData, function (item) {
                    return new NewInterval(item)
                });
                self.NewIntervals(mappedTasks);
              
            },
            error: function (err) {
                waitMsg.hide();
               
            }
        });
    }
    self.LoadNewSIPIntervals();
    
     self.LoadScheme = function () {
        var url = "/Handler/Security/LoginHandler.ashx";
        var data = { 'method': 'LoadSchemes', 'l_company_id': l_company_id, 'ccode':ccode };
        $.post(url, data,
            function (result) {
                waitMsg.hide();
                var obj = jQuery.parseJSON(result);
                var mappedTasks = $.map(obj.ResponseData, function (item) {
                    return new ParaComp(item)
                });
              
                self.Schemes(mappedTasks); 
               self.SelectedScheme(self.Schemes().find(x => x.scheme_code() == "001"));
            });



    }

    self.LoadScheme();
  


      self.LoadHolderType = function () {
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: false,
            async: true,
            url: "../../Handler/SIPHandling/SIP_RegistrationHandler.ashx",
            data: { 'method': 'GetHolderType' },
            contentType: "applicaton/json; character=utf -8",
            success: function (data) {
                data.ResponseData.push({"HolderTypeNo" : "01","HolderType" : "Individual"})
               
                var mappedTasks = $.map(data.ResponseData, function (item) {
                    return new HolderType(item)
                });
                self.Holders(mappedTasks);

            },
            error: function (err) {
                waitMsg.hide();
               
            }
        });
    }
    self.LoadHolderType();
    self.LoadHolderInfo = function () {
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: false,
            async: true,
            url: "../../Handler/SIPHandling/SIP_RegistrationHandler.ashx",
            data: { 'method': 'GetHolderType' },
            contentType: "applicaton/json; character=utf -8",
            success: function (data) {
                data.ResponseData.push({"HolderTypeNo" : "01","HolderType" : "Individual"})
               
                var mappedTasks = $.map(data.ResponseData, function (item) {
                    return new HolderInfo(item)
                });
                self.Holder_Types(mappedTasks);

            },
            error: function (err) {
                waitMsg.hide();
               
            }
        });
    }
    self.LoadHolderInfo();
    self.ViewHolderDetails = function(){
    }


//    self.ValBOID= function(){
//    
//      if(self.SelectedDps() != undefined){
//        $('#txtBOIDNO').attr('disabled', false);
//      }
//      else{
//        $('#txtBOIDNO').attr('disabled', true);

//      }
//    }
    


     self.RefreshValidation = function () {

        var errMsg = "";
        var objFocus = "";
        if(RoleId !='1'){
            if (self.SelectedCC() == undefined) {
                errMsg += "Please Select Distribution Center!!!</br>";
            }
            if (self.SelectedScheme() == undefined) {
                errMsg += "Please Select Scheme!!!<br/>";
            }
        }
        if(self.checkRptTyp() == undefined){
         errMsg += "Please Select Request Type!!!<br/>";
        }
        if(self.SelectedDps() != undefined){
         if (Validate.empty(self.BOIDNO())) {
            errMsg += "Please Enter BOID !!!<br>";
         } 
        
        }
       if(self.BOIDNO() != undefined && self.SelectedDps() != undefined){
         if (self.BOIDNO().length < 8){
            errMsg += "Please Enter 8-digit BOID !!!<br>";
            }
       }
      
        if (errMsg !== "") {

            msg(errMsg, "ALERT");

            return false;
        }
        else {
            return true;
        }

    }

   

     self.LoadStandingBanks = function () {
   
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: false,
           // async: true,
            async:false,
            url: "../../Handler/SIPHandling/SIP_RegistrationHandler.ashx",
            data: { 'method': 'GetBankName' },
            contentType: "applicaton/json; character=utf -8",
            success: function (data) {

                var mappedTasks = $.map(data.ResponseData, function (item) {
                    return new Bank(item)
                });
                self.StandingBanks(mappedTasks);
                var add ={"bankcode":'01','bankname':'N/A'};
                 self.StandingBanks.push(new Bank(add));
                 
            },
            error: function (err) {
                waitMsg.hide();
               
            }
        });
    }
    self.LoadStandingBanks();

//     $('input[name="RefreshType"]').change(function () {
//    
//        if ($('#Ammendment').prop('checked')) {
//            self.checkRptTyp('S');
//            
//        }
//        else{
//            self.checkRptTyp('B');
//        }
//    });

    self.LoadNewStandingBanks = function () {
   
        $.ajax({
            type: "GET",
            dataType: "json",
            cache: false,
            //async: true,
             async:false,
            url: "../../Handler/SIPHandling/SIP_RegistrationHandler.ashx",
            data: { 'method': 'GetBankName' },
            contentType: "applicaton/json; character=utf -8",
            success: function (data) {

                var mappedTasks = $.map(data.ResponseData, function (item) {
                    return new NewBank(item)
                });
                self.NewStandingBanks(mappedTasks);
                var add ={"bankcode":'01','bankname':'N/A'};
                 self.NewStandingBanks.push(new NewBank(add));
                 
            },
            error: function (err) {
                waitMsg.hide();
               
            }
        });
    }
    self.LoadNewStandingBanks();

    self.amountCheck = function () {   
           if(self.NewSip_amt() <1000){
                msg("SIP Installment Amount should be min. of Rs.1000","ALERT");
                self.NewSip_amt(null);
           }
    }

    self.ClearControl = function(){
        self.SIP_Reg_No('');
        self.Amdnt_No('');
        self.SelectedDp(null);
        self.Name('');
        self.Address('');
        self.Email('');
        self.Contact1('');
        self.Contact2('');
        self.SelectedHolder(null);
        self.payeename('');
        self.PayeeContactNo('');
        self.SelectedInterval(null);
        self.Sip_amt('');
        self.Effective_Dt('');
        self.Introducer('');
        self.IntroducerRem('');
        self.SelPayments(null);
        self.SelectedModel(null);
        self.termno('');
        self.Selterm(null);
        self.Last_Dt('');
        self.Action_Date('');
        self.New_Action_Date('');
        self.SelStandingBanks('');
        self.SI_BankAcc_no('');
        self.SelectedBank(null);
        self.acc_no('');
        self.BanksInfo([]);
//        self.GetCollCenters();
        self.NewContact1('');
        self.NewContact2('');
        self.Newpayeename('');
        self.NewPayeeContactNo('');
        self.NewSelectedInterval(null);
        self.NewSip_amt('');
        self.NewEffective_Dt('');
        self.NewIntroducer('');
        self.NewSelPayments(null);
        self.NewSelectedModel(null);
        self.Newtermno('');
       //self.checkRptTyp('');

    }
    self.ClearNewData = function(){
        self.NewContact1('');
        self.NewContact2('');
        self.Newpayeename('');
        self.NewPayeeContactNo('');
        self.NewSelectedInterval(null);
        self.NewSip_amt('');
        self.NewEffective_Dt('');
        self.NewIntroducer('');
        self.NewSelPayments(null);
        self.NewSelectedModel(null);
        self.Newtermno('');
        self.NewSelStandingBanks(null);
        self.NewSI_BankAcc_no('');
        self.NewSelectedBank(null);
        self.Newacc_no('');
        $('#ammend').css('display', 'none');
        self.NewLast_Dt('');
        self.NewSelterm(null);
        self.NewEmail('');
        //self.checkRptTyp();
        //self.NewSelectedModel(null);
        $('#terms,#lstDt').css("display","none");
        $('#newtxtlstdt,#newterm,#newtxttermtype').css("display","none");

    }

     self.LoadReqType = function(){
    var today = new Date().toISOString().slice(0, 10)
    var date = $("#date").text();
        if(self.Last_Dt() !== null && self.Last_Dt() !== "" && self.Last_Dt() !== undefined){
            if(self.Last_Dt() >= today){
            $("#Ammendment").prop("checked", true);
             self.checkRptTyp('02');
            // $("#Ammendment").attr("checked","checked");
           // document.getElementById("Ammendment").checked = true;
            }
            else{
             $("#Renewal").prop("checked", true);
             self.checkRptTyp('04');
            //document.getElementById("Ammendment").checked = false;
           //  $("#Renewal").attr("checked","checked");
           // document.getElementById("Renewal").checked = true;
            }
        }
        else{
         $("#Ammendment").prop("checked", true);
          self.checkRptTyp('02');
        }
    }

//    self.LoadReqType();

     $('input[name="RefreshType"]').change(function () {
    
        if ($('#Ammendment').prop('checked')) {
            self.checkRptTyp('02');
            
        }
        else{
            self.checkRptTyp('04');
        }
    });

    self.ViewPurchaseEntryForm= function(data){
    
     self.ClearControl();
    self.ClearNewData();
        $.ajax({
           dataType: "json",
           url:"../../Handler/SIPHandling/AmendmentRequestHandler.ashx" ,
           data: { 'method': 'GetSipRegNo','BOID':$('#BOID').text()},
           contentType: "application/json; charset=utf-8",
           async: false,
           success: function (data) {
           var HolderDetail=data.ResponseData;
           self.Sip_Reg_No(HolderDetail[0].SIP_Reg_No);
           self.Name(HolderDetail[0].Name);
           }
           });
 
     $.ajax({
            dataType: "json",
            url: '/Handler/SIPHandling/AmendmentRequestHandler.ashx',
            async: false,
            data: { 'method': 'GetSIPHolderDetail','scheme_code':'001', 'ccode':'1000', 'SIP_Reg_No':self.Sip_Reg_No(), 'Action':'U', 'l_company_id': '001'},
            contentType: "application/json; charset=utf-8",
            //async: false,
            success: function (data) {
                waitMsg.hide();
                 
                self.Count(data.ResponseData.length);
                 console.log(self.Count());
                if (data.ResponseData.length > 1){
                var SipHolderOld=data.ResponseData[0];
                var SipHolderNew=data.ResponseData[1];
               
                 
                $('#ammend').css('display', 'inline');
                self.APPSTATUS(SipHolderNew.APPSTATUS);  
                self.IsApproved(SipHolderNew.IsApproved);              
                self.Name(SipHolderOld.Name);
                self.Email(SipHolderOld.Email);
                self.SIP_Reg_No(SipHolderOld.SIP_Reg_No);
                var dpcode = ((SipHolderOld.boid).toString()).substr(0,8);
                self.SelectedDp(self.Depo().find(x => x.DP_Id_Cds() === dpcode));
                self.BOID(((SipHolderOld.boid).toString()).substr(8,16));
                self.SelectedHolder(self.Holders().find(x => x.HolderTypeNo() === SipHolderOld.HolderTypeNo));
                self.Address(SipHolderOld.Address);
                self.payeename(SipHolderOld.PayeeName);
                self.Contact1(SipHolderOld.Contact1);
                self.Contact2(SipHolderOld.Contact2);
                self.Email(SipHolderOld.Email);
                self.Sip_amt(SipHolderOld.Sip_amt);
                self.SIP_DT(SipHolderOld.SIP_DT);
                self.Action_Date(SipHolderOld.Action_Date);
                self.Effective_Dt(SipHolderOld.SIP_Eff_Date);
                self.SelectedInterval(self.Intervals().find(x => x.Sip_code() === SipHolderOld.SIP_Interval.trim()));
                self.Introducer(SipHolderOld.Introducer);
                self.SelectedModel(SipHolderOld.Model_of_Sip);
                if(SipHolderOld.Model_of_Sip == 'Unlimited'){
                  $('#txtlstdt,#txtnum,#txttermtype,#terms,#lstDt').css("display","none");
                  $('#lstDt,#terms,#termtype').css("display","none");
                   self.termno('');
                   self.Selterm(null);
                   self.Last_Dt('');
                 }
                 else{
                  $('#txtlstdt,#txtnum,#txttermtype,#terms,#lstDt').css("display","inline");
                  $('#lstDt,#terms,#termtype').css("display","inline");
                   var str = (SipHolderOld.Terms);
                   var splitStr = str.split(" ");
                   self.termno(splitStr[0]);
                   self.Selterm(self.TermTypes().find(x => x.TermTypeName == splitStr[1]));
                 }
                self.SelPayments(self.PaymentLists().find(x => x.PaymentCode() === SipHolderOld.PaymentCode));
                if(SipHolderOld.St_BankAccountNo ==null || SipHolderOld.St_BankAccountNo==""){
                self.SI_BankAcc_no("N/A");
                }
                else{
                self.SI_BankAcc_no(SipHolderOld.St_BankAccountNo);
                }
                if(SipHolderOld.St_BankCode == "N/A" || SipHolderOld.St_BankCode == null){
                var St_BankCode = "01";
                }
                else{
                var St_BankCode = SipHolderOld.St_BankCode;
                }
                self.SelStandingBanks(self.StandingBanks().find(x => x.bankcode() === St_BankCode));
                self.SelectedBank(self.Banks().find(x => x.bankcode() === SipHolderOld.BankCode));
                self.acc_no(SipHolderOld.Bank_Account_No);
                self.IntroducerRem(SipHolderOld.IntroducerRem);
                self.PayeeContactNo(SipHolderOld.PayeeContactNo);
                self.Last_Dt(SipHolderOld.SIP_Last_Date);
                self.File1("data:image/jpeg;base64," + SipHolderOld.File1);
                self.File2("data:image/jpeg;base64," + SipHolderOld.File2);
                self.Action('E');
                self.Is_Unit_Holder(SipHolderOld.Is_Unit_Holder);
                self.New_Action_Date(SipHolderOld.New_Action_Date);
                self.ShHolderNo(SipHolderOld.ShHolderNo);

                //newdata
                self.Amdnt_No(SipHolderNew.Amdnt_No);
                self.Newpayeename(SipHolderNew.PayeeName);
                self.NewContact1(SipHolderNew.Contact1);
                self.NewContact2(SipHolderNew.Contact2);
                self.NewEmail(SipHolderNew.Email);
                self.NewSip_amt(SipHolderNew.Sip_amt);
                self.NewEffective_Dt(SipHolderNew.SIP_Eff_Date);
                self.NewSelectedInterval(self.NewIntervals().find(x => x.NewSip_code() === SipHolderNew.SIP_Interval.trim()));
                self.NewIntroducer(SipHolderNew.Introducer);
                self.NewSelectedModel(SipHolderNew.Model_of_Sip);
                if(SipHolderNew.Model_of_Sip == 'Unlimited'){
                 
                 $('#newtxtlstdt,#newterm,#newtxttermtype,#terms').css("display","none");
                  $('#lstDt,#terms,#termtype').css("display","none");
                   self.Newtermno('');
                   self.NewSelterm(null);
                   self.NewLast_Dt('');
                 }
                 else{
               
                  $('#lstDt,#terms,#newterm,#newtxtlstdt,#newtxttermtype,#terms').css("display","inline");
                   var str = (SipHolderNew.Terms);
                   var splitStr = str.split(" ");
                   self.Newtermno(splitStr[0]);
                   self.NewSelterm(self.NewTermTypes().find(x => x.NewTermTypeName == splitStr[1]));

                   
                 }
                self.NewSelPayments(self.NewPaymentLists().find(x => x.NewPaymentCode() === SipHolderNew.PaymentCode));
                self.NewSI_BankAcc_no(SipHolderNew.St_BankAccountNo);
                 if(SipHolderNew.St_BankCode == "N/A" || SipHolderNew.St_BankCode == null){
                var St_BankCode = "01";
                }
                else{
                var St_BankCode = SipHolderNew.St_BankCode;
                }
                self.NewSelStandingBanks(self.NewStandingBanks().find(x => x.Newbankcode() === St_BankCode));
                self.NewSelectedBank(self.NewBanks().find(x => x.Newbankcode() === SipHolderNew.BankCode));
                self.Newacc_no(SipHolderNew.Bank_Account_No);
                self.NewPayeeContactNo(SipHolderNew.PayeeContactNo);
                self.NewLast_Dt(SipHolderNew.SIP_Last_Date);
                self.Action('E');
               }
               else{
                var SipHolder = data.ResponseData[0];
                if (SipHolder.Amdnt_No != null){
                $('#ammend').css('display', 'inline');
                }
//                $('#modalSearch').modal('show');
               
                self.Amdnt_No(SipHolder.Amdnt_No);
                self.Name(SipHolder.Name);
                self.Email(SipHolder.Email);
                self.SIP_Reg_No(SipHolder.SIP_Reg_No);
                var dpcode = ((SipHolder.boid).toString()).substr(0,8);
                self.SelectedDp(self.Depo().find(x => x.DP_Id_Cds() === dpcode));
                self.BOID(((SipHolder.boid).toString()).substr(8,16));
                self.SelectedHolder(self.Holders().find(x => x.HolderTypeNo() === SipHolder.HolderTypeNo));
                self.Address(SipHolder.Address);
                self.payeename(SipHolder.PayeeName);
                self.Contact1(SipHolder.Contact1);
                self.Contact2(SipHolder.Contact2);
                self.Sip_amt(SipHolder.Sip_amt);
                self.SIP_DT(SipHolder.SIP_DT);
                self.Action_Date(SipHolder.Action_Date);
                self.Effective_Dt(SipHolder.SIP_Eff_Date);
                self.SelectedInterval(self.Intervals().find(x => x.Sip_code() === SipHolder.SIP_Interval.trim()));
                self.Introducer(SipHolder.Introducer);
                self.SelectedModel(SipHolder.Model_of_Sip);
                if(SipHolder.Model_of_Sip == 'Unlimited'){
                  $('#txtlstdt,#txtnum,#txttermtype,#terms,#lstDt').css("display","none");
                  $('#lstDt,#terms,#termtype').css("display","none");
                   self.termno('');
                   self.Selterm(null);
                   self.Last_Dt('');
                 }
                 else{
                  $('#txtlstdt,#txtnum,#txttermtype,#terms,#lstDt').css("display","inline");
                  $('#lstDt,#terms,#termtype').css("display","inline");
                   var str = (SipHolder.Terms);
                   var splitStr = str.split(" ");
                   self.termno(splitStr[0]);
                   self.Selterm(self.TermTypes().find(x => x.TermTypeName == splitStr[1]));
                 }
                self.SelPayments(self.PaymentLists().find(x => x.PaymentCode() === SipHolder.PaymentCode));
                 if(SipHolder.St_BankAccountNo ==null || SipHolder.St_BankAccountNo==""){
                self.SI_BankAcc_no("N/A");
                }
                else{
                self.SI_BankAcc_no(SipHolder.St_BankAccountNo);
                }
                   if(SipHolder.St_BankCode == "N/A" || SipHolder.St_BankCode == null){
                var St_BankCode = "01";
                }
                else{
                var St_BankCode = SipHolder.St_BankCode;
                }
                self.SelStandingBanks(self.StandingBanks().find(x => x.bankcode() === St_BankCode));
                self.SelectedBank(self.Banks().find(x => x.bankcode() === SipHolder.BankCode));
                self.acc_no(SipHolder.Bank_Account_No);
                self.IntroducerRem(SipHolder.IntroducerRem);
                self.PayeeContactNo(SipHolder.PayeeContactNo);
                self.Last_Dt(SipHolder.SIP_Last_Date);
                self.File1("data:image/jpeg;base64," + SipHolder.File1);
                self.File2("data:image/jpeg;base64," + SipHolder.File2);
                self.Action('E');
                self.Is_Unit_Holder(SipHolder.Is_Unit_Holder);
                self.New_Action_Date(SipHolder.New_Action_Date);
                self.ShHolderNo(SipHolder.ShHolderNo);
                
                }
self.LoadReqType();
        }
      }); 
   
    }

   // self.ViewPurchaseEntryForm();

    self.LoadData = function(){
    var url = "/Handler/SIPHandling/AmendmentRequestHandler.ashx";
    var data = { 'method': 'LoadData', 'scheme_code': '', 'ccode': '', 'Holder_typeNo':HolderType, 'BOID':$('#BOID').text(), 'l_company_id': '001'};
    $.post(url, data,
        function (result) {
            waitMsg.hide();
                var data = jQuery.parseJSON(result);
                
                    if (data.ResponseData != null && data.ResponseData.length != 0) {
                        var mappedTasks = $.map(data.ResponseData, function (item) {
                            return new SIPHolder(item)
                    })
 
                    var data = null;
                    self.UserCenters(null);
                    self.UserCenters(mappedTasks);
                    var data = ko.toJS(self.UserCenters());
                    self.ViewPurchaseEntryForm();
                    }
                    else{
                        message = "You Do Not Have Active Sip Registration!!!";
                        msg(message, "ALERT");
                        self.UserCenters(null);
                        $('#btnProceed').attr('disabled',true);
//                        $('#tblUsers').DataTable().destroy();
//                        $('#tblUsers tbody').empty();
                    }

                    });     
    }

    self.LoadData();

   

    
      self.EditData = function(data){
       $("#btnAdd").text("Update");
        self.selectedItem(data);
        self.SelectedBank(self.Banks().find(x => x.bankcode() === data.BankCode()));
        self.acc_no(data.Bank_Account_No());
        
    }
    self.RemoveCenter = function(data){
      self.BanksInfo.remove(data);
      $("#btnAdd").text("Add");
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

            if (files[0].size > 1000000) {
                edocerror = 2;
                msg("Document size must be less than 1 mb !!!<br>");
                self.FileUpload1("");
                //self.StampFileName("");
                return;
            }

            reader.onloadend = function (event) {

                var dataUri = event.target.result
                docfile4 = dataUri;
                //self.StampFileName(docfile4);
               // self.FileUpload1(docname4);
                self.File1(docfile4);
            }
        }
        else
        {
           self.File1(''); 
        }
    });

    $("#ImgFile2").on("change", function () {
   
        if (this.files[0] != undefined) {
            edocerror5 = "";
            docsize5 = "";
            docsize5 = this.files[0].size / 1024 / 1024;

            var fileInput2 = document.getElementById('ImgFile2');
            docsize5 = fileInput2.files[0].name;

            var files = !!this.files ? this.files : [];
            if (!files.length || !window.FileReader) return;

            docsize5 = files[0].type;

            var reader = new FileReader();
            reader.readAsDataURL(files[0]);

            if (files[0].size > 1000000) {
                edocerror = 2;
                msg("Document size must be less than 1 mb !!!<br>");
                self.FileUpload2("");
                //self.StampFileName("");
                return;
            }

            reader.onloadend = function (event) {

                var dataUri = event.target.result
                docfile6 = dataUri;
                //self.StampFileName(docfile4);
               // self.FileUpload1(docname4);
                self.File2(docfile6);
            }
        }
        else
        {
           self.File2(''); 
        }
    });
    
    self.AddValidation = function(){
        var errMsg = "";
        var objFocus = null;
        //#region Validating required fields
        if (self.SelectedBank() == undefined) {
            errMsg += "Please Select Bank!!!<br>"
        }
      
        if (Validate.empty(self.acc_no())) {
            errMsg += "Please Enter Bank Account_No !!!<br>";
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
   self.AddBank = function(){
    if(self.AddValidation()){
       var add = self.selectedItem();
            if (add != undefined) {
                    add.BankName(self.SelectedBank().bankname());
                    add.BankCode(self.SelectedBank().bankcode);
                    add.Bank_Account_No(self.acc_no());
                    $("#btnAdd").text("Add");
              }
             else {
                    add = {
                        BankName: ko.toJS(self.SelectedBank().bankname()),
                        BankCode: ko.toJS(self.SelectedBank().bankcode),
                        Bank_Account_No:ko.toJS(self.acc_no())
                    };

                    if (self.BanksInfo.indexOf(add) > -1) {
                        return;
                    }
                    self.BanksInfo.push(new BankInfo(add));
              }
                $('#btnSave, #btnCancel').attr('disabled', false);
                $('#btnEdit,#btnDel').attr('disabled', true);
                self.SelectedBank(null);
                self.acc_no('')
                }
    }

    self.NewEffective_Dt.subscribe(function(){
     if( self.NewEffective_Dt()!= null && self.NewEffective_Dt()!= ""){
    var GivenDate = self.NewEffective_Dt();
     var CurrentDate = self.date();
         if(GivenDate >= CurrentDate){
            self.NewEffective_Dt(self.NewEffective_Dt());
          }else{
            msg("Please Enter Today's Date Or Future Date", alert);
            self.NewEffective_Dt(null);
         }
         }
    if(self.checkRptTyp()=='02'){
        if(self.SelectedModel() == "Limited"){
            $('#newtxtlstdt,#newterm,#newtxttermtype').css("display","inline");
            $("#newtxtlstdt,#newterm,#newtxttermtype").attr("disabled", true);
            self.NewSelectedModel(self.SelectedModel());
            self.Newtermno(self.termno());
            self.NewSelterm(self.NewTermTypes().find(x => x.NewTermTypeName == self.Selterm().TermTypeName));
            var termtype = self.Selterm().TermTypeName;
            if (termtype =='Year' ){
            var start_date =moment(self.Effective_Dt());
            var lst_date = moment(self.Last_Dt());
            var total_int = (lst_date._d.getFullYear()*12 + lst_date._d.getMonth()) - (start_date._d.getFullYear()*12 + start_date._d.getMonth());
            var neweff_dt = moment(self.NewEffective_Dt());
            var mid_int=(neweff_dt._d.getFullYear()*12 + neweff_dt._d.getMonth()) - (start_date._d.getFullYear()*12 + start_date._d.getMonth());
            var remaining_int=total_int-mid_int;
            var final_dt = neweff_dt.add(remaining_int,'months');
            var last_Date = convert(final_dt._d); 
         self.NewLast_Dt(last_Date);
         }
         if(termtype =='Month'){
//         endDateMoment.add((termno), termtype);
//         var last_Date = convert(endDateMoment._d);
//         self.NewLast_Dt(last_Date);
         }
         }
         else{
         
//          $('#newtxtlstdt,#newterm,#newtxttermtype').css("display","none");
          self.Newtermno('');
          self.NewSelterm(null);
          self.NewLast_Dt('');
         }
     }
     else{
     
     }
  }
);

    self.Getdate = function () {
    if(self.checkRptTyp()=='02'){
    if (self.SelectedModel() == self.NewSelectedModel())
    {
    
        if (self.NewSelectedModel() == "Unlimited" ){
            self.Newtermno('');
            self.NewSelterm(null);
            self.NewLast_Dt('');
             $('#newtxtlstdt,#newterm,#newtxttermtype').css("display","none");

        }
        else if(self.NewSelectedModel() == "Limited"){
       // if(self.NewEffective_Dt()==""){
            $('#terms,#lstDt').css("display","block");
            $('#newtxtlstdt,#newterm,#newtxttermtype').css("display","inline");
            $('#newtxtlstdt,#newterm,#newtxttermtype').attr("disabled",true);
            self.Newtermno(self.termno());
            //self.NewSelterm(self.TermTypes().find(x => x.TermTypeName == self.Selterm()));
            self.NewSelterm(self.NewTermTypes().find(x => x.NewTermTypeName == self.Selterm().TermTypeName))
            self.NewLast_Dt(self.Last_Dt());
//            }
//            else{

//            }
        }
    }
    else{
    
        if(self.NewSelectedModel() == "Unlimited" ){
           // $('#terms,#lstDt').css("display","none");
            $('#newtxtlstdt,#newterm,#newtxttermtype').css("display","none");
            self.Newtermno('');
            self.NewSelterm(null);
            self.NewLast_Dt('');
        }
        else if(self.NewSelectedModel() == "Limited"){
            $('#terms,#lstDt').css("display","block");
            $('#newtxtlstdt,#newterm,#newtxttermtype').css("display","inline");
            $('#newterm,#newtxttermtype').attr("disabled",false);

        }
    }
    }
    else{
     if (self.NewSelectedModel() == 'Limited') {
         $('#newtxtlstdt,#newterm,#newtxttermtype').css("display","inline");
//      $('#txtlstdt,#txtnum,#txttermtype').css("display","block");
       $('#newterm,#newtxttermtype').attr("disabled",false);
      }
      else{
        self.Newtermno('');
        self.NewSelterm(null);
        self.NewLast_Dt('');
        $('#newtxtlstdt,#newterm,#newtxttermtype').css("display","none");
          
      }
    }
    }

    self.NewSelterm.subscribe (function () {
 
    //if(self.NewLast_Dt() == ""){
      if(self.Newtermno() != undefined && self.Newtermno() >=1){
        if (self.NewSelterm() != undefined && self.NewSelterm() != null) {
          if( self.TermValidation()){
//      
        if(self.NewEffective_Dt() == ""){
            var startDate = $("#date").text();
            }
            else{
            var startDate = self.NewEffective_Dt();
            }
            if(self.NewSelectedInterval() == undefined){
             var SelectedTerm = (ko.toJS(self.SelectedInterval().No_of_Months));
            }
            else{
            var SelectedTerm = (ko.toJS(self.NewSelectedInterval().NewNo_of_Months));
            }
            var no_of_months = (SelectedTerm)*5;
//            var no_of_months = (ko.toJS(self.SelectedInterval().No_of_Months))*5;
            var term = (self.Newtermno());
            var Newtermtype = self.NewSelterm().NewTermTypeName;
            var endDateMoment = moment(startDate); // moment(...) can also be used to parse dates in string format
             var Newtermno = (self.Newtermno()-1);
            if (Newtermtype =='Year' && Newtermno==0 ){
            // endDateMoment.add((term), Newtermtype);
              endDateMoment.add((Newtermtype), term);
               if((SelectedTerm) == 1){
                endDateMoment.subtract(("Month"),1 );
              }
            }
            
            else{
           // endDateMoment.add((Newtermno), Newtermtype);
             endDateMoment.add((term), Newtermtype);
             endDateMoment.subtract(("Month"),SelectedTerm );
            }
            var last_Date = convert(endDateMoment._d);

            var endinstMoment = moment(startDate); 
            endinstMoment.add((no_of_months), "Month");
             var limitedinstdate = convert(endinstMoment._d);
               self.NewLast_Dt(last_Date);
//             }
         }    
        }
        }
        else{
        self.NewLast_Dt(null);
        self.Newtermno(null);
        //$('#txtnum').focus();
        }
//        }
//        else{
//        }
       
    }
    );

    self.TermValidation = function(){
     
    var errMsg = "";
        var objFocus = null;
        //#region Validating required fields
        if(self.checkRptTyp()=='04'){
            if ((Validate.empty(self.Newtermno()))) {
                errMsg += "Please Enter New Term No!!!<br>"
            }

            if (Validate.empty(self.NewEffective_Dt()) || self.NewEffective_Dt=="") {
                errMsg += "Please Enter New SIP Effective Date !!!<br>";
            }
        }
        else{
        }
      
        //#endregion

        if (errMsg !== "") {

            msg(errMsg, "ALERT");
            self.Newtermno(null);
            self.NewSelterm(null);
            return false;
        }
        else {
            return true;
        }
    }

     self.Cancel = function(){
            window.location = "/Modules/DashBoard.aspx";
            }


    self.SaveAmendment = function(){
    
    if(self.Validation()){
//     usercode = self.amntccode();
//     scheme_code = self.amntscheme_code();
      if(self.NewContact1() != undefined && self.NewContact1() != "" ){
      var Contact1 =self.NewContact1();
      }
      else{
       var Contact1 =self.Contact1();
      }
      if(self.NewContact2() != undefined && self.NewContact2() != "" ){
      var Contact2 =self.NewContact2();
      }
      else{
      var Contact2 =self.Contact2();
      }
       if(self.NewEmail() != undefined && self.NewEmail() != "" ){
      var Email =self.NewEmail();
      }
      else{
      var Email =self.Email();
      }
       if(self.Newpayeename() != undefined && self.Newpayeename() != "" ){
      var payeename =self.Newpayeename();
      }
      else{
       var payeename =self.payeename();
      }
      if(self.NewPayeeContactNo() != undefined && self.NewPayeeContactNo() != "" ){
      var PayeeContactNo =self.NewPayeeContactNo();
      }
      else{
       var PayeeContactNo =self.PayeeContactNo();
      }
      if(self.NewSelectedInterval() != undefined && self.NewSelectedInterval() != "" ){
      var Interval =self.NewSelectedInterval().NewSip_code();
      }
      else{
       var Interval =self.SelectedInterval().Sip_code();
      }
      if(self.NewSip_amt() != undefined && self.NewSip_amt() != "" ){
      var Sip_amt =self.NewSip_amt();
      }
      else{
       var Sip_amt =self.Sip_amt();
      }
      if(self.NewEffective_Dt() != undefined && self.NewEffective_Dt() != "" ){
      var Effective_Dt =self.NewEffective_Dt();
      }
      else{
       var Effective_Dt =self.Effective_Dt();
      }
       if(self.NewIntroducer() != undefined && self.NewIntroducer() != "" ){
      var Introducer =self.NewIntroducer();
      }
      else{
       var Introducer =self.Introducer();
      }
       if(self.NewSelPayments() != undefined && self.NewSelPayments() != "" ){
      var SelPayments =ko.toJS(self.NewSelPayments().NewPaymentCode);
      }
      else{
       var SelPayments =ko.toJS(self.SelPayments().PaymentCode);
      }
     if(self.New_Action_Date() != undefined && self.New_Action_Date() != "" ){
      var SIP_Eff_Date =self.New_Action_Date();
     }
     else{
      var SIP_Eff_Date =self.Action_Date();
     }
     if(self.NewLast_Dt() != undefined && self.NewLast_Dt() != "" ){
     var Last_Dt =self.NewLast_Dt();
     }
     else{
     if(self.NewSelectedModel() == "Unlimited"){
     var Last_Dt = null;
     }
     else{
      var Last_Dt =self.Last_Dt();
      }
     }
     if(self.NewSelStandingBanks() != undefined && self.NewSelStandingBanks() != "" ){
      var SelStandingBanks =self.NewSelStandingBanks().Newbankcode();
     }
     else{
      var SelStandingBanks =self.SelStandingBanks().bankcode();
     }
     if(self.NewSI_BankAcc_no() != undefined && self.NewSI_BankAcc_no() != "" ){
      var SI_BankAcc_no =self.NewSI_BankAcc_no();
     }
     else{
      var SI_BankAcc_no =self.SI_BankAcc_no();
     }
     if(self.NewSelectedBank() != undefined && self.NewSelectedBank() != "" ){
      var SelectedBank =self.NewSelectedBank().Newbankcode();
     }
     else{
      var SelectedBank =self.SelectedBank().bankcode();
     }
     if(self.Newacc_no() != undefined && self.Newacc_no() != "" ){
      var acc_no =self.Newacc_no();
     }
     else{
      var acc_no =self.acc_no();
     }
     if (self.NewSelectedModel() != undefined ){
        var Model_Of_Sip=self.NewSelectedModel();
        if(self.NewSelectedModel() == "Limited"){
        var Terms =  self.Newtermno()+" "+self.NewSelterm().NewTermTypeName;
        }
        else{
           Terms = null;
        }
     }
     else{
        var Model_Of_Sip=self.SelectedModel();
        if(self.SelectedModel() == "Limited"){
         var Terms =  self.termno()+" "+self.Selterm().TermTypeName;
        }
        else{
            Terms = null;
        }
     }


     
     self.Amdnt_No() != undefined ? self.Action('U'):self.Action('A');
      
      var type 

      if(self.SelectedHolder() == undefined ){
            type= "01"
      }else{
        type = ko.toJS(self.SelectedHolder().HolderTypeNo());
      }
       var args = {             Amdnt_No:self.Amdnt_No(),
                                l_company_id:l_company_id,
                                scheme_code: scheme_code,
                                ccode: ccode,
                                SIP_Reg_No: self.SIP_Reg_No(),
                                ShHolderNo: self.ShHolderNo(),
                                Name: self.Name(),
                                Email: Email,
                                boid: ko.toJS(self.SelectedDp().DP_Id_Cds())+ko.toJS(self.BOID),
                                HolderTypeNo: type,
                                SIP_Interval: Interval,
                                SIP_DT: self.SIP_DT(),
                                SIP_Eff_Date:Effective_Dt,
                                Sip_amt:Sip_amt,
                                Model_of_Sip:Model_Of_Sip,
                                Last_Date:Last_Dt,
                                Online:self.Online(),
                                ENTRY_BY: $("#username").text(),
                                ENTRY_DT: $("#date").text(),
//                                ENTRY_DT: self.day_start_date(),
                                APPROVED: "N",
                                remarks: self.remarks(),
                                APPSTATUS: "UNPOSTED",
                                Address:self.Address(),
                                Contact1:Contact1,
                                Contact2:Contact2,
                                PayeeName:payeename,
                                Introducer:Introducer,
                                IntroducerRem:self.IntroducerRem(),
                                PayeeContactNo:PayeeContactNo,
                                IsApproved:self.Approved_By(),
                                BankInfo:self.BanksInfo(),
                                St_BankCode:SelStandingBanks,
                                PaymentCode:SelPayments,
                                St_BankAccountNo:SI_BankAcc_no,
                                Terms: Terms,
                                File1:self.File1(),
                                File2:self.File2(),
                                Is_Unit_Holder: self.Is_Unit_Holder(),
                                Action : self.Action(),
                                BankCode:SelectedBank,
                                Bank_Account_No:acc_no,
                                checkRptTyp:self.checkRptTyp()
                            };
                           
                            var url = "../../Handler/SIPHandling/AmendmentRequestHandler.ashx" ;
                            var data = { 'method': 'SaveAmmendment', 'args': JSON.stringify(ko.toJS((args))) };
                            $.post(url, data,
                                function (result) {
                                 waitMsg.hide();
                                    var data = jQuery.parseJSON(result);
                                    if(data.IsSucess){
                                        var message = "";
                                        if(self.Action()=='A'){
                                        message = "Please note the Transaction Id. " + data.ResponseData + " and " + "Ammendmend Saved Succesfully!!";
                                        }
                                        else  if(self.Action()=='U'){
                                        message = "Please note the Transaction Id. " + data.ResponseData + " and " + "Ammendmend Updated Succesfully!!";
                                        }
                                        msg(message, "ALERT");
                                        self.ClearNewData();
                                        location.reload();
                                      //$("#modalSearch").modal('hide');
                                    }
                                    else{
                                    msg(data.Message, "ALERT");
                                    }
                                });
                                }
    }

    self.Validation = function(){
     var errMsg = "";
        var objFocus = "";
        if(self.checkRptTyp() == '02'){
            if (self.NewSelectedModel() == "Limited"){
                if(Validate.empty(self.Newtermno() )){
                 errMsg += "Please Enter Term No !!!<br>";
                }
                if(self.NewSelterm() == undefined){
                errMsg += "Please Select Term Type !!!<br>";
                }
            }
            if(Validate.empty(self.NewEffective_Dt() )){
            errMsg += "Please Enter New Effective Date !!!<br>";
            }
        }
        else{
            if(Validate.empty(self.NewEffective_Dt() )){
            errMsg += "Please Enter New Effective Date !!!<br>";
            }
            if(self.NewSelectedModel() == undefined){
            errMsg += "Please Select New Model Of Sip !!!<br>";
            }
            if(self.NewSelectedModel()=='Limited'){
                 if(Validate.empty(self.Newtermno() )){
                 errMsg += "Please Enter Term No !!!<br>";
                }
                if(self.NewSelterm() == undefined){
                errMsg += "Please Select Term Type !!!<br>";
                }
            }
            else if(self.NewSelectedModel()=='Unlimited'){}
        }
         if (errMsg !== "") {

            msg(errMsg, "ALERT");
            return false;
        }
        else{
        return true;
        }
    }
    
}
$(document).ready(function () {
    ValidateSession();
    ko.applyBindings(new AmendmentRequestViewModel());
    $('.pcoded .pcoded-navbar .pcoded-item #2').addClass("pcoded-trigger")
    $('.pcoded .pcoded-navbar .pcoded-item #2 ul').css('display', 'block')
    document.title = "Amendment Request";

});