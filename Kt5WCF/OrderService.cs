using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Kt5WCF
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.

    public class OrderService : IOrderService
    {
        public List<OrderStatus> GetOrderStatuses()
        {
            // Пример данных
            return new List<OrderStatus>
        {
            new OrderStatus { Status = "Processing", Count = 5 },
            new OrderStatus { Status = "Shipped", Count = 10 },
            new OrderStatus { Status = "Delivered", Count = 15 }
        };
        }
    }

}
