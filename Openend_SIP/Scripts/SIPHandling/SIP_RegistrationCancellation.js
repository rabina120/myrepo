function ListedCompany(data) {
    var self = this;
    if (data != undefined) {
        self.Comp_Id = ko.observable(data.Comp_Id);
        self.Name = ko.observable(data.Name);

    }
}

function CollCenter(data) {
    var self = this;
    if (data != undefined) {
        self.ccode = ko.observable(data.ccode);
        self.cname = ko.observable(data.cname);

    }
}


function Company(data) {
    var self = this;
    self.CompId = ko.observable(data.CompId);
    //self.l_company_id = ko.observable(data.l_company_id);
    self.CompName = ko.observable(data.CompName);
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
       self.Bo_Account_No=ko.observable(data.boid);
       self.File1=ko.observable(data.File1);
       self.File2=ko.observable(data.File2);
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


var SIPViewModel = function () {
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
    
     self.IsPosted=ko.observable();
    self.selint=ko.observable();
    self.Count =ko.observable();
    self.cancelsip=ko.observable();
    self.Bo_Account_No = ko.observable();
    self.Bo_Account_No(BOID);
    self.SIP_Reg_No= ko.observable();
    self.Name = ko.observable();
    self.Bo_Account_No= ko.observable();
    self.ShHolderNo = ko.observable();
    self.SelectedHolder = ko.observable();
    self.PaymentCode= ko.observable();
    self.Intervals =ko.observableArray([]);
    self.SelectedInterval = ko.observable();
    self.SelectedModel =ko.observable();
    self.Online = ko.observable(false);
    self.Terms = ko.observable(false);
    self.Last_Dt=ko.observable();
    self.SIP_DT = ko.observable();
    self.Effective_Dt=ko.observable();
    self.Name  =ko.observable();
    self.Email=ko.observable();
    self.BOID=ko.observable();
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
    self.SelPayments=ko.observable();
    self.SelPayments=ko.observable();
    self.SipModel = ko.observableArray(['Limited','Unlimited']);
    self.Is_Unit_Holder= ko.observable();
    self.SIP_Interval= ko.observable();
    self.IsApproved= ko.observable();
    self.Intervals = ko.observableArray([]);
    self.PayeeContactNo  = ko.observable();
    self.IntroducerRem = ko.observable();

     var TermType = function(TermTypeCode, TermTypeName) {
        this.TermTypeCode = TermTypeCode;
        this.TermTypeName = TermTypeName;
    };
    self.TermTypes = ko.observableArray([
        new TermType("01", "Month"),
        new TermType("02", "Year"),
        
    ]);

    self.date  = ko.observable();
    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = today.getFullYear();

    today = yyyy+ '-'+ mm + '-' + dd;
    paydate =dd+'-'+mm+'-'+yyyy;
    self.date(today);
    self.Cancel= function(){
       $("#cancelsipreg").prop("checked", false);
        self.cancelsip(false);
        document.getElementById("btnSumbit").disabled = true;
        self.CheckSHolders();
        GetDetail();
    }   
   
    self.LoadSIPIntervals = function () {
        $.ajax({
            type: "GET",
            dataType: "json",
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
    self.CheckcancelSip = function(){
      if ($("#cancelsipreg").prop("checked")) {
            document.getElementById("btnSumbit").disabled = false;
        } 
        else {
          
            document.getElementById("btnSumbit").disabled = true;
        }
    }
    
     self.checkcancellation = function(){
        var url = "/Handler/SIPHandling/SIPRegistrationCancellation.ashx";
            var data = { 'method': 'checkcancellation', 'scheme_code': scheme_code, 'l_company_id': l_company_id, 'Bo_Account_No': self.Bo_Account_No(),'SIP_Reg_No':self.SIP_Reg_No() };
            $.post(url, data,
              function (result) {
                  var data = jQuery.parseJSON(result);
                      self.Count(data.ResponseData.length);
                      if(data.ResponseData.length >0){
                        var SHolder = data.ResponseData[0];
                        self.IsPosted(SHolder.APPSTATUS);
                        self.IsApproved(SHolder.IsApproved);
                  }
                  
              });
       }

    self.CheckSHolders = function () {
    self.Bo_Account_No(BOID);
                        var url = "/Handler/SIPHandling/SIPRegistrationCancellation.ashx";
                       var data = { 'method': 'GetHolderInfoByBoid', 'scheme_code': scheme_code, 'l_company_id': l_company_id, 'Bo_Account_No': self.Bo_Account_No(), 'ccode': ccode, 'SHHOLDERNO': SHHOLDERNO };
                        $.post(url, data,
                            function (result) {
                                waitMsg.hide();
                                var obj = jQuery.parseJSON(result);
                                if (obj.IsSucess != null) {
                                    if (obj.ResponseData.length == 1) {
                                        var SHolder = obj.ResponseData[0];
                                         self.Introducer(SHolder.Introducer)
                                         self.IntroducerRem(SHolder.IntroducerRem)
                                         self.payeename(SHolder.PayeeName)
                                         self.PayeeContactNo(SHolder.PayeeContactNo)
                                         if(SHolder.Model_of_Sip == 'Unlimited'){
                                             self.Terms(null); 
                                         }
                                         else{
                                           var str = (SHolder.Terms);
                                           var splitStr = str.split(" ");
                                           
                                           self.Terms(str);
                                           
                                         }
                                         self.ShHolderNo(SHolder.ShHolderNo)
                                         self.Name(SHolder.Name)
                                         self.SelectedModel(SHolder.Model_of_Sip);
                                         self.SIP_DT(SHolder.SIP_DT)
                                         self.Last_Dt(SHolder.SIP_Last_Date)
                                         self.Effective_Dt(SHolder.SIP_Eff_Date)
                                         self.Contact1(SHolder.Contact1);
                                         self.Contact2(SHolder.Contact2);
                                         self.Sip_amt(SHolder.Sip_amt);
                                         self.Email(SHolder.Email)
                                         self.SelectedInterval(SHolder.SIP_Interval);
                                         self.SelPayments(SHolder.PaymentCode);
                                         self.SIP_Reg_No(SHolder.SIP_Reg_No)
                                         self.SelectedHolder(SHolder.HolderTypeNo);
                                         self.SIP_Interval(SHolder.SIP_Interval);
                                         self.SIP_Reg_No(SHolder.SIP_Reg_No);
                                         self.PaymentCode(SHolder.PaymentCode);
                                         var s =  self.Intervals().find(x => x.Sip_code() == SHolder.SIP_Interval.trim());
                                         self.selint(s.SIP_Interval());
                                         self.checkcancellation();
                                   }
                                }

                            }
                        );


    }

    self.CheckSHolders();

    self.CancleSIPRegistration = function(){
           Confirm("DO YOU WANT TO CANCEL SIP REGISTRATION?", 'Confirmation Dialog', function (r) {
                if (r) {
               var args = {
                                l_company_id:l_company_id,
                                scheme_code: scheme_code,
                                ccode: ccode,
                                SIP_Reg_No: self.SIP_Reg_No(),
                                ShHolderNo: self.ShHolderNo(),
                                Name: self.Name(),
                                Email:self.Email(),
                                boid: self.Bo_Account_No(),
                                HolderTypeNo:  self.SelectedHolder(),
                                SIP_Interval: self.SelectedInterval(),
                                SIP_DT: self.SIP_DT(),
                                SIP_Eff_Date: self.Effective_Dt(),
                                Sip_amt:self.Sip_amt(),
                                Model_of_Sip:self.SelectedModel(),
                                Last_Date:self.Last_Dt(),
                                ENTRY_BY: 'online User',
                                ENTRY_DT: $("#date").text(),
                                remarks: self.remarks(),
                                Contact1:self.Contact1(),
                                Contact2:self.Contact2(),
                                PayeeName:self.payeename(),
                                Introducer:self.Introducer(),
                                IntroducerRem:self.IntroducerRem(),
                                PayeeContactNo:self.PayeeContactNo(),
                                PaymentCode:self.SelPayments(),
                                Action:'05',
                                TranType:'02'

                               
                            };
                            console.log(JSON.stringify(ko.toJS((args))));
                            var url = "../../Handler/SIPHandling/SIPRegistrationCancellation.ashx" ;
                            var data = { 'method': 'CancelSIPHolderDetails', 'args': JSON.stringify(ko.toJS((args))) };
                            $.post(url, data,
                                function (result) {
                                 waitMsg.hide();
                                    var data = jQuery.parseJSON(result);
                                    if(data.IsSucess){
                                        var message = "";
                                        message = "REQUEST SEND SUCCESSFULLY";
                                        msg(message, alert);
                                        self.Cancel();
                                    }
                                    else{               
                                        waitMsg.hide();
                                        msg(data.Message, alert);
                                        self.Cancel();
                                 
                                    }
                                });
                }
             });

    
   }

  

};

 
    
$(document).ready(function () {
    ValidateSession();
    ko.applyBindings(new SIPViewModel());
    $('.pcoded .pcoded-navbar .pcoded-item #SIP').addClass("pcoded-trigger")
    $('.pcoded .pcoded-navbar .pcoded-item #SIP ul').css('display', 'block')
    document.title = "SIP Registration Cancellation";
});