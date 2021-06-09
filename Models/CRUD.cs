using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace MvcApplication1.Models
{
    public class CRUD
    {
        public static string l_u;
        public static int O_ID;
        public static int BillAmount;

        public static int login_access(string login_username, string login_password)
        {
            string connectionString = @"Data Source=LAPTOP-DNFN1MF7\BILLZTEE;Initial Catalog=Project;Integrated Security=True;";
            string Procedure_Name = "LoginCheck";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(Procedure_Name, connection);
            command.CommandType = CommandType.StoredProcedure;
            
            SqlParameter param = new SqlParameter();
            param = command.Parameters.Add("@UserName", SqlDbType.VarChar, 100);
            param.Value = login_username;
            l_u = login_username;
            param = command.Parameters.Add("@Password", SqlDbType.VarChar, 100);
            param.Value = login_password;

            SqlParameter Output_Param = command.Parameters.Add("@out", SqlDbType.Int);
            Output_Param.Direction = ParameterDirection.Output;
            Output_Param.Value = "";

            try
            {
                connection.Open();
                int r = command.ExecuteNonQuery();
                connection.Close();
                string str = Output_Param.Value.ToString();
                //int x = Int32.Parse(str);
                int x = 0;
                if (Int32.TryParse(str, out x))
                    return x;
                else
                    return -1;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }
     
        public static int SignUp(string FName, string LName, string Email, string UName, string pass1, string pass2, string SSN, int Age, string phno, string Addr)
        {
            string connectionString = @"Data Source=LAPTOP-DNFN1MF7\BILLZTEE;Initial Catalog=Project;Integrated Security=True;";
            string Procedure_Name = "SignUp_Check";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(Procedure_Name, connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter();
            param = command.Parameters.Add("@FName", SqlDbType.VarChar, 100);
            param.Value = FName;
            param = command.Parameters.Add("@LName", SqlDbType.VarChar, 100);
            param.Value = LName;
            param = command.Parameters.Add("@Email", SqlDbType.VarChar, 100);
            param.Value = Email;
            param = command.Parameters.Add("@UName", SqlDbType.VarChar, 100);
            param.Value = UName;
            param = command.Parameters.Add("@Pass", SqlDbType.VarChar, 100);
            param.Value = pass1;
            param = command.Parameters.Add("@CPass", SqlDbType.VarChar, 100);
            param.Value = pass2;
            param = command.Parameters.Add("@SSN", SqlDbType.VarChar, 15);
            param.Value = SSN;
            param = command.Parameters.Add("@Age", SqlDbType.Int);
            param.Value = Age;
            param = command.Parameters.Add("@PNo", SqlDbType.VarChar, 12);
            param.Value = phno;
            param = command.Parameters.Add("@Addr", SqlDbType.VarChar, 100);
            param.Value = Addr;
            SqlParameter Output_Param = command.Parameters.Add("@out", SqlDbType.Int);
            Output_Param.Direction = ParameterDirection.Output;
            Output_Param.Value = "";
            int r = -2;
            try
            {
                connection.Open();
                r = command.ExecuteNonQuery();
                connection.Close();
                string str = Output_Param.Value.ToString();
                int x = 0;
                if (Int32.TryParse(str, out x))
                    return x;
                else
                    return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return r;
            }
        }

        public static int HomePage()
        {
            string connectionString = @"Data Source=LAPTOP-DNFN1MF7\BILLZTEE;Initial Catalog=Project;Integrated Security=True;";
            string Procedure_Name = "IsMember";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(Procedure_Name, connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter();
            param = command.Parameters.Add("@UName", SqlDbType.VarChar, 100);
            param.Value = l_u;

            SqlParameter Output_Param = command.Parameters.Add("@out", SqlDbType.Int);
            Output_Param.Direction = ParameterDirection.Output;
            Output_Param.Value = "";

            try
            {
                connection.Open();
                int r = command.ExecuteNonQuery();
                connection.Close();
                string str = Output_Param.Value.ToString();
                int x = 0;
                if (Int32.TryParse(str, out x))
                    return x;
                else
                    return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        public static SqlDataReader ViewItems()
        {
            string connectionString = @"Data Source=LAPTOP-DNFN1MF7\BILLZTEE;Initial Catalog=Project;Integrated Security=True;";
            string query = "SELECT * FROM ViewItems";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public static SqlDataReader ViewMessages()
        {
            string connectionString = @"Data Source=LAPTOP-DNFN1MF7\BILLZTEE;Initial Catalog=Project;Integrated Security=True;";
            string query = "SELECT * FROM ViewMessages";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        public static int PayForCard(int card_Amt)
        {
            if (card_Amt < 500)
                return -1;
            string connectionString = @"Data Source=LAPTOP-DNFN1MF7\BILLZTEE;Initial Catalog=Project;Integrated Security=True;";
            string Procedure_Name = "PayForCard";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(Procedure_Name, connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter();
            param = command.Parameters.Add("@UName", SqlDbType.VarChar, 100);
            param.Value = l_u;

            try
            {
                connection.Open();
                int r = command.ExecuteNonQuery();
                connection.Close();
                if (card_Amt > 500)
                    return card_Amt - 500;
                else
                    return -2;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public static int GetBill(int ItemID, int ItemQty, string delivery)
        {
            string connectionString = @"Data Source=LAPTOP-DNFN1MF7\BILLZTEE;Initial Catalog=Project;Integrated Security=True;";
            string Procedure_Name = "GetBill";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(Procedure_Name, connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter();
            param = command.Parameters.Add("@ItemID", SqlDbType.Int);
            param.Value = ItemID;
            param = command.Parameters.Add("@Qty", SqlDbType.Int);
            param.Value = ItemQty;
            param = command.Parameters.Add("@Status", SqlDbType.VarChar, 100);
            param.Value = delivery;
            param = command.Parameters.Add("@UserName", SqlDbType.VarChar, 100);
            param.Value = l_u;

            SqlParameter Output_Param = command.Parameters.Add("@out", SqlDbType.Int);
            Output_Param.Direction = ParameterDirection.Output;
            Output_Param.Value = "";

            SqlParameter Output_Param2 = command.Parameters.Add("@OID", SqlDbType.Int);
            Output_Param2.Direction = ParameterDirection.Output;
            Output_Param2.Value = "";

            try
            {
                connection.Open();
                int r = command.ExecuteNonQuery();
                connection.Close();
                string str1 = Output_Param.Value.ToString();
                string str2 = Output_Param2.Value.ToString();
                int x = 0, y = 0;
                if (Int32.TryParse(str1, out x) && Int32.TryParse(str2, out y))
                {
                    O_ID = y;
                    BillAmount = x;
                    return x;
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public static int PayBill(int Bill_Amt)
        {
            if (Bill_Amt < BillAmount)
                return -1;
            string connectionString = @"Data Source=LAPTOP-DNFN1MF7\BILLZTEE;Initial Catalog=Project;Integrated Security=True;";
            string Procedure_Name = "PayBill";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(Procedure_Name, connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter();
            param = command.Parameters.Add("@Amt_Paid", SqlDbType.Int);
            param.Value = Bill_Amt;
            param = command.Parameters.Add("@OID", SqlDbType.Int);
            param.Value = O_ID;
            param = command.Parameters.Add("@UName", SqlDbType.VarChar, 100);
            param.Value = l_u;
            param = command.Parameters.Add("@Amt", SqlDbType.Int);
            param.Value = BillAmount;

            SqlParameter Output_Param = command.Parameters.Add("@out", SqlDbType.Int);
            Output_Param.Direction = ParameterDirection.Output;
            Output_Param.Value = "";

            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                string str = Output_Param.Value.ToString();
                int x = 0;
                if (Int32.TryParse(str, out x))
                    return x;
                else
                    return -2;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -2;
            }
        }
        public static int CancelOrder()
        {
            string connectionString = @"Data Source=LAPTOP-DNFN1MF7\BILLZTEE;Initial Catalog=Project;Integrated Security=True;";
            string Procedure_Name = "CancelOrder";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(Procedure_Name, connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter();
            param = command.Parameters.Add("@OID", SqlDbType.Int);
            param.Value = O_ID;

            SqlParameter Output_Param = command.Parameters.Add("@out", SqlDbType.Int);
            Output_Param.Direction = ParameterDirection.Output;
            Output_Param.Value = "";

            try
            {
                connection.Open();
                int r = command.ExecuteNonQuery();
                connection.Close();
                string str = Output_Param.Value.ToString();
                int x = 0;
                if (Int32.TryParse(str, out x))
                    return x;
                else
                    return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 1;
            }
        }
        public static int Feedback(string feedback)
        {
            string connectionString = @"Data Source=LAPTOP-DNFN1MF7\BILLZTEE;Initial Catalog=Project;Integrated Security=True;";
            string Procedure_Name = "TakeFeedback";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(Procedure_Name, connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter();
            param = command.Parameters.Add("@UName", SqlDbType.VarChar, 100);
            param.Value = l_u;
            param = command.Parameters.Add("@OID", SqlDbType.Int);
            param.Value = O_ID;
            param = command.Parameters.Add("@Feedback", SqlDbType.VarChar, 100);
            param.Value = feedback;

            try
            {
                connection.Open();
                int r = command.ExecuteNonQuery();
                connection.Close();
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 1;
            }
        }

        public static SqlDataReader SearchByCategory(string searchbycategory)
        {
            string connectionString = @"Data Source=LAPTOP-DNFN1MF7\BILLZTEE;Initial Catalog=Project;Integrated Security=True;";
            string query = "SELECT * FROM dbo.SearchByCategory('" + searchbycategory + "')";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public static SqlDataReader SearchByName(string searchbyname)
        {
            string connectionString = @"Data Source=LAPTOP-DNFN1MF7\BILLZTEE;Initial Catalog=Project;Integrated Security=True;";
            string query = "SELECT * FROM dbo.SearchByName('" + searchbyname + "')";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public static int SeeEarning(DateTime earningdate)
        {
            string connectionString = @"Data Source=LAPTOP-DNFN1MF7\BILLZTEE;Initial Catalog=Project;Integrated Security=True;";
            string Procedure_Name = "SeeEarning";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(Procedure_Name, connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter();
            param = command.Parameters.Add("@Date", SqlDbType.Date);
            param.Value = earningdate;

            SqlParameter Output_Param = command.Parameters.Add("@out", SqlDbType.Int);
            Output_Param.Direction = ParameterDirection.Output;
            Output_Param.Value = "";

            try
            {
                connection.Open();
                int r = command.ExecuteNonQuery();
                connection.Close();
                string str = Output_Param.Value.ToString();
                if (str == "")
                    return 0;
                int x = 0;
                if (Int32.TryParse(str, out x))
                    return x;
                else
                    return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }
        public static int SeeEarningFromTo(DateTime startearningdate, DateTime endearningdate)
        {
            string connectionString = @"Data Source=LAPTOP-DNFN1MF7\BILLZTEE;Initial Catalog=Project;Integrated Security=True;";
            string Procedure_Name = "SeeEarningFromTo";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(Procedure_Name, connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter();
            param = command.Parameters.Add("@From", SqlDbType.Date);
            param.Value = startearningdate;
            param = command.Parameters.Add("@To", SqlDbType.Date);
            param.Value = endearningdate;

            SqlParameter Output_Param = command.Parameters.Add("@out", SqlDbType.Int);
            Output_Param.Direction = ParameterDirection.Output;
            Output_Param.Value = "";

            try
            {
                connection.Open();
                int r = command.ExecuteNonQuery();
                connection.Close();
                string str = Output_Param.Value.ToString();
                if (str == "")
                    return 0;
                int x = 0;
                if (Int32.TryParse(str, out x))
                    return x;
                else
                    return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        public static int AddEmpInfo(string EName, int EAge, string ESSN, string EPNo, string EAddress, string EDes, int ESal)
        {
            string connectionString = @"Data Source=LAPTOP-DNFN1MF7\BILLZTEE;Initial Catalog=Project;Integrated Security=True;";
            string Procedure_Name = "AddEmpInfo";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(Procedure_Name, connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter();
            param = command.Parameters.Add("@EName", SqlDbType.VarChar, 100);
            param.Value = EName;
            param = command.Parameters.Add("@EAge", SqlDbType.Int);
            param.Value = EAge;
            param = command.Parameters.Add("@ESSN", SqlDbType.VarChar, 15);
            param.Value = ESSN;
            param = command.Parameters.Add("@EPNo", SqlDbType.VarChar, 12);
            param.Value = EPNo;
            param = command.Parameters.Add("@EAddress", SqlDbType.VarChar, 100);
            param.Value = EAddress;
            param = command.Parameters.Add("@EDes", SqlDbType.VarChar, 100);
            param.Value = EDes;
            param = command.Parameters.Add("@ESal", SqlDbType.Int);
            param.Value = ESal;

            SqlParameter Output_Param = command.Parameters.Add("@out", SqlDbType.Int);
            Output_Param.Direction = ParameterDirection.Output;
            Output_Param.Value = "";
            int r = -2;
            try
            {
                connection.Open();
                r = command.ExecuteNonQuery();
                connection.Close();
                string str = Output_Param.Value.ToString();
                int x = 0;
                if (Int32.TryParse(str, out x))
                    return x;
                else
                    return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return r;
            }
        }
        public  static SqlDataReader ViewEmp()
        {
            string connectionString = @"Data Source=LAPTOP-DNFN1MF7\BILLZTEE;Initial Catalog=Project;Integrated Security=True;";
            string query = "SELECT * FROM Employee";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public static int RemEmpInfo(int EID)
        {
            string connectionString = @"Data Source=LAPTOP-DNFN1MF7\BILLZTEE;Initial Catalog=Project;Integrated Security=True;";
            string Procedure_Name = "RemEmpInfo";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(Procedure_Name, connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter();
            param = command.Parameters.Add("@EID", SqlDbType.Int);
            param.Value = EID;

            SqlParameter Output_Param = command.Parameters.Add("@out", SqlDbType.Int);
            Output_Param.Direction = ParameterDirection.Output;
            Output_Param.Value = "";
            int r = -2;
            try
            {
                connection.Open();
                r = command.ExecuteNonQuery();
                connection.Close();
                string str = Output_Param.Value.ToString();
                int x = 0;
                if (Int32.TryParse(str, out x))
                    return x;
                else
                    return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return r;
            }
        }
        public static int AddExpInfo(int EAmt, string EReason)
        {
            string connectionString = @"Data Source=LAPTOP-DNFN1MF7\BILLZTEE;Initial Catalog=Project;Integrated Security=True;";
            string Procedure_Name = "AddExpInfo";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(Procedure_Name, connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter();
            param = command.Parameters.Add("@EAmt", SqlDbType.Int);
            param.Value = EAmt;
            param = command.Parameters.Add("@EReason", SqlDbType.VarChar, 100);
            param.Value = EReason;

            SqlParameter Output_Param = command.Parameters.Add("@out", SqlDbType.Int);
            Output_Param.Direction = ParameterDirection.Output;
            Output_Param.Value = "";
            int r = -2;
            try
            {
                connection.Open();
                r = command.ExecuteNonQuery();
                connection.Close();
                string str = Output_Param.Value.ToString();
                int x = 0;
                if (Int32.TryParse(str, out x))
                    return x;
                else
                    return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return r;
            }
        }
        public static int AddItemInfo(string IName, string IPrice, string Ing, string Cat)
        {
            string connectionString = @"Data Source=LAPTOP-DNFN1MF7\BILLZTEE;Initial Catalog=Project;Integrated Security=True;";
            string Procedure_Name = "AddItemInfo";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(Procedure_Name, connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter();
            param = command.Parameters.Add("@IName", SqlDbType.VarChar, 100);
            param.Value = IName;
            param = command.Parameters.Add("@IPrice", SqlDbType.VarChar, 100);
            param.Value = IPrice;
            param = command.Parameters.Add("@Ing", SqlDbType.VarChar, 100);
            param.Value = Ing;
            param = command.Parameters.Add("@Cat", SqlDbType.VarChar, 100);
            param.Value = Cat;

            SqlParameter Output_Param = command.Parameters.Add("@out", SqlDbType.Int);
            Output_Param.Direction = ParameterDirection.Output;
            Output_Param.Value = "";
            int r = -2;
            try
            {
                connection.Open();
                r = command.ExecuteNonQuery();
                connection.Close();
                string str = Output_Param.Value.ToString();
                //int x = Int32.Parse(str);
                int x = 0;
                if (Int32.TryParse(str, out x))
                    return x;
                else
                    return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return r;
            }
        }

        public static SqlDataReader ViewUsers()
        {
            string connectionString = @"Data Source=LAPTOP-DNFN1MF7\BILLZTEE;Initial Catalog=Project;Integrated Security=True;";
            string query = "SELECT * FROM [User]";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public static int add_message(string name, string email, string sms)
        {
            string connectionString = @"Data Source=LAPTOP-DNFN1MF7\BILLZTEE;Initial Catalog=Project;Integrated Security=True;";
            string Procedure_Name = "add_message";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(Procedure_Name, connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter();
            command.Parameters.Add("@name", SqlDbType.VarChar, 20).Value = name;
            command.Parameters.Add("@email", SqlDbType.VarChar, 30).Value = email;
            command.Parameters.Add("@sms", SqlDbType.VarChar, 100).Value = sms;

            return 0;
        }


        public static SqlDataReader ShowFeedback()
        {
            string connectionString = @"Data Source=LAPTOP-DNFN1MF7\BILLZTEE;Initial Catalog=Project;Integrated Security=True;";
            string query = "SELECT * FROM Feedback";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public static string SeeProfit(int month, int year)
        {
            string connectionString = @"Data Source=LAPTOP-DNFN1MF7\BILLZTEE;Initial Catalog=Project;Integrated Security=True;";
            string Procedure_Name = "SeeProfit";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(Procedure_Name, connection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter param = new SqlParameter();
            param = command.Parameters.Add("@month", SqlDbType.Int);
            param.Value = month;
            param = command.Parameters.Add("@year", SqlDbType.Int);
            param.Value = year;

            SqlParameter Output_Param = command.Parameters.Add("@Sal_Sum", SqlDbType.VarChar, 100);
            Output_Param.Direction = ParameterDirection.Output;
            Output_Param.Value = "";
            SqlParameter Output_Param1 = command.Parameters.Add("@Exp_Sum", SqlDbType.VarChar, 100);
            Output_Param1.Direction = ParameterDirection.Output;
            Output_Param1.Value = "";
            SqlParameter Output_Param2 = command.Parameters.Add("@Earn_Sum", SqlDbType.VarChar, 100);
            Output_Param2.Direction = ParameterDirection.Output;
            Output_Param2.Value = "";
            SqlParameter Output_Param3 = command.Parameters.Add("@out", SqlDbType.VarChar, 100);
            Output_Param3.Direction = ParameterDirection.Output;
            Output_Param3.Value = "";

            try
            {
                connection.Open();
                int r = command.ExecuteNonQuery();
                connection.Close();
                string str_sal = Output_Param.Value.ToString();
                string str_exp = Output_Param1.Value.ToString();
                string str_earn = Output_Param2.Value.ToString();
                string str_out = Output_Param3.Value.ToString();
                if (str_out == "DateError")
                    return str_out;
                int x, y, z;
                if (!(Int32.TryParse(str_sal, out x)))
                    x = 0;
                if (!(Int32.TryParse(str_exp, out y)))
                    y = 0;
                if (!(Int32.TryParse(str_earn, out z)))
                    z = 0;
                int ans = z - (x + y);
                return ans.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
        }
        public static SqlDataReader GraphicalEarning()
        {
            string connectionString = @"Data Source=LAPTOP-DNFN1MF7\BILLZTEE;Initial Catalog=Project;Integrated Security=True;";
            string query = "SELECT * FROM GraphicalEarning";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                return reader;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}