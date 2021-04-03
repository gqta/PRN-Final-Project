using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PRN_Final_Project
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Search",
                url: "quiz/search",
                defaults: new { controller = "Quiz", action = "Search", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Course",
                url: "quiz/course",
                defaults: new { controller = "Quiz", action = "Course", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "TestQuiz",
                url: "quiz/test/{id}",
                defaults: new { controller = "Quiz", action = "Test", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Learn quiz",
                url: "quiz/learn/{id}",
                defaults: new { controller = "Quiz", action = "Learn", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "AddQuiz",
                 url: "quiz/add",
                 defaults: new { controller = "Quiz", action = "Add", id = UrlParameter.Optional }
             );
            routes.MapRoute(
                name: "ViewCourse",
                url: "quiz/detail",
                defaults: new { controller = "Quiz", action = "ViewCourse", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "EditCourse",
                url: "quiz/edit",
                defaults: new { controller = "Quiz", action = "EditCourse", id = UrlParameter.Optional }

           );


            routes.MapRoute(
              name: "Forget Password",
              url: "user/forgotpassword",
              defaults: new { controller = "User", action = "ForgotPassword" }
          );
            routes.MapRoute(
                name: "Login",
                url: "login",
                defaults: new { controller = "User", action = "Login" }
            );
            routes.MapRoute(
                name: "Logout",
                url: "logout",
                defaults: new { controller = "User", action = "Logout" }
            );
            routes.MapRoute(
                name: "ForgotPassword",
                url: "forgotpassword",
                defaults: new { controller = "User", action = "ForgotPassword" }
            );
            routes.MapRoute(
              name: "ChangePassword",
              url: "changepassword",
              defaults: new { controller = "User", action = "ChangePass" }
          );

            routes.MapRoute(
                name: "Register",
                url: "register",
                defaults: new { controller = "User", action = "Register" }
            );
            routes.MapRoute(

                name: "ActivationMail",
                url: "activation",
                defaults: new { controller = "User", action = "ActivationMail" }
                );

            //                 

            routes.MapRoute(
               name: "DeleteQuiz",
               url: "quiz/delete",
               defaults: new { controller = "Quiz", action = "DeleteQuiz", id = UrlParameter.Optional }
           );



            routes.MapRoute(
                name: "Error Page",
                url: "error/404",
                defaults: new { controller = "Error", action = "NotFound", id = UrlParameter.Optional }
            );

        }
    }
}
