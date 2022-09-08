using Grpc.Net.Client;
using System.Threading.Channels;
using static EmployeeServiceProto.DictionariesService;
using static DepartmentServiceProto.DepartmentService;

namespace EmployeeClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            DepartmentServiceClient clientDepartment = new DepartmentServiceClient(channel);
            selectAction(channel);

        }

        static void selectAction(GrpcChannel channel)
        {
            Console.Clear();
            Console.WriteLine("Введите номер выбранного типа действия: ");
            Console.WriteLine("1. Добавить тип сотрудника. ");
            Console.WriteLine("2. Какая-то работа с департаментом. ");
            Console.WriteLine("3. Выйти. ");
            string inputNumber = Console.ReadLine();
            switch (inputNumber) 
            {
                case "1":
                    DictionariesServiceClientDemonstration dictionariesServiceClientDemonstration = new DictionariesServiceClientDemonstration(new DictionariesServiceClient(channel));
                    dictionariesServiceClientDemonstration.AddEmployeeType();
                    break;
                case "2":
                    DepartmentServiceClient clientDepartment = new DepartmentServiceClient(channel);
                    DepartmentServiceClientDemonstartion departmentServiceClientDemonstartion = new DepartmentServiceClientDemonstartion(clientDepartment);
                    departmentServiceClientDemonstartion.SelecActionDepartment();
                    break;
                    case"3":
                    return;
                default:
                    Console.WriteLine("Выбранного действия не существует");
                    break;

            }
            selectAction(channel);
        }
    }
}