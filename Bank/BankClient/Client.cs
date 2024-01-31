//namespace Person
//{
//    public class Person
//    {
//        public string firstName = "";
//        public string secondName = "";
//        public int age;
//        public string status = "";

//        private double wallet = 0;

//        protected Person(string firstName, string secondName, int age, double wallet = 10000)
//        {
//            this.firstName = firstName;
//            this.secondName = secondName;
//            this.age = age;
//            this.wallet = wallet;
//        }

//        public double Wallet
//        {
//            get { return wallet; }
//            set { wallet = value; }
//        }

//        public void WithdrawDeposit()
//        {
//            Bank.Bank bank = new Bank.Bank(this);
//            bank.WithdrawDeposit();
//        }

//        public virtual void ActionsWithWallet()
//        { }

//        public virtual double[] CreateContribut()
//        {
//            int numberContributs = 0;

//            Console.WriteLine("Меню создания вклада");
//            Console.Write("Введите количество вкладов: ");
//            numberContributs = int.Parse(Console.ReadLine());

//            while (numberContributs <= 0)
//            {
//                Console.WriteLine($"Введеное количество равно {numberContributs}\nЭто не допустимо! Введите новое количество вкладов превыщающий нуля");
//                numberContributs = int.Parse(Console.ReadLine());
//            }

//            double[] contributs = new double[numberContributs];

//            Console.WriteLine($"Кошелек: {wallet}");
//            if (wallet == 0)
//            {
//                Console.WriteLine("У вас недостаточно денег чтобы сделать вклад");
//            }
//            else
//            {
//                for (int i = 0; i < numberContributs; i++)
//                {
//                    Console.Write($"Введите количество денег для {i + 1}: ");
//                    double contribut = double.Parse(Console.ReadLine());
//                    double balance = wallet -= contribut;
//                    if (balance < 0)
//                    {
//                        while (balance < 0)
//                        {
//                            balance = 0;
//                            Console.WriteLine($"Невозможно выполнить, так как у вас {wallet} денег");
//                            Console.Write($"Введите количество денег для {i + 1}: ");
//                            contribut = double.Parse(Console.ReadLine());
//                            balance = wallet -= contribut;
//                        }
//                    }
//                    else if (balance == 0)
//                    {
//                        wallet -= contribut;
//                        contributs[i] = contribut;
//                        Console.WriteLine($"Кошелек: {wallet}");
//                        Console.WriteLine("Закончились деньги, производится выход...");
//                        break;
//                    }

//                    wallet -= contribut;
//                    contributs[i] = contribut;
//                }
//            }

//            return contributs;
//        }
//    }

//    class Client : Person
//    {
        

//        public Client(string firstName, string secondName, int age, double wallet = 10000) : base(firstName, secondName, age, wallet)
//        {
//            status = "usual";
//        }

//        ~Client() 
//        {
//            Console.WriteLine($"Персонаж с именем {firstName} и фамилием {secondName}, стёрт");
//        }

//        public override void ActionsWithWallet()
//        {
//            Console.WriteLine("Переход к банкомату...");
//            CashMachine.CashMachine cashMachine = new CashMachine.CashMachine(this);
//            cashMachine.MenuCashMachine();
//        }
//    }

//    class VIPClient : Person
//    {
//        public VIPClient(string firstName, string secondName, int age) : base(firstName, secondName, age, 00000000)
//        {
//            status = "vip";
//        }

//        public override void ActionsWithWallet()
//        {
//            Console.WriteLine("Переход к банкомату...");
//            CashMachine.CashMachine cashMachine = new CashMachine.CashMachine(this);
//            cashMachine.MenuCashMachine();
//        } 

//        public override double[] CreateContribut()
//        {
//            int numberContributs = 0;

//            Console.WriteLine("Вы VIP клиент, на вклады у вас бесконечное количество денег");

//            Console.WriteLine("Меню создания вклада");
//            Console.Write("Введите количество вкладов: ");
//            numberContributs = int.Parse(Console.ReadLine());

//            while (numberContributs <= 0)
//            {
//                Console.WriteLine($"Введеное количество равно {numberContributs}\nЭто не допустимо! Введите новое количество вкладов превыщающий нуля");
//                numberContributs = int.Parse(Console.ReadLine());
//            }

//            double[] contributs = new double[numberContributs];

//            for (int i = 0; i < numberContributs; i++)
//            {
//                Console.Write($"Введите количество денег для {i + 1}: ");
//                double contribut = double.Parse(Console.ReadLine());

//                contributs[i] = contribut;
//            }

//            return contributs;
//        }
//    }
//}
