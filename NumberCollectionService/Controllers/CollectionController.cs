namespace NumberCollectionService.Controllers
{
    [ApiController]
    [Route("")]
    public class CollectionController : ControllerBase
    {
        private readonly ILogger<CollectionController> _logger;
        private readonly NumberRegistrationService _numberRegistrationService;

        public CollectionController(ILogger<CollectionController> logger,
            NumberRegistrationService numberRegistrationService)
        {
            _numberRegistrationService = numberRegistrationService;
            _logger = logger;
        }

        [HttpPost("collect")]
        public async ValueTask<ActionResult> CollectNumber()
        {
            try
            {
                var number = await _numberRegistrationService.GetNumber();

                _logger.LogInformation($"Collect number: {number}");

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while processing CollectNumber");
                return StatusCode(500);
            }
        }

    }
}
