namespace patientlist.Models
{
    public class Contact
    {
        public string FirstName { get; }
        public string LastName { get; }
        public int Age { get; }

        public Contact(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public override string ToString() => $"{FirstName}, {LastName} ({Age})";

    }
}
