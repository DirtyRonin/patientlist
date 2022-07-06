using patientlist.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace patientlist.Commands
{
    public class CreateContactCommand : CommandBase
    {
        private readonly ContactViewModel _contactViewModel;
        private readonly ObservableCollection<ContactMappingViewModel> _contactList;


        public CreateContactCommand(ContactViewModel contactViewModel, ObservableCollection<ContactMappingViewModel> contactList)
        {
            _contactList = contactList;
            _contactViewModel = contactViewModel;
            _contactList.CollectionChanged += OnContactsCountChanged;
            _contactList.CollectionChanged += OnContactsAddedChanged;
        }

        private void OnContactsAddedChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
                OnCanExecuteChanged();
        }

        private void OnContactsCountChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
                if (sender is ObservableCollection<ContactMappingViewModel> contacts)
                    if (contacts.Count == 0)
                        OnCanExecuteChanged();
        }

        public void OnAgePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (HasAgePropertyChanged(e))
                OnCanExecuteChanged();
        }

        private bool HasAgePropertyChanged(PropertyChangedEventArgs e)
        {
            return e.PropertyName == nameof(ContactMappingViewModel.Age);
        }

        public override bool CanExecute(object parameter)
        {
            foreach (var contactView in _contactViewModel.Contacts)
                if (!int.TryParse(contactView?.Age, out int age))
                    return false;


            return base.CanExecute(parameter);
        }

        public override void Execute(object parameter)
        {
            _contactList.Insert(0, new ContactMappingViewModel("John", "Doe", "0", OnAgePropertyChanged));
        }
    }
}
