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

function ParaComp(data) {
    var self = this;
    if (data != undefined) {
        self.scheme_code = ko.observable(data.scheme_code);
        self.SchemeEnName = ko.observable(data.SchemeEnName);
        self.PerShVal = ko.observable(data.PerShVal);
        self.MaxKitta = ko.observable(data.MaxKitta);
        self.minkitta = ko.observable(data.Minkitta);
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
function PaymentModeList(data){
    var self = this;
    if(data != undefined){
        self.PaymentCode = ko.observable(data.PaymentCode);
        self.PaymentMode = ko.observable(data.PaymentMode);
    }
}

function ChargeType(data) {
    var self = this;
    if (data != undefined) {
        self.SDescription = ko.observable(data.SDescription);
        self.SCharge_Code = ko.observable(data.SCharge_Code);
    }
}

function ShHolder(data) {
    var self = this;
    if (data != undefined) {
        self.Scheme_code = ko.observable(data.Scheme_code);
        self.ShHolderNo = ko.observable(data.ShHolderNo);
        self.cname =ko.observable(data.cname);
        self.Title = ko.observable(data.Title);
        self.FName = ko.observable(data.FName);
        self.MName = ko.observable(data.MName);
        self.LName = ko.observable(data.LName);
        self.Nep_DOB = ko.observable(data.Nep_DOB);
        self.Eng_DOB = ko.observable(data.Eng_DOB);
        self.Gender = ko.observable(data.Gender);
        self.Nationality = ko.observable(data.Nationality);
        self.Citizenship_No = ko.observable(data.Citizenship_No);
        self.Cit_Issue_District = ko.observable(data.Cit_Issue_District);
        self.Cit_Issue_Dt = ko.observable(data.Cit_Issue_Dt);
        self.PAN_No = ko.observable(data.PAN_No);
        self.P_CountryCode = ko.observable(data.P_CountryCode);
        self.P_ProvinceCode = ko.observable(data.P_ProvinceCode);
        self.P_DistrictCode = ko.observable(data.P_DistrictCode);
        self.P_Mun = ko.observable(data.P_Mun);
        self.P_Ward_No = ko.observable(data.P_Ward_No);
        self.P_Tole = ko.observable(data.P_Tole);
        self.P_TelNo = ko.observable(data.P_Tel_No);
        self.P_Mobile_no = ko.observable(data.P_Mobile_no);
        self.Email_ID = ko.observable(data.Email_ID);
        self.Website = ko.observable(data.Website);
        self.T_CountryCode = ko.observable(data.T_CountryCode);
        self.T_ProvinceCode = ko.observable(data.T_ProvinceCode);
        self.T_DistrictCode = ko.observable(data.T_DistrictCode);
        self.T_Mun = ko.observable(data.T_Mun);
        self.T_Tel_No = ko.observable(data.T_Tel_No);
        self.T_Ward_No = ko.observable(data.T_Ward_No);
        self.T_Tole = ko.observable(data.T_Tole);
        self.T_Mobile_No = ko.observable(data.T_Mobile_No);
        self.FaName = ko.observable(data.FaName);
        self.GFName = ko.observable(data.GFName);
        self.MotherName = ko.observable(data.MotherName);
        self.SpouseName = ko.observable(data.SpouseName);
        self.SonName = ko.observable(data.SonName);
        self.DaughterName = ko.observable(data.DaughterName);
        self.DaughterinLawName = ko.observable(data.DaughterinLawName);
        self.MotherinLawName = ko.observable(data.MotherinLawName);
        self.ChiefExecutiveName = ko.observable(data.ChiefExecutiveName);
        self.Com_SecretaryName = ko.observable(data.Com_SecretaryName);
        self.Company_Type = ko.observable(data.Company_Type);
        self.Country_of_Registration = ko.observable(data.Country_of_Registration);
        self.Reg_No = ko.observable(data.Reg_No);
        self.Reg_Office = ko.observable(data.Reg_Office);
        self.Reg_Date = ko.observable(data.Reg_Date);
        self.VAT_Reg_No = ko.observable(data.VAT_Reg_No);
        self.Main_Com_Name = ko.observable(data.Main_Com_Name);
        self.Main_Com_Address = ko.observable(data.Main_Com_Address);
        self.Business_Nature = ko.observable(data.Business_Nature);
        self.Area_of_Wok = ko.observable(data.Area_of_Wok);
        self.IsListed = ko.observable(data.IsListed);
        self.Listed_Dt = ko.observable(data.Listed_Dt);
        self.Bo_Account_No = ko.observable(data.Bo_Account_No);
        self.Bank_Account_No = ko.observable(data.Bank_Account_No);
        self.BankCode = ko.observable(data.BankCode);
        self.TotalKitta = ko.observable(data.TotalKitta);
        self.TfracKitta = ko.observable(data.TfracKitta);
        self.EntryBy = ko.observable(data.EntryBy);
        self.Entry_Dt = ko.observable(data.Entry_Dt);
        self.Approved = ko.observable(data.Approved);
        self.App_Status = ko.observable(data.App_Status);
        self.Approved_By = ko.observable(data.Approved_By);
        self.App_date = ko.observable(data.App_date);
        self.Ref_Name = ko.observable(data.Ref_Name);
        self.Ref_Address = ko.observable(data.Ref_Address);
        self.Ref_ContactNo = ko.observable(data.Ref_ContactNo);
        self.Reference_No = ko.observable(data.Reference_No);
        self.NRN_ID = ko.observable(data.NRN_ID);
        self.IsMinor = ko.observable(data.IsMinor);
        self.IsInstitution = ko.observable(data.IsInstitution);
        self.FatherinLawName = ko.observable(data.FatherinLawName);
        self.Ref_Date = ko.observable(data.Ref_Date);
        self.NepName = ko.observable(data.NepName);
        self.NepAddress = ko.observable(data.NepAddress);
        self.BankAccountType = ko.observable(data.BankAccountType);
        self.Branch_code = ko.observable(data.Branch_code);
        self.OccupationDetail = ko.observable(data.OccupationDetail);
        self.InstitutionDetail = ko.observable(data.InstitutionDetail);
        self.Minor = ko.observable(data.Minor);
        self.Nominee = ko.observable(data.Nominee);
        self.Institutiondetail_sign = ko.observable(data.Institutiondetail_sign);
        self.Signature = ko.observable(data.Signature);
        self.REQUEST_NO = ko.observable(data.REQUEST_NO);
        self.Boid_No= ko.observable(data.Boid_No);
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

function Bank(data) {
    var self = this;
    if (data != undefined) {
        self.bankcode = ko.observable(data.bankcode);
        self.bankname = ko.observable(data.bankname);
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
function HolderType(data){
    var self = this;
    if(data != undefined){
        self.HolderTypeNo = ko.observable(data.HolderTypeNo);
        self.HolderType = ko.observable(data.HolderType);
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


function PaymentTypeList(data) {
    var self = this;
    if (data != undefined) {
        self.PaymentCode = ko.observable(data.PaymentCode);
        self.PaymentMode = ko.observable(data.PaymentMode);
        self.PaymentStatus = ko.observable(data.PaymentStatus);
        self.PaymentFileName = ko.observable(data.PaymentFileName);
    }
}

var SIPViewModel = function () {
    var self = this;

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
    var ProductIdentity=  BOID.toString();   

    self.Comp_Id = ko.observable();
    self.l_company_id = ko.observable();
    self.CompName = ko.observable();
    self.Companies = ko.observableArray([]);
    self.Companylst = ko.observableArray([]);
    self.SelectedName = ko.observable();
    self.CompId = ko.observable();
    self.CCenters = ko.observableArray([]);
    self.scheme_code = ko.observable();
    self.SchemeEnName = ko.observable();
    self.Companies = ko.observableArray([]);
    self.SelectedComp = ko.observable();
    self.ccode = ko.observable();
    self.cname = ko.observable();
    self.CCenters = ko.observableArray([]);
    self.SelectedCC = ko.observable();

    self.SIP_Reg_No = ko.observable();
    self.Name = ko.observable();
    self.Bo_Account_No = ko.observable();
    self.ShHolderNo = ko.observable();
    self.Holders = ko.observableArray([]);
    self.SelectedHolder = ko.observable();
    self.Intervals = ko.observableArray([]);
    self.SelectedInterval = ko.observable();
    self.SelectedModel = ko.observable();
    self.Online = ko.observable(false);
    self.Last_Dt = ko.observable();
    self.SIP_DT = ko.observable();
    self.Effective_Dt = ko.observable();
    self.Name = ko.observable();
    self.Email = ko.observable();
    self.BOID = ko.observable();
    self.Sip_amt = ko.observable();
    self.acc_no = ko.observable();
    self.Reg_no = ko.observable();
    self.Contact1 = ko.observable();
    self.Contact2 = ko.observable();
    self.Address = ko.observable();
    self.payeename = ko.observable();
    self.Introducer = ko.observable();
    self.Approved_By = ko.observable();
    self.remarks = ko.observable();
    self.Action = ko.observable();
    self.File1 = ko.observable();
    self.File2 = ko.observable();
    self.FileUpload1 = ko.observable();
    self.ShHolders = ko.observableArray([]);
    self.Schemes = ko.observableArray([]);
    self.SelectedScheme = ko.observable();
    self.SipModel = ko.observableArray(['Limited [ अवधि तोकिएको  ] ', 'Unlimited [ असिमित किस्ताहरु ]']);
    //self.Is_Unit_Holder = ko.observable();
     var IS_UNIT_HOLDER;
    self.day_start_date = ko.observable();
    self.othersource = ko.observable();
    //For DP

    self.Depo = ko.observableArray([]);
    self.DPName = ko.observable();
    self.SelectedDp = ko.observable();
    self.Depo = ko.observable();
    self.DP_Id_Cds = ko.observable();
    self.Bo_Account_No = ko.observable();

    // for Bank
    self.BanksInfo = ko.observableArray([]);
    self.Banks = ko.observableArray([]);
    self.bankcode = ko.observable();
    self.SelectedBank = ko.observable();
    self.bankname = ko.observable();
    self.selectedItem = ko.observable();
    self.amtDetail = ko.observable();
    self.File3= ko.observable();
    self.FileName3 = ko.observable();

    // Payment Mode
    self.PaymentLists = ko.observableArray([]);
    self.PaymentCode = ko.observable();
    self.PaymentMode = ko.observable();

    self.PaymentStatus = ko.observable();
    self.PaymentFileName = ko.observable();
    self.PaymentTypeLists = ko.observableArray([]);

    self.SelPayments = ko.observable();
    self.Integrationcode= ko.observable();

    self.SI_BankAcc_no = ko.observable();
    self.PayeeContactNo = ko.observable();
    self.IntroducerRem = ko.observable();
    var TermType = function (TermTypeCode, TermTypeName) {
        this.TermTypeCode = TermTypeCode;
        this.TermTypeName = TermTypeName;
    };
    self.TermTypes = ko.observableArray([
        new TermType("01", "Month"),
        new TermType("02", "Year"),
        
    ]);
     var SipModel = function (ModelEngName, ModelName) {
        this.ModelEngName = ModelEngName;
        this.ModelName= ModelName;
    };
    self.SipModels = ko.observableArray([
        new SipModel("Limited", "Limited [ अवधि तोकिएको ] "),
        new SipModel("Unlimited", "Unlimited [ असिमित किस्ताहरु ]")
        
    ]);
    self.AShSearch = ko.observable();
    self.FShSearch = ko.observable();
    self.GShSearch = ko.observable();
    self.Selterm = ko.observable();
    self.termno = ko.observable();

    //For SignUP
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

    self.IsOnline = ko.observable();
    self.ShHoldersbyBoid = ko.observableArray([]);
    self.SIP_DT.subscribe(function () {
        self.Effective_Dt(self.SIP_DT());
    });
   // self.IS_UNIT_HOLDER= ko.observable();
    self.MName= ko.observable();
    self.LName= ko.observable();
    self.FaName= ko.observable();
    self.GFName= ko.observable();
    self.P_Tel_No = ko.observable();
    self.P_Mobile_no = ko.observable();
    self.UserList  = ko.observableArray([]);
    self.BalUnit = ko.observable();
    self.date  = ko.observable();
    self.Sh_File= ko.observable();
    self.IS_UNIT_HOLDER= ko.observable();
    self.Token= ko.observable();
    self.IsPosted= ko.observable();
    self.Count= ko.observable();
    self.KhaltiAmt = ko.observable();

    var SHHOLDERNO = $('#SHHOLDERNO').text();

   self.Sip_amt.subscribe(function(){
    self.KhaltiAmt(self.Sip_amt());
   });


    self.PSIP_Amt = ko.observable();
    self.PSIP_Reg_Date = ko.observable();
    self.PTerms = ko.observable();
    self.PModel_of_Sip = ko.observable();
    self.PName = ko.observable();
    self.PSIP_Interval = ko.observable();
    self.PEffective_Dt = ko.observable();
    self.PLast_Date = ko.observable();
    self.cancelsip = ko.observable();

    self.idx = ko.observable();
    self.GatewayCode = ko.observable('005');

     //For E-Banking  
    self.BankId = ko.observable('004');                            
    self.MD = ko.observable('P');   
    self.CRN = ko.observable('NPR');                            
    self.CG = ko.observable('N');
    self.USER_LANG_ID = ko.observable('001');
    self.UserType = ko.observable('1');
    self.AppType = ko.observable('retail');
    self.ITC = ko.observable();

    var LoginSIPRegistrationURL = $("#ContentPlaceHolder1_LoginSIPRegistrationURL").val();
    self.TestURL = ko.observable(LoginSIPRegistrationURL);  // To Pass URL Link of mutual fund
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

    //payment
    self.TXNID = ko.observable();

    var PayMarchantId = $("#ContentPlaceHolder1_PayMarchantId").val();
    var PayAppIdLoginSIPRegistration = $("#ContentPlaceHolder1_PayAppIdLoginSIPRegistration").val();
    self.PayMarchantId=ko.observable(PayMarchantId);           
    self.PayAppId=ko.observable(PayAppIdLoginSIPRegistration);   

    self.PayAppName=ko.observable('SIP Registration By Login');
    self.PayTxnDate=ko.observable();
    self.PayTxnCurency=ko.observable('NPR');
    self.PayTxnAmount=ko.observable();
    self.PayRefId=ko.observable();
    self.PayRemarks=ko.observable(" SIP Registration");
    self.PayParticulars=ko.observable("Paid to Nibl Ace Capital");
    self.PayToken=ko.observable('TOKEN');
    self.GTotal = ko.observable();
    self.SubmitStatus = ko.observable();

    self.FileName1 = ko.observable();
    self.FileName2= ko.observable();
    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = today.getFullYear();
     var Name = $('#Name').text();
    today = yyyy+ '-'+ mm + '-' + dd;
      paydate =dd+'-'+mm+'-'+yyyy;
    self.date(today);
    self.PayTxnDate(paydate);
  
   self.DSIP_Reg_No= ko.observable();
   self.HasDrep=ko.observable(false);
   self.ViewFile1 = function (value) {


                self.Sh_File(null);
               self.Sh_File("data:image/jpeg;base64," + ko.toJS(value.File1));
              
                $("#ViewSign").modal('show');
              
    }

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



    self.openpage = function(){
        var objFra = window.open('../../Modules/Ebanking.aspx', '_blank');
     }
    self.ViewFile2 = function (value) {


                self.Sh_File(null);
                self.Sh_File("data:image/jpeg;base64," + ko.toJS(value.File2));
               // self.Sh_File(ko.toJS(value.File2));
                $("#ViewSign").modal('show');
              
            }
             self.ViewFile3 = function (value) {
   
 
                self.Sh_File(null);
                self.Sh_File("data:image/jpeg;base64," + ko.toJS(value.File3));
               // self.Sh_File(ko.toJS(value.File3));
                $("#ViewSign").modal('show');
              
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
            self.DSIP_Reg_No(res[1]);
            self.AMOUNT(res[0]);
            },
            error: function (err) {
                waitMsg.hide();
                msg(err.status + " - " + err.statusText, "FAILURE");
            }
            });
    }
  // self.SIP_DT.subscribe(function(){
  self.Effective_Dt.subscribe(function(){
   if( self.Effective_Dt()!= null && self.Effective_Dt()!= ""){
    
     var GivenDate = self.Effective_Dt();
     var CurrentDate = self.date();
         if(GivenDate >= CurrentDate){
            self.Effective_Dt(self.Effective_Dt());
          }else{
            msg("Please Enter Valid Date", alert);
            self.Effective_Dt(null);
         }
         }
         });
     $('input[name="optionsRadios"]').change(function () {
   
        if ($('#Radio3').prop('checked')) {
         $('#other').css('display','inline');   
        }
        else{
              $('#other').css('display','none');  
              $('#other').val(null);
        }
    });

     self.SIP_DT(today);
    
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
    self.HolderCollection = function(){
    var  DIS = {
                    l_company_id:l_company_id,
                    DSIP_Reg_No: self.DSIP_Reg_No(),
                    scheme_code: scheme_code,
                    ccode: ccode,
                    entry_user: 'Online User',
                    entry_dt: today,
                    Amount:self.Sip_amt(),
                    tran_dt:today,
                    dbcr:'D',
                    PaymentCode:self.Integrationcode(),
                    remarks:self.PayRemarks(),
                    TXNID:self.TXNID(),
                    GatewayCode: self.GatewayCode(),
                    Integrationcode:self.Integrationcode()
                }
                var url = "../../Handler/SIPHandling/SIP_RegistrationHandler.ashx" ;
                var data = { 'method': 'SaveFundCollection', 'args': JSON.stringify(ko.toJS((DIS))) };
                $.post(url, data,
                        function (result) {
                        var obj = jQuery.parseJSON(result);
                        if(obj.IsSucess){
                           
                          //  msg(obj.ResponseData, alert);
                               
                        } 
                       
                     });

   }

   self.DispalyPaymentOptions= function(){
            if(self.Validation()){
                $('#PaymentType').modal('show'); 
             }
     }

      self.UpdateToken = function(payload){
        var url = "../../Handler/RequestHandling/PurchaseRequestHandler.ashx" ;
        var data = { 'method': 'UpdateToken', 'TXNID': self.TXNID(), 'Action':'B', 'Token': payload.token };
                            $.post(url, data,
                                function (result) {
                        });
   }
   
    //To open Khalti payment form with Config
   var config = {
            "publicKey": Khaltiref,
            "productName": "SIP Reg by Login",
            "productUrl": LoginSIPRegistrationURL,
             "paymentPreference": [
                "KHALTI"
                ],
            "eventHandler": {
                onSuccess (payload) {
                    // hit merchant api for initiating verfication
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
                         tAmt.setAttribute('value',(parseFloat(self.Sip_amt())));
                    
                    form.appendChild(tAmt);

                     //--amt --
                     var amt =document.createElement('input');
                         amt.setAttribute('type', 'hidden');
                         amt.setAttribute('name', 'amt');
                         amt.setAttribute('id', 'amt');
                         amt.setAttribute('value',(parseFloat(self.Sip_amt())));
                    
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
                         su.setAttribute('value', LoginSIPRegistrationURL+'?q=su');
                    
                    form.appendChild(su);

                     //--fu --
                     var fu =document.createElement('input');
                         fu.setAttribute('type', 'hidden');
                         fu.setAttribute('name', 'fu');
                         fu.setAttribute('id', 'fu');
                         fu.setAttribute('value',LoginSIPRegistrationURL+'?q=fu');
                    
                  form.appendChild(fu);
                  document.body.appendChild(form);
                 form._submit_function_(); 
     }
   self.SaveData = function(paymentcode){
  //  waitMsg.show();
     self.Integrationcode(paymentcode);  
       //if(self.Validation()){
         var boid =ko.toJS(self.SelectedDp().DP_Id_Cds())+ko.toJS(self.BOID);
       if(self.Selterm() != undefined){
        var Terms =  self.termno()+" "+self.Selterm().TermTypeName;
        }
        else{
        Terms = null;
        }  
        $('#btnProceed,#btnCancel').attr('disabled',true);
        $('.Submit').attr('disabled',true);
         var args = {
                                l_company_id:l_company_id,
                                scheme_code: scheme_code,
                                ccode: ccode,
                                SIP_Reg_No: self.DSIP_Reg_No(),
                                ShHolderNo: SHHOLDERNO,
                                Name: self.Name(),
                                Email: self.Email(),
                                boid: ko.toJS(self.SelectedDp().DP_Id_Cds())+ko.toJS(self.BOID),
                                HolderTypeNo: '01',
                                SIP_Interval: self.SelectedInterval().Sip_code(),
                                SIP_DT:  $('#txtsipdt').val(),
                                SIP_Eff_Date: $('#txteffdate').val(),
                                Sip_amt:self.Sip_amt(),
                                Model_of_Sip:self.SelectedModel().ModelEngName.trim(),
                                Last_Date:self.Last_Dt(),
                                Online:self.Online(),
                                ENTRY_BY: $("#username").text(),
                                ENTRY_DT: self.date(),
                                IsApproved: "N",
                                remarks: self.remarks(),
                                APPSTATUS: "INITIAL",
                                Address:self.Address(),
                                Contact1:self.Contact1(),
                                Contact2:self.Contact2(),
                                PayeeName:self.payeename(),
                                Introducer:self.Introducer(),
                                IntroducerRem:self.IntroducerRem(),
                                PayeeContactNo:self.PayeeContactNo(),
                                Bank_Account_No:self.acc_no(),
                                BankCode:self.SelectedBank().bankcode(),
                                St_BankCode:'01',
                                PaymentCode:self.SelPayments().PaymentCode(),
                                St_BankAccountNo:'N/A',
                                Terms: Terms,
                                File1:self.File1(),
                                File2:self.File2(),
                                File3: self.File3(),
                                 FileName1:self.FileName1(),
                                FileName2:self.FileName2(),
                                FileName3:self.FileName3(),
                                Is_Unit_Holder: self.IS_UNIT_HOLDER(),
                                Action:'I',
                                TranType:'02',
                                Status:'0',
                                source : source,
                                GatewayCode: self.GatewayCode(),
                                Integrationcode:self.Integrationcode(),
                                HasDrep:self.HasDrep(),


                            };
                                
                            var url = "../../Handler/SIPHandling/SIP_RegistrationHandler.ashx" ;
                            var data = { 'method': 'SaveSipRegistration', 'args': JSON.stringify(ko.toJS((args))) };
                            $.post(url, data,
                                function (result) {
                              
                                       var obj = jQuery.parseJSON(result);
                                      if(obj.IsSucess){
                                      var DSIP_Reg_No = obj.ResponseData;
                                      var res = DSIP_Reg_No.split(" ");
                                      self.DSIP_Reg_No(res[0]);
                                      self.TXNID(res[1]);
                                      self.PayTxnAmount((parseFloat(self.Sip_amt()))*100);
                                      self.PayRefId(boid);
                                      self.HolderCollection();
                                      sessionStorage.setItem("SIP_Reg_No", self.DSIP_Reg_No());
                                      sessionStorage.setItem("TXNID", self.TXNID());
                                     //Open Respecitve Payment Screen
                                          if(self.Integrationcode() == '07') {
                                            //ConnectIPS
                                            self.ProceedToPayment();
                                          } 
                                          else if(self.Integrationcode() == '10') {
                                           self.EBankingProceedToPayment();
                                          }
                                          else if(self.Integrationcode() == '12') {
                                           self.ESewaProceedToPayment();
                                          }
                                      }
                                     

                                });

    }


    // When click Khalti for payment

     var checkout = new KhaltiCheckout(config);

    $(document).on('click', '#payment-button', function () {
       self.PaymentCode('09');
        waitMsg.show();
       self.Integrationcode('09');   
       if(self.Validation()){
       var boid =ko.toJS(self.SelectedDp().DP_Id_Cds())+ko.toJS(self.BOID);
       ProductIdentity =boid.toString();
       if(self.Selterm() != undefined){
        var Terms =  self.termno()+" "+self.Selterm().TermTypeName;
        }
        else{
        Terms = null;
        }  

        $('#btnProceed,#btnCancel').attr('disabled',true);
        $('.Submit').attr('disabled',true);
               var args = {
                                l_company_id:l_company_id,
                                scheme_code: scheme_code,
                                ccode: ccode,
                                DSIP_Reg_No: self.DSIP_Reg_No(),
                                ShHolderNo: SHHOLDERNO,
                                Name: self.Name(),
                                Email: self.Email(),
                                boid: ko.toJS(self.SelectedDp().DP_Id_Cds())+ko.toJS(self.BOID),
                                HolderTypeNo: '01',
                                SIP_Interval: self.SelectedInterval().Sip_code(),
                                SIP_DT:  $('#txtsipdt').val(),
                                SIP_Eff_Date: $('#txteffdate').val(),
                                Sip_amt:self.Sip_amt(),
                                Model_of_Sip:self.SelectedModel().ModelEngName.trim(),
                                Last_Date:self.Last_Dt(),
                                Online:self.Online(),
                                ENTRY_BY: $("#username").text(),
                                ENTRY_DT: self.date(),
                                IsApproved: "N",
                                remarks: self.remarks(),
                                APPSTATUS: "INITIAL",
                                Address:self.Address(),
                                Contact1:self.P_Tel_No(),
                                Contact2:self.P_Mobile_no(),
                                PayeeName:self.payeename(),
                                Introducer:self.Introducer(),
                                IntroducerRem:self.IntroducerRem(),
                                PayeeContactNo:self.PayeeContactNo(),  
                                Bank_Account_No:self.acc_no(),
                                BankCode:self.SelectedBank().bankcode(),
                                St_BankCode:'01',
                                PaymentCode:self.SelPayments().PaymentCode(),
                             //   PaymentCode:self.SelPayments().PaymentCode,
                                St_BankAccountNo:'N/A',
                                Terms: Terms,
                                File1:self.File1(),
                                File2:self.File2(),
                                File3: self.File3(),
                                FileName1:self.FileName1(),
                                FileName2:self.FileName2(),
                                FileName3:self.FileName3(),
                                Is_Unit_Holder: self.IS_UNIT_HOLDER(),
                                Action:'I',
                                TranType:'02',
                                Status:'0',
                                source : source,
                                DOB : self.DOB(),
                                GatewayCode: self.GatewayCode(),
                                Integrationcode:self.Integrationcode(),
                                HasDrep: self.HasDrep(),                               
                                OTP: self.OTPPass()
                            };
                           
                            var url = "../../Handler/SIPHandling/SIP_RegistrationHandler.ashx" ;
                            var data = { 'method': 'SaveSipRegistration', 'args': JSON.stringify(ko.toJS((args))) };
                            $.post(url, data,
                                function (result) {
                               
                                      var obj = jQuery.parseJSON(result);
                                      waitMsg.hide();
                                      if(obj.IsSucess){
                                      var DSIP_Reg_No = obj.ResponseData;
                                      var res = DSIP_Reg_No.split(" ");
                                      self.DSIP_Reg_No(res[0]);
                                      self.TXNID(res[1]);
                                      self.PayTxnAmount((parseFloat(self.Sip_amt()))*100);
                                      self.PayRefId(boid);
                                      self.HolderCollection();
                                      sessionStorage.setItem("SIP_Reg_No", self.DSIP_Reg_No());
                                      sessionStorage.setItem("TXNID", self.TXNID());
                                      var amt=((parseFloat(self.Sip_amt()))*100);
                                      checkout._config.productIdentity =ProductIdentity;
                                      // minimum transaction amount must be 10, i.e 1000 in paisa.
                                       checkout.show({amount: amt});
      
                                      }
                                      else{
                                       msg('FAILURE', alert);
                                      }

                                });
     
           }
          
    });
 
//To verify Khalti Payment

function VerifyKhaltiPayment(payload) {
 waitMsg.hide();
                waitMsg.hide1();
    var paymentdata = {
        GatewayCode: self.GatewayCode(),
        TXNID:self.TXNID(),
        referenceId : self.DSIP_Reg_No(),
        amount: payload.amount,
        idx:payload.idx,  //For VendorTXNID
        token: payload.token,
        Action:'SIPREG'      
    }
    var url = '../../Handler/Collection/CollectionHandler.ashx';
    var data = { 'method': 'VerifyKhaltiPayment', 'data': JSON.stringify(ko.toJS(paymentdata)) ,
                 'Action': 'U',
                 'GatewayCode': self.GatewayCode(),
                 'TXNID':self.TXNID(),
                 'ReferenceID':ko.toJS(self.SelectedDp().DP_Id_Cds())+ko.toJS(self.BOID),
                  'PaymentCode':self.Integrationcode()
                  };
                  

   $.post(url, data, result => {
    var obj = JSON.parse(result);
    var dataObj = JSON.parse(obj.data);
   

    if (obj.IsSucess) {

        if (dataObj.state.name == "Completed") {
            sessionStorage.clear();
            $('#PaymentType').modal('hide');
            self.GetData();
            msg('Transaction has been Sucessfull', alert); 
            self.SubmitStatus(dataObj.state.name);
            $('.Hidden').css('display','none');
            $('.Submit').attr('disabled','disabled');
            $('#btnProceed,#btnCancel').attr('disabled', true);
            $('#BtnSave').attr('disabled', false);
            $('#PaymentType').modal('hide'); 
            waitMsg.hide();
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
            waitMsg.hide();
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

  self.UpdateToken = function(payload){
        var url = "../../Handler/RequestHandling/PurchaseRequestHandler.ashx" ;
        var data = { 'method': 'UpdateToken', 'TXNID': self.TXNID(), 'Action':'B', 'Token': self.Token() };
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
                    ',REMARKS='+ ko.toJS(self.SelectedDp().DP_Id_Cds()) + ko.toJS(self.BOID) + self.PayRemarks() +
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
                         RefId.setAttribute('value', ko.toJS(self.SelectedDp().DP_Id_Cds()) + ko.toJS(self.BOID) + self.PayRemarks());
                    
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
     
   self.SignUp =ko.observable();
   
    self.SaveSipRegistration = function(){
      if( self.SubmitStatus()  =="SUCCESS"   || self.SubmitStatus()  =="Completed") {
     if(self.Validation()){
     if(self.Selterm() != undefined){
        var Terms =  self.termno()+" "+self.Selterm().TermTypeName;
        }
        else{
        Terms = null;
        }  
        if(self.Selterm() != undefined){}
             Confirm("DO YOU WANT TO SUBMIT YOUR FORM??", 'Confirmation Dialog', function (r) {
                if (r) {
           
               var args = {
                                l_company_id:l_company_id,
                                scheme_code: scheme_code,
                                ccode: ccode,
                                DSIP_Reg_No: self.DSIP_Reg_No(),
                                SIP_Reg_No: self.SIP_Reg_No(),
                                ShHolderNo: self.ShHolderNo(),
                                Name: self.Name(),
                                Email: self.Email(),
                                boid: ko.toJS(self.SelectedDp().DP_Id_Cds())+ko.toJS(self.BOID),
                                HolderTypeNo: '01',
                                SIP_Interval: self.SelectedInterval().Sip_code(),
                                SIP_DT:  $('#txtsipdt').val(),
                                SIP_Eff_Date: $('#txteffdate').val(),
                                Sip_amt:self.Sip_amt(),
                                Model_of_Sip:self.SelectedModel().ModelEngName.trim(),
                                Last_Date:self.Last_Dt(),
                                Online:self.Online(),
                                ENTRY_BY: $("#username").text(),
                                ENTRY_DT: self.date(),
                                IsApproved: "N",
                                remarks: self.remarks(),
                                APPSTATUS: "UNPOSTED",
                                Address:self.Address(),
                                Contact1:self.Contact1(),
                                Contact2:self.Contact2(),
                                PayeeName:self.payeename(),
                                Introducer:self.Introducer(),
                                IntroducerRem:self.IntroducerRem(),
                                PayeeContactNo:self.PayeeContactNo(),
                                Bank_Account_No:self.acc_no(),
                                BankCode:self.SelectedBank().bankcode(),
                                PaymentCode:self.SelPayments().PaymentCode(),
                                Terms: Terms,
                                File1:"data:image/jpeg;base64," + ko.toJS(self.File1()),
                                File2:"data:image/jpeg;base64," + ko.toJS(self.File2()),
                                File3:"data:image/jpeg;base64," + ko.toJS(self.File3()),
                                FileName1:self.FileName1(),
                                FileName2:self.FileName2(),
                                FileName3:self.FileName3(),
                                Is_Unit_Holder: self.IS_UNIT_HOLDER(),
                                Action:'A',
                                TranType:'02',
                                status:'0',
                                source:source,
                                GatewayCode: self.GatewayCode(),
                                Integrationcode:self.Integrationcode(),
                                HasDrep: self.HasDrep() 
                               // OTP: self.OTPPass()
                            };

                            var url = "../../Handler/SIPHandling/SIP_RegistrationHandler.ashx" ;
                             var data = { 'method': 'SaveSipRegistration', 'args': JSON.stringify(ko.toJS((args))) ,'SignUp': JSON.stringify(ko.toJS((self.SignUp)))};
                            $.post(url, data,
                                function (result) {

                                 waitMsg.hide();
                                    var data = jQuery.parseJSON(result);
                                    if(data.IsSucess){
                                        msg("Request Sent Successfully!!!", alert);
                                        self.PrintSIPRegistraion(args,data.ResponseData)
                                        self.ClearControls();
                                    }
                                    else{               
                                    waitMsg.hide();
                                    msg(err.status + " - " + err.statusText, "FAILURE");
                                 
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

  self.PrintSIPRegistraion = function (data, reqno) {
      var data={
        cname : "Online Client",
        Name : self.Name(),
        SIP_Reg_No : self.DSIP_Reg_No(),
        SIP_Last_Date : self.Last_Dt(),
        HolderType : "Individual",
       
        SIP_Interval  : self.SelectedInterval().SIP_Interval(),
        SIP_Reg_Date : self.SIP_DT(),
        PaymentMode  : self.SelPayments().PaymentMode(),
        scheme_code:scheme_code,
        ccode:ccode,
        l_company_id:l_company_id
        }
        var url = '/Handler/SIPHandling/CreateSIPRegistration.ashx';
        var data = { 'method': 'CreateRegistrationPdf',  'args':  JSON.stringify(ko.toJS((data))) };
        //new  format
        $.post(url, data, function (result) {
                waitMsg.hide();
                 var obj = jQuery.parseJSON(result);
                 var objFra ='/Reports/Registration/' + obj.ResponseData;
                downloadURI(objFra, 'Sip Registration Receipt');
                 deleteFile(objFra);
        });

 //********old format******
//            $.ajax({
//            dataType: "json",      
//            url: '/Handler/SIPHandling/CreateSIPRegistration.ashx',
//            data: { 'method': 'CreateRegistrationPdf', 'args': JSON.stringify(ko.toJS((data))) },
//            contentType: "application/json; charset=utf-8",
//            async: false,
//            success: function (data) {
//                waitMsg.hide();
//                var obj = JSON.parse(JSON.stringify(data));
//                 var objFra ='/Reports/Registration' + obj.ResponseData;
//                downloadURI(objFra, objFra);
//                //var objFra = window.open('/Reports/Registration' + obj.ResponseData, '_blank');
//            },
//            error: function (err) {
//                waitMsg.hide();
//                alert("Woops something went wrong !");
//            }
//        });

    }

    self.RefreshValidation = function () {

        var errMsg = "";
        var objFocus = "";
        if (self.SelectedComp() == undefined) {
            errMsg += "Please Select Company!!!</br>";
        }
        if (self.SelectedCC() == undefined) {
            errMsg += "Please Select Distribution Center!!!<br/>";
        }
        if (self.SelectedScheme() == undefined) {
            errMsg += "Please Select Scheme!!!<br/>";
        }
    

        if (Validate.empty(self.day_start_date())) {
            errMsg += "Please Enter day_start_date !!!<br>";
        }
        if (errMsg !== "") {
            self.day_start_date(null);
            msg(errMsg, "ALERT");

            return false;
        }
        else {
            return true;
        }

    }

       self.BOIDValidation = function () {
        var errMsg = "";
        var objFocus = null;
        //#region Validating required fields

        if (Validate.empty(self.BOID())) {
            errMsg += "Please Enter BOID!!!<br>";
        }
        if (self.SelectedDp() == undefined) {
            errMsg += "Please Select Depository Participants!!!<br>";
        }
        if (self.BOID().length < 8) {
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
                            self.FileName1(null);
                            self.File1(null);

                            return;
                        }

                        if (files[0].size > 1000000) {
                            edocerror = 2;
                            msg("Document size must be less than 1 mb !!!<br>");
                              self.FileName1(null);
                            self.File1(null);
                            $('#ImgFile1').val("");
                            return;
                        }

            reader.onloadend = function (event) {

                var dataUri = event.target.result
                docfile4 = dataUri;
                self.FileName1(docname2);
                self.File1(docfile4);
            }
        }
        else {
            self.File1('');
            self.FileName1(null);
        }
    });

    $("#ImgFile2").on("change", function () {

        if (this.files[0] != undefined) {
            edocerror5 = "";
            docsize5 = "";
            docsize5 = this.files[0].size / 1024 / 1024;

            var fileInput2 = document.getElementById('ImgFile2');
            docname5 = fileInput2.files[0].name;

            var files = !!this.files ? this.files : [];
            if (!files.length || !window.FileReader) return;

            docsize5 = files[0].type;

            var reader = new FileReader();
            reader.readAsDataURL(files[0]);


                         if (files[0].type != "image/jpeg" && files[0].type != "image/png") {
                            edocerror = 1;
                                  msg("Document format must only be jpeg, png and jpg format!!!<br>");
                             $('#ImgFile2').val("");
                              self.FileUpload2("");

                            return;
                        }

            if (files[0].size > 1000000) {
                edocerror = 2;
                msg("Document size must be less than 1 mb !!!<br>");
                $('#ImgFile2').val("");
                self.FileUpload2("");
                return;
            }

            reader.onloadend = function (event) {

                var dataUri = event.target.result
                docfile6 = dataUri;
                self.FileName2(docname5);
                self.File2(docfile6);
            }
        }
        else {
            self.File2('');
            self.FileName2(null);
        }
    });

      $("#ImgFile3").on("change", function () {
      
        if (this.files[0] != undefined) {
            edocerror2 = "";
            docsize2 = "";
            docsize2 = this.files[0].size / 1024 / 1024;

            var fileInput = document.getElementById('ImgFile3');
            docname3 = fileInput.files[0].name;

            var files = !!this.files ? this.files : [];
            if (!files.length || !window.FileReader) return;

            doctype2 = files[0].type;

            var reader = new FileReader();
            reader.readAsDataURL(files[0]);
            if (files[0].type != "image/jpeg" && files[0].type != "image/png") {
                            edocerror = 1;
                                 msg("Document format must only be jpeg, png and jpg format!!!<br>");
                             $('#ImgFile3').val("");
                              self.FileUpload3("");

                            return;
                        }

            

            if (files[0].size > 1000000) {
                edocerror = 2;
                msg("Document size must be less than 1 mb !!!<br>");
                $('#ImgFile3').val("");
                              self.FileUpload3("");
                return;
            }

            reader.onloadend = function (event) {

                var dataUri = event.target.result
                docfile4 = dataUri;
                self.FileName3(docname3);
                self.File3(docfile4);
            }
        }
        else {
            self.File3('');
            self.FileName3(null);
        }
    });
        self.LoadPaymentMode = function () {
     $.ajax({
                dataType: "json",
                url: '../../Handler/SIPHandling/SIP_RegistrationHandler.ashx',
                async: true,
                data: { 'method': 'LoadPaymentMode' },
                contentType: "application/json; charset=utf-8",
                async: false,
                success: function (result) {
                var mappedTasks = $.map(result.ResponseData, function (item) {
                return new PaymentModeList(item)
                });
                self.PaymentLists(mappedTasks);
                },
                error: function (err) {
                    waitMsg.hide();
                    msg(err.status + " - " + err.statusText, "FAILURE");
                }
                });

    }
    self.LoadPaymentMode();




    function convert(str) {
        var date = new Date(str),
        mnth = ("0" + (date.getMonth() + 1)).slice(-2),
        day = ("0" + date.getDate()).slice(-2);
        return [date.getFullYear(), mnth, day].join("-");
    }


    self.TermValidation = function(){
  
    var errMsg = "";
        var objFocus = null;
        //#region Validating required fields
        if (self.SelectedInterval() == undefined) {
            errMsg += "Please Select SIP Interval[!!!<br>"
        }

        if (Validate.empty(self.Effective_Dt())) {
            errMsg += "Please Enter SIP Start Date !!!<br>";
        }
      
        //#endregion

        if (errMsg !== "") {

            msg(errMsg, "ALERT");
            self.termno(null);
            self.Selterm(null);
            return false;
        }
        else {
            return true;
        }
    }
    self.ClearInterval = function(){
              self.Last_Dt(null);
              self.Selterm(null);
              self.termno(null);
    }
    self.ClearTermType = function () {

        if (self.Selterm != undefined) {
            self.Selterm(null);
            self.Last_Dt('');
        }
        else {
        }
    }

   self.LoadLastDate = function () {
  
      if(self.termno() != undefined && self.termno() >=1){
        if (self.Selterm() != undefined && self.Selterm() != null) {
          if( self.TermValidation()){
            var startDate = self.Effective_Dt();
            var no_of_months = (ko.toJS(self.SelectedInterval().No_of_Months))*5;
            var term = (self.termno());
            var termtype = self.Selterm().TermTypeName;
            var endDateMoment = moment(startDate); // moment(...) can also be used to parse dates in string format
             var termno = (self.termno()-1);
            if (termtype =='Year' && termno==0 ){
                
              endDateMoment.add((termtype),term );
              if(ko.toJS(self.SelectedInterval().No_of_Months) == 1){
                endDateMoment.subtract(("Month"),1 );
              }
//              if(ko.toJS(self.SelectedInterval().No_of_Months) == 3){
//                endDateMoment.subtract(("Month"),3 );
//              }
              
            }
            
            else{
               endDateMoment.add((term), termtype);
              
                endDateMoment.subtract(("Month"),ko.toJS(self.SelectedInterval().No_of_Months) );
//              }
//              if(ko.toJS(self.SelectedInterval().No_of_Months) == 3){
//                endDateMoment.subtract(("Month"),3 );
//              }
//              if(ko.toJS(self.SelectedInterval().No_of_Months) == 6){
//                endDateMoment.subtract(("Month"),6 );
//              }
//              if(ko.toJS(self.SelectedInterval().No_of_Months) == 12){
//                endDateMoment.subtract(("Month"),12 );
//              }
            }
            var last_Date = convert(endDateMoment._d);

            var endinstMoment = moment(startDate); 
            endinstMoment.add((no_of_months), "Month");
             var limitedinstdate = convert(endinstMoment._d);
          
            if(last_Date<limitedinstdate){
              msg("Must Filled Minimum 6 installment as Per Your SIP interval", alert);
              self.Last_Dt(null);
              self.Selterm(null);
              self.termno(null);
             }
             else{
               self.Last_Dt(last_Date);
             }
         }    
        }
        }
        else{
        self.Last_Dt(null);
        self.termno(null);
        //$('#txtnum').focus();
        }
        
    }

    self.LoadHolderSearchBYBoid = function () {
        if (self.SelectedScheme() != undefined && self.SelectedCC() != undefined && self.SelectedComp() != undefined) {
            l_company_id = ko.toJS(self.SelectedComp().Comp_Id);
            scheme_code = ko.toJS(self.SelectedScheme().scheme_code);
            ccode = ko.toJS(self.SelectedCC().ccode);
        }
        var searchtype = "";
        var errmsg = "";


        if (!Validate.empty(self.AShSearch()) || !Validate.empty(self.FShSearch()) || !Validate.empty(self.GShSearch())) {

            var url = "/Handler/SIPHandling/SIP_RegistrationHandler.ashx";
            var data = { 'method': 'SearchHoldersByName', 'ASearch': self.AShSearch(), 'FSearch': self.FShSearch(), 'GSearch': self.GShSearch(), 'scheme_code': scheme_code, 'l_company_id': l_company_id };
            $.post(url, data,
                function (result) {

                    waitMsg.hide();
                    var obj = jQuery.parseJSON(result);
                    if (obj.ResponseData.length > 0) {
                        var mappedTasks = $.map(obj.ResponseData, function (item) {
                            return new ShHolder(item)

                        });
                        self.ShHoldersbyBoid(mappedTasks);
                        //#region Pagination

                        if (self.ShHolders().length > 0) {
                            var width = document.getElementById('Table1').offsetWidth;
                            document.getElementById('Div2').style.width = width + "px";
                            var rowCount = $('#Table1 >tbody >tr').length;
                            $('#Div2').smartpaginator({ totalrecords: rowCount, recordsperpage: 10, datacontainer: 'Table1', dataelement: 'tbody tr', initval: 0, next: '>', prev: '<', first: '<<', last: '>>', theme: 'white' });
                            $("#Div2").show();
                        }
                    }
                    else {
                        msg("Record Not Found", alert);
                        self.AShSearch('');
                        self.FShSearch('');
                        self.GShSearch('');
                    }

                    //#endregion Pagination
                });


        }

    }
    self.ViewSHolderbyboidNo = function (SHolder) {
     
        self.AShSearch('');
        self.AShSearch('');
        self.GShSearch('');
        // self.ShHolderNo(SHolder.ShHolderNo());
        $("#modalBOID").modal('hide');
        //  self.ShHolders(null);
        $("#SearchPager").hide();
        self.CheckSHolders(SHolder.Bo_Account_No);

    }
    self.ShowHolderModalBYBOID = function () {

        if (self.SelectedScheme() != undefined && self.SelectedCC() != undefined && self.SelectedComp() != undefined) {
            l_company_id = ko.toJS(self.SelectedComp().Comp_Id);
            scheme_code = ko.toJS(self.SelectedScheme().scheme_code);
            ccode = ko.toJS(self.SelectedCC().ccode);
            $("#modalBOID").modal('show');
        }

        else {

            msg("Please Select Scheme Name and Distribution Center!!!", "ALERT");

        }

    }
     self.LoadBanks = function () {

        $.ajax({
            type: "GET",
            dataType: "json",
            async: true,
            url: "../../Handler/SIPHandling/SIP_RegistrationHandler.ashx",
            data: { 'method': 'GetBankName' },
             async: false,
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
    self.StandingBanks = ko.observableArray([]);
    self.SelStandingBanks = ko.observable();
   
    self.GetHolderDetail = function () { }
    self.ViewDetails = function (data) {

    }
    self.AddValidation = function () {
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
     self.Validation= function(){
        var errMsg = "";
        var objFocus = null;
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
        //#region Validating required fields
        if (self.SelectedDp() == undefined) {
            errMsg += "Please Select DP!!!<br>"
        }
        if (Validate.empty(self.BOID())) {
            errMsg += "Please Enter BOID !!!<br>";
        } 
        else if (self.BOID().length < 8){
        errMsg += "Please Enter 8-digit BOID !!!<br>";
        }
        if (Validate.empty(self.Name())) {
            errMsg += "Please Enter Name !!!<br>";
        } 
        if (Validate.empty(self.Contact1())) {
            errMsg += "Please Enter Contact No1 !!!<br>";
        }else if(self.Contact1().length < 10){
            errMsg +="Please Enter Correct Contact No1 !!! <br/>"
        }  
        if (Validate.empty(self.amtDetail())) {
            errMsg += "Please Enter Source!!!<br>";
        } 
        if (Validate.empty(self.Sip_amt())) {
            errMsg += "Please Enter SIP Installment Amount!!!<br>";
        } 
        if (Validate.empty(self.SIP_DT())) {
            errMsg += "Please Enter SIP Registration Date!!!<br>";
        } 
         if (Validate.empty(self.Effective_Dt())) {
            errMsg += "Please Enter SIP Start Date!!!<br>";
        } 
       
        if (Validate.empty(self.SelPayments())) {
            errMsg += "Please Select Payment Mode!!!<br>";
        } 
         if (self.SelectedInterval() == undefined) {
            errMsg += "Please Select SIP Interval!!!<br>"
        }
        if (Validate.empty(self.SelectedModel())) {
            errMsg += "Please Select Model of SIP!!!<br>";
        } 
        if(Validate.empty(self.SelectedBank())){
         errMsg += "Please select Bank Name!!!<br>"
        } 
         if(Validate.empty(self.acc_no())){
         errMsg += "Please Enter Bank Account Number!!!<br>"
        } 
         if(self.SelectedModel() != undefined){
        if (self.SelectedModel().ModelEngName.trim()== 'Limited') {
        if(Validate.empty(self.termno())){
         errMsg += "Please Enter Term!!!<br>"
        } 
         if(Validate.empty(self.Selterm())){
         errMsg += "Please select Term!!!<br>"
        } 
       }
        
       
        }
        if(self.payeename() != undefined && self.payeename() != ""){
      
            if(self.Name() != undefined && self.Name() != ""){
                var upperPayee = self.payeename().toUpperCase();
                var uppername = self.Name().toUpperCase()
                upperPayee = upperPayee.split(/\s/).join('');
                uppername = uppername.split(/\s/).join('');
               
                if( uppername != upperPayee){
                    if (self.File3() == undefined || self.File3() == "") {
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
    
 self.ClearControls = function(){
     sessionStorage.setItem("REQUEST_NO", "");
     sessionStorage.setItem("TXNID", "");
    sessionStorage.setItem("ProofFileName", "");
    self.SelectedCC(null);
    self.SelectedScheme(null);
    self.SelectedComp(null);
    self.SelectedHolder(null);
    self.Address('');
    self.payeename('');
    self.day_start_date(null);
    self.Sip_amt(null);
    self.SIP_DT(today);
   self.Effective_Dt(today);
    self.SelectedInterval(null);
    self.Introducer('');
    self.SelectedModel(null);
    self.SelectedBank(null);
    self.acc_no('');
    self.SelectedBank(null);
    self.BanksInfo([]);
    self.SIP_Reg_No('');
     self.DSIP_Reg_No('');
    self.SelPayments(null);
    self.SelStandingBanks(null);
    self.SI_BankAcc_no('');
    self.Email('');
     self.Action('');
    self.PayeeContactNo('');
    self.IntroducerRem('');
    $('#ImgFile1').val('');
    $('#ImgFile2').val('');
    $('#ImgFile3').val('');
    self.File1(null);
    self.File2(null);
    self.File3(null);
    self.FileName1(null);
    self.FileName2(null);
    self.FileName3(null);
    self.LoadScheme();
    self.amtDetail(null);
    self.othersource(null);
    self.Selterm(null);
    self.termno(null);
    self.Last_Dt(null);
    self.SelectedModel(null);
    self.HasDrep(false);
    $('#btnProceed,#btnCancel').attr('disabled',false);
    $('#BtnSave').attr('disabled',true);
    $('.Submit').attr('disabled',false);
    $('#loginView').css('display', 'none');
    $('#ImgFile1,#ImgFile2, #ImgFile3, .Hidden').css('display', 'inline');
    $('#ImgFileUpload1,#ImgFileUpload2,#ImgFileUpload3 ').css('display', 'none');
    window.history.replaceState("object or string", "Title", self.TestURL());
    self.CheckSHolders();
    location.reload();
       
    }
    self.AddBank = function () {
        if (self.AddValidation()) {
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
                    Bank_Account_No: ko.toJS(self.acc_no())
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

      self.LoadSIPIntervals = function () {
        $.ajax({
            type: "GET",
            dataType: "json",
            url: "../../Handler/SIPHandling/SIP_RegistrationHandler.ashx",
            async: true,
            data: { 'method': 'GetSipIntervals' },
            contentType: "applicaton/json; character=utf -8",
            async: false,
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

     self.IsApproved= ko.observable();
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
                        $('#Drep').css('display', 'none');
                    }
                    else{
                         $('#Drep').css('display', 'block');
                    }
            } 
            else {
            }
        });
    }
     self.CheckSHolders = function () {
        if (self.BOIDValidation()) {
            var Bo_Account_No = self.SelectedDp().DP_Id_Cds() + self.BOID();  
            self.Bo_Account_No(Bo_Account_No);
             var url = "/Handler/SIPHandling/SIP_RegistrationHandler.ashx";
                       var data = { 'method': 'GetSIPHolderInfoByBoid', 'scheme_code': scheme_code, 'l_company_id': l_company_id, 'Bo_Account_No': self.Bo_Account_No(), 'ccode': ccode, 'SHHOLDERNO': SHHOLDERNO };
                        $.post(url, data,
                          function (result) {
                            var data1 = jQuery.parseJSON(result); 
                            if(data1.ResponseData.length >=1)
                            {
  
                             self.SIP_Reg_No(data1.ResponseData[0].SIP_Reg_No);
                             self.PSIP_Amt(data1.ResponseData[0].Sip_amt);
                             self.PSIP_Reg_Date(data1.ResponseData[0].SIP_DT);
                             self.PTerms(data1.ResponseData[0].Terms);
                             self.PModel_of_Sip(data1.ResponseData[0].Model_of_Sip);
                             self.PName(Name);
                             self.PSIP_Interval(data1.ResponseData[0].SIP_Interval);
                             self.PEffective_Dt(data1.ResponseData[0].SIP_Eff_Date);
                             self.PLast_Date(data1.ResponseData[0].SIP_Last_Date);
                       
                               $('#Existing').css('display','inline');
                               $('#New').css('display','None');
                            }
                            else{
                             $('#Existing').css('display','None');
                            $('#New').css('display','inline');
                            }
                          
                        });

            var url = "/Handler/RequestHandling/ShHolderHandler.ashx";
            var data = { 'method': 'GetSHolders', 'scheme_code': scheme_code, 'l_company_id': l_company_id, 'Bo_Account_No': self.Bo_Account_No(), 'ccode': ccode, 'SHHOLDERNO': null };
            $.post(url, data,
              function (result) {
                  var data = jQuery.parseJSON(result);
                  if(data.ResponseData.length >0){
                      var SHolder = data.ResponseData[0];
                        $('.Existing').attr("disabled", true);
                        self.Name(SHolder.FName + " " + SHolder.MName + " " + SHolder.LName);
                        self.MName(SHolder.MName);
                        self.LName(SHolder.LName);
                        self.FaName(SHolder.FaName);
                        self.GFName(SHolder.GFName);
                        self.IS_UNIT_HOLDER('Y');
                        self.Email(EmailUser)
                        self.Contact1($("#Contact_No").text());
                        self.Contact2($("#Contact_No2").text());
                        //self.HasDrep(SHolder.HasDrep);
                        if (SHolder.HasDrep == true){
                            $('#Drep').css('display', 'none');
                        }
                        else{
                          self.CheckPosted();
                        }

                  }
                  else {
                   $('.Existing').attr("disabled", false);
                      self.IS_UNIT_HOLDER('N');
                     self.BalUnit(0);
                  }
              });
        }
        else{
        self.BOID(null);
        self.SelectedDp(null);
         self.HasDrep(false);
        }
      }
       self.CheckSHolders();


       
       self.OpenModal= function(){
        if($('#chklogin').prop('checked')){
             $("#modalShHolder").modal('show');
        }
    }

       self.amountCheck = function () {   
           if(self.Sip_amt() <1000){
                msg("SIP Installment Amount should be min. of Rs.1000","ALERT");
                self.Sip_amt(null);
           }
       
    }

        self.Getdate = function () {
 
      self.Last_Dt('');
       
        if (self.SelectedModel() == 'Limited [ अवधि तोकिएको  ] ') {

            $('#Limited').css("display", "block");
           // $('#lstDt,#terms,#termtype').css("display", "inline");
        }
        else {
            if (self.Selterm != undefined) {
                self.termno('');
                self.Selterm(null);
                self.Last_Dt('');
            }
            else {
            }
            $('#Limited').css("display", "none");
           // $('#lstDt,#terms,#termtype').css("display", "none");
            
        }
         
   }

     self.Getdate = function () {
  
    
      self.Last_Dt('');
       if(self.SelectedModel() != undefined){
        if (self.SelectedModel().ModelEngName.trim() == 'Limited') {

            $('#Limited').css("display", "block");
           // $('#lstDt,#terms,#termtype').css("display", "inline");
        }
        else {
            if (self.Selterm != undefined) {
                self.termno('');
                self.Selterm(null);
                self.Last_Dt('');
            }
            else {
            }
            $('#Limited').css("display", "none");
           // $('#lstDt,#terms,#termtype').css("display", "none");
            
        }
         }
   }

   self.GetData = function(){
    var DSIP_Reg_No= self.DSIP_Reg_No();
    if(DSIP_Reg_No != undefined||DSIP_Reg_No!="" ){
     $.ajax({
                type: "GET",
                dataType: "json",
                cache: false,
                async: true,
                url: '/Handler/SIPHandling/SIP_RegistrationHandler.ashx',
                data: { 'method': 'GetSIPHolderDetail', 'scheme_code': scheme_code, 'ccode': ccode ,'l_company_id':l_company_id, 'SIP_Reg_No':DSIP_Reg_No , 'Action':'B'},
                contentType: "applicaton/json; character=utf -8",
                async: false,
                success: function (data) {
                var SHolder = data.ResponseData[0];
             
                self.Name(SHolder.Name);
                self.Email(EmailUser);
                self.SIP_DT(SHolder.SIP_DT);
                self.SelectedInterval(self.Intervals().find(x => x.Sip_code() == SHolder.SIP_Interval.trim()));
                self.SelectedModel(self.SipModels().find(x => x.ModelEngName == SHolder.Model_of_Sip));
                self.P_Tel_No(SHolder.Contact1); 
                self.P_Mobile_no(SHolder.Contact2); 
                self.payeename(SHolder.PayeeName); 
                self.Integrationcode(SHolder.Integrationcode);
                self.Sip_amt(SHolder.Sip_amt); 
                self.PayeeContactNo(SHolder.PayeeContactNo); 
                self.Effective_Dt(SHolder.Action_Date); 
                self.IS_UNIT_HOLDER(SHolder.Is_Unit_Holder); 
                             
                self.SelPayments(self.PaymentLists().find(x => x.PaymentCode() == SHolder.PaymentCode));
                              
                self.SelectedBank(self.Banks().find(x => x.bankcode() == SHolder.BankCode));
                self.acc_no(SHolder.Bank_Account_No);
            
                self.Last_Dt(SHolder.SIP_Last_Date);
                self.File1(SHolder.File1);
                self.File2(SHolder.File2);
                self.File3(SHolder.File3);
                if(self.File1() != null){
                    $('#ImgFile1').css('display','none');
                    $('#ImgFileUpload1').css('display','inline');
                }
                    if(self.File2() != null){
                    $('#ImgFile2').css('display','none');
                    $('#ImgFileUpload2').css('display','inline');
                }
                    if(self.File3() != null){
                    $('#ImgFile3').css('display','none');
                    $('#ImgFileUpload3').css('display','inline');
                }
                self.FileName1(SHolder.FileName1);  
                self.FileName2(SHolder.FileName2);   
                self.FileName3(SHolder.FileName3);
                
                if (SHolder.HasDrep == true){
                     $('#Drep').css('display', 'none');
                 }
                 else{
                    $('#Drep').css('display', 'block');
                  }
                 self.HasDrep(SHolder.HasDrep);     
                if(SHolder.Model_of_Sip == 'Unlimited'){
                  $('#Limited').css("display", "none");
                }
                else{
               $('#Limited').css("display", "block");
                   var str = (SHolder.Terms);
                   var splitStr = str.split(" ");
                   self.termno(splitStr[0]);
                   self.Selterm(self.TermTypes().find(x => x.TermTypeName == splitStr[1]));
                   self.Last_Dt(SHolder.SIP_Last_Date);
                } 
                 self.amtDetail(SHolder.source);
                    if(self.amtDetail() != "Loan" && self.amtDetail() != "Salary" && self.amtDetail()!= "Assets" && self.amtDetail() != "Business" )
                    {
                        $('#Radio3').prop("checked",true);
                        $('#other').css('display','inline');   
                        $('#other1').css('display','inline'); 
                        self.othersource(ko.toJS(self.amtDetail()));
                    }       
                }, 
                error: function (err) {
                    waitMsg.hide();
                    msg(err.status + " - " + err.statusText, "FAILURE");             
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

        //--ITC --
        var ITCData = document.createElement('input');
        ITCData.setAttribute('type', 'hidden');
        ITCData.setAttribute('name', 'ITC');
        ITCData.setAttribute('value', ko.toJS(self.SelectedDp().DP_Id_Cds()) + ko.toJS(self.BOID));
        form.appendChild(ITCData);

        //--AMT --
        var AMTData = document.createElement('INPUT');
        AMTData.setAttribute('TYPE', 'hidden');
        AMTData.setAttribute('NAME', 'AMT');
        // AMTData.setAttribute('VALUE',self.PayTxnAmount());
        AMTData.setAttribute('VALUE', self.Sip_amt())
        form.appendChild(AMTData);

        document.body.appendChild(form);
        form._submit_function_();

    }

    self.ValidateAmount = function(){
   var RE =getUrlParamVal('TXNID');
   $.ajax({
              type: "GET",
                dataType: "json",
                cache: false,
                async: true,
                url: "../../Handler/SIPHandling/SIP_RegistrationHandler.ashx" ,
                data: { 'method': 'ValidateSIPAmount', 'TXNID':  self.TXNID(), 'Action':'SIPREG' },
                contentType: "applicaton/json; character=utf -8",
                async: false,
                success: function (obj) {
                 var PayTxnAmount= obj.ResponseData[0].Sip_amt;
                 self.DSIP_Reg_No(obj.ResponseData[0].DSIP_Reg_No);
                 self.GTotal((parseFloat(PayTxnAmount))*100);
                 self.Bo_Account_No(obj.ResponseData[0].boid);
                 self.Integrationcode(obj.ResponseData[0].Integrationcode);
                 self.AMOUNT(parseFloat(PayTxnAmount).toFixed(2));
                }
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
           // AMOUNT: self.AMOUNT(),
            AMOUNT: getUrlParamVal('amt'),
            BID: getUrlParamVal('refId'),
            CustRefType: getUrlParamVal('oid'),
            scd: Esewascd ,
            Action:'SIPREG'
        }
        var url = '../../Handler/Collection/CollectionHandler.ashx';
        var data = { 'method': 'VerifyEsewaTransaction', 'data': JSON.stringify(resData), 'Action': 'E', 'GatewayCode': self.GatewayCode(), 'PaymentCode': '12' };
        $.post(url, data, result => {
            var obj = JSON.parse(result);
            if (obj.IsSucess) {
            if(obj.data == "SUCCESS"){
                // sessionStorage.clear();
                 self.GetData();
                 $('#PaymentType').modal('hide');
                 msg('Transaction has been Sucessfull', alert); 
                 self.SubmitStatus(obj.data);
                 $('.Hidden').css('display','none');
                 $('.Submit').attr('disabled','disabled');
                 $('#btnProceed,#btnCancel').attr('disabled', true);
                 $('#BtnSave').attr('disabled', false);
                 if (self.IS_UNIT_HOLDER()=='N'){
                    $('#loginView').css('display','block');
                  }
                $('#PaymentType').modal('hide');
                waitMsg.hide1();
                window.history.replaceState("object or string", "Title", self.TestURL()); 
          }
          else
             {
                self.SubmitStatus(obj.data);
                msg("FAILED", alert);   
                var DSIP_Reg_No = sessionStorage.getItem("SIP_Reg_No");
                self.DSIP_Reg_No(DSIP_Reg_No);
                self.GetData();
                $('.Hidden').css('display', 'none');
                $('.Submit').attr('disabled', 'disabled');
                $('#BtnSave,#btnProceed').attr('disabled', true);
                $('#btnCancel').attr('disabled', false);
                waitMsg.hide1();
                window.history.replaceState("object or string", "Title", self.TestURL());
             }                
            }
            else{
                msg(obj.Message, alert);
                var DSIP_Reg_No = sessionStorage.getItem("SIP_Reg_No");
                self.DSIP_Reg_No(DSIP_Reg_No);
                self.GetData();
                $('.Hidden').css('display', 'none');
                $('.Submit').attr('disabled', 'disabled');
                $('#BtnSave,#btnProceed').attr('disabled', true);
                $('#btnCancel').attr('disabled', false);
                waitMsg.hide1();
                window.history.replaceState("object or string", "Title", self.TestURL());
            }
         });
        }
        else if( getUrlParamVal('q') =="fu"){
        msg('Failed ', alert);
        var DSIP_Reg_No = sessionStorage.getItem("SIP_Reg_No");
        self.DSIP_Reg_No(DSIP_Reg_No);
        self.GetData();
        $('.Hidden').css('display', 'none');
        $('.Submit').attr('disabled', 'disabled');
        $('#BtnSave,#btnProceed').attr('disabled', true);
        $('#btnCancel').attr('disabled', false);
        waitMsg.hide1();
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

                    var TXNID = sessionStorage.getItem("TXNID");
                    var DSIP_Reg_No = sessionStorage.getItem("SIP_Reg_No");
                    self.DSIP_Reg_No(DSIP_Reg_No);
                    sessionStorage.clear();
                    self.GetData();
                    msg('Transaction has been Sucessfull', alert);
                    self.SubmitStatus(self.status());                
                    $('.Hidden').css('display', 'none');
                    $('.Submit').attr('disabled', 'disabled');
                    $('#btnProceed,#btnCancel').attr('disabled', true);
                    $('#BtnSave').attr('disabled', false);
                    $('#loginView').css('display', 'block');
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

  

     //Get Transaction ID in URL  with verify Connect IPS Payment Data
    if (getUrlParamVal('TXNID') != undefined && getUrlParamVal('TXNID') != "") {
        ValidatePage();
      var RE =getUrlParamVal('TXNID');
      var TXNID= sessionStorage.getItem("TXNID"); 
      if (RE==TXNID){
         self.TXNID(RE);
         $('.Submit').attr('disabled','disabled');
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
                                                        "Action":'SIPREG'
                                                }
                                        let url = '../../Handler/Collection/CollectionHandler.ashx';
                                        let data = { 'method': 'ValidatePayment', 'data': JSON.stringify(ko.toJS(postDate)) ,'Action': 'U' ,'ReferenceID':self.Bo_Account_No(), 'AppID' :self.PayAppId(),'PayAppName': self.PayAppName(),'GatewayCode': self.GatewayCode() ,'PaymentCode':self.Integrationcode()};
                                        $.post(url, data, result => {
                                            var obj = JSON.parse(result);
                            
                                            var dataObj=JSON.parse(obj.data);
                                               waitMsg.hide();
                                                   waitMsg.hide1();
                                               if(obj.IsSucess){
                                                 if (dataObj.status=="SUCCESS")
                                                 {
                                                     sessionStorage.clear();
                                                     self.GetData();
                                                     msg(dataObj.statusDesc,alert);
                                                     self.SubmitStatus(dataObj.status);
                                                     $('.Hidden').css('display','none');
                                                     $('.Submit').attr('disabled','disabled');
                                                     $('#btnProceed,#btnCancel').attr('disabled', true);
                                                     $('#BtnSave').attr('disabled', false);
                                                    // $('#loginView').css('display','block');
                                                      if (self.IS_UNIT_HOLDER()=='N'){
                                                           $('#loginView').css('display','block');
                                                     }
                                                  
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

                                                     window.history.replaceState("object or string", "Title", self.TestURL());
                                                  
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

      self.CancleSIPRegistration = function(){
      var args = {
                                l_company_id:l_company_id,
                                scheme_code: scheme_code,
                                ccode: ccode,
                                SIP_Reg_No: self.SIP_Reg_No(),
                                boid: ko.toJS(self.SelectedDp().DP_Id_Cds())+ko.toJS(self.BOID),
                                ENTRY_BY: 'Online User',
                                ENTRY_DT: $("#date").text(),
                                Action:'05'
                            };                           
                            var url = "../../Handler/SIPHandling/SIPRegistrationCancellation.ashx" ;
                            var data = { 'method': 'CancelSIPRegistration', 'args': JSON.stringify(ko.toJS((args))) };
                            $.post(url, data,
                                function (result) {
                                 waitMsg.hide();
                                    var data = jQuery.parseJSON(result);
                                    if(data.IsSucess){
                                        var message = "";
                                        message = "SIP Cancellation Request Send SuccessFully!! ";
                                        //No: " + data.ResponseData +" "+ data.Message ;
                                        msg(message, "ALERT");
                                        self.Cancel();
                                     
                                    }
                                    else{               
                                    waitMsg.hide();
                                    msg("FAILURE");
                                    self.Cancel();
                                 
                                    }
                                });
      }

      self.Cancel = function(){
         self.cancelsip(false);
         $('#Button1').css('display', 'none');
         $('#Button2').css('display', 'none');
          self.CheckSHolders();
      }
};

    
 
    
$(document).ready(function () {
        validLoginUser();
        ValidateSession();
        ko.applyBindings(new SIPViewModel());
      //  document.getElementById("select2-dp-container").style.backgroundColor = "#f5f6f6";
});