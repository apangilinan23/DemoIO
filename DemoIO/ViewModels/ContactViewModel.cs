using DemoIO.Models;

namespace DemoIO.ViewModels
{
    public class ContactViewModel
    {
        public ContactViewModel() 
        {
            Contacts = new List<Contact>();
        }

        public List<Contact> Contacts { get; set; }
    }
}
