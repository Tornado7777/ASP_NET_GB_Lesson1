using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EmployeeServiceProto.DictionariesService;

namespace EmployeeClient
{
    internal class DictionariesServiceClientDemonstration
    {
        DictionariesServiceClient _client;

        public DictionariesServiceClientDemonstration(DictionariesServiceClient client)
        {
            _client = client;
        }

        public void AddEmployeeType()

        {
            Console.Write("Укажите тип сотрудника: ");

            var response = _client.CreateEmployeeType(new EmployeeServiceProto.CreateEmployeeTypeRequest
            {
                Description = Console.ReadLine()
            });

            if (response != null)
            {
                Console.WriteLine($"Тип сотрудника успешно добавлен: #{response.Id}");
            }

            var getAllEmployeeTypesResponse = _client.GetAllEmployeeTypes(new EmployeeServiceProto.GetAllEmployeeTypesRequest());
            foreach (var employeeType in getAllEmployeeTypesResponse.EmployeeTypes)
            {
                Console.WriteLine($"#{employeeType.Id} / {employeeType.Description}");
            }

            Console.ReadKey(true);
        }
       
    }
}
