using System.Threading;

namespace CashMachine
{
    public class CashMachine
    {
        private Person.Person person;

        public CashMachine(Person.Person person) 
        {
            this.person = person;
        }

        ~CashMachine() { }

        public void MenuCashMachine()
        {
            Console.WriteLine();
            Console.WriteLine("Подключение к банкомату...");
            Thread.Sleep(1500);

            if(person.status == "usual")
            {
                Console.WriteLine("Выберите действие");
                Console.WriteLine("1. Пополнить кошелек");
                Console.WriteLine("2. Показать счет кошелька");
                Console.WriteLine("0. Показать счет кошелька");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CashMachineUpWallet();
                        break;

                    case 2:
                        WithdrawalWallet();
                        break;

                    case 0:
                        Console.WriteLine("Осуществляется выход...");
                        Thread.Sleep(1500);
                        break;

                    default:
                        Console.WriteLine("На данный момент не существует других действий");
                        MenuCashMachine();
                        break;
                }
            }
            else if(person.status == "vip")
            {
                Console.WriteLine("Выберите действие");
                Console.WriteLine("1. Показать счет кошелька");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        WithdrawalWallet();
                        break;

                    default:
                        Console.WriteLine("На данный момент не существует других действий");
                        MenuCashMachine();
                        break;
                }
            }
        }

        // Пополнение счета через банкомат
        private void CashMachineUpWallet()
        {
            Console.WriteLine($"На данный момент ваш счет составляет: {person.Wallet} рублей ");
            Console.Write("На сколько вы хотите пополнить ваш кошелек?\n: ");
            int value = int.Parse(Console.ReadLine());
            Console.WriteLine(" рублей");

            Thread.Sleep(1500);

            person.Wallet += value;

            Console.WriteLine($"Ваш кошелек пополнен на {value} рублей");
            MenuCashMachine();
        }

        private void WithdrawalWallet()
        {
            Console.WriteLine($"На вашем кошельке сейчас лежит {person.Wallet} рублей");
            MenuCashMachine();
        }
    }
}
