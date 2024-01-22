using System;

namespace Bank
{
    class Contribution
    {
        private double[] contributions;
        private double[] finalyContribution;

        public Contribution(double[] contributions)
        {
            this.contributions = contributions;
            finalyContribution = new double[contributions.Length];
        }

        ~Contribution() 
        {
            Console.WriteLine("Вклад/вклады были очистены");
        }

        public void SetFinalyContribution(double[] contributs)
        {
            for(int i = 0; i < contributs.Length; i++)
            {
                finalyContribution[i] = contributs[i];
            }
        }

        public int GetSizeContributions
        {
            get { return contributions.Length; }
        }

        public double[] GetContribution
        {
            get
            {
                return contributions;
            }
        }

        public double[] GetFinalyContribution
        {
            get
            {
                return finalyContribution;
            }
        }
    }

    class Bank
    {
        private double percent = 0;
        private double year = 0;
        private double contribution = 0;
        private Contribution contribut;

        public Bank(Contribution contribut, double year = 1.5, double percent = 7.5) 
        {
            this.contribut = contribut;
            this.year = year;
            this.percent = percent;
        }

        public void CalculationDeposit()
        {
            FutureContribution();
            DepositWithdrawal();
        }

        private void DepositWithdrawal()
        {
            Console.WriteLine("Вклад(ы): ");
            for (int i = 0; i < contribut.GetSizeContributions; ++i)
            {
                Console.WriteLine($"{i + 1}. {contribut.GetContribution[i]}");
            }
            Console.WriteLine();

            Console.WriteLine($"На {year} лет, с процентом {percent}");
            Console.WriteLine();

            Console.WriteLine("Вышло: ");
            for (int i = 0; i < contribut.GetSizeContributions; ++i)
            {
                Console.WriteLine($"{i + 1}. {contribut.GetFinalyContribution[i]}");
            }

        }

        private void FutureContribution()
        {
            double totalPercent = percent * year;
            double[] newContribut = new double[contribut.GetSizeContributions];
            
            for(int i = 0; i < contribut.GetSizeContributions; ++i)
            {
                newContribut[i] = contribut.GetContribution[i] * (totalPercent / 100 + 1);
            }

            contribut.SetFinalyContribution(newContribut);
        }
    }
}
