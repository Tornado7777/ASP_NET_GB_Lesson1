using static DepartmentServiceProto.DepartmentService;

namespace EmployeeClient
{
    internal class DepartmentServiceClientDemonstartion
    {
        DepartmentServiceClient _client;

        public DepartmentServiceClientDemonstartion(DepartmentServiceClient client)
        {
            _client = client;
        }

        public void SelecActionDepartment()
        {
            string description;
            int id;
            Console.Clear();
            Console.WriteLine("Введите номер выбранного действия: ");
            Console.WriteLine("1. Добавить депртамент. ");
            Console.WriteLine("2. Получить информацию о всех департаментах. ");
            Console.WriteLine("3. Получить информацию о департаменте c указанным Id. ");
            Console.WriteLine("4. Изменить информацию о департаменте с указанным Id. ");
            Console.WriteLine("5. Удалить департамент с указанным Id. ");
            Console.WriteLine("6. Выйти из действий с департаментами. ");
            string inputNumber = Console.ReadLine();
            switch (inputNumber)
            {
                case "1":
                    Console.WriteLine("Введите название департамента: ");
                    description = Console.ReadLine();
                    AddDepartment(description);
                    break;
                case "2":
                    GetAllDepartment();
                    break;
                case "3":
                    Console.WriteLine("Введите номер id департамента: ");
                    int.TryParse(Console.ReadLine(),out id);
                    GetByIdDepartment(id);
                    break;
                case "4":
                    Console.WriteLine("Введите название департамента: ");
                    description = Console.ReadLine();
                    Console.WriteLine("Введите номер id департамента: ");
                    int.TryParse(Console.ReadLine(), out id);
                    UpdateDepartment(description, id);
                    break;
                case "5":
                    Console.WriteLine("Введите номер id департамента: ");
                    int.TryParse(Console.ReadLine(), out id);
                    DeleteDepartment(id);
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Такое действие не определно ");
                    break;

            }
            SelecActionDepartment();
        }

        private void AddDepartment(string description)
        {
            var request = new DepartmentServiceProto.CreateDepartmentRequest();
            request.Description = description;
            var response = _client.CreateDepartment(request);
                
            if (response != null)
            {
                Console.WriteLine($"Депртамент успешно добавлен: #{response.Id}");
            }
            GetAllDepartment();


        }
        private void GetAllDepartment()
        {
            var getAllDepartmentResponse = _client.GetAllDepartments(new DepartmentServiceProto.GetAllDepartmentsRequest());
            foreach (var Department in getAllDepartmentResponse.Departments)
            {
                Console.WriteLine($"#{Department.Id} / {Department.Description}");
            }
            Console.ReadKey(true);
        }
        private void GetByIdDepartment(int id)
        {
            var request = new DepartmentServiceProto.GetByIdDepartmentRequest();
            request.Id = id;
            var response = _client.GetByIdDepartment(request);

            if (response != null)
            {
                Console.WriteLine($"Департамент: #{response.Id} / {response.Description}");
            }
            Console.ReadKey(true);
        }

        private void UpdateDepartment(string description, int id)
        {
            var request = new DepartmentServiceProto.UpdateDepartmentRequest();
            request.Description = description;
            request.Id = id;
            var response = _client.UpdateDepartment(request);

            if (response != null)
            {
                Console.WriteLine($"Депртамент успешно изменен: #{request.Id}");
            }
            GetAllDepartment();
        }

        private void DeleteDepartment(int id)
        {
            var request = new DepartmentServiceProto.DeleteDepartmentRequest();
            request.Id = id;
            var response = _client.DeleteDepartment(request);

            if (response != null)
            {
                Console.WriteLine($"Депртамент успешно удален: #{request.Id}");
            }
            GetAllDepartment();
        }
    }
}
