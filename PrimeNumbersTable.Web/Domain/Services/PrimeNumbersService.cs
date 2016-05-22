using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PrimeNumbersTable.Web.Domain.Repositories;

namespace PrimeNumbersTable.Web.Domain.Services
{
    public interface IPrimeNumbersService
    {
        int[] GetListOfPrimeNumbers(int totalOfPrimeNumbers);
    }

    public class PrimeNumbersService
    {
        private IPrimeNumbersRepository _repository;

        public PrimeNumbersService(IPrimeNumbersRepository repository)
        {
            this._repository = repository;
        }

        public int[] GetListOfPrimeNumbers(int totalOfPrimeNumbers)
        {
            return this._repository.GetListOfPrimeNumbers(totalOfPrimeNumbers);
        }
    }
}