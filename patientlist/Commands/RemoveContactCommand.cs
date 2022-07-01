using patientlist.Models;
using patientlist.ViewModels;
using System;
using System.Collections.ObjectModel;

namespace patientlist.Commands
{
    public class RemoveContactCommand : CommandBase
    {
        private readonly ObservableCollection<ContactMappingViewModel> _contactList;

        public RemoveContactCommand(ObservableCollection<ContactMappingViewModel> contactList)
        {
            _contactList = contactList;
        }

        public override void Execute(object parameter)
        {
            if (parameter is ContactMappingViewModel contact)
            {
                _contactList.Remove(contact);
            }
        }
    }
}
