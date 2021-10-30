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
            //For adding employee
           AddressModel model = new AddressModel();
            //model.FName = "Varun";
            //model.LName = "Lad";
            //model.Phone = 9834471126;
            //addressBook.UpdateAddress(model);
            Console.ReadLine();
        }
    }
}
