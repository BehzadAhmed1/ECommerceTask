using ECommerceTask.Api.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceTask.Domain.Contracts
{
    public interface IOrderService
    {
        Task<int> CreateOrderAsync(OrderDto orderDto);
    }
}
