using System;

namespace Person
{
    class Person
    {
        public string firstName = "";
        public string secondName = "";
        public int age;

        private double money = 0;

        protected Person(string firstName, string secondName, int age, double money = 10000)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.age = age;
            this.money = money;
        }

        public virtual double[] CreateContribut()
        {
            int numberContributs = 0;

            Console.WriteLine("Меню создания вклада");
            Console.Write("Введите количество вкладов: ");
            numberContributs = int.Parse(Console.ReadLine());

            while (numberContributs <= 0)
            {
                Console.WriteLine($"Введеное количество равно {numberContributs}\nЭто не допустимо! Введите новое количество вкладов превыщающий нуля");
                numberContributs = int.Parse(Console.ReadLine());
            }

            double[] contributs = new double[numberContributs];

            Console.WriteLine($"Кошелек: {money}");
            if (money == 0)
            {
                Console.WriteLine("У вас недостаточно денег чтобы сделать вклад");
            }
            else
            {
                for (int i = 0; i < numberContributs; i++)
                {
                    Console.Write($"Введите количество денег для {i + 1}: ");
                    double contribut = double.Parse(Console.ReadLine());
                    double balance = money -= contribut;
                    if (balance < 0)
                    {
                        while (balance < 0)
                        {
                            balance = 0;
                            Console.WriteLine($"Невозможно выполнить, так как у вас {money} денег");
                            Console.Write($"Введите количество денег для {i + 1}: ");
                            contribut = double.Parse(Console.ReadLine());
                            balance = money -= contribut;
                        }
                    }
                    else if (balance == 0)
                    {
                        money -= contribut;
                        contributs[i] = contribut;
                        Console.WriteLine($"Кошелек: {money}");
                        Console.WriteLine("Закончились деньги, производится выход...");
                        break;
                    }

                    money -= contribut;
                    contributs[i] = contribut;
                }
            }

            return contributs;
        }
    }

    class Client : Person
    {
        public Client(string firstName, string secondName, int age, double money = 10000) : base(firstName, secondName, age, money)
        {}

        ~Client() 
        {
            Console.WriteLine($"Персонаж с именем {firstName} и фамилием {secondName}, стёрт");
        }
    }

    class VIPClient : Person
    {
        public VIPClient(string firstName, string secondName, int age) : base(firstName, secondName, age, 1000000000)
        { }

        public override double[] CreateContribut()
        {
            int numberContributs = 0;

            Console.WriteLine("Вы VIP клиент, на вклады у вас бесконечное количество денег");

            Console.WriteLine("Меню создания вклада");
            Console.Write("Введите количество вкладов: ");
            numberContributs = int.Parse(Console.ReadLine());

            while (numberContributs <= 0)
            {
                Console.WriteLine($"Введеное количество равно {numberContributs}\nЭто не допустимо! Введите новое количество вкладов превыщающий нуля");
                numberContributs = int.Parse(Console.ReadLine());
            }

            double[] contributs = new double[numberContributs];

            for (int i = 0; i < numberContributs; i++)
            {
                Console.Write($"Введите количество денег для {i + 1}: ");
                double contribut = double.Parse(Console.ReadLine());

                contributs[i] = contribut;
            }

            return contributs;
        }
    }
}
