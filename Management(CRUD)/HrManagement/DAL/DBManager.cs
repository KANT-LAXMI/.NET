
using BOL;
using MySql.Data.MySqlClient;
using System.Reflection.Metadata;

namespace DAL
{
    public class DBManager
    {
        public static string conString = @"server=localhost;port=3306;user=root;password=ashu0311;database=hrmanagement";
    
        //List all Employees
        public static List<Employee> GetAllEmployees()
    {
            List<Employee> allEmployees=new List<Employee>();
            MySqlConnection con=new MySqlConnection();
            con.ConnectionString=conString;
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                string query = "select * from emp";
                cmd.CommandText=query;
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int empId = int.Parse(reader["empId"].ToString());
                    string firstName = reader["firstName"].ToString();
                    string lastName = reader["lastName"].ToString();
                    string department = reader["department"].ToString();
                    string email = reader["email"].ToString();
                    string password = reader["password"].ToString();
                    double sal = double.Parse(reader["sal"].ToString());
                    Employee e = new Employee(empId, firstName, lastName,department, email, password, sal);
                    allEmployees.Add(e);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }

            return allEmployees;
        }

        //GET SINGLE EMPLOYEE DETAILS
        public static Employee GetEmpDetails(int id)
        {
            Employee e = null;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = conString;
            try
            {
                string query = "select * from emp where empId=" + id;
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int empId = int.Parse(reader["empId"].ToString());
                    string firstName = reader["firstName"].ToString();
                    string lastName = reader["lastName"].ToString();
                    string department = reader["department"].ToString();
                    string email = reader["email"].ToString();
                    string password = reader["password"].ToString();
                    double sal = double.Parse(reader["sal"].ToString());
                    e=new Employee(id, firstName, lastName,department, email, password, sal);
                }
            }catch(Exception ee)
            {
                throw ee;
            }
            finally
            {
                con.Close();
            }
            return e;
        }


        //INSERT EMPLOYEE
        public static bool Insert(Employee e)
        {
            bool status = false;
           
            string query = "INSERT INTO emp (empId, firstName, lastName,department, email, password, sal) " +
                  "VALUES (" + e.EmpId + ", '" + e.FirstName + "', '" + e.LastName +"', '"+e.Department+ "', '" + e.Email + "', '" 
                  + e.Password + "', " + e.Salary + ")";
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = conString;
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                status = true;

            }catch(Exception ee)
            {
                throw ee;
            }
            finally
            {
                con.Close();
            }
            return status;
        }


        //UPDATE EMPLOYEE DETAILS
        public static bool Update(Employee e)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = conString;
            try
            {

                string query = "UPDATE emp SET firstName = @FirstName, lastName = @LastName, department = @Department, email = @Email, password = @Password, sal = @Salary " +
                  "WHERE empId = @EmpId";
                
                con.Open() ;

                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.Parameters.AddWithValue("@EmpId", e.EmpId);
                cmd.Parameters.AddWithValue("@FirstName", e.FirstName);
                cmd.Parameters.AddWithValue("@LastName", e.LastName);
                cmd.Parameters.AddWithValue("@Department", e.Department);
                cmd.Parameters.AddWithValue("@Email", e.Email);
                cmd.Parameters.AddWithValue("@Password", e.Password);
                cmd.Parameters.AddWithValue("@Salary", e.Salary);

               int rowsAffected= cmd.ExecuteNonQuery() ;
                status = rowsAffected > 0;
            }
            catch(Exception ee)
            {
                throw ee;
            }
            finally
            {
                con.Close();
            }
            return status;
        }


        //DELETE EMPLOYEE
        public static bool Delete(int empId)
        {

            bool status = false;
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = conString;
            try
            {
                string query = "delete from emp where empId=" + empId;
                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();
                int rowsAffected= cmd.ExecuteNonQuery();
                status = rowsAffected > 0;
            }
            catch (Exception ee)
            {
                throw ee;
            }
            finally
            {
                con.Close();
            }
            return status;
        }


        }

    }
