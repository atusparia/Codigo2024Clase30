using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DStudent
    {
        //public List<Student> Listar(string firstName, string lastName, bool? EsActivo)
        public List<Student> Listar(string firstName, string lastName)
        {
            SqlCommand command = null;            
            SqlParameter sqlParameter = null;
            SqlParameter sqlParameter2 = null;
            List<Student> students = null;

            try
            {
                students = new List<Student>();

                using (SqlConnection conexion = new SqlConnection(Constantes._connectionString))
                {
                    conexion.Open();

                    command = new SqlCommand("USP_SearchStudent", conexion);
                    command.CommandType = CommandType.StoredProcedure;

                    sqlParameter = new SqlParameter("@FirstName", SqlDbType.NVarChar, 100);
                    sqlParameter.Value = firstName;
                    sqlParameter2 = new SqlParameter("@LastName", SqlDbType.NVarChar, 100);
                    sqlParameter2.Value = lastName;
                    //sqlParameter2 = new SqlParameter("@LastName", SqlDbType.Bit);
                    //sqlParameter2.Value = EsActivo;

                    command.Parameters.Add(sqlParameter);
                    command.Parameters.Add(sqlParameter2);


                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {


                        students.Add(new Student
                        {
                            StudentID = Convert.ToInt32(reader["StudentID"]),
                            FirstName = Convert.ToString(reader["FirstName"]),
                            LastName = Convert.ToString(reader["LastName"])
                        }
                       );
                    }

                }

            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                command = null;
                sqlParameter = null;
            }

            return students;

        }        

        public int Insert(Student student)
        {          
            using (SqlConnection connection = new SqlConnection(Constantes._connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("USP_InsertStudent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@FirstName", student.FirstName);
                    command.Parameters.AddWithValue("@@LastName", student.LastName);                    

                    /*
                    SqlParameter idOutput = new SqlParameter("@IdCabecera", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    command.Parameters.Add(idOutput);
                    */
                    command.ExecuteNonQuery();

                    //(int)idOutput.Value: Retorna el valor del parámetro de salida

                    //return (int)idOutput.Value;
                    return 0;
                }
            }

        }
    }
}
