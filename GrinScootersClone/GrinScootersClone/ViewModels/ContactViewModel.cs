using GrinScootersClone.Interfaces;
using GrinScootersClone.Models;
using GrinScootersClone.Services;
using Plugin.ContactService.Shared;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GrinScootersClone.ViewModels
{
    public class ContactViewModel : BaseViewModel, IInitialize
    {
        #region Fields

        private readonly INavigation _navigation;

        #endregion

        #region Properties

        public string SearchText { get; set; }
        public ObservableCollection<ContactModel> Contacts { get; private set; }

        #endregion

        #region Commands

        public Command GoBackCommand { get; private set; }

        #endregion

        #region Constructors

        public ContactViewModel(INavigation navigation)
        {
            _navigation = navigation;
            Contacts = new ObservableCollection<ContactModel>();

            GoBackCommand = new Command(
                async () => await NavigateToBackAsync()
            );

            LoadNavBar();

        }

        #endregion

        #region Methods

        private void LoadNavBar()
        {
            NavBackgroundColor = "#09D46B";
            NavArrow = "navbar_arrow_white";
            NavBarButtonVisible = true;
        }

        public async Task InitializeAsync()
        {
            await GetContacts();
        }

        private async Task GetContacts()
        {
            try
            {
                var contacts = await Plugin.ContactService.CrossContactService.Current.GetContactListAsync();

                LoadContacts(contacts
                    .Where(w => !string.IsNullOrEmpty(w.Name) && !string.IsNullOrEmpty(w.Number))
                    .OrderBy(o => o.Name)
                );
            }
            catch (TaskCanceledException)
            {
                Console.WriteLine("Erro ao obter lista de contatos");
            }
        }

        private void LoadContacts(IEnumerable contacts)
        {
            Contacts.Clear();

            foreach (Contact contact in contacts)
            {
                Contacts.Add(ConvertContact(contact));
            }
        }

        private ContactModel ConvertContact(Contact contact)
        {
            return new ContactModel()
            {
                Name = contact.Name,
                Number = GetCustomNumber(contact.Number),
                Abbreviation = GetAbbreviation(contact.Name)
            };
        }

        private string GetCustomNumber(string number)
        {
            number = number.Contains("+55") ? number : $"+55{number}";

            return number.Replace('-', ' ').Replace(" ", string.Empty);
        }

        private string GetAbbreviation(string name)
        {
            var nameSplit = name.Split(' ');

            if (nameSplit.Length < 2)
                return nameSplit[0].Substring(0,1).ToUpper();

            return $"{nameSplit[0].Substring(0, 1).ToUpper()}{nameSplit[1].Substring(0, 1).ToUpper()}";
        }

        private async Task NavigateToBackAsync()
        {
            await _navigation.PopModalAsync();
        }

        #endregion
    }
}
