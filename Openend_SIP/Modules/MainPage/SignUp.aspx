<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMaster.Master" AutoEventWireup="true"
    CodeBehind="SignUp.aspx.cs" Inherits="Openend_SIP.Modules.MainPage.SignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Sign Up |  </title>
    <link rel="icon" href="/Styles/Images/apple-icon-57x57.png" type="image/gif" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .btn
        {
            background-color: #1e4483;
        }
        .nepalistyle
        {
            font-size: 12px;
        }
        label
        {
            font-weight: bold;
            font-size: 15px;
        }
        #loader
        {
            position: absolute;
            top: 90%;
            left: 50%;
            transform: translate(-50%, -50%);
            -ms-transform: translate(-50%, -50%);
            text-align: center;
        }
        
        .footer
        {
            position: inherit !important;
        }
        
        .disabledbutton
        {
            pointer-events: none;
            opacity: 0.4;
        }
    </style>
    <script>
        function validate(input) {
            if (/^\s/.test(input.value))
                input.value = '';
        }
        
    </script>
       <form id ="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="forgeryToken" runat="server"/>
    <div class="container" style="margin-bottom: 25px; margin-top: 156px;">
        <div class="image">
            <h3 align="center" style="font-weight: bold;">
                <div class="row">
                    <div class="col-md-12 col-xs-12 col-lg-12 col-sm-12">
                        Sign Up Form
                    </div>
                </div>
            </h3>
            <br />
            <br />
            <div class="card-body ">
                <div class="col-md-6" style="border: 1px solid #e5e5e5;">
                    <div class="row" style="padding-top: 10px;">
                        <div class="col-md-6 col-xs-12 col-lg-6 col-sm-12 ">
                            <div class="form-group">
                                <label for="Username"> Depository Participants <span class="mandatory">*</span></label>
                                <select id="dp" class="form-control Existing" data-bind='options:Depo, optionsText:"DPName", value:SelectedDp, optionsCaption:"   --- Select DP --- "'>
                                </select>
                            </div>
                            <div class="clear"></div>
                        </div>
                        <div class="col-md-6 col-xs-12 col-lg-6 col-sm-12 ">
                            <div class="form-group">
                                <label for="Username">
                                    Boid No <span class="mandatory">*</span></label>
                                <input type="text" id="txtboid" onkeypress="return isNumberKey(event)" class="form-control Existing"
                                    maxlength="8" oninput="validate(this)" data-bind="value:Boid_No , valueUpdate: 'input', executeOnEnter:CheckSHolders, event{blur:CheckSHolders}" />
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-xs-12 col-lg-6 col-sm-12 ">
                            <div class="form-group">
                                <label for="Username">
                                    Name <span class="mandatory">*</span></label>
                                <input type="text" id="txtName" data-bind="value:Name" oninput="validate(this)" class="form-control "
                                    onkeypress='return (event.charCode >= 65 && event.charCode <= 122)  || event.charCode == 32' />
                            </div>
                        </div>
                        <%-- <div class="col-md-6 col-xs-12 col-lg-6 col-sm-12" style="  padding-top: 21px;">
                        <div class="form-group" >
                            <label for="Gender">
                              Gender <span class="mandatory">*</span></label>
                          <input type="radio" id="txtmale" name ="Gender" value="male" data-bind="checked:Gender"   /> Male
                          <input type="radio" id="txtfemale" name ="Gender" value="female" data-bind="checked:Gender"  /> Female
                          <input type="radio" id="txtothers" name ="Gender" value="others" data-bind="checked:Gender"   /> Others
                        </div>
                 </div>--%>
                        <div class="col-md-6 col-xs-12 col-lg-6 col-sm-12 ">
                            <div class="form-group">
                                <label for="Username">
                                    DOB <span class="mandatory">*</span></label>
                                <input type="Date" id="txtDOB" data-bind="value:DOB" class="form-control" />
                            </div>
                        </div>
                    </div>
                  <%--  <div class="row">
                        <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12 ">
                            <div class="form-group">
                                <label for="Username">
                                    Contact No <span class="mandatory">*</span></label>
                                <input type="text" id="txtContact_No" onkeypress="return isNumberKey(event)" maxlength="10"
                                    data-bind="value:Contact_No" class="form-control" />
                            </div>
                        </div>
                        <div class="col-md-3 col-xs-5 col-lg-3 col-sm-5 ">
                            <div class="form-group">
                                <label for="ContactOTP" style="font-weight: bold;">
                                    OTP
                                </label>
                                <label class="nepalistyle">
                                    [ ओटिपी ]</label><span class="mandatory">*</span>
                                <input type="text" id='txtContactOTP' data-bind="value:OTPContactPass,valueUpdate: 'input'"
                                    autocomplete="off" class="form-control Submit" maxlength="6">
                            </div>
                        </div>
                        <div class="col-md-5 col-xs-7 col-lg-5 col-sm-7" style=" margin-top:25px;">
                            <div class="form-group" style="">
                                <button class="btn " style="background-color: #5d2e8e; color: white;" autocomplete="off"
                                    data-bind="click:GenerateContactNoOTP" type="submit">
                                    GET OTP</button>
                                <button class="btn " id='VerifyContactotp' style="background-color: #21ba45; display: none;
                                    color: white;" autocomplete="off" data-bind="click:CheckContactNoOTP" type="submit">
                                    Verify OTP</button>
                            </div>
                        </div>
                    </div>--%>

                         <div class="row">
                      <div class="col-md-6 col-xs-12 col-lg-6 col-sm-12 ">
                            <div class="form-group">
                                <label for="Username">
                                    Contact No
                                </label>
                                <input type="text" id="Text3" onkeypress="return isNumberKey(event)" maxlength="10"
                                    data-bind="value:Contact_No2" class="form-control" />
                            </div>
                        </div>

                        <div class="col-md-6 col-xs-12 col-lg-6 col-sm-12">
                            <div class="form-group">
                                <label for="Username">
                                    UserName <span class="mandatory">*</span></label>
                                <input type="text" id="txtUserName" data-bind="value:UserName, executeOnEnter:validateUserName, event{blur:validateUserName}"
                                    class="form-control" oninput="validate(this)" />
                            </div>
                        </div>
                    </div>

                  
                    <div class="row">
                        
                         <div class="col-md-6 col-xs-12 col-lg-6 col-sm-12 ">
                            <div class="form-group">
                                <label for="Username" style="text-align:left;">
                                    Citizenship Number <span class="mandatory">*</span></label>
                                <input type="text" oninput="validate(this)" id="txtcitizen" data-bind="value:CitizenshipNo"
                                    class="form-control" />
                            </div>
                        </div>
                         <div class="col-md-6 col-xs-12 col-lg-6 col-sm-12">
                            <div class="form-group">
                                <label for="Username">
                                    Email <span class="mandatory">*</span></label>
                                <input type="text" id="txtemail" data-bind="value:Email,valueUpdate: 'input', executeOnEnter:CheckEmail, event{blur:CheckEmail}"
                                    class="form-control" oninput="validate(this)" />
                            </div>
                        </div>
                       <%-- <div class="col-md-6 col-xs-12 col-lg-6 col-sm-12">
                            <div class="form-group">
                                <label for="Username">
                                    Email <span class="mandatory">*</span></label>
                                <input type="text" id="txtemail" data-bind="value:Email,valueUpdate: 'input', executeOnEnter:CheckEmail, event{blur:CheckEmail}"
                                    class="form-control" oninput="validate(this)" />
                            </div>
                        </div>--%>
                    </div>
                    
                    <div class="row">
                    <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12 ">
                            <div class="form-group">
                                <label for="Username">
                                    Contact No <span class="mandatory">*</span></label>
                               <%-- <input type="text" id="txtContact_No" onkeypress="return isNumberKey(event)" maxlength="10"
                                    data-bind="value:P_Tel_No" class="form-control" />--%>
                                    <input type="text" onkeypress="return isNumberKey(event)" data-bind="value:P_Tel_No"
                                maxlength="10" class="form-control Clicklogin Submit" id="txtCnt1" maxlength="10">
                            </div>
                        </div>
                        <div class="col-md-4 col-xs-5 col-lg-4 col-sm-5 ">
                            <div class="form-group">
                                <label for="Email" style="font-weight: bold;">
                                    OTP
                                </label>
                                <label class="nepalistyle">
                                    [ ओटिपी ]</label><span class="mandatory">*</span>
                                <input type="text"  id='txtotp' data-bind="value:OTPPass " class="form-control" maxlength="6">
                            </div>
                        </div>
                        <div class="col-md-6 col-xs-7 col-lg-4 col-sm-7" style=" margin-top:25px;">
                     <%--  <div class="col-md-4 col-xs-12 col-lg-4 col-sm-12 Hidden style=" margin-top:25px;"">--%>
                            <div class="form-group" style="">
                                <button class="btn btn-sm" style="background-color: #5d2e8e; color: white;" data-bind="click:GenerateOTP"
                                    type="submit">
                                    GET OTP</button>
                                 <button class="btn btn-sm" id='Verifyotp'  style="background-color: #21ba45; display:none;color: white;" autocomplete="off" data-bind="click:CHECKOTP"
                                    type="submit">
                                    Verify OTP</button>
                            </div>
                        </div>
                    </div>
                        <%--  </div>
                <div class="row">--%>
               
                    <p style="text-align: justify; color: red;">
                        <span>* If the information has not updated yet in your Demat account or to Fund Manager
                            then you can simply download the Login Registration Form from below link and fill
                            up the form properly with valid signature of your Demat Account and upload the form
                            along with your citizenship here for your Login Registration. </span><span class="nepalistyle">
                                [ यदि तँपाईको व्यक्तिगत विवरण आफ्नो हितग्राहि खातामा वा योजना व्यवस्थापकसँग अद्यावधीक
                                रहेको छैन् भने कृपया निम्म लिंकमार्फत Login Registration Form डाउनलोड गरी आफ्नो
                                हितग्राहि खातामा रहेको हस्ताक्षर गरी आफ्नो नागरिकताको साथमा Upoad गरी Login विवरण
                                प्राप्त गर्न सक्नुहुनेछ ।]</span>
                        <br />
                        <span>
                            <button type="button" class="btn-link" data-bind="click:openpdfe">
                                Click Here to Download the Form</button>
                        </span>
                    </p>
                    <div class="row">
                        <div class="col-md-6 col-xs-12 col-lg-6 col-sm-12">
                            <div class="form-group">
                                <label for="Username">
                                    Upload File
                                </label>
                                <input type="file" id="txtUploadFile" data-bind="value:UploadFile" class="form-control" />
                            </div>
                        </div>
                        <div class="col-md-6 col-xs-12 col-lg-6 col-sm-12">
                            <div class="form-group">
                                <label for="Username">
                                    Citizenship
                                </label>
                                <input type="file" id="txtSign" data-bind="value:Signature1" class="form-control" />
                            </div>
                        </div>
                    </div>
                    <p style="text-align: justify; color: red;">
                        <span>( Document size must be less than 1 mb and jpeg, png and jpg format is only acceptable)</span>
                    </p>
                    <div class="row">
                        <div class="padding-left-15 margin-top-15 margin-bottom-15 pull-right">
                            <button data-bind="click:SubmitForm" title="Click To Proceed" value="Proceed" class="btn btn-primary btn-md"
                                id="btnProceed">
                                Submit
                            </button>
                            <button title="Click To Cancel" data-bind="click:ClearControls" value="Cancel" class="btn btn-primary btn-md "
                                id="Button1">
                                Cancel
                            </button>
                        </div>
                    </div>
                </div>
            </div>
            <div class=" col-md-6">
                <fieldset>
                    <p style="background-color: #bce8f1; font-size: 16px;">
                        <i class="fa fa-caret-square-o-up"></i>Notes For Login Registration :</strong>
                    </p>
                    <p>
                        <i class="fa fa-fw fa-star"></i>This login registration is only for existing unit-holders
                        of the scheme.<br />
                        <span class="nepalistyle">[यो सुविधा योजनामा हाल कायम रहेका इकाईधनीहरुका लागी मात्र
                            रहेको छ ।]</span>
                    </p>
                    <p>
                        <i class="fa fa-fw fa-star"></i>Please fill up the form properly as per the record
                        maintained in your Demat Account or information provided to Fund Manager.<span class="nepalistyle">[कृपया
                            हितग्राहि खातामा वा योजना व्यवस्थापकमा रहेको आफ्नो विवरण भरी बुझाउनु होला ।]</span></p>
                    <p>
                        <i class="fa fa-fw fa-star"></i>If the information provided in this form shall not
                        be verified with the records in Demat Account or Fund Manger’s record then the application
                        shall be rejected. <span class="nepalistyle">[यदि यस फारममा मार्फत बुझाइएको विवरण हितग्राहि
                            खातामा वा योजना व्यवस्थापकमा रहेका विवरणसँग रुजु नभएमा यस आवेदन स्वतः खारेज हुनेछ
                            ।]</span></p>
                    <p>
                        <i class="fa fa-fw fa-star"></i>The Login details shall be sent to the e-mail address
                        provided in this form after verification of the information within 3 working days
                        and if it takes some more days then please contact to Fund Manager.<br />
                        <span class="nepalistyle">[Login विवरण यस आवेदनमा उल्लेख भएको ईमेलमा ३ कार्य दिन भित्रमा
                            प्रदान गरीनेछ र यदि सो दिन भित्रमा ईमेल प्राप्त नभएमा कृपया योजना व्यवस्थापकलाई
                            सम्पर्क गर्नुहोला ।]</span></p>
                    <p>
                        <i class="fa fa-fw fa-star"></i>The unit-holders will be fully liable of all transaction
                        made with the Login Details. <span class="nepalistyle">[यस Login मार्फत गरीएको सम्पूर्ण
                            कारोबारहरुको जिम्बेवार स्वंम इकाईधनी नै रहनेछन् ।]</span></p>
                    <p>
                        <i class="fa fa-fw fa-star"></i>The Fund Manager shall have all rights to cancel/block/reject
                        the Login Registration without inform to Unit-holders.<span class="nepalistyle">[इकाईधनीलाई
                            सूचित गरी वा नगरी यस Login Registration रद्द/रोक्का वा फिर्ता गर्न सक्ने सम्पूर्ण
                            अधिकार योजना व्यवस्थापक सँग रहेको हुन्छ ।]</span></p>
                    <p>
                        <i class="fa fa-fw fa-star"></i>Please keep your Login details confedential and
                        if you lost, change it or inform to Fund Manager immediately.<span class="nepalistyle">[इकाईधनीले
                            आफ्नो Login विवरण सुरक्षित तथा गोप्य रुपमा राख्नुपर्नेछ र सो विवरण हराएमा वा बिर्सिएमा
                            तुरुन्त परिवर्तन गर्नुपर्नेछ वा योजना व्यवस्थापकलाई जानकारी गराउनु पर्नेछ ।]</span></p>
                </fieldset>
            </div>
        </div>
    </div>
    </form>
    <script src="../../Scripts/MainPage/SignUp.js?v=0.1" type="text/javascript"></script>
</asp:Content>
