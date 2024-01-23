namespace Program
{
    class Program
    {
        public static void Main(string[] args) 
        {
            double[] contributClients;
            //double[] contributVipClients;

            Person.Client client = new Person.Client("Максим", "Грушин", 19, 128472);
            //Person.VIPClient vipClient = new Person.VIPClient("Гена", "Филин", 27);

            contributClients = client.CreateContribut();
            Console.WriteLine();
            //contributVipClients = vipClient.CreateContribut();

            Bank.Contribution contributsClients = new Bank.Contribution(contributClients);
            //Bank.Contribution contributsVipClients = new Bank.Contribution(contributVipClients);

            Bank.Bank bank = new Bank.Bank(contributsClients);
            //Bank.Bank bank2 = new Bank.Bank(contributsVipClients);

            Console.WriteLine();
            bank.CalculationDeposit();
            //Console.WriteLine();
            //bank2.CalculationDeposit();

            client.ActionsWithWallet();

            bank.WithdrawDeposit();

            client.ActionsWithWallet();
        }
    }
}