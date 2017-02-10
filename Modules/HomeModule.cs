using Nancy;
using AddressBook.Objects;
using System.Collections.Generic;

namespace AddressBook
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };
      Get["/contacts"] = _ => {
        List<Contact> allContacts = Contact.GetAll();
        return View["contacts.cshtml", allContacts];
      };
      Get["/contacts/new"] = _ => {
        return View["contact_form.cshtml"];
      };

      Get["/contacts/{id}"] = parameters => {
        Contact contact = Contact.Find(parameters.id);
        return View["/contact.cshtml", contact];
        };
      // Post["/contact/new"] = _ => {
      //   return View["contact_added.cshtml"];
      // };
      Post["/contacts"] = _ => {
        Contact newContact = new Contact(Request.Form["contact-name"], Request.Form["contact-address"], Request.Form["contact-phone"]);
        List<Contact> allContacts = Contact.GetAll();
        return View["contacts.cshtml", allContacts];
      };

      Post["/contacts/clear"] = _ => {
        Contact.ClearAll();
        return View["contacts_cleared.cshtml"];
      };
    }
  }
}
