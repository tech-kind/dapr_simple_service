namespace CounterService.Controllers
{
    [ApiController]
    [Route("")]
    public class NumberController : ControllerBase
    {
        private readonly ILogger<NumberController> _logger;
        private readonly INumberRepository _numberRepository;

        public NumberController(ILogger<NumberController> logger, INumberRepository numberRepository)
        {
            _logger = logger;
            _numberRepository = numberRepository;
        }

        [HttpGet("number")]
        public ActionResult<int> GetNumber()
        {
            int number = _numberRepository.GetNumber();
            _logger.LogInformation($"Get number: {number}");
            return number;
        }
    }
}
