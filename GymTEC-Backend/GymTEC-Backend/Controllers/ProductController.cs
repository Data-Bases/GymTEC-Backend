using GymTEC_Backend.Dtos;
using GymTEC_Backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Nest;
using System.ComponentModel.DataAnnotations;

namespace GymTEC_Backend.Controllers
{
    public class ProductController : ControllerBase
    {
        private readonly IGymTecRepository _gymTecRepository;

        public ProductController(IGymTecRepository gymTecRepository)
        {
            _gymTecRepository = gymTecRepository;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetProducts", Name = "GetProducts")]
        public ActionResult<IEnumerable<ProductNoDescriptionDto>> GetProducts()
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var payrolls = _gymTecRepository.GetProducts();


            if (payrolls.IsNullOrEmpty())
            {
                return NotFound();
            }

            return Ok(payrolls);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("CreateProduct", Name = "CreateProduct")]
        public ActionResult<Result> CreateProduct(ProductDto productDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _gymTecRepository.CreateProduct(productDto);

            if (result.Equals(Result.Error))
            {
                return NotFound();
            }

            if (result.Equals(Result.Noop))
            {
                return BadRequest();
            }

            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("DeleteProduct", Name = "DeleteProduct")]
        public ActionResult<Result> DeleteProduct([Required] int barcode)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _gymTecRepository.DeleteProduct(barcode);

            if (result.Equals(Result.Noop))
            {
                return BadRequest();
            }

            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [HttpGet("GetProductByBarcode/{barcode}", Name = "GetProductByBarcode")]
        public ActionResult<ProductNoBarcodeDto> GetProductByBarcode([Required] int barcode)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = _gymTecRepository.GetProductByBarcode(barcode);


            if (string.IsNullOrEmpty(product.Name))
            {
                return NotFound();
            }

            return Ok(product);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("UpdateDescriptionProduct", Name = "UpdateDescriptionProduct")]
        public ActionResult<Result> UpdateDescriptionProduct([Required] int barcode, [Required] string newDescription)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _gymTecRepository.UpdateDescriptionProduct(barcode, newDescription);

            if (result.Equals(Result.Noop))
            {
                return NotFound();
            }

            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("UpdateCostProduct", Name = "UpdateCostProduct")]
        public ActionResult<Result> UpdateCostProduct([Required] int barcode, [Required] int newCost)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _gymTecRepository.UpdateCostProduct(barcode, newCost);

            if (result.Equals(Result.Noop))
            {
                return NotFound();
            }

            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("UpdateNameProduct", Name = "UpdateNameProduct")]
        public ActionResult<Result> UpdateNameProduct([Required] int barcode, [Required] string newName)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _gymTecRepository.UpdateNameProduct(barcode, newName);

            if (result.Equals(Result.Noop))
            {
                return NotFound();
            }

            return Ok();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("AddProductToBranch", Name = "AddProductToBranch")]
        public ActionResult<Result> AddProductToBranch(int productBarcode, string branchName)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _gymTecRepository.AddProductToBranch(productBarcode, branchName);

            if (result.Equals(Result.Error))
            {
                return NotFound();
            }

            if (result.Equals(Result.Noop))
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
