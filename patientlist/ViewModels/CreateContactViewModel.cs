using System;
using System.Collections.Generic;
using System.Text;

namespace patientlist.ViewModels
{
    public class CreateContactViewModel : ViewModelBase
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

        private string _age;

        public string Age
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

        private readonly ContactMappingViewModel _contactMappingViewModel;

        public CreateContactViewModel(ContactMappingViewModel contactMappingViewModel)
        {
            _contactMappingViewModel = contactMappingViewModel;
        }
    }
}
