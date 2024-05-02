namespace AtmMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to ATM Machine!");
            Account account = new(10000);
            int flag;
            do
            {
                Console.WriteLine("Enter the Choice:\n1.Check Balance\n2.Cash Deposit\n3.Cash Withdraw\n4.Exit");
                _ = int.TryParse(Console.ReadLine(), out flag);
                switch (flag)
                {
                    case 1:
                        Console.WriteLine("Balance :" + account.CheckBalance());
                        break;
                    case 2:
                        Console.WriteLine("Enter the Amount to be Deposited");
                        _ = int.TryParse(Console.ReadLine(), out int amount);
                        account.Deposit(amount);
                        Console.WriteLine("Deposited Amount : "+amount+" Balance : "+account.CheckBalance());
                        break;
                    case 3:
                        Console.WriteLine("Enter the Amount to be Withdrawn");
                        _ = int.TryParse(Console.ReadLine(), out int amt);
                        if (amt < account.CheckBalance())
                            Console.WriteLine("Withdrawed Amount : "+account.withdraw(amt)+ " Balance : " + account.CheckBalance());
                        else
                            Console.WriteLine("Not Able to Withdraw Money Check Balance Please");
                        break;
                    default:
                        flag = 0;
                        break;
                }
                
            } 
            while (flag != 0);
        }
    }
}
