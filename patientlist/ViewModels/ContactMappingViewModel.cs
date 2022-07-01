using patientlist.Models;

namespace patientlist.ViewModels
{
    public class ContactMappingViewModel : ViewModelBase
    {
        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                OnPropertyAndDisplayChanged(nameof(FirstName));

            }
        }

        private string _lastName;

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                OnPropertyAndDisplayChanged(nameof(LastName));
            }
        }

        private int _age;

        public int Age
        {
            get
            {
                return _age;
            }
            set
            {
                _age = value;
                OnPropertyAndDisplayChanged(nameof(Age));
            }
        }
      
        public string DisplayContact => $"{_firstName}, {_lastName} ({_age})";

        public ContactMappingViewModel(Contact contact)
        {
            _firstName = contact.FirstName;
            _lastName = contact.LastName;
            _age = contact.Age;
        }

        
    }
}
