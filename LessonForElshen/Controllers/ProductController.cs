using Microsoft.AspNetCore.Mvc;

namespace LessonForElshen.Controllers
{
    public class ProductController: BaseController
    {

        [Produces("application/json")]
        [HttpGet("test")]
        public string Test()
           
        {

            return "Texst";

        }
    }
}
