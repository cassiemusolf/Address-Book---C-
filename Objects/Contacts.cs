using System.Collections.Generic;

namespace AddressBook.Objects
{
  public class Contact
  {
    private static List<Contact> _instances = new List<Contact> {};
    private string _name;
    private int _id;

    public Contact(string contactName, string contactAddress, string contactPhoneNumber)
    {
      _contactName = contactName;
      _instances.Add(this);
      _id = _instances.Count;
      _contactAddress = contactAddress;
      _contactPhoneNumber = contactPhoneNumber;
    }

    public string GetName()
    {
      return _contactName;
    }
    public int GetId()
    {
      return _id;
    }
    public static List<Contact> GetAll()
    {
      return _instances;
    }
    public static void Clear()
    {
      _instances.Clear();
    }
    public static Contact Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
