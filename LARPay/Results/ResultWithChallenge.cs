using Microsoft.AspNetCore.Mvc;

namespace dk.lashout.LARPay.Web.Results
{
    public class UnauthorizedWithChallengeResult: UnauthorizedResult
    {
        private readonly string _wwwAuthenticate;

        public UnauthorizedWithChallengeResult(string wwwAuthenticate)
        {
            _wwwAuthenticate = wwwAuthenticate;
        }

        public override void ExecuteResult(ActionContext context)
        {
            base.ExecuteResult(context);
            context.HttpContext.Response.Headers.Add("WWW-Authenticate", _wwwAuthenticate);
        }

    }
}
