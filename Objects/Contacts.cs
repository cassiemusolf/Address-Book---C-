using System.Collections.Generic;

namespace AddressBook.Objects
{
  public class Contact
  {
    private static List<Contact> _instances = new List<Contact> {};
    private string _contactName;
    private int _id;
    private string _contactAddress;
    private string _contactPhoneNumber;

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
    public void SetName(string newName)
    {
      _contactName = newName;
    }
    public int GetId()
    {
      return _id;
    }
    public string GetAddress()
    {
      return _contactAddress;
    }
    public void SetAddress(string newAddress)
    {
      _contactAddress = newAddress;
    }
    public string GetPhoneNumber()
    {
      return _contactPhoneNumber;
    }
    public void SetPhoneNumber(string newPhoneNumber)
    {
      _contactPhoneNumber = newPhoneNumber;
    }
    public static List<Contact> GetAll()
    {
      return _instances;
    }
    public void Save()
    {
      _instances.Add(this);
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
    public static Contact Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
