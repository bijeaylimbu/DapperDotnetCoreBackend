namespace TaxSlabCalculator.Application.Interfaces;

public interface IUnitOfWork
{
    ITaxRepository PersonRepository { get; }
}