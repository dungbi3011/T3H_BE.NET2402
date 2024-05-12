using Buoi13_BTVN.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi13_BTVN.IServices
{
    public interface ICustomerServices
    {
        Task GetCustomers();
        Task<int> Customer_Insert();
        Task<Customers> Customer_Find(string ten);
        Task Customer_Delete();
        Task Customer_Update();
    }
}
