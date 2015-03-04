using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace VenomitIT
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
        }
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.aspx/{*pathInfo}");
            routes.IgnoreRoute("{resource}.htm/{*pathInfo}");
            routes.IgnoreRoute("{resource}.html/{*pathInfo}");
            routes.IgnoreRoute("{resource}.txt/{*pathInfo}");
            routes.IgnoreRoute("{resource}.xml/{*pathInfo}");

            routes.MapRoute("home", "", new { controller = "Home", action = "Index" });
            routes.MapRoute("HomePage", "Home");
            routes.MapRoute("DashBoard", "dashboard", new { controller = "Home", action = "DashBoard" });
            routes.MapRoute("ChangePasswordPage", "changepassword", new { controller = "Account", action = "ChangePassword" });
            routes.MapRoute("ForgotPasswordPage", "forgotpassword", new { controller = "Account", action = "ForgotPassword" });
            routes.MapRoute("SignOutPage", "signout", new { controller = "Account", action = "SignOut" });

            //Domain Details
            routes.MapRoute("ManageDomain", "managedomain", new { controller = "Domain", action = "DomainDetails" });
            routes.MapRoute("EditDomain", "editdomain/{domainId}/", new { controller = "Domain", action = "EditDomain" });
            routes.MapRoute("AddDomain", "adddomain/", new { controller = "Domain", action = "AddDomain" });
            routes.MapRoute("DeleteDomain", "deletedomain/{domainId}/", new { controller = "Domain", action = "DeleteDomain" });
            routes.MapRoute("ManageDomainContent", "managecontent/{domainId}/", new { controller = "Domain", action = "DomainMange" });

            //Slider Details
            routes.MapRoute("ManageSlider", "manageslider/{domainId}/", new { controller = "Slider", action = "ManageSlider" });
            routes.MapRoute("EditSlider", "editslider/{sliderId}/", new { controller = "Slider", action = "EditSlider" });
            routes.MapRoute("AddSlider", "addSlider/{domainId}/", new { controller = "Slider", action = "AddSlider" });
            routes.MapRoute("DeleteSlider", "deleteslider/{sliderId}/", new { controller = "Slider", action = "DeleteSlider" });

            //slider content details
            routes.MapRoute("ManageSliderContent", "manageslidercontent/{sliderId}/", new { controller = "Slider", action = "ManageSliderContent" });
            routes.MapRoute("EditSliderContent", "editslidercontent/{sliderDetailsId}/", new { controller = "Slider", action = "EditSliderContent" });
            routes.MapRoute("AddSliderContent", "addSlidercontent/{sliderId}/", new { controller = "Slider", action = "AddSliderContent" });
            routes.MapRoute("DeleteSliderContent", "deleteslidercontent/{sliderDetailsId}/", new { controller = "Slider", action = "DeleteSliderContent" });

            //About Us Details
            routes.MapRoute("ManageAbout", "manageabout/{domainId}/", new { controller = "About", action = "ManageAbout" });
            routes.MapRoute("EditAbout", "editabout/{aboutId}/", new { controller = "About", action = "EditAbout" });
            routes.MapRoute("AddAbout", "addabout/{domainId}/", new { controller = "About", action = "AddAbout" });
            routes.MapRoute("DeleteAbout", "deleteabout/{aboutId}/", new { controller = "About", action = "DeleteAbout" });

            //About Us content details
            routes.MapRoute("ManageAboutContent", "manageaboutcontent/{aboutId}/", new { controller = "About", action = "ManageAboutContent" });
            routes.MapRoute("EditAboutContent", "editaboutcontent/{aboutDetailsId}/", new { controller = "About", action = "EditAboutContent" });
            routes.MapRoute("AddAboutContent", "addaboutcontent/{aboutId}/", new { controller = "About", action = "AddAboutContent" });
            routes.MapRoute("DeleteAboutContent", "deleteaboutcontent/{aboutDetailsId}/", new { controller = "About", action = "DeleteAboutContent" });


            //Pricing

            routes.MapRoute("ManagePricing", "managepricing/{domainId}/", new { controller = "Pricing", action = "ManagePricing" });
            routes.MapRoute("EditPricing", "editpricing/{pricingId}/", new { controller = "Pricing", action = "EditPricing" });
            routes.MapRoute("AddPricing", "addpricing/{domainId}/", new { controller = "Pricing", action = "AddPricing" });
            routes.MapRoute("DeletePricing", "deletepricing/{pricingId}/", new { controller = "Pricing", action = "DeletePricing" });


            //Pricing details
            routes.MapRoute("ManagePricingContent", "managepricingcontent/{pricingId}/", new { controller = "Pricing", action = "ManagePricingContent" });
            routes.MapRoute("EditPricingContent", "editpricingcontent/{pricingDetailsId}/", new { controller = "Pricing", action = "EditPricingContent" });
            routes.MapRoute("AddPricingContent", "addpricingcontent/{pricingId}/", new { controller = "Pricing", action = "AddPricingContent" });
            routes.MapRoute("DeletePricingContent", "deletepricingcontent/{pricingDetailsId}/", new { controller = "Pricing", action = "DeletePricingContent" });

            //Services Details

            routes.MapRoute("ManageService", "manageservice/{domainId}/", new { controller = "Services", action = "ManageService" });
            routes.MapRoute("EditService", "editservice/{serviceId}/", new { controller = "Services", action = "EditService" });
            routes.MapRoute("AddService", "addservice/{domainId}/", new { controller = "Services", action = "AddService" });
            routes.MapRoute("DeleteService", "deleteservice/{serviceId}/", new { controller = "Services", action = "DeleteService" });

            //Testimonial Details

            routes.MapRoute("ManageTestimonial", "managetestimonial/{domainId}/", new { controller = "Testimonial", action = "ManageTestimonial" });
            routes.MapRoute("EditTestimonial", "edittestimonial/{testimonialId}/", new { controller = "Testimonial", action = "EditTestimonial" });
            routes.MapRoute("AddTestimonial", "addtestimonial/{domainId}/", new { controller = "Testimonial", action = "AddTestimonial" });
            routes.MapRoute("DeleteTestimonial", "deletetestimonial/{testimonialId}/", new { controller = "Testimonial", action = "DeleteTestimonial" });


            //DataCenter

            routes.MapRoute("ManageDataCenter", "managedatacenter/{domainId}/", new { controller = "DataCenter", action = "ManageDataCenter" });
            routes.MapRoute("EditDataCenter", "editdatacenter/{datacenterId}/", new { controller = "DataCenter", action = "EditDataCenter" });
            routes.MapRoute("AddDataCenter", "adddatacenter/{domainId}/", new { controller = "DataCenter", action = "AddDataCenter" });
            routes.MapRoute("DeleteDataCenter", "deletedatacenter/{datacenterId}/", new { controller = "DataCenter", action = "DeleteDataCenter" });


            //DataCenter details
            routes.MapRoute("ManageDataCenterContent", "managedatacentercontent/{datacenterId}/", new { controller = "DataCenter", action = "ManageDataCenterContent" });
            routes.MapRoute("EditDataCenterContent", "editdatacentercontent/{dataDetailId}/", new { controller = "DataCenter", action = "EditDataCenterContent" });
            routes.MapRoute("AddDataCenterContent", "adddatacentercontent/{datacenterId}/", new { controller = "DataCenter", action = "AddDataCenterContent" });
            routes.MapRoute("DeleteDataCenterContent", "deletedatacentercontent/{dataDetailId}/", new { controller = "DataCenter", action = "DeleteDataCenterContent" });


            //Why We Details
            routes.MapRoute("ManageWhyWe", "managewhywe/{domainId}/", new { controller = "WhyWe", action = "ManageWhyWe" });
            routes.MapRoute("EditWhyWe", "editwhywe/{whyweId}/", new { controller = "WhyWe", action = "EditWhyWe" });
            routes.MapRoute("AddWhyWe", "addwhywe/{domainId}/", new { controller = "WhyWe", action = "AddWhyWe" });
            routes.MapRoute("DeleteWhyWe", "deletewhywe/{whyweId}/", new { controller = "WhyWe", action = "DeleteWhyWe" });

            //Customer Testimonial
            routes.MapRoute("ManageCustomerTestimonial", "managecustomer/{domainId}/", new { controller = "Testimonial", action = "ManageCustomerTestimonial" });
            routes.MapRoute("EditCustomerTestimonial", "editcustomer/{customerId}/", new { controller = "Testimonial", action = "EditCustomerTestimonial" });
            routes.MapRoute("AddCustomerTestimonial", "addcustomer/{domainId}/", new { controller = "Testimonial", action = "AddCustomerTestimonial" });
            routes.MapRoute("DeleteCustomerTestimonial", "deletecustomer/{customerId}/", new { controller = "Testimonial", action = "DeleteCustomerTestimonial" });


            //Backup Details
            routes.MapRoute("ManageBackup", "managebackup/{domainId}/", new { controller = "Backup", action = "ManageBackup" });
            routes.MapRoute("EditBackup", "editbackup/{backupId}/", new { controller = "Backup", action = "EditBackup" });
            routes.MapRoute("AddBackup", "addbackup/{domainId}/", new { controller = "Backup", action = "AddBackup" });
            routes.MapRoute("DeleteBackup", "deletebackup/{backupId}/", new { controller = "Backup", action = "DeleteBackup" });

            //Contact Details
            routes.MapRoute("ManageContact", "managecontact/{domainId}/", new { controller = "Contact", action = "ManageContact" });
            routes.MapRoute("EditContact", "editcontact/{contactId}/", new { controller = "Contact", action = "EditContact" });
            routes.MapRoute("AddContact", "addcontact/{domainId}/", new { controller = "Contact", action = "AddContact" });
            routes.MapRoute("DeleteContact", "deletecontact/{contactId}/", new { controller = "Contact", action = "DeleteContact" });


        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
        void Application_BeginRequest(Object Sender, EventArgs e)
        {
        }
        protected void Application_Error()
        {
        }
    }
}