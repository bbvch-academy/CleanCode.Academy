namespace bbv.Examples.SOLID._5_DIP.II_Solution
{
    using System;
    using Implementations;

    public static class Execution
    {
        public static void Run()
        {
            Console.WriteLine("DIP Solution Example");

            IMessage mail = new Email("sombody@example.com", "Testmessage", "Foo Bar");
            IMessage sms = new SMS("(+41) 71 234 56 78", "Foo Bar");

            var notification = new Notification(new []{ mail, sms });
            notification.Send();
        }
    }
}
