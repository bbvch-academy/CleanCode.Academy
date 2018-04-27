namespace bbv.Examples.SOLID._5_DIP.I_Violation
{
    using System;

    public class SMS
    {
        private readonly string phoneNumber;

        private readonly string message;

        public SMS(string phoneNumber, string message)
        {
            this.phoneNumber = phoneNumber;
            this.message = message;
        }

        public void SendSMS()
        {
            Console.WriteLine(
                "Sending mail to {0} > {1}",
                this.phoneNumber,
                this.message);
        }
    }
}