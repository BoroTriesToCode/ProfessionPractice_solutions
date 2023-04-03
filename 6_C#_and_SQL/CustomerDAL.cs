using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace program
{
    public static class CustomerDAL
    {

        public static MySqlConnection connection;

        static CustomerDAL()
        {
            connection = new MySqlConnection(Constants.getConnection());
            
        }

        //Insert(Customer pCustomer), it calls the CustomerInsert stored procedure, you must assign the output ID value to the customer's ID property.
        public static void CustomerInsert(Customer pCustomer)
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            MySqlTransaction transaction;
            transaction = connection.BeginTransaction();
            cmd.Transaction = transaction;

            try
            {
                cmd = new MySqlCommand("CustomerInsert", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlParameter customerID = new MySqlParameter();
                customerID.ParameterName = "$ID";
                customerID.Value = pCustomer.getCustomerID();
                customerID.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(customerID);
                cmd.Parameters.Add(new MySqlParameter("$Name", pCustomer.getCustomerName()));
                cmd.Parameters.Add(new MySqlParameter("$Email", pCustomer.getCustomerEmail()));
                cmd.Parameters.Add(new MySqlParameter("$User_Name", pCustomer.getCustomerUsername()));
                cmd.Parameters.Add(new MySqlParameter("$Password", pCustomer.getCustomerPassword()));
                int rowAffected=cmd.ExecuteNonQuery();
                transaction.Commit();
                Console.WriteLine("Customer inserted successfully! Rows affected: "+rowAffected);
                string id = cmd.Parameters["$ID"].Value.ToString();
                pCustomer.setCustomerID(Convert.ToInt32(id));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: "+ex.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception ex2)
                {
                    Console.WriteLine("Rollback Error:"+ex2.Message);
                }
            }
            finally 
            {

                connection.Close();
            }
            
        }

        //Update(Customer pCustomer) – calls the CustomerUpdate stored procedure.
        public static void CustomerUpdate(Customer pCustomer)
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            MySqlTransaction transaction;
            transaction = connection.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                cmd = new MySqlCommand("CustomerUpdate", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("$ID", pCustomer.getCustomerID()));
                cmd.Parameters.Add(new MySqlParameter("$Name", pCustomer.getCustomerName()));
                cmd.Parameters.Add(new MySqlParameter("$Email", pCustomer.getCustomerEmail()));
                cmd.Parameters.Add(new MySqlParameter("$User_Name", pCustomer.getCustomerUsername()));
                cmd.Parameters.Add(new MySqlParameter("$Password", pCustomer.getCustomerPassword()));
                int rowAffected = cmd.ExecuteNonQuery();
                transaction.Commit();
                Console.WriteLine("Customer updated successfully! Rows affected: " + rowAffected);
            }
            catch(Exception ex)
            {
                System.Console.WriteLine("Error:" + ex.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception ex2)
                {
                    Console.WriteLine("Rollback Error:" + ex2.Message);
                }
            }
            finally { connection.Close(); }
        }

        //Delete(Customer pCustomer) – calls the CustomerDelete stored procedure.
        public static void CustomerDelete(int id)
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            MySqlTransaction transaction;
            transaction = connection.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                cmd = new MySqlCommand("CustomerDelete", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("$ID", id));
                int rowAffected = cmd.ExecuteNonQuery();
                transaction.Commit();
                Console.WriteLine("Customer deleted successfully! Rows affected: " + rowAffected);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception ex2)
                {
                    Console.WriteLine("Rollback Error:" + ex2.Message);
                }
            }
            finally { connection.Close(); }
        }

        //GetByID(Customer pCustomer) – calls the GetByID stored procedure and populates the customer's fields with the values retrieved with the procedure.
        public static void CustomerGetByID(Customer pCustomer)
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            MySqlTransaction transaction;
            transaction = connection.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                cmd = new MySqlCommand("CustomerGetByID", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("$ID", pCustomer.getCustomerID()));
                DataTable dataTable = new DataTable();
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(cmd);
                transaction.Commit();
                mySqlDataAdapter.Fill(dataTable);
                String[] stringArray = dataTable.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();
                connection.Close();
                pCustomer.setCustomerID(Convert.ToInt32(stringArray[0]));
                pCustomer.setCustomerName(stringArray[1]);
                pCustomer.setCustomerEmail(stringArray[2]);
                pCustomer.setCustomerUsername(stringArray[3]);
                pCustomer.setCustomerPassword(stringArray[4]);
                pCustomer.setIsActive(Convert.ToBoolean(stringArray[5]));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: "+ex.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception ex2)
                {
                    Console.WriteLine("Rollback Error:" + ex2.Message);
                }
            }
            finally { connection.Close(); }
        }

        //Browse(Customer pCustomer) – this will return a DataSet containing all the rows returned by the CustomerBrowse procedure, this should use filters for Name and UserName.
        public static DataSet CustomerBrowse(string param)
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            MySqlTransaction transaction;
            transaction = connection.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                cmd = new MySqlCommand("CustomerBrowse", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("$param", param));
                DataSet resultDataSet = new DataSet();
                transaction.Commit();
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(cmd);
                mySqlDataAdapter.Fill(resultDataSet, "customers");
                connection.Close();
                return resultDataSet;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                try
                {
                    transaction.Rollback();
                    return null;
                }
                catch (Exception ex2)
                {
                    Console.WriteLine("Rollback Error:" + ex2.Message);
                    return null;
                }
            } 
        }

        //GetCollection – this one still calls the CustomerBrowse procedure but won't return a dataset, instead it will return a List<Customer>.
        //Each row must be transformed into an instance, then added to the list.
        public static List<Customer> CustomerCollection(string param)
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            MySqlTransaction transaction;
            transaction = connection.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                cmd = new MySqlCommand("CustomerBrowse", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("$param", param));
                DataTable resultDataTable = new DataTable();
                List<Customer> resultList = new List<Customer>();
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(cmd);
                transaction.Commit();
                mySqlDataAdapter.Fill(resultDataTable);
                for (int i = 0; i < resultDataTable.Rows.Count; i++)
                {
                    Customer newCustomer = new Customer(0, "", "", "", "", false);
                    String[] stringArray = resultDataTable.Rows[i].ItemArray.Select(x => x.ToString()).ToArray();
                    newCustomer.setCustomerID(Convert.ToInt32(stringArray[0]));
                    newCustomer.setCustomerName(stringArray[1]);
                    newCustomer.setCustomerEmail(stringArray[2]);
                    newCustomer.setCustomerUsername(stringArray[3]);
                    newCustomer.setCustomerPassword(stringArray[4]);
                    newCustomer.setIsActive(Convert.ToBoolean(stringArray[5]));
                    resultList.Add(newCustomer);
                }
                connection.Close();
                return resultList;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                try
                {
                    transaction.Rollback();
                    return null;
                }
                catch (Exception ex2)
                {
                    Console.WriteLine("Rollback Error:" + ex2.Message);
                    return null;
                }
            }

        }
    }
}
