using System;
using System.Net.Sockets;
using System.Text.Json;
using Person;
using System.Text;

namespace BankClient
{
    class BankClient
    {
        public BankClient()
        {
            client = new TcpClient();
            CreatePerson();
            try
            {
                client.Connect(localAddr, port);
                CreateRequest();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void CreateRequest()
        {
            NetworkStream stream = client.GetStream();
            Byte[] buffer = new Byte[3072];

            var options = new JsonSerializerOptions { WriteIndented = true };

            for(int i = 0; i < persons.Count; i++)
            {
                string json = JsonSerializer.Serialize(persons[i], options);
                buffer = Encoding.UTF8.GetBytes(json);
            }
        }

        //Создание пользователя/пользователей
        private void CreatePerson()
        {
            bool access = false;
            bool continueCreatePerson = true;
            string firstName = "";
            string secondName = "";
            int age;
            double wallet = 0;

            string answer = "";
            while(continueCreatePerson)
            {
                Console.WriteLine("Создание обычного пользователя. Если вы VIP клиент, то введите пароль.");
                Console.WriteLine("У вас есть пароль для VIP клиента?(Да|Нет)");
                answer = Console.ReadLine();

                if (answer.ToLower() == "да")
                {
                    while (access)
                    {
                        Console.Write("Пароль: ");
                        answer = Console.ReadLine();

                        //Создание VIP клиента
                        if (answer == "DrugVip")
                        {
                            access = true;

                            Console.WriteLine("Введите имя пользователя: ");
                            firstName = Console.ReadLine();
                            Console.WriteLine("Введите фамилию пользователя: ");
                            secondName = Console.ReadLine();
                            Console.WriteLine("Введите сколько лет пользователю: ");
                            age = int.Parse(Console.ReadLine());

                            VIPClient vipClient = new VIPClient(firstName, secondName, age);
                            persons.Add(vipClient);

                            Console.WriteLine("Создание еще одного пользователя?(Да|Нет)");
                            answer = Console.ReadLine();

                            if(answer.ToLower() == "да")
                            {
                                continue;
                            }
                            else if(answer.ToLower() == "нет")
                            {
                                continueCreatePerson = false;
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Не понимать! Продолжаем создавать пользователей");
                                continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Пароль неверен");
                            Console.WriteLine("Хотите повторить?(Да|Нет)");
                            answer = Console.ReadLine();

                            if (answer.ToLower() == "да")
                            {
                                continue;
                            }
                            else if (answer.ToLower() == "нет")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Не понимать! Продолжим создание обычного пользователя");
                                break;
                            }
                        }
                    }
                }
                //Создание обычного клиента
                else if (answer.ToLower() == "нет")
                {
                    Console.WriteLine("Введите имя пользователя: ");
                    firstName = Console.ReadLine();
                    Console.WriteLine("Введите фамилию пользователя: ");
                    secondName = Console.ReadLine();
                    Console.WriteLine("Введите сколько лет пользователю: ");
                    age = int.Parse(Console.ReadLine());
                    Console.WriteLine("Введите баланс кошелька пользователя: ");
                    wallet = double.Parse(Console.ReadLine());

                    Client client = new Client(firstName, secondName, age, wallet);
                    persons.Add(client);

                    Console.WriteLine("Создание еще одного пользователя?(Да|Нет)");
                    answer = Console.ReadLine();

                    if (answer.ToLower() == "да")
                    {
                        continue;
                    }
                    else if (answer.ToLower() == "нет")
                    {
                        continueCreatePerson = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Не понимать! Продолжаем создавать пользователей");
                        continue;
                    }
                }
            }
        }
            

        private string localAddr = "127.0.0.1";
        private int port = 8888;
        private TcpClient client;
        private bool newRequest = true;
        private List<Person.Person> persons = new List<Person.Person>();
    }
}
