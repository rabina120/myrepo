function ShHolder(data) {
    var self = this;
    if (data != undefined) {
        self.Scheme_code = ko.observable(data.Scheme_code);
        self.cname = ko.observable(data.cname);
        self.ShHolderNo = ko.observable(data.ShHolderNo);
        self.Title = ko.observable(data.Title);
        self.FName = ko.observable(data.FName);
        self.MName = ko.observable(data.MName);
        self.LName = ko.observable(data.LName);
        self.Nep_DOB = ko.observable(data.Nep_DOB);
        self.Eng_DOB = ko.observable(data.Eng_DOB);
   
        self.FaName = ko.observable(data.FaName);
        self.GFName = ko.observable(data.GFName);
        self.Bo_Account_No = ko.observable(data.Bo_Account_No);
        self.Bank_Account_No = ko.observable(data.Bank_Account_No);
        self.BankCode = ko.observable(data.BankCode);
        self.TotalKitta = ko.observable(data.TotalKitta);
        self.TfracKitta = ko.observable(data.TfracKitta);
      
        self.BalUnit = ko.observable(data.BalUnit);
        self.Inv_Amt = ko.observable(data.Inv_Amt);
        self.minkitta= ko.observable(data.minkitta);
        self.Sign= ko.observable(data.Sign);
        self.Boid_No= ko.observable(data.Boid_No);
        
    }
}

function Transaction(data) {

    var self = this;
    if (data != undefined) {
        self.scheme_code = ko.observable(data.scheme_code);
        self.SHHOLDERNO= ko.observable(data.SHHOLDERNO);
        self.Allocation_no = ko.observable(data.Allocation_no);
        self.value_dt = ko.observable(data.value_dt);
        self.balance_unit = ko.observable(data.balance_unit);
        self.inv_amt = ko.observable(data.inv_amt);
        self.inv_amt_redem_unit = ko.observable(data.inv_amt_redem_unit);
        self.redem_unit = ko.observable(data.redem_unit);
        self.seqno = ko.observable(data.seqno);
        self.cap_gain_tax = ko.observable(data.cap_gain_tax);
        self.inv_amt_redem_unit = ko.observable(data.inv_amt_redem_unit);
        self.cur_val = ko.observable(data.cur_val);
        self.exe_load = ko.observable(data.exe_load);
        self.capital_gain= ko.observable(data.capital_gain);
        self.p_dt = ko.observable(data.p_dt);
        self.Unposted_Unit= ko.observable(data.Unposted_Unit);
        self.Holding_Days= ko.observable(data.Holding_Days);
        self.locked_unit= ko.observable(data.locked_unit);
        self.FName= ko.observable(data.FName);
       // self.Can_be_Sell = ko.observable(data.balance_unit -data.Unposted_Unit -data.locked_unit)
       self.Can_be_Sell=ko.observable(data.Can_be_sell);
        self.shouldShowMessage= ko.observable(false);
        self.SNO=ko.observable(data.SNO);
        self.CGT=ko.observable(data.CGT);
        self.tran_type=ko.observable(data.tran_type);
        self.capital_gain_amount=ko.observable(data.capital_gain_amount);
        self.capital_gain_tax_amount=ko.observable(data.capital_gain_tax_amount);
        self.CGT=ko.observable(data.CGT);
        self.SNO=ko.observable(data.SNO);
        self.Sip_Holding_Days=ko.observable(data.Sip_Holding_Days);
        self.Sip_value_dt=ko.observable(data.Sip_value_dt);
    }
   
}
function Bank(data) {
    var self = this;
    if (data != undefined) {
        self.bankcode = ko.observable(data.bankcode);
        self.bankname = ko.observable(data.bankname);
    }
}
function bank_branch(data) {
    var self = this;
    if (data != undefined) {
        self.branch_code = ko.observable(data.branch_code);
        self.branch_address = ko.observable(data.branch_address);
    }
}
function CollCenter(data) {
    var self = this;
    if (data != undefined) {
        self.ccode = ko.observable(data.ccode);
        self.cname = ko.observable(data.cname);

    }
}
function ChargeType(data){
    var self = this;
    if (data != undefined) {   
        self.SDescription = ko.observable(data.SDescription);
        self.SCharge_Code = ko.observable(data.SCharge_Code);
    }   
}
function Sign(data){
var self = this;
    if (data != undefined) {   
        self.Sign = ko.observable(data.signature);
        self.sign_seqno = ko.observable(data.seqno);
      
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

function DPCharge(data) {
    var self = this;
    if (data != undefined) {
        self.Depo = ko.observable(data.Depo);
        self.DPName = ko.observable(data.DPName);
        self.DP_Id_Cds =ko.observable(data.DP_Id_Cds);
        

    }
}
var RedemptionEntryViewModel = function () {
    var self = this;
    //ShHolder
    self.scheme_code = ko.observable();
    self.ccode = ko.observable();
    self.REQUEST_NO = ko.observable();
    self.ShHolderNo = ko.observable();
    self.Name = ko.observable();
    self.MName = ko.observable()
    self.FName = ko.observable();
    self.LName = ko.observable();
    self.Title = ko.observable();
    self.FaName = ko.observable();
    self.GFName = ko.observable();
    self.P_Mobile_no = ko.observable();
    self.P_TelNo = ko.observable();
    self.Bo_Account_No = ko.observable();
    self.Citizenship_No = ko.observable();
    self.PAN_No = ko.observable();
    self.Reg_No = ko.observable();
    self.P_Mun = ko.observable();
    self.P_Tel_No = ko.observable();
    self.P_Ward_No = ko.observable();
    self.P_Mobile_no = ko.observable();
    self.P_Tole = ko.observable();
    self.HolderType = ko.observable();
    self.Address = ko.observable();
    self.Bank_Account_No  = ko.observable();
    self.IsInstitution = ko.observable();
    self.IS_UNIT_HOLD = ko.observable(); 
    self.ViewSign = ko.observable();
    //Redemtion
    self.APPLY_UNIT = ko.observable();
    self.APPLY_DT = ko.observable();
    self.AMOUNT = ko.observable();
    self.cashorcheque = ko.observable();
    self.bcode_cheque = ko.observable();
    self.CHK_NO = ko.observable();
    self.ENTRY_BY = ko.observable();
    self.ENTRY_DT = ko.observable();
    self.APPROVED = ko.observable();
    self.APPSTATUS = ko.observable();
    self.APPROVED_BY = ko.observable();
    self.APP_DATE = ko.observable();
    self.TOBE_PROCEED = ko.observable();
    self.is_proceed = ko.observable();
    self.PROCEED_DT = ko.observable();
    self.PROCEED_BY = ko.observable();
    self.proceed_batch = ko.observable();
    self.appno = ko.observable();
    self.remarks = ko.observable();
    self.current_nav = ko.observable();
    self.nav_date = ko.observable();
    self.exit_load = ko.observable();
    self.face_val = ko.observable();
    self.cal_type = ko.observable();
    self.gaintax = ko.observable();
    self.charge_amount = ko.observable();
    self.exe_load = ko.observable();
    self.inv_amt_redem_unit = ko.observable();
    self.cap_gain_tax = ko.observable();
    self.redem_unit = ko.observable();
    self.otherchrg = ko.observable();
    self.selectedItem = ko.observable();

    self.other_charges = ko.observable();
    self.Unposted_Unit = ko.observable();

    self.ActAverage_Price =ko.observable();

    // self.Transaction = ko.observable();

    // bank
    self.bankcode = ko.observable();
    self.BRANCHCODE = ko.observable();
    self.bankname = ko.observable();
    self.Banks = ko.observableArray([]);
    self.SelectedBank = ko.observable();
    self.BANKCODE = ko.observable();


    self.Email_ID = ko.observable()
    //Branches
    self.branch_code = ko.observable();
    self.branch_address = ko.observable();
    self.telno = ko.observable();
    self.SelectedBranch = ko.observable();
    self.Branches = ko.observableArray([]);

    // coll center
    self.ccode = ko.observable();
    self.cname = ko.observable();
    self.CCenters = ko.observable();
    self.SelectedCCenter = ko.observable();

    // ParaComp
    self.scheme_code = ko.observable();
    self.CompEnName = ko.observable();
    self.Companies = ko.observable();
    self.SelectedComp = ko.observable();
    self.face_val= ko.observable();
    self.minkitta=ko.observable();
    self.MaxKitta=ko.observable();
    // transaction
    self.seqno = ko.observable();
    self.Allocation_no = ko.observable();
    self.value_dt = ko.observable();
    self.balance_unit = ko.observable();
    self.inv_amt = ko.observable();
    self.free_unit = ko.observable();
    self.status = ko.observable();
    self.entry_user = ko.observable();
    self.entry_dt = ko.observable();
    self.status = ko.observable();
    self.lock_unit = ko.observable();
    self.redem_unit = ko.observable();
    self.cap_gain_tax = ko.observable();
    self.inv_amt_redem_unit = ko.observable();
    self.cur_val = ko.observable();
    self.tot_redem_unit = ko.observable();
    self.tot_inv_amt_redem_unit = ko.observable();
    self.tot_cur_val = ko.observable();
    self.tot_exe_load = ko.observable();
    self.tot_cap_gain= ko.observable();
    self.sellingUnit = ko.observable();
    self.seqno = ko.observable();
    self.Flat_percent = ko.observable();
    self.rate = ko.observable();
    self.capital_gain_amount = ko.observable();
    self.capital_gain_tax_amount = ko.observable();
    self.CGT = ko.observable();
    // Charges

    self.ChargeTypes = ko.observableArray([]);
    self.SDescription = ko.observable();
    self.SelectedCharge = ko.observable();
    self.Average_Price = ko.observable();
    self.Unposted_Unit = ko.observable();
    self.Holding_Days = ko.observable();
    self.amt_pay_before_tax = ko.observable();
    self.Can_be_Sell= ko.observable();
     //DP
    self.Depo = ko.observable();
    self.DPName = ko.observable();
    self.SelectedDp = ko.observable();
    self.DP_Id_Cds = ko.observable();
    self.Boid_No = ko.observable();
    self.Boid_No= ko.observable();
     self.validateunit= ko.observable();
     //Scheme
    self.scheme_code = ko.observable();
    self.SchemeEnName = ko.observable();
    self.SelectedScheme = ko.observable();
    self.Schemes = ko.observableArray();
    
     self.PanCard = ko.observable();
     self.Sh_File=ko.observable();
      self.File1 = ko.observable();
    // CapitalGain
    var CapitalGain = function(GainName, GainID, GainCharge) {
        this.GainName = GainName;
        this.GainID = GainID;
        this.GainCharge = GainCharge;
    };
    var Status = function(StatusName) {
        this.StatusName = StatusName;  
    };
    self.CapitalGains = ko.observableArray([
        new CapitalGain("Individual",0, 5),
        new CapitalGain("Company", 1, 10),
        new CapitalGain("None", 2, 0),
    ]);
    self.Status=ko.observableArray([
        new Status("L"),
        new Status("G")
    ]);
    self.selectedGain = ko.observable();
    self.selectedGain(self.CapitalGains().find(x => x.GainCharge == 5));
    self.selectedGLStatus= ko.observable();
    self.StatusName = ko.observable();
    self.GainName = ko.observable();
    
     self.selectedGain(self.CapitalGains().find(x => x.GainID == 0));

    self.Sign = ko.observable();
    self.sign_seqno = ko.observable();
    self.Sh_Sign = ko.observable();
    self.AShSearch = ko.observable();
    self.FShSearch = ko.observable();
    self.GShSearch = ko.observable();
    self.ShHolders = ko.observableArray([]);
    self.Signatures= ko.observableArray([]);
    //self.PayType("1");
    self.Action = ko.observable();
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
    var SHHOLDERNO = $('#SHHOLDERNO').text()
   
    self.SHolders = ko.observableArray([]);
    self.SHHolders = ko.observableArray([]);
    self.UserCenters = ko.observableArray([]);
    self.BalUnit = ko.observable();
    self.Inv_Amt = ko.observable();
    self.gainloss_status = ko.observable();
    self.capital_gain_tax = ko.observable();
    self.capital_gain_tax_amt = ko.observable();
    self.capital_gain = ko.observable();
    self.gainloss_status= ko.observable();
    self.p_dt = ko.observable();
    self.Holding_Days = ko.observable();
    self.SEBON_Fee = ko.observable();
    self.locked_unit  = ko.observable();
    $('#dllCompany').focus();
    self.Action = ko.observable();
    self.shouldShowMessage = ko.observable();
    self.SNO = ko.observable();
    self.tran_type= ko.observable();
     self.CurrDate = ko.observable();
     self.VerifyList = ko.observable();
     self.ActAverage_Price= ko.observable();
     self.PAN= ko.observable();

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

    self.Passcode = ko.observable()
    self.EmailOtp = ko.observable()
    self.OTP  = ko.observable();
    self.OTPPass = ko.observable();
    self.TransPin = ko.observable()
    var Email = $("#Email").text();
    self.VerifyOtp= ko.observable()
    self.VerifyOtp(false);

//
    self.Sip_Holding_Days=ko.observable();
    self.Sip_Reg_Date=ko.observable();


    self.GetClientDetial = function(){
     $.ajax({
                    type: "GET",
                    dataType: "json",
                    cache: false,
                    async: false,
                    url: '/Handler/RequestHandling/RedemptionRequestHandler.ashx',
                    data: { 'method': 'GetClientDetial' , 'scheme_code':scheme_code, 'BOID':BOID },
                    contentType: "applicaton/json; character=utf -8",
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

    self.CurrentDate = function(){
       $.ajax({
                    type: "GET",
                    dataType: "json",
                    cache: false,
                    async: false,
                    url: '/Handler/Collection/DateHandler.ashx',
                    data: { 'method': 'GetCurrentDate' },
                    contentType: "applicaton/json; character=utf -8",
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
                  // if (self.CurrDate() >= self.startdate() && self.CurrDate() <= self.Enddate()  && day != 5 && day != 6){
                        self.current_nav(data.ResponseData[0].nav_value);
                        self.nav_date(data.ResponseData[0].nav_date);
                       // self.GetServiceChargeAmt();
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
    var myInputs = document.querySelectorAll('.fixed');
        myInputs.forEach(function(elem) {
        elem.addEventListener("input", function() {
        var dec = elem.getAttribute('decimals');
        var regex = new RegExp("(\\.\\d{" + dec + "})\\d+", "g");
       elem.value = elem.value.replace(regex, '$1');
        });
    });

//     self.ViewFile = function (value) {
//         
//                self.Sh_File(null);
//                self.Sh_File("data:image/jpeg;base64," + ko.toJS(value.File1));
//            //    $("#ViewSign").modal('show');
//            }

//             $("#ImgFile1").on("change", function () {
//      
//        if (this.files[0] != undefined) {
//            edocerror2 = "";
//            docsize2 = "";
//            docsize2 = this.files[0].size / 1024 / 1024;

//            var fileInput = document.getElementById('ImgFile1');
//            docname2 = fileInput.files[0].name;

//            var files = !!this.files ? this.files : [];
//            if (!files.length || !window.FileReader) return;

//            doctype2 = files[0].type;

//            var reader = new FileReader();
//            reader.readAsDataURL(files[0]);


//                        if (files[0].type != "image/jpeg" && files[0].type != "image/png") {
//                            edocerror = 1;
//                                  msg("Document format must only be jpeg, png and jpg format!!!<br>");
//                            $('#ImgFile1').val("");
//                            self.File1("");
//                            self.PanCard(null);

//                            return;
//                        }

//                        if (files[0].size > 1000000) {
//                            edocerror = 2;
//                            msg("Document size must be less than 1 mb !!!<br>");
//                            self.File1("");
//                            $('#ImgFile1').val("");
//                            return;
//                        }

//            reader.onloadend = function (event) {
//               //  self.ProofFileName(docname2);
//                var dataUri = event.target.result
//                 self.PanCard(docname2);
//                docfile4 = dataUri;
//                self.File1(docfile4);
//               
//            }
//        }
//        else {
//            self.File1('');
//        }
//    });

    self.ShowHolderModal = function(){

        $("#AShSearch").val('');
        $("#FShSearch").val('');
        $("#GShSearch").val('');
        if (self.SelectedComp() != undefined && self.SelectedCCenter() != undefined) {

            scheme_code = ko.toJS(self.SelectedComp().scheme_code);
            usercode = ko.toJS(self.SelectedCCenter().ccode);
        }
        else{
            scheme_code=scheme_code;
            usercode =usercode;

        }
        if (scheme_code == "1" || usercode == "1") {
        
            msg("Please Select Scheme Name and Distribution Center!!!", "ALERT");

        }
        else {
            $("#modalShHolder").modal('show');
            self.ShHolders.removeAll();
            $("#Div1").hide();
        }
    }
    self.LoadHolderSearch = function(){
        if (self.SelectedComp() != undefined && self.SelectedCCenter() != undefined) {
            scheme_code = ko.toJS(self.SelectedComp().scheme_code);
            usercode = ko.toJS(self.SelectedCCenter().ccode);
        }
        var searchtype = "";
        var errmsg = "";
        if (!Validate.empty(self.AShSearch()) || !Validate.empty(self.FShSearch()) || !Validate.empty(self.GShSearch())) {

            var url = "/Handler/RequestHandling/PurchaseRequestHandler.ashx";
            var data = { 'method': 'SearchHoldersByName', 'ASearch': self.AShSearch(), 'FSearch': self.FShSearch(), 'GSearch': self.GShSearch(), 'scheme_code': scheme_code };
            $.post(url, data,
                function (result) {
                    waitMsg.hide();
                    var obj = jQuery.parseJSON(result);
                    if(obj.ResponseData.length >0){
                        var mappedTasks = $.map(obj.ResponseData, function (item) {
                            return new ShHolder(item)

                        });
                        self.ShHolders(mappedTasks);
                        if (self.ShHolders().length > 0) {
                            var width = document.getElementById('Table2').offsetWidth;
                            document.getElementById('Div1').style.width = width + "px";
                            var rowCount = $('#Table2 >tbody >tr').length;
                            $('#Div1').smartpaginator({ totalrecords: rowCount, recordsperpage: 10, datacontainer: 'modalShHolder', dataelement: 'tbody tr', initval: 0, next: '>', prev: '<', first: '<<', last: '>>', theme: 'white' });
                            $("#Div1").show();
                        }
                    }
                    else{
                        msg("Record Not Found", alert);
                        self.AShSearch('');
                        self.FShSearch('');
                        self.GShSearch('');
                    }
                    //#endregion Pagination
                });


        }

    }
    self.ViewSHolderbyHolderNo= function(SHolder){
        self.AShSearch('');
        self.AShSearch('');
        self.GShSearch('');
        self.ShHolderNo(SHolder.ShHolderNo());
        $("#modalShHolder").modal('hide');
        self.ShHolders(null);
        $("#SearchPager").hide();
        self.CheckSHolders(SHolder);

    }

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

    self.ChargeType = function () {

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
                   
                    self.SelectedScheme() ? self.face_val(self.SelectedScheme().PerShVal()) : 0;
                    
                    self.SelectedCharge(self.ChargeTypes()[1]);
                    //$("#dllChargeTypes").attr("disabled", true);   
                });
        

    }

    self.ChargeType();
      
    
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
   
    self.ClearControls = function () {
        self.Cleartextboxes();
        self.UserCenters.removeAll()
        $("#RShare *").attr('disabled', true);
        if ($("#usercode").text() != "1") {
            $("#dllCompany").attr('disabled', 'disabled');
            $("#ddlCCenter").attr('disabled', 'disabled');
        }
         $("#btnSave").text('Save');
        $("#btnSave ,#btnCancel").attr('disabled', true);
        $("#btnAdd, #btnEdit, #btnDel, #btnShHolder, #btnDelPost").attr('disabled', false);
        self.Action('');
        self.tot_redem_unit('');
        self.SHolders([]);
        self.APPLY_DT('');
        self.current_nav('');
        self.nav_date('');
        self.PAN_No('');        
        self.TransPin('')
        self.Passcode('')
        self.EmailOtp('')
        self.PanCard(null);
        self.File1(null);
        $('#ImgFile1').val(null);
        $("#txtredemunit").attr('disabled', false);
     }


    self.EnableControlDel = function () {
        $('#RemoveCenter').css('display', 'none');
        $('#Request').css('display', 'inline');
        $('#txtrequestno').attr('disabled', false);
        self.Action("D");
        $('#btnSearch').attr('disabled', true);
        $('#btnShHolder, #txtSHolder, #btnDelPost').attr('disabled', true);
        $("#btnSave").text("Save");
        self.SetControls();

    }
    self.EnableControlEdit = function () {
        $('#RemoveCenter').css('display', 'none');
        $('#Request').css('display', 'inline');
        $('#txtrequestno').attr('disabled', false);
        self.Action("E");
        $('#btnSearch').attr('disabled', true);
        $('#btnShHolder, #txtSHolder, #btnDelPost').attr('disabled', true);
        $("#btnSave").text("Update");
        self.SetControls();
        
    }

    
    self.EnablePostedControlDel = function(){
        $('#RemoveCenter').css('display', 'none');
        $('#Request').css('display', 'inline');
        $('#txtrequestno').attr('disabled', false);
        self.Action("P");
        $('#btnSearch').attr('disabled', true);
        $('#btnShHolder, #txtSHolder').attr('disabled', true);
        $("#btnSave").text("Save");
        self.SetControls();
    }

    self.SetControls = function () {

        if ($("#usercode").text() != "1") {
            $("#dllCompany").attr('disabled', 'disabled');
            $("#ddlCCenter").attr('disabled', 'disabled');
        }
        $("#btnSave ,#btnCancel").attr('disabled', false);
        (self.Action() =='P') ? $("#btnSearch").attr('disabled', true): $("#btnSearch").attr('disabled', false);
        $(" #btnEdit, #btnDel,#btnDelPost").attr('disabled', true);

    }
    self.EnableControlAdd = function () {

        if (self.Action() != "E" && self.Action() != "D") {
            self.Action("A");
        }

        self.SetControls();



    }
    self.ShowModal = function () {
        scheme_code = scheme_code;
        usercode = ccode;
        ShHolderNo = SHHOLDERNO 
        var url = "/Handler/RequestHandling/RedemptionRequestHandler.ashx";
        var data = { 'method': 'GetAllocatedData', 'scheme_code': scheme_code,'ccode': usercode, 'REQUEST_NO': self.REQUEST_NO(), 'SHHOLDERNO': ko.toJS(self.ShHolderNo()), 'Action' : 'A' };
        $.post(url, data,
            function (result) {

                  waitMsg.hide();
                var obj = jQuery.parseJSON(result);
                
                var mappedTasks = $.map(obj.ResponseData, function (item,i) {
                item.SNO=i+1;
//                if(self.selectedGain().GainID ==0){
//                  item.TrueOrFalseProperty= true;
//                }
//                else{
//                  item.TrueOrFalseProperty= false;
//                }
                 return new Transaction(item)
                })
                self.SHolders(mappedTasks);
                 
            })

    }
   
    self.ViewSHolderbySearch = function (Transaction) {
  
        self.p_dt(ko.toJS(Transaction.value_dt));
        self.GetServiceCharge();
        self.redem_unit('');
        self.inv_amt('');
        self.inv_amt_redem_unit('');
        self.exe_load('');
        self.cap_gain_tax('');
        self.cur_val('');
        self.p_dt('');
        self.seqno('');
        self.Allocation_no('');
        self.Unposted_Unit('');
        self.locked_unit('');
        $("#modalSearch").modal('hide');

        if (self.CheckAllocationNo(Transaction) == false) {
            self.balance_unit('');
            self.inv_amt('');
            self.Holding_Days('');
        }
        else {
            self.Allocation_no(Transaction.Allocation_no);
            self.balance_unit(Transaction.balance_unit());
            self.inv_amt(Transaction.inv_amt());
            self.Allocation_no(Transaction.Allocation_no());
            self.p_dt(Transaction.value_dt());
            self.Unposted_Unit(Transaction.Unposted_Unit());
            self.seqno(Transaction.seqno());
            self.locked_unit(Transaction.locked_unit());
            // self.CheckAllocationNo(Transaction);

        }


    }
    // self.SelectedCharge.subscribe(function () {
    self.GetServiceCharge= function(){

        if (self.SelectedCharge() != undefined) {
            if (self.APPLY_DT() != undefined && self.APPLY_DT() != "") {
                $.ajax({
                    type: "GET",
                    dataType: "json",
                    cache: false,
                    async: false,
                    url: '/Handler/RequestHandling/PurchaseRequestHandler.ashx',
                    data: { 'method': 'GetServiceChargeAmt', 'ApplyDate':self.p_dt() ,'Scheme_code':scheme_code, 'NAV_Date':self.nav_date(),'SCharge_Code':self.SelectedCharge().SCharge_Code() },
                    contentType: "applicaton/json; character=utf -8",
                    success: function (data) {
                        if(data.ResponseData.length >0) {
                            self.Flat_percent(data.ResponseData[0].Flat_percent);
                            self.rate(data.ResponseData[0].rate);
                            self.Holding_Days(data.ResponseData[0].Holding_Days);
                        }
                    },
                    error: function (err) {
                        waitMsg.hide();
                        msg(err.status + " - " + err.statusText, "WARNING");
                    }

                })
            }
            else
            {
                msg("Please Choose ApplyDate", alert);
                self.SelectedCharge(null);
            }
        }
    }
    
Number.prototype.round = function(places) {
  return +(Math.round(this + "e+" + places)  + "e-" + places);
}
    self.loadValue = function () {
    if (self.balance_unit() != undefined && self.balance_unit() != null) {
            if(self.APPLY_DT() != undefined && self.SelectedCharge() != undefined)
            {
                var balunit = self.balance_unit()-self.Unposted_Unit()-self.locked_unit();
                if (self.redem_unit() <= balunit){
                    var data1 = parseFloat((self.ActAverage_Price() * self.redem_unit()).toFixed(4));
                    self.inv_amt_redem_unit(data1.round(2));
                    var data2 = parseFloat((self.current_nav() * self.redem_unit()).toFixed(4));
                    self.cur_val(data2.round(2));
                    self.GetServiceCharge();
                    if(self.Flat_percent() =='F')
                    {
                        self.exe_load(self.rate());
                    }
                    else if(self.Flat_percent() =='P')
                    {
                        var charge_amount = parseFloat(((self.cur_val()) * ((self.rate()) / 100)).toFixed(4));
                        self.exe_load((charge_amount).round(2));
                    }

                }
                else{
                    msg("Please Enter Redemption Unit less than Balance Unit", "ALERT");
                    // alert("Please Choose Apply Date and Charge Type");
                    self.Clear();
                    self.redem_unit('');
                    self.inv_amt_redem_unit('');
                    self.exe_load('');
                }
            }

            else{
                msg("Please Choose Apply Date and Charge Type", "ALERT");
                // alert("Please Choose Apply Date and Charge Type");
                self.redem_unit('');
            }

        }

    }

    self.capitalgaintaxamt = function(day,cg){
      if(self.selectedGain().GainID == 0){
            if (day <= 365){
             self.CGT(7.5);
             self.capital_gain_tax_amount((cg*0.075).round(2));
            }
            else{
             self.CGT(5);
             self.capital_gain_tax_amount((cg*0.05).round(2));
            }
        }
       else if(self.selectedGain().GainID != 0){
         self.CGT(self.selectedGain().GainCharge);
         self.capital_gain_tax_amount(((self.selectedGain().GainCharge*cg)/100).round(2));  
        }
    }
    self.AddData = function () {
    
     if(self.redem_unit()>=100){
        var total_1 =(ko.toJS(self.SHolders()).reduce((n, {Can_be_Sell}) => n + Can_be_Sell, 0));
        var total =(total_1.round(2));
        self.UserCenters([]);
        if(self.AddValidation()){
         $('#txtredemunit').attr('disabled',true);
        if (self.SHolders().length >= 0){
        if(self.tot_redem_unit()== undefined){
            self.tot_redem_unit(0);
        }
        var SNO= 0;
        var Allocation_no= 0;
        var balance_unit=0;
        var p_dt =0;
        var redem_unit =0;
        var inv_amt_redem_unit =0;
        var exe_load =0;
        var Holding_Days =0;
        var capital_gain_amount =0;
        var capital_gain_tax_amount =0;
        var CGT =0;
        var SNO =0;
        var Can_be_Sell =0
        var tran_type =0;
        var Sip_Holding_Days =0;
        var Sip_Reg_Date =0;
        var seqno;
        var  totalunit  =self.redem_unit(); 
        for (var i = 0; i < self.SHolders().length; i++) {
           var x = i + 1;
           SNO =parseInt($(tblSearch.rows.item(x).cells[0]).text().trim());
           Can_be_Sell =parseFloat($(tblSearch.rows.item(x).cells[10]).text().trim());
           if(totalunit > 0){
           if(totalunit>=Can_be_Sell){
            redem_unit =Can_be_Sell;
           }
           else{
           redem_unit=totalunit;
           }
           Allocation_no =parseInt($(tblSearch.rows.item(x).cells[2]).text().trim());
           p_dt =($(tblSearch.rows.item(x).cells[5]).text().trim());
           inv_amt_redem_unit= redem_unit*self.ActAverage_Price();
           Holding_Days =parseInt($(tblSearch.rows.item(x).cells[12]).text().trim());
           data2 = parseFloat((self.current_nav() * redem_unit).toFixed(4));
           tran_type=parseInt($(tblSearch.rows.item(x).cells[11]).text().trim());
           seqno=parseInt($(tblSearch.rows.item(x).cells[3]).text().trim());
           balance_unit=parseFloat($(tblSearch.rows.item(x).cells[6]).text().trim());
           Sip_Holding_Days=parseInt($(tblSearch.rows.item(x).cells[14]).text().trim());
           Sip_Reg_Date=($(tblSearch.rows.item(x).cells[13]).text().trim());
           self.cur_val(data2.round(2));
           if(tran_type != "02"){
            self.p_dt(p_dt);
           }
           else{
            self.p_dt(Sip_Reg_Date);
           }
           var data1 = parseFloat((self.ActAverage_Price() * redem_unit).toFixed(4));
           self.inv_amt_redem_unit(data1.round(2));
           var data2 = parseFloat((self.current_nav() * redem_unit).toFixed(4));
           self.cur_val(data2.round(2));

           self.GetServiceCharge();
           if(tran_type !="03"){
              if(self.Flat_percent() =='F')
              {
                  exe_load=(self.rate());
              }
              else if(self.Flat_percent() =='P')
              {
                  var charge_amount = parseFloat(((self.cur_val()) * ((self.rate()) / 100)).toFixed(4));
                  exe_load=((charge_amount).round(2));
              }
            }
            else{
//             self.exe_load(parseFloat(0.00).round(2));
            exe_load=(parseFloat(0.00).round(2))
            }
              if(SNO== 1){
                        var amt_before_tax =(self.cur_val() - exe_load-25);
                        if(amt_before_tax > self.inv_amt_redem_unit()){
                        var data3 = parseFloat((data2 - exe_load-25- data1).toFixed(4));

                        self.capital_gain_amount(data3.round(2));
                        //self.capitalgaintaxamt(p_dt,data3)
                         self.capitalgaintaxamt(Holding_Days,data3)
                        var data4 = parseFloat((self.cur_val()-25-exe_load-self.capital_gain_tax_amount()).toFixed(4));
                      
                        }
                        else{
                         self.capital_gain_amount(0);
                         self.capital_gain_tax_amount(0);
                         var data4 = parseFloat((self.cur_val()-25-self.exe_load()-self.capital_gain_tax_amount()).toFixed(4));
                        }
                      }
                      else {
                        var amt_before_tax =(self.cur_val() - exe_load);
                        if(amt_before_tax > self.inv_amt_redem_unit()){
                        var data3 = parseFloat((data2 - exe_load- data1).toFixed(4));
                        self.capital_gain_amount(data3.round(2));
                       // self.capitalgaintaxamt(p_dt,data3)
                        self.capitalgaintaxamt(Holding_Days,data3)
                         var data4 = parseFloat((self.cur_val()-exe_load-self.capital_gain_tax_amount()).toFixed(4));
                       
                        }
                       else{
                         self.capital_gain_amount(0);
                         self.capital_gain_tax_amount(0);
                         var data4 = parseFloat((self.cur_val()-exe_load-self.capital_gain_tax_amount()).toFixed(4));
                        }
                      }
                 var add = self.selectedItem();
         
                    add = {
                        Allocation_no: ko.toJS(Allocation_no),
                        balance_unit: ko.toJS(balance_unit),
                        //redem_unit: (parseFloat(ko.toJS(redem_unit.toFixed(4)))).round(2),
                         redem_unit: parseFloat(parseFloat(redem_unit).toFixed(4)).round(2),
                        inv_amt_redem_unit: ko.toJS(self.inv_amt_redem_unit()),
                        exe_load: ko.toJS(exe_load),
                        p_dt:ko.toJS(p_dt),
                        //Holding_Days:ko.toJS(self.Holding_Days()),
                        Holding_Days:Holding_Days,
                        Sip_Holding_Days:Sip_Holding_Days,
                        capital_gain_amount:self.capital_gain_amount(),
                        capital_gain_tax_amount:self.capital_gain_tax_amount(),
                        CGT:self.CGT(),
                        SNO:SNO,
                        seqno:ko.toJS(seqno)
                   };

                    if (self.UserCenters.indexOf(add) > -1) {
                        return;
                    }

                    self.UserCenters.push(new Transaction(add));
                    $('#btnSave').attr('disabled',false);
               
                self.GetTotal();
                totalunit = totalunit-redem_unit;
            }
        }
      }
    }
    }
    else{
    alert("Cannot Redem Unit less than 100", msg);
    self.redem_unit(null);
    }
  }
  self.EditData = function (value) {
        $("#btnAdd").text("Update");
        $('#btnShowModal').attr('disabled', true);
        self.selectedItem(value);
        self.Allocation_no(value.Allocation_no());
        self.balance_unit(value.balance_unit());
        self.inv_amt(value.inv_amt());
        self.redem_unit(value.redem_unit());
        self.inv_amt_redem_unit(value.inv_amt_redem_unit());
        self.cur_val(value.cur_val());
        self.exe_load(value.exe_load());
        self.cap_gain_tax(value.cap_gain_tax());
        self.p_dt(value.p_dt());
        self.Holding_Days(value.Holding_Days());
        self.seqno(value.seqno());
        self.Unposted_Unit(value.Unposted_Unit());
        self.locked_unit(value.locked_unit());
    }

    self.Cleartextboxes = function () {
       
        self.inv_amt('');
        self.redem_unit('');
        self.inv_amt('');
        self.inv_amt_redem_unit('');
        self.exe_load('');
        self.cap_gain_tax('');
        self.cur_val('');
        self.tot_redem_unit('');
        self.REQUEST_NO(null);
        self.nav_date('');
        self.appno('');
        self.other_charges('');
        self.remarks('');
        self.tot_cap_gain('');
        self.tot_cur_val('');
        self.tot_inv_amt_redem_unit('');
        self.amt_pay_before_tax('');
        
        self.tot_exe_load('');
        self.tot_redem_unit('');
       
        $('#tblUsers').val('');
        self.selectedGLStatus(null);
        self.capital_gain_tax_amt('');
        self.Holding_Days('');
        self.SEBON_Fee('');
        self.seqno('');
        self.Unposted_Unit('');
        self.locked_unit('');
        self.p_dt('');
        self.Allocation_no('');

    }
    self.Clear= function(){
    
        self.selectedGLStatus(null);
        self.selectedGain(null);
        self.tot_cap_gain('');
        self.tot_cur_val('');
        self.tot_inv_amt_redem_unit('');
        self.tot_exe_load('');
        self.tot_redem_unit('');
        self.balance_unit('');
        self.inv_amt('');
        self.redem_unit('');
        self.inv_amt('');
        self.locked_unit('');
        self.inv_amt_redem_unit('');
        self.other_charges('');
        self.amt_pay_before_tax('');
         self.capital_gain_tax_amt('');
        self.SEBON_Fee('');
        self.GetTotal();
        self.Holding_Days('');
        self.p_dt('');
        self.Unposted_Unit('');
        self.seqno('');
        self.Allocation_no('');
        self.exe_load('');
       
        $('#btnShowModal').attr('disabled', false);
        self.selectedItem(null);
        $("#btnAdd").text("Add");
    }
    self.RemoveCenter = function (Transaction) {
    
        self.UserCenters.remove(Transaction);
        self.Clear();
        $("#btnAdd").text("Add");
        //if(self.Action() == "E"){
        self.ShowAction();
        //}

    }
    self.AddValidation = function () {
        var errMsg = "";
        var objFocus = null;
        if (Validate.empty(self.redem_unit())) {
            errMsg += "Please Enter Redemption Unit !!!<br>";
        }
        if (Validate.empty(self.APPLY_DT())) {
            errMsg += "Please Enter Apply Date !!!<br>";
        }
        var total_1 =(ko.toJS(self.SHolders()).reduce((n, {Can_be_Sell}) => n + Can_be_Sell, 0));
        var total = (total_1.round(2));
        if(self.redem_unit() > total){
         errMsg += "Please Enter Redemption Unit less or equal to sum of Can Be Sell Unit !!!<br>";
        }

        if (errMsg !== "") {

            msg(errMsg, "ALERT");
            self.redem_unit(null);
            self.UserCenters([]);
            self.GetTotal();
            return false;
        }
        else {
            return true;
        }

    }

      self.CheckAllocationNo = function (Transaction) {
    
         for (var i = 0; i < self.SHolders().length; i++) {
            var x = i + 1;
            var sn;
            var valuedate = $(tblSearch.rows.item(x).cells[4]).text().trim();
            var tot_unit = $(tblSearch.rows.item(x).cells[5]).text().trim();
            if (valuedate == ko.toJS(Transaction.value_dt)) {
                sn= x;
                if (sn ==1) {
                for (var i = 0; i < self.UserCenters().length; i++) {
                    var y = i + 1; 
                    var seqno = $(tblUsers.rows.item(y).cells[8]).text().trim();
                    var lotno = $(tblUsers.rows.item(y).cells[1]).text().trim();
                    var red_unit = $(tblUsers.rows.item(y).cells[4]).text().trim();
                    if (seqno == Transaction.seqno() && lotno == ko.toJS(Transaction.Allocation_no)) {
                            msg("Please Select Another Row",alert);
                            return false;
                    }
                    else{
                    return true;
                    }
                   }
                 }
                else{
                    var tot_redem_unit;
                    if (isNaN(parseFloat(ko.toJS(self.tot_redem_unit())))) {
                        tot_redem_unit=0;
                        }
                    else {
                        tot_redem_unit= self.tot_redem_unit();// + parseInt($(tblSearch.rows.item(x-1).cells[6]).text().trim());
                    }
                    var balunit =0;
                    for (var i = sn; sn >1; sn--) {
                        balunit = parseInt($(tblSearch.rows.item(sn-1).cells[9]).text().trim()) + balunit;
                    }
                    if (tot_redem_unit < balunit){
                            msg("Please First sell Unit Having less Holding Days", alert);
                        return false;
                    }
                  
                    else{
                    if (self.UserCenters().length >0 ) {
                      if( self.UserCenters().find(x=>x.p_dt() == ko.toJS(Transaction.value_dt))){
                        var y = x; 
                        var seqno = $(tblUsers.rows.item(y).cells[8]).text().trim();
                        var lotno = $(tblUsers.rows.item(y).cells[1]).text().trim();
                        var red_unit = $(tblUsers.rows.item(y).cells[4]).text().trim();
                        if (seqno == Transaction.seqno() && lotno == ko.toJS(Transaction.Allocation_no)) {
                                msg("Please Select Another Row",alert);
                                return false;
                        }
                       else{
                            return true;
                         }
                    }
                   }
                }
             }
         }
       }      
    }

    self.CheckBalanceUnit= function(sn){
    var tot_redem_unit;
    if (isNaN(parseFloat(ko.toJS(self.tot_redem_unit())))) {
           tot_redem_unit=0;
        }
    else {
        tot_redem_unit= self.tot_redem_unit();
    }
    for (var i = sn; i >=0; i--) {
    var balunit = $(tblSearch.rows.item(sn-1).cells[5]).text().trim();
    if (tot_redem_unit <= balunit){
     msg("Please First sell Unit Having less Holding Days", alert);
    return false;
    }
    }
    
    }

    self.GetTotal = function () {
       self.capital_gain_tax_amt('');
       $('#dllCapitalGain').attr('disabled', true);
        var tot_redem_unit = 0;
        var tot_redem_inv = 0;
        var tot_cur_val = 0;
        var tot_exe_load = 0;
        var tot_cap_gain = 0;
        var cap_gain = 0;
        var tot_cap_gain_amount = 0;
        var amt_payable_before_tax =0
        var capital_gain_tax_amt =0
        if (self.UserCenters().length > 0) {
            for (var i = 0; i < self.UserCenters().length; i++) {
                var x = i + 1;
                var redem_unit = $(tblUsers.rows.item(x).cells[4]).text().trim();
                tot_redem_unit = tot_redem_unit + +redem_unit;
                tot_redem_inv = parseFloat((tot_redem_unit*self.ActAverage_Price()).toFixed(4));
                tot_cur_val = parseFloat((tot_redem_unit* self.current_nav()).toFixed(4));         

                var exe_load = $(tblUsers.rows.item(x).cells[6]).text().trim();
                tot_exe_load = tot_exe_load + + exe_load;

//                self.tot_redem_unit(tot_redem_unit);
                self.tot_redem_unit(tot_redem_unit.toFixed(2));
                self.tot_inv_amt_redem_unit(tot_redem_inv.round(2));
                self.tot_cur_val(tot_cur_val.round(2));
                self.tot_exe_load(tot_exe_load.toFixed (2));
                if(self.tot_cur_val() != undefined){
                 var sebon_fee = (0*self.tot_cur_val());
                 self.SEBON_Fee(sebon_fee.toFixed (2));
                }
                self.other_charges('25');
                amt_payable_before_tax =  parseFloat((self.tot_cur_val() - self.tot_exe_load() - parseFloat(self.SEBON_Fee()) - parseFloat(self.other_charges())).toFixed(4));
                self.amt_pay_before_tax(amt_payable_before_tax.round(2));
                if (amt_payable_before_tax > self.tot_inv_amt_redem_unit())
                {
                    
                    self.selectedGLStatus(self.Status().find(x => x.StatusName == "G"));
                }
                else
                {
                    self.selectedGain(self.CapitalGains().find(x => x.GainCharge == 0 ));
                    self.selectedGLStatus(self.Status().find(x => x.StatusName == "L"));
                    $('#dllCapitalGain').attr('disabled', true);
                
                }
               var cap_gain = $(tblUsers.rows.item(x).cells[8]).text().trim();
               tot_cap_gain_amount = tot_cap_gain_amount + + cap_gain;
               self.tot_cap_gain(tot_cap_gain_amount.toFixed (2));
               var cap_gain_txt_amt = $(tblUsers.rows.item(x).cells[9]).text().trim();
               capital_gain_tax_amt = capital_gain_tax_amt + + cap_gain_txt_amt;
               self.capital_gain_tax_amt(capital_gain_tax_amt.toFixed (2));

            }
        }
        else {
            self.tot_redem_unit('');
            self.tot_inv_amt_redem_unit('');
            self.tot_cur_val('');
            self.tot_exe_load('');
            self.tot_cap_gain('');
            self.other_charges('');
            self.SEBON_Fee('');
            self.selectedGLStatus(null);
            self.amt_pay_before_tax(null);
        }
      

    }

   self.GetCGTAmt = function () {

   if(self.selectedGain() != 2 && self.selectedGain() != null){
        var tot_cap_gain_tax = parseFloat((self.tot_cap_gain()*(self.selectedGain().GainCharge/100)).toFixed(4));
        self.capital_gain_tax_amt(tot_cap_gain_tax.round(2));
    }

   }
   
   self.CheckRedemptionSecurity = function () { 
   self.CHECKUNITTOBEREDEM()
    if(self.validateunit() == true){
   if (self.Validation()) {
       self.EmailOtp('')
       self.Passcode('')
        var args = {
                BOID: BOID,
                UserId: UserId,
                SHHOLDERNO: SHHOLDERNO,
                OldPin : ko.toJS(self.TransPin()),
                Email: Email
               
            }
            var url = "/Handler/RequestHandling/RedemptionRequestHandler.ashx";
            var data = { 'method': 'VerifyingTransaction', 'username' : $("#UserName").text() , 'args' : ko.toJSON(args)};
            $.post(url, data,
               function (result) {
                  waitMsg.hide();
                  var data = jQuery.parseJSON(result);
                 
                  if(data.IsSucess){
                                       
                     if(data.ResponseData.toUpperCase() == "SUCCESS"){
                        
                           $("#VerifySercurity").modal('show');
                           $('#Otpwaitmsg').css('display', 'inline');
                                var url = "../../Handler/Security/EmailHandler.ashx" ;
                                var data = { 'method': 'SendMailForOTP',  'Email': ko.toJS(Email) };
                                $.post(url, data,
                                    function (result) {
                
                                    var obj = jQuery.parseJSON(result);
                                    if(obj.IsSucess){
                                       $('#Otpwaitmsg').css('display', 'none');
                                        msg("OTP Send To Your Mail","ALERT")                   
                                    }  
                               });
                     }
                     else{
                       msg(data.ResponseData , "ALERT")
                       self.TransPin('')
                     }
                  }else{
                    msg("Something Gone Wrong", 'ALERT')
                  }
                  self.EmailOtp('')
                  self.Passcode('')
               });  

        }
        }

   }
    self.CHECKOTP = function () {
        if(self.EmailOtp() && !Validate.empty(self.EmailOtp())){
       
            var url = "../../Handler/Security/EmailHandler.ashx";
            var data = { 'method': 'CHECKOTP',  'Email': ko.toJS(Email),'OTP':ko.toJS(self.EmailOtp()) };
            $.post(url, data,
                function (result) {
                var obj = jQuery.parseJSON(result);
                if(obj.IsSucess){  
                   self.VerifyOtp(obj.IsSucess);    
                }  
                else{
                 msg("You have entered wrong OTP or the OTP time has expired. PLease Re-Generate the OTP and verify the OTP.","ALERT") 
                 self.VerifyOtp(obj.IsSucess);
                }
           });
        }
        if(Validate.empty(self.EmailOtp())){
         msg("Please Enter OTP","ALTER")
        }
    }
    self.SecurityValidation = function () {
 
        var errMsg = "";
        var objFocus = null;
        //#region Validating required fields
        if (self.Passcode() == undefined) {
            errMsg += "Please Enter Your Password !!!<br>"
        }
//         if (self.EmailOtp() == undefined) {
//            errMsg += "Please Enter OTP From Mail !!!<br>"
//        }
//        if(self.EmailOtp()  != self.OTP()){
//             errMsg += "Please Verify OTP From Mail !!!<br>"
//        }
         if(self.VerifyOtp() == false){
         errMsg += "Please Verify Your OTP!!!<br/>"
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

   self.RedemptionVerified = function (){
     self.CHECKOTP();
        if(self.SecurityValidation()){
            var args = {
                BOID: BOID,
                UserId: UserId,
                SHHOLDERNO: SHHOLDERNO,
                OldPin : ko.toJS(self.TransPin()),
                Email: Email
               
            }
            self.VerifyList(args);
            var url = "/Handler/RequestHandling/RedemptionRequestHandler.ashx";
            var data = { 'method': 'VerifyingSecurity', 'password' :self.Passcode() , 'username' : $("#UserName").text() , 'args' : ko.toJSON(args)};
            $.post(url, data,
               function (result) {
                  waitMsg.hide();
                  var data = jQuery.parseJSON(result);
                 
                  if(data.IsSucess){
                                       
                     if(data.ResponseData.toUpperCase() == "SUCCESS"){
                        $("#VerifySercurity").modal('hide');
                        
                        self.SaveRedemptionEntry()
                     }else{
                       msg(data.ResponseData , "ALERT")
                       
                     }
                  }else{
                    msg("Something Gone Wrong", 'ALERT')
                  }
                  self.EmailOtp('')
                  self.Passcode('')
                  
               });
        }
      
   }

   
   self.CHECKUNITTOBEREDEM = function(){
        if (self.BOIDValidation()) {
            openloader();
            var Bo_Account_No = self.SelectedDp().DP_Id_Cds() + self.Boid_No();
            self.Bo_Account_No(Bo_Account_No);
            var url ="/Handler/RequestHandling/RedemptionRequestHandler.ashx";
            var data = { 'method': 'CHECKUNITTOBEREDEM', 'scheme_code': scheme_code, 'APPLIED_UNIT': self.redem_unit(), 'BOID': self.Bo_Account_No(), 'L_COMPANY_ID': l_company_id, 'SHHOLDERNO': self.ShHolderNo() ,'APPLY_DT': self.APPLY_DT() };
            $.post(url, data,
              function (result) {
                  closeloader();
                  waitMsg.hide();
                  var data = jQuery.parseJSON(result);
                  if(data.IsSucess){
                     var data =(data.IsSucess);
                      self.validateunit(data);
                      
                  }
                  else{
                      msg(data.Message,'error');
                      self.validateunit(data);
                  }
              });
        }
    }

     self.PasswordValidation = function () {
 
        var errMsg = "";
        var objFocus = null;
        //#region Validating required fields
        if (self.Passcode() == undefined || self.Passcode() == "") {
            errMsg += "Please Enter Your Password !!!<br>"
        }
         if(self.EmailOtp() == undefined || self.Passcode() == ""){
         errMsg += "Please Emter Your OTP!!!<br/>"
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
    self.SaveRedemptionEntry = function () {
//     self.CHECKUNITTOBEREDEM();
//     if(self.validateunit() == true){
    //if(self.SecurityValidation()){
    if(self.PasswordValidation()){
            var args = {
                BOID: BOID,
                UserId: UserId,
                SHHOLDERNO: SHHOLDERNO,
                OldPin : ko.toJS(self.TransPin()),
                Email: Email
               
            }
            self.VerifyList(args);
           if (self.Validation()) {

                        if(self.SelectedBranch() != undefined){
                            var SelectedBranch=self.SelectedBranch().branch_code();
                        }
                        else{
                            SelectedBranch= null;
                        }
                       
                        var args = {
                            Scheme_code: scheme_code,
                            ccode: usercode,
                            REQUEST_NO:self.REQUEST_NO(),
                            ShHolderNo: self.ShHolderNo(),
                            FName: self.Name(),
                            LName: self.LName(),
                            FaName: self.FaName(),
                            GFName: self.GFName(),
                            address: self.Address,
                            P_Tel_No: self.P_Tel_No(),
                            PAN_No: self.PAN_No(),
                            APPLY_UNIT: self.tot_redem_unit(),
                            APPLY_DT: self.APPLY_DT(),
                            BankCode: self.SelectedBank().bankcode(),
                            Branch_code: SelectedBranch,
                            Bank_Account_No: self.Bank_Account_No(),
                            ENTRY_BY: self.Name(),
                            ENTRY_DT: $("#date").text(),
                            APPROVED: "N",
                            APPSTATUS: "UNPOSTED",
                            appno: self.appno(),
                            remarks: self.remarks(),
                            Bo_Account_No: self.Bo_Account_No(),
                            nav_date: self.nav_date(),
                            current_nav: self.current_nav(),
                            SCharge_Code:self.SelectedCharge().SCharge_Code(),
                            capital_gain_tax: self.selectedGain().GainCharge,
                            tot_redeem_amt_nav: self.tot_cur_val(),
                            tot_redeem_amount: self.tot_inv_amt_redem_unit(),
                            tot_exit_load: self.tot_exe_load(),
                            tot_capital_gain: self.tot_cap_gain(),
                            capital_gain_tax_amt:self.capital_gain_tax_amt(),
                            other_charges: self.other_charges(),
                            SEBON_Fee:self.SEBON_Fee(),
                            gainloss_status:self.selectedGLStatus().StatusName, 
                            Action: self.Action(),
                            Transaction: ko.toJS(self.UserCenters()),
                            l_company_id : l_company_id,
                            BOID: self.Bo_Account_No(),
                            
                            
                        };

                                        var url = "/Handler/RequestHandling/RedemptionRequestHandler.ashx";
                                        var data = { 'method': 'SaveRedemptionEntry', 'args': JSON.stringify(ko.toJS(args)), 'type': 'SHolder', 'OTP':self.EmailOtp(), 'Email': ko.toJS(Email), 'password' :self.Passcode() , 'username' : $("#UserName").text() ,'args2' : ko.toJSON(self.VerifyList())};
                                        $.post(url, data,
                                                                 function (result) {
                                                                    waitMsg.hide();
                                                                    var data = jQuery.parseJSON(result);
                                                                     $("#VerifySercurity").modal('hide');
                                                                    var message = " ";
                                                                    message += data.Message;
                                                                    msg(message, "ALERT");
                                                                    self.ClearControls();
                                                                 });



                    }

    //}
    //}
    }
    }


    self.Validation = function () {

        var errMsg = "";
        var objFocus = null;
        //#region Validating required fields
        if (self.SelectedBank() == undefined) {
            errMsg += "Please Select Bank!!!<br>"
        }
        if (Validate.empty(self.Bank_Account_No())) {
            errMsg += "Please Enter Bank Account No!!!<br>"
        }
        if (self.SelectedScheme() == undefined) {
            errMsg += "Please Select Scheme Name !!!<br>"
        }
        if (self.SelectedCharge() == undefined) {
            errMsg += "Please Select Charge !!!<br>"
        }
        
        if(Validate.empty(self.TransPin())){
            errMsg += "Please Enter Transaction Pin !!!<br>"
        }
        if (Validate.empty(self.APPLY_DT())) {
            errMsg += "Please Enter ApplyDate !!!<br>";
        }
      
//        if (Validate.empty(self.other_charges())) {
//            errMsg += "Please Enter Other Charges !!!<br>";
//        }
//        if (Validate.empty(self.SEBON_Fee())) {
//            errMsg += "Please Enter SEBON Fee !!!<br>";
//        }
        if(self.Action() =="E")
        {
            if (Validate.empty(self.REQUEST_NO())) {
                errMsg += "Please Enter Request No !!!<br>";
            }
        }
        if(self.UserCenters().length == 0){
            errMsg += "Please Add Data To Be Sell !!!<br>";
        }
         if (Validate.empty(self.capital_gain_tax_amt())) {
            errMsg += "Please Choose Capital Gain Tax !!!<br>";
        } 
         if(Validate.empty(self.PAN_No())) {
                errMsg += "Please Enter PAN No !!!<br>";
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
    self.GetRedemData = function (SHolder) {
    
    if (self.REQUEST_NO() != undefined){
        if (self.Action() == "E" || self.Action() == "D" || self.Action() == "P" ){
            if (self.SelectedComp() != undefined && self.SelectedCCenter() != undefined) {
                scheme_code = ko.toJS(self.SelectedComp().scheme_code);
                usercode = ko.toJS(self.SelectedCCenter().ccode);
                REQUEST_NO = self.REQUEST_NO();
               
            }
            if (scheme_code == "1" || usercode == "1") {

                msg("Please Select Scheme Name and Distribution Center!!!", "ALERT");

            }
            var url = "/Handler/RequestHandling/RedemptionRequestHandler.ashx";
            var data = { 'method': 'GetRedemData', 'scheme_code': scheme_code, 'ccode': usercode, 'REQUEST_NO': REQUEST_NO, 'Action': self.Action() };
            $.post(url, data, function (result) {
                waitMsg.hide();
                var obj = jQuery.parseJSON(result);
                if (obj.ResponseData != null) {
                    if (obj.ResponseData.length >= 1) {
                        $('#txtSHolder').attr('disabled', true);
                        $('#btnShHolder, #btnSearch, #txtapplydt, #dllChargeTypes,#dp').attr('disabled', true);
                        $('#txtrequestno').attr('disabled', true);
                        var SHolder = obj.ResponseData[0];
                        self.ShHolderNo(SHolder.ShHolderNo);
                        self.Name(SHolder.FName +" "+SHolder.LName);
                        self.FName(SHolder.FName);
                        self.LName(SHolder.LName);
                        self.FaName(SHolder.FaName)
                        self.Bo_Account_No(SHolder.Bo_Account_No);
                        self.Boid_No(((SHolder.Bo_Account_No).toString()).substr(8,16));
                        var dpcode = ((SHolder.Bo_Account_No).toString()).substr(0,8);
                        self.SelectedDp(self.Depo().find(x => x.DP_Id_Cds() === dpcode));
                        document.getElementById("select2-dp-container").innerHTML=ko.toJS(self.SelectedDp().DPName);
                        self.GFName(SHolder.GFName);
                        self.P_Tel_No(SHolder.P_Tel_No);
                        self.PAN_No(SHolder.PAN_No);
                        self.Reg_No(SHolder.Reg_No);
                        self.SEBON_Fee(SHolder.SEBON_Fee);
                        self.Citizenship_No(SHolder.Citizenship_No);
                        self.Signatures(SHolder.Sign.map(x => new Sign(x)));
                        if(SHolder.IsInstitution =='True'){
                            self.IsInstitution('True');
                            $('#Company').prop('checked', true);
                        }
                        else{
                            self.IsInstitution('False');
                            $('#Individual').prop('checked', true);
                        }
                        self.Bank_Account_No(SHolder.Bank_Account_No);
                        self.BalUnit(SHolder.BalUnit);
                        self.Inv_Amt(SHolder.Inv_Amt);
                        self.Average_Price(((ko.toJS(self.Inv_Amt()))/(ko.toJS(self.BalUnit()))).toFixed(2));
                        self.appno(SHolder.appno);
                        self.other_charges(SHolder.other_charges);
                        self.remarks(SHolder.remarks);
                        self.APPLY_DT(SHolder.APPLY_DT);
                        self.GetNavValue();
                        self.current_nav(SHolder.current_nav);
                        self.nav_date(SHolder.nav_date);
                        self.capital_gain_tax(SHolder.capital_gain_tax);
                        self.gainloss_status(SHolder.gainloss_status);
                        self.SelectedBank(self.Banks().find(x => x.bankcode() === SHolder.BankCode));
                        self.SelectedBranch(self.Branches().find(x => x.branch_code() === SHolder.Branch_code));  
                        self.SelectedCharge(self.ChargeTypes().find(x => x.SCharge_Code() === SHolder.SCharge_Code));
                        self.UserCenters(SHolder.Transaction.map(x => new Transaction(x)));
                        self.tot_redem_unit(SHolder.APPLY_UNIT);
                        self.tot_inv_amt_redem_unit(SHolder.tot_redeem_amount);
                        self.tot_cur_val(SHolder.tot_redeem_amt_nav);
                        self.tot_exe_load(SHolder.tot_exit_load);
                        
                        var amt_payable_before_tax =  (parseFloat(self.tot_cur_val()) - parseFloat(self.tot_exe_load()) - parseFloat(self.SEBON_Fee()) - parseFloat(self.other_charges()));
                        self.amt_pay_before_tax(amt_payable_before_tax.toFixed (2));
                        self.tot_cap_gain(SHolder.tot_capital_gain);
                        self.capital_gain_tax_amt(SHolder.capital_gain_tax_amt);
                        self.selectedGLStatus(self.Status().find(x => x.StatusName ==SHolder.gainloss_status));
                        self.selectedGain(self.CapitalGains().find(x => x.GainCharge ==SHolder.capital_gain_tax));
                        self.ShowAction();
                        if (amt_payable_before_tax > self.tot_inv_amt_redem_unit())
                        {
                            tot_cap_gain = (amt_payable_before_tax)- (parseFloat(self.tot_inv_amt_redem_unit()));
                            self.tot_cap_gain(tot_cap_gain.toFixed (2));
                            self.selectedGLStatus(self.Status().find(x => x.StatusName == "G"));
                        }
                        else
                        {
                
                            tot_cap_gain =0;
                            self.tot_cap_gain(tot_cap_gain);
                            self.selectedGain(self.CapitalGains().find(x => x.GainCharge == 0 ));
                            self.selectedGLStatus(self.Status().find(x => x.StatusName == "L"));
                            $('#dllCapitalGain').attr('disabled', true);
                            self.capital_gain_tax_amt(0);
                        }
                    }
                    else {
                        msg("No Record Found !!!", alert)
                        self.ClearControls();
                         
                    }
                }
            });
        }
      } 
    }

    self.ShowAction = function(){
    
    var ln =self.UserCenters().length;
          for (var i =0; i < ln; i++){ 
            if (ln == (i+1)){ 
             (self.UserCenters()[i].shouldShowMessage(true)); 
            }
            else{
               (self.UserCenters()[i].shouldShowMessage(false));
            }
        }

    }

    self.ShowModal2 = function () {
  
        self.EnableControlAdd();
        //  self.Cleartextboxes();
        $("#txtASearch").val('');
        $("#txtFSearch").val('');
        $("#txtGSearch").val('');

        if (self.SelectedComp() != undefined && self.SelectedCCenter() != undefined) {
            scheme_code = ko.toJS(self.SelectedComp().scheme_code);
            usercode = ko.toJS(self.SelectedCCenter().ccode);
        }
        if (scheme_code == "1" || usercode == "1") {

            msg("Please Select Scheme Name and Distribution Center!!!", "ALERT");

        }
        else {
            $("#ModalSearch2").modal('show');
            self.SHHolders.removeAll();
            $("#Div2").hide();
        }
    }
    self.LoadSearch = function () {

        if (self.SelectedComp() != undefined && self.SelectedCCenter() != undefined) {
            scheme_code = ko.toJS(self.SelectedComp().scheme_code);
            usercode = ko.toJS(self.SelectedCCenter().ccode);
        }
        var searchtype = "";
        var errmsg = "";


        if (!Validate.empty(self.ASearch()) || !Validate.empty(self.FSearch()) || !Validate.empty(self.GSearch())) {

            var url = "/Handler/RequestHandling/RedemptionRequestHandler.ashx";
            var data = { 'method': 'SearchRedemHolders', 'ASearch': self.ASearch(), 'FSearch': self.FSearch(), 'GSearch': self.GSearch(), 'scheme_code': scheme_code, 'type': 'SHolder', 'APPSTATUS': 'UNPOSTED' };
            $.post(url, data,
                function (result) {

                    waitMsg.hide();
                    var obj = jQuery.parseJSON(result);
                    var mappedTasks = $.map(obj.ResponseData, function (item) {
                        return new ShHolder(item)

                    });
                    self.SHHolders(mappedTasks);
                    //#region Pagination

                    if (self.SHHolders().length > 0) {

                        var width = document.getElementById('Table1').offsetWidth;

                        document.getElementById('Table1').style.width = width + "px";
                        var rowCount = $('#Table1 >tbody >tr').length;
                        $('#Div2').smartpaginator({ totalrecords: rowCount, recordsperpage: 10, datacontainer: 'tblSearch', dataelement: 'tbody tr', initval: 0, next: '>', prev: '<', first: '<<', last: '>>', theme: 'white' });
                        $("#Div2").show();

                    }
                    //#endregion Pagination
                }
            );


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
                     self.Boid_No(($('#BOID').text()).substr(8,16));
                    var dpcode = ($('#BOID').text()).substr(0,8);
                    self.SelectedDp(self.Depo().find(x => x.DP_Id_Cds() === dpcode));
              
                    }

            });

    }
    self.LoadDp();
    self.ViewRedemSHolderbySearch = function (SHolder) {
        self.ShHolderNo(SHolder.ShHolderNo());
        self.REQUEST_NO(SHolder.REQUEST_NO());
        $("#ModalSearch2").modal('hide');
        self.SHolders(null);
        $("#SearchPager").hide();
        self.GetRedemData(SHolder);
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

    if (self.BOIDValidation()) {
            var Bo_Account_No = self.SelectedDp().DP_Id_Cds() + self.Boid_No();
            self.Bo_Account_No(Bo_Account_No);
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
                        self.P_Tel_No($("#Contact_No").text());
                        self.P_Mobile_no($("#Contact_No2").text());
                        self.BalUnit(SHolder.BalUnit);
                        self.ShHolderNo(SHolder.ShHolderNo);
                        self.Bank_Account_No(SHolder.Bank_Account_No);
                        self.bankcode(SHolder.BankCode);
                        self.Email_ID(SHolder.Email_ID);
                        self.branch_code(SHolder.Branch_code);
                        self.HolderType(SHolder.IsInstitution);
                        self.SelectedBank(self.Banks().find(x => x.bankcode() === SHolder.BankCode));
                        self.SelectedBranch(self.Branches().find(x => x.branch_code() === SHolder.Branch_code));
                        self.BalUnit(SHolder.BalUnit);
                        self.Inv_Amt(SHolder.Inv_Amt);
                        if(self.BalUnit() != undefined && self.Inv_Amt() != undefined){
                            self.Average_Price(((ko.toJS(self.Inv_Amt()))/(ko.toJS(self.BalUnit()))).toFixed(2));
                            self.ActAverage_Price((ko.toJS(self.Inv_Amt()))/(ko.toJS(self.BalUnit())));
                        }
                        else{  
                           self.Average_Price(0);
                           self.ActAverage_Price(0); 
                        }
                        self.ShowModal();
                  }
                  else {
                   $('.Existing').attr("disabled", false);
                     self.IS_UNIT_HOLDER('N');
                     self.BalUnit(0);
                  }
              });
        }


     self.CheckSHolders = function () {
    if(self.Boid_No() !=undefined && self.Boid_No() != ""){
        if(self.SelectedDp() != undefined){
            var Bo_Account_No= self.SelectedDp().DP_Id_Cds() + self.Boid_No();
            self.Bo_Account_No(Bo_Account_No);
        }
       
       }
       
        if(ko.toJS(self.Bo_Account_No()).length == 16){
            self.EnableControlAdd();
            
            if (self.SelectedComp() != undefined && self.SelectedCCenter() != undefined) {
                scheme_code = ko.toJS(self.SelectedComp().scheme_code);
                usercode = ko.toJS(self.SelectedCCenter().ccode);
                
                if (!(Validate.empty(SHolder.Bo_Account_No()))) {
                    var url = "/Handler/RequestHandling/ShHolderHandler.ashx";
                    var data = { 'method': 'GetSHolders', 'scheme_code': scheme_code, 'Bo_Account_No': ko.toJS(self.Bo_Account_No()),  'ccode': usercode, 'SHHOLDERNO' :SHHOLDERNO };
                    $.post(url, data,
                        function (result) {
                            waitMsg.hide();
                            var obj = jQuery.parseJSON(result);
                            if (obj.ResponseData != null) {
                            
                                if (obj.ResponseData.length == 1) {
                                    var SHolder = obj.ResponseData[0];
                                    self.Reg_No(SHolder.Reg_No);
                                    self.P_Mobile_no(SHolder.P_Mobile_no);
                                    self.P_Tel_No(SHolder.P_Tel_No);
                                    self.Bank_Account_No(SHolder.Bank_Account_No);
                                    self.BalUnit(SHolder.BalUnit);
                                    self.Inv_Amt(SHolder.Inv_Amt);
                                    $('#btnSave').attr('disabled', false);
                                    $('#btnEdit').attr('disabled', true);
                                    $('#btnDel').attr('disabled', true);
                                    $('#btnCancel').attr('disabled', false);
                                    $('#txtSHolder, #btnShHolder, #dp').attr('disabled', true);
                                    if(self.BalUnit() != undefined && self.Inv_Amt() != undefined){
                                        self.Average_Price(((ko.toJS(self.Inv_Amt()))/(ko.toJS(self.BalUnit()))).toFixed(2));
                                        self.ActAverage_Price(((ko.toJS(self.Inv_Amt()))/(ko.toJS(self.BalUnit()))).toFixed(2));
                                    }
                                    else  {  
                                     self.Average_Price(0); 
                                    }
                                 }
                                 else if (obj.ResponseData.length > 1){
                                    var mappedTasks = $.map(obj.ResponseData, function (item) {
                                    return new ShHolder(item)
                                    });
                                    self.ShHolders(mappedTasks);
                                    $("#modalShHolder").modal('show');
                                 }
                                else {
                                    msg("No Record Found !!!", alert);
                                    self.ClearSHolderInfo();
                                }
                            }

                        }
                    );
                }
            }
        }
       
    }


}

$(document).ready(function () {
    ValidateSession();
    ko.applyBindings(new RedemptionEntryViewModel());
    var now = new Date();
    maxDate = now.toISOString().substring(0,10);
    $('#txtapplydt').prop('max', maxDate);
});
