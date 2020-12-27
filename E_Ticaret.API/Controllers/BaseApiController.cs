using E_Ticaret.Common.Client.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace E_Ticaret.API.Controllers
{
    [Authorize]
    [ApiController]
    public abstract class BaseApiController<T> : ControllerBase where T : BaseApiController<T>
    {
        private IWorkContext _workContext;
        public BaseApiController()
        {

        }

        public IWorkContext WorkContext
        {
            get
            {
                if (_workContext == null)
                {
                    _workContext = HttpContext.RequestServices.GetService<IWorkContext>();                     
                }
                return _workContext;
            }
        }
    }
}
