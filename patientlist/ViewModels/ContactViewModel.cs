using patientlist.Commands;
using patientlist.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace patientlist.ViewModels
{
    public class ContactViewModel : ViewModelBase
    {

        private ContactMappingViewModel _selectedContact;
        public ContactMappingViewModel SelectedContact
        {
            get
            {
                return _selectedContact;
            }
            set
            {
                _selectedContact = value;
                OnPropertyChanged(nameof(SelectedContact));
            }
        }

        public ICommand CreateContactCommand { get; }
        public ICommand RemoveContactCommand { get; }

        private readonly ContactList _contactList;

        private ObservableCollection<ContactMappingViewModel> _contacts;

        public IEnumerable<ContactMappingViewModel> Contacts => _contacts;



        public ContactViewModel(ContactList contactList)
        {
            _contactList = contactList;
            _contacts = new ObservableCollection<ContactMappingViewModel>();

            CreateContactCommand = new CreateContactCommand(_contacts);
            RemoveContactCommand = new RemoveContactCommand(_contacts);

            UpdateContacts();
        }

        private void UpdateContacts()
        {
            _contacts.Clear();

            foreach (var contact in _contactList.GetAllContacts())
                _contacts.Add(new ContactMappingViewModel(contact));
        }
    }
}
