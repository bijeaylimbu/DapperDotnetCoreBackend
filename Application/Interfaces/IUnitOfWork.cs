namespace TaxSlabCalculator.Application.Interfaces;

public interface IUnitOfWork
{
    IPersonRepository PersonRepository { get; }
}