using System.Net;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CatalogService.Service.Authorization;

[AttributeUsage(AttributeTargets.Class)]
public class CustomAuthorization : Attribute, IAuthorizationFilter
{
    /// <summary>  
    /// This will Authorize User  
    /// </summary>  
    /// <returns></returns>  
    public void OnAuthorization(AuthorizationFilterContext filterContext)
    {

        if (filterContext != null)
        {
            Microsoft.Extensions.Primitives.StringValues authTokens;
            filterContext.HttpContext.Request.Headers.TryGetValue("Authorization", out authTokens);

            var _token = authTokens.FirstOrDefault();

            if (_token != null)
            {
                string authToken = _token;
                if (authToken != null)
                {
                    if (IsValidToken(authToken))
                    {
                        // filterContext.HttpContext.Response.Headers.Add("authToken", authToken);
                        filterContext.HttpContext.Response.Headers.Add("AuthStatus", "Authorized");

                        filterContext.HttpContext.Response.Headers.Add("storeAccessiblity", "Authorized");

                        return;
                    }
                    else
                    {
                        // filterContext.HttpContext.Response.Headers.Add("authToken", authToken);
                        filterContext.HttpContext.Response.Headers.Add("AuthStatus", "NotAuthorized");

                        filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                        filterContext.HttpContext.Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "Not Authorized";
                        filterContext.Result = new JsonResult("NotAuthorized")
                        {
                            Value = new
                            {
                                Status = "Error",
                                Message = "Invalid Token"
                            },
                        };
                    }

                }

            }
            else
            {
                filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.ExpectationFailed;
                filterContext.HttpContext.Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "Please Provide Bearer Token";
                filterContext.Result = new JsonResult("Please Provide Bearer Token")
                {
                    Value = new
                    {
                        Status = "Error",
                        Message = "Please Provide Bearer Token"
                    },
                };
            }
        }
    }

    public bool IsValidToken(string bearerToken)
    {
        //TODO validate Token here  
        return true;
    }

}