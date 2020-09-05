namespace PaymentProcessor.Entities
{
    public class Membership
    {
        public Membership(string name)
        {
            NameOfHolder = name;
        }

        public string NameOfHolder { get; private set; }

    }
}
