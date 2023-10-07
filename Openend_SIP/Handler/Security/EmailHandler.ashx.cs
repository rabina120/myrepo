using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using SI.Utility;
using SI.Security.BLL;
using System.Net.Mail;
using System.Net.Configuration;
using System.Configuration;
using System.Net;
namespace Openend_SIP.Handler.Security
{
    /// <summary>
    /// Summary description for EmailHandler
    /// </summary>
    public class EmailHandler : UserHandler
    {
        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public object SendMail(string Username, string Email, int UserId, string BOID)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();
            if (IsValidEmail(Email))
            {
                JsonResponse response1 = new JsonResponse();
                MailMessage message = new MailMessage();
                SmtpClient smtpClient = new SmtpClient();
                string NewPass = GeneratePassword.CreateRandomPassword();
                BLLUser bllObj = new BLLUser();
                response = bllObj.Changepassword(Username, NewPass, UserId, BOID, Email);
                if (response.IsSucess == true)
                {
                    string msg = string.Empty;

                    try
                    {
                        using (System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage(CredentialManager.EmailUserName, Email))
                        {
                            mail.To.Add(CredentialManager.EmailUserName);
                            mail.Subject = " Your account is successfully created";
                            mail.IsBodyHtml = true;

                            mail.Body = "<div class= container>";
                            mail.Body += "<p>Dear Sir/Madam,</p>";
                            mail.Body += "<p>ATTN : Please do not reply to this email.This mailbox is not monitored and you will not receive a response.</p>";
                            mail.Body += "<h4>Your login  Username is :" + " " + Username + " and password is " + NewPass + "</h4>";
                            mail.Body += "<br/>";
                            mail.Body += "<p>" + ConfigurationManager.AppSettings["EmailKey1"] + "</p>";
                            mail.Body += "<p>" + ConfigurationManager.AppSettings["EmailKey2"] + "</p>";
                            mail.Body += "<p>" + ConfigurationManager.AppSettings["EmailKey3"] + "</p>";
                            mail.Body += "<p>" + ConfigurationManager.AppSettings["EmailKey4"] + "</p>";
                            mail.Body += "<p>" + ConfigurationManager.AppSettings["EmailKey5"] + "</p>";
                            mail.Body += "<p>" + ConfigurationManager.AppSettings["EmailKey6"] + "<br/></p>";
                            mail.Body += "<p>" + ConfigurationManager.AppSettings["EmailKey7"] + "</p>";
                            mail.Body += "<p>" + ConfigurationManager.AppSettings["EmailKey8"] + "</p>";
                            mail.Body += "</div>";

                            SmtpClient smtp = new SmtpClient();
                            smtp.Host = CredentialManager.EmailHost;
                            smtp.EnableSsl = CredentialManager.EmailEnableSSL;
                            NetworkCredential networkCred = new NetworkCredential(CredentialManager.EmailUserName, CredentialManager.EmailPassword);
                            smtp.UseDefaultCredentials = CredentialManager.EmailDefaultCredential;
                            smtp.Credentials = networkCred;
                            smtp.Port = CredentialManager.EmailPort;
                            smtp.Send(mail);

                            var value = string.Format("Email Send for User Credential Request ", Email);
                            SaveEventLog objEvent = new SaveEventLog();
                            objEvent.EmailLogDetail(Username, value, "Mail Send", BOID, Email, "NULL");
                            response.IsSucess = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        msg = ex.Message;
                    }
                }
            }
            else
            {
                response.Message = "Enter Email Address is Not Valid";
                response.IsSucess = false;
            }
            return JsonUtility.Serialize(response);
        }


     
        public object SendMailForUserName(string Email, string BOID, string Username = null)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();
            BLLUser bllObj = new BLLUser();
            response = bllObj.GetUsername(Email, BOID);
            if (response.IsSucess)
            {
                Username = response.Message;

                response = new JsonResponse();
                MailMessage message = new MailMessage();
                SmtpClient smtpClient = new SmtpClient();
                string msg = string.Empty;

                try
                {

                    using (System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage(CredentialManager.EmailUserName, Email))
                    {
                        mail.To.Add(CredentialManager.EmailUserName);
                        mail.Subject = " Your User Name Request ";
                        mail.IsBodyHtml = true;
                        mail.Body = "<div class= container>";
                        mail.Body += "<p>Dear Sir/Madam,</p>";
                        mail.Body += "<p>ATTN : Please do not reply to this email.This mailbox is not monitored and you will not receive a response.</p>";
                        mail.Body += "<h4>Your login  Username is :" + " " + Username + "</h4>";
                        mail.Body += "<h4>Your BOID Number is :" + " " + BOID + "</h4>";
                        mail.Body += "<br/>";
                        mail.Body += "<p>" + ConfigurationManager.AppSettings["EmailKey1"] + "</p>";
                        mail.Body += "<p>" + ConfigurationManager.AppSettings["EmailKey2"] + "</p>";
                        mail.Body += "<p>" + ConfigurationManager.AppSettings["EmailKey3"] + "</p>";
                        mail.Body += "<p>" + ConfigurationManager.AppSettings["EmailKey4"] + "</p>";
                        mail.Body += "<p>" + ConfigurationManager.AppSettings["EmailKey5"] + "</p>";
                        mail.Body += "<p>" + ConfigurationManager.AppSettings["EmailKey6"] + "<br/></p>";
                        mail.Body += "<p>" + ConfigurationManager.AppSettings["EmailKey7"] + "</p>";
                        mail.Body += "<p>" + ConfigurationManager.AppSettings["EmailKey8"] + "</p>";
                        mail.Body += "</div>";

                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = CredentialManager.EmailHost;
                        smtp.EnableSsl = CredentialManager.EmailEnableSSL;
                        NetworkCredential networkCred = new NetworkCredential(CredentialManager.EmailUserName, CredentialManager.EmailPassword);
                        smtp.UseDefaultCredentials = CredentialManager.EmailDefaultCredential;
                        smtp.Credentials = networkCred;
                        smtp.Port = CredentialManager.EmailPort;
                        smtp.Send(mail);

                        response.IsSucess = true;
                        var value = string.Format("Email Send for User Credential Request ", Email);
                        SaveEventLog objEvent = new SaveEventLog();
                        objEvent.EmailLogDetail(Username, value, "Mail Send", BOID, Email, "NULL");
                        //msg = "Successful";
                        //response.Message = msg;
                        //BLLUser bllObj = new BLLUser();
                        //response.IsSucess = true;
                        response.Message = "UserName Send to Your Mail";

                    }
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                }
            }
            return JsonUtility.Serialize(response);
        }



        public object CheckEmail(string Email)
        {
            JsonResponse response = new JsonResponse();
            try
            {
                var addr = new System.Net.Mail.MailAddress(Email);
                response.IsSucess = true;
            }
            catch
            {
                response.IsSucess = false;
            }
            return JsonUtility.Serialize(response);
        }
        public object validateEmailaddress(string Email)
        {
            JsonResponse response = new JsonResponse();
            try
            {
                BLLUser bllObj = new BLLUser();
                response = bllObj.validateEmailaddress(Email);
                response.IsSucess = true;
                return JsonUtility.Serialize(response);

            }
            catch
            {
                response.IsSucess = false;
            }
            return JsonUtility.Serialize(response);
        }

        public object SendMailForOTP(string Email,string ContactNumber)
        {
            ValidateToken("A", null);
            JsonResponse response = new JsonResponse();
            if (IsValidEmail(Email))
            {
                try
                {
                    BLLUser bllObj = new BLLUser();
                    response = bllObj.SendMailForOTP(Email,ContactNumber);
                    response.IsSucess = true;
                    return JsonUtility.Serialize(response);

                }
                catch
                {
                    response.IsSucess = false;
                }
            }
            else
            {
                response.IsSucess = false;
                response.Message = "Enter Email Address is Not Valid";
            }
            return JsonUtility.Serialize(response);
        }





        public object CHECKOTP(string Email, string OTP)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                BLLUser bllObj = new BLLUser();
                response = bllObj.CHECKOTP(Email, OTP);
                // response.IsSucess = true;
                return JsonUtility.Serialize(response);
            }
            catch
            {
                response.IsSucess = false;
            }
            return JsonUtility.Serialize(response);
        }
        //public object SendMailForOTP( string Email)
        //{
        //    var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";
        //    var Charsarr = new char[6];
        //    var random = new Random();

        //    for (int i = 0; i < Charsarr.Length; i++)
        //    {
        //        Charsarr[i] = characters[random.Next(characters.Length)];
        //    }

        //    var OTP = new String(Charsarr);
        //    JsonResponse response = new JsonResponse();
        //    MailMessage message = new MailMessage();
        //    SmtpClient smtpClient = new SmtpClient();
        //    string msg = string.Empty;   

        //    try
        //    {

        //        using (System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage(CredentialManager.EmailUserName, Email))
        //        {
        //            mail.To.Add(CredentialManager.EmailUserName);
        //            mail.Subject = " Your One Time Password ";
        //            mail.IsBodyHtml = true;
        //            string htmlBody;
        //            mail.Body = "<div class= container>";
        //            mail.Body += "<p>Dear Sir/Madam,</p>";
        //            mail.Body += "<p>ATTN : Please do not reply to this email.This mailbox is not monitored and you will not receive a response.</p>";
        //            mail.Body += "<h4>Your OTP is " + OTP + " .</h4>";
        //            mail.Body += "<br/>";
        //            //mail.Body += EmailMsg;
        //            mail.Body += "<p>" + ConfigurationManager.AppSettings["EmailKey1"] + "</p>";
        //            mail.Body += "<p>" + ConfigurationManager.AppSettings["EmailKey2"] + "</p>";
        //            mail.Body += "<p>" + ConfigurationManager.AppSettings["EmailKey3"] + "</p>";
        //            mail.Body += "<p>" + ConfigurationManager.AppSettings["EmailKey4"] + "</p>";
        //            mail.Body += "<p>" + ConfigurationManager.AppSettings["EmailKey5"] + "</p>";
        //            mail.Body += "<p>" + ConfigurationManager.AppSettings["EmailKey6"] + "<br/></p>";
        //            mail.Body += "<p>" + ConfigurationManager.AppSettings["EmailKey7"] + "</p>";
        //            mail.Body += "<p>" + ConfigurationManager.AppSettings["EmailKey8"] + "</p>";
        //            mail.Body += "</div>";
        //            //htmlBody = "Your OTP is " + otp;
        //            //mail.Body = htmlBody;
        //            SmtpClient smtp = new SmtpClient();
        //            smtp.Host = CredentialManager.EmailHost;
        //            smtp.EnableSsl = CredentialManager.EmailEnableSSL;
        //            NetworkCredential networkCred = new NetworkCredential(CredentialManager.EmailUserName, CredentialManager.EmailPassword);
        //            smtp.UseDefaultCredentials = CredentialManager.EmailDefaultCredential;
        //            smtp.Credentials = networkCred;
        //            smtp.Port = CredentialManager.EmailPort;
        //            smtp.Send(mail);

        //            msg = "Successful";
        //            response.Message = msg;
        //            BLLUser bllObj = new BLLUser();

        //            response.IsSucess = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        msg = ex.Message;
        //    }
        //    return JsonUtility.Serialize(response);
        //}
    }
}