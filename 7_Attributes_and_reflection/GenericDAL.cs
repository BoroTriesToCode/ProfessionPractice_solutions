using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Reflection;


namespace Attributes_and_reflection
{

    public static class GenericDAL<T>
    {
        public static MySqlConnection connection = new MySqlConnection("server=192.168.10.10;database=training_nb;port=3306;uid=nagyb;pwd=training;");

        public static void insertTable(T entity)
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            MySqlTransaction transaction;
            transaction = connection.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {

                Type type = typeof(T);
                PropertyInfo[] propertiesInfo = type.GetProperties();
                if (propertiesInfo.Length <= 0)
                {
                    
                }
                else {
                    String string1 = propertiesInfo[0].Name;
                    String string2 = propertiesInfo[0].GetValue(entity).ToString();
               
                Console.WriteLine(propertiesInfo[0].GetValue(entity));
                foreach (PropertyInfo propertyInfo in propertiesInfo.Skip(1))
                {
                    if (propertyInfo.PropertyType == typeof(string)) { 
                        string1 = string1 + "," + propertyInfo.Name;
                        string2 = string2 + ",'" + propertyInfo.GetValue(entity)+"'";
                    }
                    else
                    {
                        string1 = string1 + "," + propertyInfo.Name;
                        string2 = string2 + "," + propertyInfo.GetValue(entity);
                    }
                }
                //Console.WriteLine(finalString);

                 String queryInsert = "INSERT INTO customers" + "(" + string1 + ") VALUES (" + string2 + ")";
                 cmd = new MySqlCommand(queryInsert, connection);
                 transaction.Commit();
                 int rowAffected = cmd.ExecuteNonQuery();
                 Console.WriteLine("Customer inserted successfully! Rows affected: " + rowAffected);

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

        public static void updateRecord(T entity)
        {
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            MySqlTransaction transaction;
            transaction = connection.BeginTransaction();
            cmd.Transaction = transaction;
            List<String> list1=new List<String>();
            List<String> list2=new List<String>();
            Type type = typeof(T);
            PropertyInfo[] propertiesInfo = type.GetProperties();
            int count = 0;
            foreach (PropertyInfo propertyInfo in propertiesInfo)
            {
                list1[count] = propertyInfo.Name;
                list2[count] = propertyInfo.GetValue(entity).ToString();
            }
            String queryUpdate = $"UPDATE customer_sent_emails SET ("+list1[0]+"="+list2[0];
            for (int i = 1; i < count; i++)
            {
                queryUpdate = "," + queryUpdate + list1[i] + "=" + list2[i];
            }
            queryUpdate = queryUpdate + ")";
            Console.WriteLine(queryUpdate); 
            /*
            try
            {
                
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
            */
        }


    }


    
   
}
