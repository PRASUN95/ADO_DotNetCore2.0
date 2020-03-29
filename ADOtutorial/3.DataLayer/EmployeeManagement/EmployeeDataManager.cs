using Common;
using Common.Contracts;
using Common.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeDataManagement
{
    public class EmployeeDataManager : IEmployeeDbManager
    {
        private readonly IDataConnection _dbConnection;
        /// <summary>
        /// 
        /// </summary>
        public EmployeeDataManager(IDataConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Respone getAllEmployee()
        {
            List<Employee> employees = new List<Employee>();
            string responseCode = string.Empty;
            try
            {
                using (SqlCommand cmd = new SqlCommand("P_GET_ALL_EMPLOYEE", _dbConnection.getConn()))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id",0);
                    SqlParameter outputParameter = new SqlParameter("@ResponseCode", SqlDbType.VarChar,10);
                    outputParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outputParameter);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        employees.Add
                        (
                            new Employee()
                            {
                                Id = reader["Id"].ToString(),
                                Name = reader["Name"].ToString(),
                                Department = reader["Department"].ToString(),
                                Email = reader["Email"].ToString(),
                            }
                        );
                    }
                    reader.Close(); // reader must be closed before accessing output parameters 
                    responseCode = outputParameter.Value.ToString();
                }
            }
            catch (Exception e)
            {
                e.ToString();
                AppException appException = new AppException()
                {
                    ExceptionMessage = e.ToString(),
                    Machine = System.Environment.MachineName,
                    LogType = "Error",
                    Module = "EmployeeDataManager"
                };
                _dbConnection.LogException(appException);
            }
            Respone respone = new Respone()
            {
                Data = employees,
                Code = responseCode
            };
            return respone;
        }


        public Employee GetEmployee(string Id)
        {
            Employee employee = null;
            using (SqlCommand cmd = new SqlCommand("Select * from Employee where Id = @Id", _dbConnection.getConn()))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add(new SqlParameter("Id", Id));
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    employee = new Employee()
                    {
                        Id = reader["Id"].ToString(),
                        Name = reader["Name"].ToString(),
                        Department = reader["Department"].ToString(),
                        Email = reader["Email"].ToString(),
                    };
                }
            }
            return employee;
        }

        public string getName()
        {
            return "";
        }
    }
}
