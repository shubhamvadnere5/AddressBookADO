using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_AddressBook
{
    class AddressBookRepository
    {
        //Connecting to Database
        public static string connectionString = @"Data Source=LAPTOP-FLMD11MK\SQLEXPRESS;Initial Catalog=AddressBookService058;Integrated Security=True";
        //passing the string to sqlconnection to make connection 
        SqlConnection sqlconnection = new SqlConnection(connectionString);
        //GetAllAddressBook method

        public void GetAllAddressBook()
        {
            try
            {
                //Creating object for addressModel and access the fields
                AddressModel addressModel = new AddressModel();
                //Retrieve query
                string query = @"select * from AddressBook";
                SqlCommand sqlCommand = new SqlCommand(query, sqlconnection);
                //Open the connection
                this.sqlconnection.Open();
                //ExecuteReader: Returns data as rows.
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        
                        addressModel.FName = reader["FirstName"] == DBNull.Value ? default : reader["FirstName"].ToString();
                        addressModel.LName = reader["LastName"] == DBNull.Value ? default : reader["LastName"].ToString();
                        addressModel.Address = reader["Address"] == DBNull.Value ? default : reader["Address"].ToString();
                        addressModel.City = reader["city"] == DBNull.Value ? default : reader["city"].ToString();
                        addressModel.State = reader["StateName"] == DBNull.Value ? default : reader["StateName"].ToString();
                        addressModel.ZipCode = Convert.ToDouble(reader["ZipCode"] == DBNull.Value ? default : reader["ZipCode"]);
                        addressModel.Phone = Convert.ToDouble(reader["PhoneNum"] == DBNull.Value ? default : reader["PhoneNum"]);
                        addressModel.Email = reader["EmailId"] == DBNull.Value ? default : reader["EmailId"].ToString();


                        Console.WriteLine("{0} {1} {2}  {3} {4} {5}  {6} {7}   ", addressModel.FName, addressModel.LName, addressModel.Address, addressModel.City, addressModel.State, addressModel.ZipCode, addressModel.Address, addressModel.Phone, addressModel.Email);
                        Console.WriteLine("\n");
                    }
                }
                else
                {
                    Console.WriteLine("No data found");
                }
                reader.Close();

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.sqlconnection.Close();
            }


        }

        public void AddAddress(AddressModel model)
        {
            try
            {

                using (this.sqlconnection)
                {
                    SqlCommand command = new SqlCommand("dbo.spAddAddressBookDetails", this.sqlconnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FName", model.FName);
                    command.Parameters.AddWithValue("@LName", model.LName);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@city", model.City);
                    command.Parameters.AddWithValue("@StateName", model.State);
                    command.Parameters.AddWithValue("@PhoneNum", model.Phone);
                    command.Parameters.AddWithValue("@ZipCode", model.ZipCode);
                    command.Parameters.AddWithValue("@EmailId", model.Email);
                    sqlconnection.Open();
                    var result = command.ExecuteNonQuery();

                    if (result != 0)
                    {
                        Console.WriteLine("Successfully inserted the records");
                    }
                    else
                    {
                        Console.WriteLine("Insertion of result is unsuccessfull");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                sqlconnection.Close();
            }
        }
    }
}