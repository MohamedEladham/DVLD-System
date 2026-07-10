using System;
using DVLD_Models;
using DVLD_Infrastructure;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace DVLD_DAL
{
    public class clsPersonDAL
    {
        // Check For Exists Value
        public static bool NationalNumberExists(string nationalNumber)
        {
            bool isExists = false;

            string query = "Select 1 From Persons Where NationalNO = @NationalNO";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@NationalNO", System.Data.SqlDbType.VarChar, 250).Value = nationalNumber;
                connection.Open();
                object result = command.ExecuteScalar();
                isExists = result != null;
            }

            return isExists;
        }

        public static bool EmailExists(string email)
        {
            bool isExists = false;

            string query = "Select 1 From Persons Where Email = @Email";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@Email", System.Data.SqlDbType.VarChar, 550).Value = email;
                connection.Open();
                object result = command.ExecuteScalar();
                isExists = result != null;
            }

            return isExists;
        }

        public static bool EmailExists(string email, int personID)
        {
            bool isExists = false;

            string query = "Select 1 From Persons Where Email = @Email AND PersonID != @PersonID";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@PersonID", System.Data.SqlDbType.Int).Value = personID;
                command.Parameters.Add("@Email", System.Data.SqlDbType.VarChar, 550).Value = email;
                connection.Open();
                object result = command.ExecuteScalar();
                isExists = result != null;
            }

            return isExists;
        }

        public static bool PhoneExists(string phoneNumber)
        {
            bool isExists = false;

            string query = "Select 1 From Persons Where Phone = @Phone";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@Phone", System.Data.SqlDbType.VarChar, 50).Value = phoneNumber;
                connection.Open();
                object result = command.ExecuteScalar();
                isExists = result != null;
            }

            return isExists;
        }

        public static bool PhoneExists(string phoneNumber, int personID)
        {
            bool isExists = false;

            string query = "Select 1 From Persons Where Phone = @Phone AND PersonID != @PersonID";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@PersonID", System.Data.SqlDbType.Int).Value = personID;
                command.Parameters.Add("@Phone", System.Data.SqlDbType.VarChar, 50).Value = phoneNumber;
                connection.Open();
                object result = command.ExecuteScalar();
                isExists = result != null;
            }

            return isExists;
        }

        // >>

        private static clsPerson _MapReaderToPerson(SqlDataReader reader)
        {
            return new clsPerson
            {
                PersonID = (int)reader["PersonID"],
                NationalNO = Convert.ToString(reader["NationalNO"]),
                FirstName = Convert.ToString(reader["FirstName"]),
                SecondName = Convert.ToString(reader["SecondName"]),
                ThirdName = Convert.ToString(reader["ThirdName"]),
                LastName = Convert.ToString(reader["LastName"]),
                Gender = Convert.ToChar(reader["Gender"]),
                DateOfBirth = (DateTime)reader["DateOfBirth"],
                Email = Convert.ToString(reader["Email"]),
                Phone = Convert.ToString(reader["Phone"]),
                Address = Convert.ToString(reader["Address"]),
                NationalityCountryID = reader.IsDBNull(reader.GetOrdinal("NationalityCountryID")) ? null : (int?)reader["NationalityCountryID"],
                ImageName = Convert.ToString(reader["ImageName"]),
                IsDeleted = (bool)reader["IsDeleted"]
            };
        }


        private static clsPerson _MapReaderToDeletedPerson(SqlDataReader reader)
        {
            return new clsPerson
            {
                PersonID = (int)reader["PersonID"],
                NationalNO = Convert.ToString(reader["NationalNO"]),
                FirstName = Convert.ToString(reader["FirstName"]),
                SecondName = Convert.ToString(reader["SecondName"]),
                ThirdName = Convert.ToString(reader["ThirdName"]),
                LastName = Convert.ToString(reader["LastName"]),
                Gender = Convert.ToChar(reader["Gender"]),
                DateOfBirth = (DateTime)reader["DateOfBirth"],
                Email = Convert.ToString(reader["Email"]),
                Phone = Convert.ToString(reader["Phone"]),
                Address = Convert.ToString(reader["Address"]),
                NationalityCountryID = reader.IsDBNull(reader.GetOrdinal("NationalityCountryID")) ? null : (int?)reader["NationalityCountryID"],
                ImageName = Convert.ToString(reader["ImageName"]),
                IsDeleted = (bool)reader["IsDeleted"],
                DeletedAt = reader.IsDBNull(reader.GetOrdinal("DeletedAt")) ? null : (DateTime?)reader["DeletedAt"]
            };
        }

        public static clsPerson GetPersonByID(int personID)
        {
            clsPerson personInfo = null;

            string query = @"Select 
                                    [PersonID], 
                                    [NationalNO], 
                                    [FirstName], 
                                    [SecondName], 
                                    [ThirdName], 
                                    [LastName], 
                                    [Gender], 
                                    [DateOfBirth], 
                                    [Email], 
                                    [Phone], 
                                    [Address], 
                                    [NationalityCountryID], 
                                    [ImageName],
                                    [IsDeleted]
                                From Persons
                                Where PersonID = @PersonID";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@PersonID", System.Data.SqlDbType.Int).Value = personID;
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        personInfo = _MapReaderToPerson(reader);
                }
            }

            return personInfo;
        }

        public static List<clsPerson> GetAllPersonsInfo()
        {
            List<clsPerson> persons = new List<clsPerson>();

            string query = @"Select 
                                    [PersonID], 
                                    [NationalNO], 
                                    [FirstName], 
                                    [SecondName], 
                                    [ThirdName], 
                                    [LastName], 
                                    [Gender], 
                                    [DateOfBirth], 
                                    [Email], 
                                    [Phone], 
                                    [Address], 
                                    [NationalityCountryID], 
                                    [ImageName], 
                                    [IsDeleted]
                                From Persons WHERE IsDeleted = 0";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clsPerson person = _MapReaderToPerson(reader);
                        persons.Add(person);
                    }
                }
            }

            return persons;
        }

        public static List<clsPerson> GetAllDeletedPersonsInfo()
        {
            List<clsPerson> persons = new List<clsPerson>();

            string query = @"Select 
                                    [PersonID], 
                                    [NationalNO], 
                                    [FirstName], 
                                    [SecondName], 
                                    [ThirdName], 
                                    [LastName], 
                                    [Gender], 
                                    [DateOfBirth], 
                                    [Email], 
                                    [Phone], 
                                    [Address], 
                                    [NationalityCountryID], 
                                    [ImageName], 
                                    [IsDeleted],
                                    [DeletedAt]
                                From Persons WHERE IsDeleted = 1";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clsPerson person = _MapReaderToDeletedPerson(reader);
                        persons.Add(person);
                    }
                }
            }

            return persons;
        }

        public static bool AddNewPersonAndGetNewID(clsPerson person, out int newID)
        {
            newID = -1;

            string query = @"INSERT INTO Persons 
                                                ([NationalNO],
                                                [FirstName],
                                                [SecondName],
                                                [ThirdName],
                                                [LastName],
                                                [Gender],
                                                [DateOfBirth],
                                                [Email],
                                                [Phone], 
                                                [Address], 
                                                [NationalityCountryID], 
                                                [ImageName])
                                        VALUES 
                                                (@NationalNO,
                                                @FirstName,
                                                @SecondName,
                                                @ThirdName,
                                                @LastName,
                                                @Gender,
                                                @DateOfBirth,
                                                @Email,
                                                @Phone,
                                                @Address,
                                                @NationalityCountryID,
                                                @ImageName); 
                                        SELECT SCOPE_IDENTITY();";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@NationalNO", System.Data.SqlDbType.VarChar, 250).Value = person.NationalNO;
                command.Parameters.Add("@FirstName", System.Data.SqlDbType.NVarChar, 50).Value = person.FirstName;
                command.Parameters.Add("@SecondName", System.Data.SqlDbType.NVarChar, 50).Value = person.SecondName;
                command.Parameters.Add("@ThirdName", System.Data.SqlDbType.NVarChar, 50).Value = person.ThirdName;
                command.Parameters.Add("@LastName", System.Data.SqlDbType.NVarChar, 50).Value = person.LastName;
                command.Parameters.Add("@Gender", System.Data.SqlDbType.Char, 1).Value = person.Gender;
                command.Parameters.Add("@DateOfBirth", System.Data.SqlDbType.Date).Value = person.DateOfBirth;
                command.Parameters.Add("@Phone", System.Data.SqlDbType.VarChar, 50).Value = person.Phone;

                if (string.IsNullOrWhiteSpace(person.Email))
                    command.Parameters.Add("@Email", System.Data.SqlDbType.VarChar, 550).Value = DBNull.Value;
                else
                    command.Parameters.Add("@Email", System.Data.SqlDbType.VarChar, 550).Value = person.Email;

                if (string.IsNullOrWhiteSpace(person.Address))
                    command.Parameters.Add("@Address", System.Data.SqlDbType.NVarChar, 500).Value = DBNull.Value;
                else
                    command.Parameters.Add("@Address", System.Data.SqlDbType.NVarChar, 500).Value = person.Address;

                if (person.NationalityCountryID == null)
                    command.Parameters.Add("@NationalityCountryID", System.Data.SqlDbType.Int).Value = DBNull.Value;
                else
                    command.Parameters.Add("@NationalityCountryID", System.Data.SqlDbType.Int).Value = person.NationalityCountryID;

                if (string.IsNullOrWhiteSpace(person.ImageName))
                    command.Parameters.Add("@ImageName", System.Data.SqlDbType.VarChar, 1000).Value = DBNull.Value;
                else
                    command.Parameters.Add("@ImageName", System.Data.SqlDbType.VarChar, 1000).Value = person.ImageName;

                connection.Open();

                var result = command.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                    newID = Convert.ToInt32(result);
            }

            return newID > 0;
        }

        public static bool UpdatePersonInfo(clsPerson person)
        {
            bool isUpdate = false;

            string query = @"UPDATE Persons 
                                        SET
                                            [FirstName]   = @FirstName, 
                                            [SecondName]  = @SecondName, 
                                            [ThirdName]   = @ThirdName, 
                                            [LastName]    = @LastName, 
                                            [Gender]      = @Gender, 
                                            [DateOfBirth] = @DateOfBirth, 
                                            [Email]       = @Email, 
                                            [Phone]       = @Phone, 
                                            [Address]     = @Address, 
                                            [NationalityCountryID] = @NationalityCountryID, 
                                            [ImageName]   = @ImageName
                                        WHERE PersonID = @PersonID";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@FirstName", System.Data.SqlDbType.NVarChar, 50).Value = person.FirstName;
                command.Parameters.Add("@SecondName", System.Data.SqlDbType.NVarChar, 50).Value = person.SecondName;
                command.Parameters.Add("@ThirdName", System.Data.SqlDbType.NVarChar, 50).Value = person.ThirdName;
                command.Parameters.Add("@LastName", System.Data.SqlDbType.NVarChar, 50).Value = person.LastName;
                command.Parameters.Add("@Gender", System.Data.SqlDbType.Char, 1).Value = person.Gender;
                command.Parameters.Add("@DateOfBirth", System.Data.SqlDbType.Date).Value = person.DateOfBirth;

                if (string.IsNullOrWhiteSpace(person.Email))
                    command.Parameters.Add("@Email", System.Data.SqlDbType.VarChar, 550).Value = DBNull.Value;
                else
                    command.Parameters.Add("@Email", System.Data.SqlDbType.VarChar, 550).Value = person.Email;

                command.Parameters.Add("@Phone", System.Data.SqlDbType.VarChar, 50).Value = person.Phone;

                if (string.IsNullOrWhiteSpace(person.Address))
                    command.Parameters.Add("@Address", System.Data.SqlDbType.NVarChar, 500).Value = DBNull.Value;
                else
                    command.Parameters.Add("@Address", System.Data.SqlDbType.NVarChar, 500).Value = person.Address;


                if (person.NationalityCountryID == null)
                    command.Parameters.Add("@NationalityCountryID", System.Data.SqlDbType.Int).Value = DBNull.Value;
                else
                    command.Parameters.Add("@NationalityCountryID", System.Data.SqlDbType.Int).Value = person.NationalityCountryID;

                if (string.IsNullOrWhiteSpace(person.ImageName))
                    command.Parameters.Add("@ImageName", System.Data.SqlDbType.VarChar, 1000).Value = DBNull.Value;
                else
                    command.Parameters.Add("@ImageName", System.Data.SqlDbType.VarChar, 1000).Value = person.ImageName;

                command.Parameters.Add("@PersonID", System.Data.SqlDbType.Int).Value = person.PersonID;

                connection.Open();

                isUpdate = (command.ExecuteNonQuery() > 0);
            }

            return isUpdate;
        }

        public static bool SoftDeletePerson(int personID)
        {
            bool isDeleted = false;

            string query = @"Update Persons 
                                        Set 
		                                IsDeleted = 1,
		                                DeletedAt = GETDATE()
		                                Where PersonID = @PersonID AND IsDeleted = 0";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@PersonID", System.Data.SqlDbType.Int).Value = personID;

                connection.Open();

                isDeleted = (command.ExecuteNonQuery() > 0);
            }

            return isDeleted;
        }

        public static bool RestoreDeletedPerson(int personID)
        {
            bool isRestored = false;

            string query = @"Update Persons 
                                        Set 
		                                IsDeleted = 0,
		                                DeletedAt = null
		                                Where PersonID = @PersonID AND IsDeleted = 1";

            using (SqlConnection connection = new SqlConnection(clsConnectionsStrings.ConnectionStringTODB_DVLD2))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@PersonID", System.Data.SqlDbType.Int).Value = personID;

                connection.Open();

                isRestored = (command.ExecuteNonQuery() > 0);
            }

            return isRestored;
        }
    }
}
