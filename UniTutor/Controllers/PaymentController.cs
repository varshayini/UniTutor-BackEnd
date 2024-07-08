using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Stripe;
using Stripe.Checkout;

namespace UniTutor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly string _domain = "http://localhost:3000"; // Replace with your frontend URL
        private readonly SessionService _sessionService;

        // Mapping of product names/IDs to Stripe Price IDs
        private readonly Dictionary<string, string> _productPriceMapping = new Dictionary<string, string>
        {
            { "50Coins", "price_1PZdLhRpFIOqSDU7mcvKWMBn" }, // Replace with actual Price IDs
            { "100Coins", "price_1PZppFRpFIOqSDU78HHthSvI" },
            { "150Coins", "price_1PZpq0RpFIOqSDU7ps46AJvo" }
        };

        public PaymentController()
        {
            StripeConfiguration.ApiKey = "sk_test_51PZdGJRpFIOqSDU7gn8nZf5YToro00t6r6LSwVs4IdoHTITRWzbfXCEgpaPKTMoULOemJihLmebyF3novKc6OsKN00aL1cC7YM"; // Replace with your Stripe Secret Key
            _sessionService = new SessionService();
        }

        [HttpPost("create-checkout-session")]
        public ActionResult CreateCheckoutSession([FromBody] SingleProductItem product)
        {
            // Log the received data
            Console.WriteLine($"Received data: {JsonConvert.SerializeObject(product)}");

            if (!_productPriceMapping.TryGetValue(product.coins, out var priceId))
            {
                return BadRequest(new { error = $"Product {product.coins} does not exist." });
            }

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
        {
            new SessionLineItemOptions
            {
                Price = priceId,
                Quantity = 1 // Ensure you set the quantity as needed
            },
        },
                Mode = "payment",
                SuccessUrl = "http://localhost:3000/return?session_id={{CHECKOUT_SESSION_ID}}",
                CancelUrl = "http://localhost:3000/return?session_id={{CHECKOUT_SESSION_ID}}", // Adjust as needed
            };

            try
            {
                Session session = _sessionService.Create(options);
                return Ok(new { clientSecret = session.ClientSecret });
            }
            catch (StripeException e)
            {
                return BadRequest(new { error = $"Stripe Error: {e.Message}" });
            }
        }

        [HttpGet("session-status")]
        public ActionResult GetSessionStatus([FromQuery] string session_id)
        {
            Session session = _sessionService.Get(session_id);
            return Ok(new { status = session.PaymentStatus, customer_email = session.CustomerDetails?.Email });
        }

        public class SingleProductItem
        {
            public string coins { get; set; } // Simple identifier for the product
        }
    }
}
