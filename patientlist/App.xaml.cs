using patientlist.Models;
using patientlist.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace patientlist
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ContactList _contactList;

        public App()
        {
            _contactList = new ContactList();
            
        }

        protected override void OnStartup(StartupEventArgs e)
        {

            SetDummies();

            MainWindow = new MainWindow()
            {
                DataContext = new ContactViewModel(_contactList)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }
        private void SetDummies()
        {
            _contactList.AddContact(new Contact("Peter", "Parker", 16));
            _contactList.AddContact(new Contact("Betty", "Sue", 20));
            _contactList.AddContact(new Contact("Fredderick", "Kruger", 56));
        }
    }
}
