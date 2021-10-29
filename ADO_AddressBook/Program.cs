using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            AddressBookRepository addressBook = new AddressBookRepository();
            addressBook.GetAllAddressBook();
            // For adding employee
            AddressModel model = new AddressModel();
            model.FName = "Shubham";
            model.LName = "Vadnere";
            model.Address = "Mulund";
            model.City = "Navi Mumbai";
            model.State = "Maharashtra";
            model.Phone = 8888156666;
            model.Email = "ShubhamVadnere@gmail.com";
            model.ZipCode = 421007;
            addressBook.AddAddress(model);
            Console.ReadLine();
        }
    }
}
