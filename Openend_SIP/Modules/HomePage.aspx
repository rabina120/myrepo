<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMaster.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Openend_SIP.Modules.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <title>NIBL Ace Capital Limited • Managing shares. Managing investments.</title>
  <link rel="icon" href="/Styles/Images/apple-icon-57x57.png" type="image/gif" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


  <form id ="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:HiddenField ID="forgeryToken" runat="server"/>

<div class="banner-container">
			<div class="bannergroup">
	<div id="myCarousel" class="carousel slide" data-ride="carousel" data-interval="2500">
		<!-- Wrapper for slides -->
		<div class="carousel-container-wrapper">
			<div class="container carousel-control-holder hidden-xs">
	  				<ol class="carousel-indicators">
	  					  				
   							<li data-target="#myCarousel" data-slide-to="0" class="active"></li>
						
						  				
   							<li data-target="#myCarousel" data-slide-to="1" class=""></li>
						
						  				
   							<li data-target="#myCarousel" data-slide-to="2" class=""></li>
						
						  				
   							<li data-target="#myCarousel" data-slide-to="3" class=""></li>
						
						
					
				      <!--<li data-target="#myCarousel" data-slide-to="1"></li>
				      <li data-target="#myCarousel" data-slide-to="2"></li>
				      <li data-target="#myCarousel" data-slide-to="3"></li> -->
				    </ol>
				    
	  			</div>
		</div>
	  	<div class="carousel-inner carousel-inner-visible" role="listbox">
              
	  				  																																																																															<div class="item active" alt="connectIPS Self-verification">
								<img src="../Styles/Images/banner-one.jpg" alt="connectIPS Self-verification" class="img-responsive">
								<div class="desc color-1" style="right: 98px;">
									<div class="banner-text">
																				<%--<h4 style="text-align: right; right-margin: 40px !important;"><a href="/index.php/component/content/article/41-self-verification-faq?Itemid=">More Information</a></h4>--%>
																			</div>
									<div class="banner-button"></div>
								</div>
							</div>
																							  		
				    		  			
	  				  																																																																															<div class="item" alt="corporatebanner">
								<img src="../Styles/Images/banner-two.jpg" alt="corporatebanner" class="img-responsive">
								<div class="desc color-1" style="right: 98px;">
									<div class="banner-text">
																				
																			</div>
									<div class="banner-button"></div>
								</div>
							</div>
																							  		
				    		  			
	  				  																																																																															<div class="item" alt="Govt Payment">
								<img src="../Styles/Images/banner-three.jpg" alt="Govt Payment" class="img-responsive">
								<div class="desc color-1" style="right: 98px;">
									<div class="banner-text">
																				
<%--<p style="font-weight: 400;">&nbsp;<a href="/index.php/component/content/article/26-govt-pay?Itemid=">More Information</a></p>--%>
																			</div>
									<div class="banner-button"></div>
								</div>
							</div>
																							  		
				    		  			
	  				  																																																																															<div class="item" alt="Corona-awareness">
								<img src="../Styles/Images/banner-four.jpg" alt="Corona-awareness" class="img-responsive">
								<div class="desc color-1" style="right: 98px;">
									<div class="banner-text">
																				
																			</div>
									<div class="banner-button"></div>
								</div>
							</div>
																							  		
				    		  	</div>
	</div>
</div>



		</div>
 </form>

</asp:Content>

