using patientlist.Models;
using patientlist.ViewModels;
using System.Collections.ObjectModel;

namespace patientlist.Commands
{
    public class CreateContactCommand : CommandBase
    {

        private readonly ObservableCollection<ContactMappingViewModel> _contactList;

        public CreateContactCommand(ObservableCollection<ContactMappingViewModel> contactList)
        {
            _contactList = contactList;
        }

        public override void Execute(object parameter)
        {
            _contactList.Add(new ContactMappingViewModel(new Contact("John", "Doe",0)));
        }
    }
}
