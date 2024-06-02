using Console_NetCore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_NetCore.IServices
{
    public interface IOrderServices
    {
        Task<OrderReturnData> Order_Create(OrdersCreateRequestData requestData);
    }
}
