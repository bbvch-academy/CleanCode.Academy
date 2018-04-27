namespace bbv.Examples.SOLID._5_DIP.I_Violation
{
    public class Notification
    {
        private readonly Email email;
        private readonly SMS sms;

        public Notification(Email email, SMS sms)
        {
            this.email = email;
            this.sms = sms;
        }

        public void Send()
        {
            this.email.SendMail();
            this.sms.SendSMS();
        }
    }
}