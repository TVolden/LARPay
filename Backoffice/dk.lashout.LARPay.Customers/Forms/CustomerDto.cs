namespace dk.lashout.LARPay.Customers.Forms
{
    public class CustomerDto
    {
        public string Username { get; }
        public string Name { get; }

        public CustomerDto(string username, string name)
        {
            Username = username;
            Name = name;
        }
    }
}