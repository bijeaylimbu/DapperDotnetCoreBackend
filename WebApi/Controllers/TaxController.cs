using Microsoft.AspNetCore.Mvc;
using TaxSlabCalculator.Application.Interfaces;
using TaxSlabCalculator.Application.Requests;

namespace TaxSlabCalculator.Controllers;
[Route("api")]
[ApiController]
public class TaxController: ControllerBase
{
    private readonly IPersonRepository _repository;

    public TaxController(IPersonRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    [HttpPost("createPerson")]
    public async Task<IActionResult> CreatePerson(CreatePersonRequest createPerson)
    {
        try
        {
            var createdPerson = await _repository.CreatePerson( createPerson);
            return Ok(createdPerson);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPost("payableItem")]
    public async Task<IActionResult> CreatePayableItem(CreatePayableItemRequest request, int PersonId)
    {
        try
        {
            var createdPayable = await _repository.CreatePayableItem(request, PersonId);
            return Ok(createdPayable);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpPost("deductingItem")]
    public async Task<IActionResult> CreateDeductingItem(CreateDeductingItemRequest request, int PersonId)
    {
        try
        {
            var deductingItem = await _repository.CreateDeductionItem(request, PersonId);
            return Ok(deductingItem);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    [HttpGet("allPersonName")]
    public async Task<IActionResult> GetAllPersonName()
    {
        try
        {
            var personName = await _repository.GetAllPersonName();
            return Ok(personName);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("allDeductingItem/{id}")]
    public async Task<IActionResult> GetAllDeductingItem(int id)
    {
        try
        {
            var deductingItem = await _repository.GetAllDeductionItem(id);
            return Ok(deductingItem);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    [HttpGet("allPayableItem/{id}")]
    public async Task<IActionResult> GetAllPayableItem(int id)
    {
        try
        {
            var payableItem = await _repository.GetAllPayableItem(id);
            return Ok(payableItem);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("getPayableIteemById/{id}")]
    public async Task<IActionResult> GetPayableItemById(int id)
    {
        try
        {
            var payableItem = await _repository.GetPayableItemById(id);
            return Ok(payableItem);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpPut("updatePayableItemById/{id}")]
    public async Task<IActionResult> UpdatePayableItem(UpdatePayableItemRequest request, int id)
    {
        try
        {
            var dbPayableItem = await _repository.GetPayableItemById(id);
            if (dbPayableItem == null)
                return NotFound();
            await _repository.UpdatePayableItem(request, id);
            return NoContent();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    [HttpPut("updateDeductingItemById/{id}")]
    public async Task<IActionResult> UpdateDeductingItem(UpdateDeductingItemRequest request, int id)
    {
        try
        {
            var dbDeductingItem = await _repository.GetDeductingItemById(id);
            if (dbDeductingItem == null)
                return NotFound();
            await _repository.UpdateDeductionItem(request, id);
            return NoContent();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpDelete("deletePayableItemById/{id}")]
    public async Task<IActionResult> DeletePayableItemById(int id)
    {
        try
        {
            var dbPayableItem = await _repository.GetPayableItemById(id);
            if(dbPayableItem==null)
                return NotFound();
            await _repository.DeletePayableItemById(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    [HttpDelete("deleteDeductingItemById/{id}")]
    public async Task<IActionResult> DeleteDeductingItemById(int id)
    {
        try
        {
            var dbDeductingItem = await _repository.GetDeductingItemById(id);
            if(dbDeductingItem==null)
                return NotFound();
            await _repository.DeleteDeductingItemById(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
 
}