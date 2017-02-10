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
      Get["/"] = _ => {
        List<Contact> allContacts = Contact.GetAll();
        return View["index.cshtml", allContacts];
      };
      Get["/contacts"] = _ => {
        return View["contact_form.cshtml"];
      };
      Get["/contacts/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedContact = Contact.Find(parameters.id);
        model.Add("contact", selectedContact);
        // model.Add("albums", artistAlbums);
        return View["contacts.cshtml", model];
      };
      Post["/contact/new"] = _ => {
        return View["contact_added.cshtml"];
      };
      Post["/"] = _ => {
        Contact newContact = new Contact(Request.Form["contact-name"], Request.Form["contact-address"], Request.Form["contact-phone"]);
        List<Contact> allContacts = Contact.GetAll();
        return View["/", allContacts];
      };
      Post["/contacts/clear"] = _ => {
        Contact.ClearAll();
        return View["contacts_cleared.cshtml"];
      };
    }
  }
}
