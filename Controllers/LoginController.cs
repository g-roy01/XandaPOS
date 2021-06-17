using System;
using System.Web.Mvc;
using XandaPOS.Business;


namespace XandaPOS.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        //[HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginMain()
        {
            return View();
        }

        //[ValidateAntiForgeryToken]
        //public ActionResult Index(string loginId, string loginPass)
        //{
        //    try
        //    {
        //        LoginBL _loginBl = new LoginBL();
        //        var _verificationResult = _loginBl.LoginVerifier(loginId, loginPass);

        //        if (!_verificationResult)
        //        {
        //            throw new Exception("Verification Failed For The Credentials, Please Check The Credentials");
        //        }
        //        return Json(new { Result = "Redirect", Url = Url.Action("Index", "Dashboard"), Message = "Successfully Logged In" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Result = "Failed", Url = Url.Action("Index", "Dashboard"), Message = ex.Message.ToString() });
        //    }
        //}


        //[ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult LoginVerification(string loginId, string loginPass)
        {
            try
            {
                LoginBL _loginBl = new LoginBL();
                var _verificationResult = _loginBl.LoginVerifier(loginId, loginPass);

                if (!_verificationResult)
                {
                    throw new Exception("Verification Failed For The Credentials, Please Check The Credentials");
                }
                return Json(new { Result = "Redirect", Url = Url.Action("Index", "Dashboard"), Message = "Successfully Logged In" });
            }
            catch(Exception ex)
            {
                return Json(new { Result = "Failed", Url = Url.Action("Index", "Dashboard"), Message = ex.Message.ToString() }) ;
            }
        }
    }
}