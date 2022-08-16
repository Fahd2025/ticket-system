using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private IMapper _mapper;   
        protected IMapper Mapper => _mapper ??= HttpContext.RequestServices.GetService<IMapper>();

        private IConfiguration _configuration;
        protected IConfiguration Configuration => _configuration ??= HttpContext.RequestServices.GetService<IConfiguration>();
        
        private ILogger<BaseApiController> _logger;
        protected ILogger<BaseApiController> Logger => _logger ??= HttpContext.RequestServices.GetService<ILogger<BaseApiController>>();
    }
}