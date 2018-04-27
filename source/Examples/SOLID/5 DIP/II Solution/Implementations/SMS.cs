namespace bbv.Examples.SOLID._5_DIP.II_Solution.Implementations
{
    using System;

    public class SMS : IMessage
    {
        private readonly string phoneNumber;

        private readonly string message;

        public SMS(string phoneNumber, string message)
        {
            this.phoneNumber = phoneNumber;
            this.message = message;
        }

        public void Send()
        {
            Console.WriteLine(
                "Sending mail to {0} > {1}",
                this.phoneNumber,
                this.message);
        }
    }
}