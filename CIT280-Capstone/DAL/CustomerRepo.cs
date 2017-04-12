using CIT280_Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIT280_Capstone.DAL
{
    public class CustomerRepo
    {
        private List<Customer> _customers;

        public Customer SelectOne(int id)
        {
            //Brewery selectedBrewery =
            //(from brewery in _breweries
            // where brewery.Id == id
            // select brewery).FirstOrDefault();

            Customer selectedBrewery = _customers.Where(p => p.ID == id).FirstOrDefault();

            return selectedBrewery;
        }
        public CustomerRepo()
        {
            CustomerRepo Customers = new CustomerRepo();

            using (CustomerRepo)
            {
                _customers = Customers.Read() as List<Customer>;
            }
        }

        private List<Customer> Read()
        {
            throw new NotImplementedException();
        }
    }