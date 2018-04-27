namespace bbv.Examples.SOLID._5_DIP.I_Violation
{
    using System;

    public static class Execution
    {
        public static void Run()
        {
            Console.WriteLine("DIP Violation Example");

            var mail = new Email("sombody@example.com", "Testmessage", "Foo Bar");
            var sms = new SMS("(+41) 71 234 56 78", "Foo Bar");

            var notification = new Notification(mail, sms);
            notification.Send();
        }
    }
}
