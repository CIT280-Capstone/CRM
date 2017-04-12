using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CIT280_Capstone.Models;

namespace CIT280_Capstone.DAL
{
    public interface IRepository
    {
        IEnumerable<Customer> SelectCustomers();
        Customer SelectCustomer(int customerID);
        void EditCustomer(Customer customer);
        void DeleteCustomer(Customer customer);

        IEnumerable<Order> SelectOrders();
        Order SelectOrder(int orderID);


        IEnumerable<Promotion> SelectPromotions();
        Promotion SelectPromotion(int promotionId);
        void EditPromotion(Promotion promotion);
        IList<Customer> SelectAll();
    }
}
