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
    public static class CustomerSentEmailDAL
    {
        public static MySqlConnection connection;

        static CustomerSentEmailDAL()
        {
            connection = new MySqlConnection(Constants.getConnection());

        }

        //Customer_Sent_Email: Insert(Customer pCustomer), it calls the CustomerInsert stored procedure, you must assign the output ID value to the customer's ID property.
        public static void EmailInsert(CustomerSentEmails pCustomerEmail)
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            MySqlTransaction transaction;
            transaction = connection.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                String queryInsert = $"INSERT INTO customer_sent_emails(ID,Customer_ID,From_Address,CC_Address,BCC_Address,Subject,`Message`,Sent_When) VALUES ({pCustomerEmail.getCustomerEmailID()},{ pCustomerEmail.getCustomerID()  },'{pCustomerEmail.getFromAddress()}', '{pCustomerEmail.getCcAddress()}', '{pCustomerEmail.getBccAddress()}', '{pCustomerEmail.getSubject()}', '{pCustomerEmail.getMessage()}', '{pCustomerEmail.getSentWhen()}' )";
                cmd = new MySqlCommand(queryInsert, connection);
                transaction.Commit();
                int rowAffected = cmd.ExecuteNonQuery();
                Console.WriteLine("Email inserted successfully! Rows affected: " + rowAffected);
                string id = cmd.Parameters["ID"].Value.ToString();
                pCustomerEmail.setCustomerID(Convert.ToInt32(id));
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
            finally {
                connection.Close();
            }
        }

        //Customer_Sent_Email:Update(Customer pCustomer) – calls the CustomerUpdate stored procedure. 
        public static void EmailUpdate(CustomerSentEmails pCustomerEmail)
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            MySqlTransaction transaction;
            transaction = connection.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                String queryUpdate = $"UPDATE customer_sent_emails SET ID={pCustomerEmail.getCustomerEmailID()},Customer_ID={pCustomerEmail.getCustomerID()},From_Address='{pCustomerEmail.getFromAddress()}',CC_Address= '{pCustomerEmail.getCcAddress()}', BCC_Address='{pCustomerEmail.getBccAddress()}', Subject='{pCustomerEmail.getSubject()}', Message='{pCustomerEmail.getMessage()}' , Sent_When='{pCustomerEmail.getSentWhen()}' WHERE ID={pCustomerEmail.getCustomerEmailID()}";
                cmd = new MySqlCommand(queryUpdate, connection);
                transaction.Commit();
                int rowAffected = cmd.ExecuteNonQuery();
                Console.WriteLine("Email updated successfully! Rows affected: " + rowAffected);
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

        //Customer_Sent_Email:	Delete(Customer pCustomer) – calls the CustomerDelete stored procedure
        public static void EmailDelete(int emailID)
          {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            MySqlTransaction transaction;
            transaction = connection.BeginTransaction();
            cmd.Transaction = transaction;
            try
              {
                  String queryDelete = $"DELETE FROM customer_sent_emails WHERE ID ={emailID}";
                  cmd = new MySqlCommand(queryDelete, connection);
                transaction.Commit();
                  int rowAffected = cmd.ExecuteNonQuery();
                  Console.WriteLine("Email deleted successfully! Rows affected: " + rowAffected);
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
              finally
              {
                  connection.Close();
              }
          }

        //Customer_Sent_Email:GetByID(Customer pCustomer) – calls the GetByID stored procedure and populates the customer's fields with the values retrieved with the procedure.
        public static void EmailGetByID(CustomerSentEmails pCustomerEmail)
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            MySqlTransaction transaction;
            transaction = connection.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                String queryGetByID = $"SELECT * FROM customer_sent_emails WHERE ID ={pCustomerEmail.getCustomerEmailID()}";
                cmd = new MySqlCommand(queryGetByID, connection);
                
                DataTable dataTable = new DataTable();
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(cmd);
                transaction.Commit();
                mySqlDataAdapter.Fill(dataTable);
                String[] stringArray = dataTable.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();
                pCustomerEmail.setCustomerEmailID(Convert.ToInt32(stringArray[0]));
                pCustomerEmail.setCustomerID(Convert.ToInt32(stringArray[1]));
                pCustomerEmail.setFromAddress(stringArray[2]);
                pCustomerEmail.setCcAddress(stringArray[3]);
                pCustomerEmail.setBccAddress(stringArray[4]);
                pCustomerEmail.setSubject(stringArray[5]);
                pCustomerEmail.setMessage(stringArray[6]);
                pCustomerEmail.setSentWhen(stringArray[7]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                try
                {
                    transaction.Rollback();
                    connection.Close();
            
                }
                catch (Exception ex2)
                {
                    Console.WriteLine("Rollback Error:" + ex2.Message);
                }
            }
            finally { connection.Close(); }
        }


        //Customer_Sent_Email:Browse(Customer pCustomer) – this will return a DataSet containing all the rows returned by the CustomerBrowse procedure, this should use filters for Name and UserName. 
        //I used From_Address, Message and Subject as filters
        public static DataSet EmailBrowse(String param)
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            MySqlTransaction transaction;
            transaction = connection.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                String queryBrowse = $"SELECT * FROM customer_sent_emails WHERE( From_Address LIKE '%{param}%' OR Subject LIKE '%{param}%' OR Message LIKE '%{param}%')";
                cmd = new MySqlCommand(queryBrowse, connection);
                DataSet resultDataSet = new DataSet();
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(cmd);
                transaction.Commit();
                mySqlDataAdapter.Fill(resultDataSet, "customer_sent_emails");
                connection.Close();
                return resultDataSet;
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
                return null;
            }
           

        }

        //Customer_Sent_Email:GetCollection – this one still calls the CustomerBrowse procedure but won't return a dataset, instead it will return a List<Customer>. Each row must be transformed into an instance, then added to the list.
        public static List<CustomerSentEmails> EmailCollection(string param)
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            MySqlTransaction transaction;
            transaction = connection.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                String queryBrowse = $"SELECT * FROM customer_sent_emails WHERE( From_Address LIKE '%{param}%' OR Subject LIKE '%{param}%' OR Message LIKE '%{param}%')";
                cmd = new MySqlCommand(queryBrowse, connection);
                DataTable resultDataTable = new DataTable();
                List<CustomerSentEmails> resultList = new List<CustomerSentEmails>();
                MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(cmd);
                transaction.Commit();
                mySqlDataAdapter.Fill(resultDataTable);
                for (int i = 0; i < resultDataTable.Rows.Count; i++)
                {
                    CustomerSentEmails newEmail = new CustomerSentEmails(0,0, "", "", "", "","","");
                    String[] stringArray = resultDataTable.Rows[i].ItemArray.Select(x => x.ToString()).ToArray();
                    newEmail.setCustomerEmailID(Convert.ToInt32(stringArray[0]));
                    newEmail.setCustomerID(Convert.ToInt32(stringArray[1]));
                    newEmail.setFromAddress(stringArray[2]);
                    newEmail.setCcAddress(stringArray[3]);
                    newEmail.setBccAddress(stringArray[4]);
                    newEmail.setSubject(stringArray[5]);
                    newEmail.setMessage(stringArray[6]);
                    newEmail.setSentWhen(stringArray[7]);
                    resultList.Add(newEmail);
                }

                return resultList;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                try
                {
                    transaction.Rollback();
                    connection.Close();
                }
                catch (Exception ex2)
                {
                    Console.WriteLine("Rollback Error:" + ex2.Message);
                }
                return null;
            }

        }
    }
}
