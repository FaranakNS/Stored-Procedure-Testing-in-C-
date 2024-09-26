using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Data.SqlClient;


namespace DataConnect
{
    internal class Program
    {
        static void GetProgramExample()
        {
            SqlConnection MyDataSource = new();
            MyDataSource.ConnectionString = @"Persist Security Info=False; Database=fnasoori1;User ID=fnasoori1; Password=D$xil3938;Server=dev1.baist.ca;";
            MyDataSource.Open();

            SqlCommand ExampleCommand = new();
            {
                ExampleCommand.Connection = MyDataSource;
                ExampleCommand.CommandType = CommandType.StoredProcedure;
                ExampleCommand.CommandText = "GetProgram";

            }
            SqlDataReader ExampleDataReader;
            ExampleDataReader = ExampleCommand.ExecuteReader();

            if (ExampleDataReader.HasRows)
            {
                Console.WriteLine("Coloums");
                Console.WriteLine("-----");

                for (int Index = 0; Index < ExampleDataReader.FieldCount; Index++)
                {

                    Console.WriteLine(ExampleDataReader.GetName(Index));

                }
                Console.WriteLine("Values");
                Console.WriteLine("_");

                while (ExampleDataReader.Read())
                {
                    for (int Index = 0; Index < ExampleDataReader.FieldCount; Index++)
                    {
                        Console.WriteLine(ExampleDataReader[Index].ToString());
                    }
                    Console.WriteLine("_");
                }

                ExampleDataReader.Close();
                MyDataSource.Close();
            }
        }
        static void AddProgramExample()
        {

            //Console.WriteLine("  AddProgramExecuteNonQueryExample");
            //connectin first to sql

            SqlConnection MyDataSource;
            MyDataSource = new();
            MyDataSource.ConnectionString = @"Persist Security Info=False; Database=fnasoori1;User ID=fnasoori1; Password=D$xil3938;Server=dev1.baist.ca;";
            MyDataSource.Open();

            SqlCommand ExampleCommand = new();
            ExampleCommand.Connection = MyDataSource;
            ExampleCommand.CommandType = CommandType.StoredProcedure;
            ExampleCommand.CommandText = "AddProgram";

            SqlParameter ExampleCommandParameter;

            ExampleCommandParameter = new()
            {
                ParameterName = "@ProgramCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "BAIST"
            };
            ExampleCommand.Parameters.Add(ExampleCommandParameter);
            ExampleCommandParameter = new()
            {
                ParameterName = "@Description",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "ISMAjor"
            };
            ExampleCommand.Parameters.Add(ExampleCommandParameter);
            ExampleCommand.ExecuteNonQuery();

            MyDataSource.Close();
            Console.WriteLine("Success- Executenon Query");
        }

        static void AddStudentExample()
        {

            SqlConnection MyDataSource;
            MyDataSource = new();
            MyDataSource.ConnectionString = @"Persist Security Info=False; Database=fnasoori1;User ID=fnasoori1; Password=D$xil3938;Server=dev1.baist.ca;";
            MyDataSource.Open();

            SqlCommand ExampleCommand = new();
            ExampleCommand.Connection = MyDataSource;
            ExampleCommand.CommandType = CommandType.StoredProcedure;
            ExampleCommand.CommandText = "AddStudent";

            SqlParameter ExampleCommandParameter;

            ExampleCommandParameter = new()
            {
                ParameterName = "@StudentID",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "S001"
            };
            ExampleCommand.Parameters.Add(ExampleCommandParameter);
            ExampleCommandParameter = new()
            {
                ParameterName = "@FirstName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "Farah"
            };
            ExampleCommand.Parameters.Add(ExampleCommandParameter);
            ExampleCommandParameter = new()
            {
                ParameterName = "@LastName",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "Nasoori"
            };
            ExampleCommand.Parameters.Add(ExampleCommandParameter);
            ExampleCommandParameter = new()
            {
                ParameterName = "@Email",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "frh@nait.ca"
            };
            ExampleCommandParameter = new()
            {
                ParameterName = "@ProgramCode",
                SqlDbType = SqlDbType.VarChar,
                Direction = ParameterDirection.Input,
                SqlValue = "CS101"
            };
            ExampleCommand.Parameters.Add(ExampleCommandParameter);
            ExampleCommand.ExecuteNonQuery();

            MyDataSource.Close();
            Console.WriteLine("Success- Student Added");
        }

        static void UpdateStudentExample()
        {
           
            string connectionString = @"Persist Security Info=False; Database=fnasoori1;User ID=fnasoori1; Password=D$xil3938;Server=dev1.baist.ca;";

           
            using (SqlConnection myDataSource = new SqlConnection(connectionString))
            {
                try
                {
                    myDataSource.Open();
                    Console.WriteLine("Connected to the database successfully.");

                    using (SqlCommand exampleCommand = new SqlCommand("UpdateStudent", myDataSource))
                    {
                        exampleCommand.CommandType = CommandType.StoredProcedure;

                        
                        SqlParameter returnParameter = new SqlParameter
                        {
                            ParameterName = "@ReturnVal", 
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.ReturnValue
                        };
                        exampleCommand.Parameters.Add(returnParameter);

                      
                        SqlParameter studentIdParam = new SqlParameter
                        {
                            ParameterName = "@StudentID",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 10, 
                            Direction = ParameterDirection.Input,
                            Value = "S001" 
                        };
                        exampleCommand.Parameters.Add(studentIdParam);

                        
                        SqlParameter firstNameParam = new SqlParameter
                        {
                            ParameterName = "@FirstName",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 25,
                            Direction = ParameterDirection.Input,
                            Value = (object)"Farah Updated" ?? DBNull.Value 
                        };
                        exampleCommand.Parameters.Add(firstNameParam);

                       
                        SqlParameter lastNameParam = new SqlParameter
                        {
                            ParameterName = "@LastName",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 25,
                            Direction = ParameterDirection.Input,
                            Value = (object)"Doe" ?? DBNull.Value
                        };
                        exampleCommand.Parameters.Add(lastNameParam);

                    
                        SqlParameter emailParam = new SqlParameter
                        {
                            ParameterName = "@Email",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 50,
                            Direction = ParameterDirection.Input,
                            Value = (object)"farah.updated@nait.ca" ?? DBNull.Value
                        };
                        exampleCommand.Parameters.Add(emailParam);

                    
                        SqlParameter programCodeParam = new SqlParameter
                        {
                            ParameterName = "@ProgramCode",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 10,
                            Direction = ParameterDirection.Input,
                            Value = (object)"CS101" ?? DBNull.Value
                        };
                        exampleCommand.Parameters.Add(programCodeParam);

                      
                        exampleCommand.ExecuteNonQuery();

                       
                        int returnCode = (int)(returnParameter.Value ?? 1); // Default to 1 if null

                        
                        if (returnCode == 0)
                        {
                            Console.WriteLine("Success - Student Updated");
                        }
                        else
                        {
                            Console.WriteLine($"Failure - Student Update Failed with Return Code: {returnCode}");
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Error: {ex.Message}");
                   
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Error: {ex.Message}");
                   
                }
            }
        }

        static void DeleteStudentExample()
        {
            // Define the connection string (consider securing this in a real application)
            string connectionString = @"Persist Security Info=False; Database=fnasoori1;User ID=fnasoori1; Password=D$xil3938;Server=dev1.baist.ca;";

            // Initialize the SQL connection with 'using' for automatic disposal
            using (SqlConnection myDataSource = new SqlConnection(connectionString))
            {
                try
                {
                    myDataSource.Open();
                    Console.WriteLine("Connected to the database successfully.");

                    using (SqlCommand exampleCommand = new SqlCommand("DeleteStudent", myDataSource))
                    {
                        exampleCommand.CommandType = CommandType.StoredProcedure;

                        // Add the return value parameter first
                        SqlParameter returnParameter = new SqlParameter
                        {
                            ParameterName = "@ReturnVal", // Name can be arbitrary
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.ReturnValue
                        };
                        exampleCommand.Parameters.Add(returnParameter);

                        // Add input parameter @StudentID (Required)
                        SqlParameter studentIdParam = new SqlParameter
                        {
                            ParameterName = "@StudentID",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 10, // As defined in the stored procedure
                            Direction = ParameterDirection.Input,
                            Value = "S001" // The StudentID to delete
                        };
                        exampleCommand.Parameters.Add(studentIdParam);

                        // Execute the stored procedure
                        exampleCommand.ExecuteNonQuery();

                        // Retrieve the return value
                        int returnCode = (int)(returnParameter.Value ?? 1); // Default to 1 if null

                        // Check the return code
                        if (returnCode == 0)
                        {
                            Console.WriteLine("Success - Student Deleted");
                        }
                        else
                        {
                            Console.WriteLine($"Failure - Student Deletion Failed with Return Code: {returnCode}");
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Error: {ex.Message}");
                    // Optionally, log the error or handle it as needed
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Error: {ex.Message}");
                    // Optionally, log the error or handle it as needed
                }
            }
        }

        static void GetStudentExample()
        {
            // Define the connection string (consider securing this in a real application)
            string connectionString = @"Persist Security Info=False; Database=fnasoori1;User ID=fnasoori1; Password=D$xil3938;Server=dev1.baist.ca;";

            // Initialize the SQL connection with 'using' for automatic disposal
            using (SqlConnection myDataSource = new SqlConnection(connectionString))
            {
                try
                {
                    myDataSource.Open();
                    Console.WriteLine("Connected to the database successfully.");

                    using (SqlCommand exampleCommand = new SqlCommand("GetStudent", myDataSource))
                    {
                        exampleCommand.CommandType = CommandType.StoredProcedure;

                        // Add the return value parameter
                        SqlParameter returnParameter = new SqlParameter
                        {
                            ParameterName = "@ReturnVal", // Arbitrary name for return value
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.ReturnValue
                        };
                        exampleCommand.Parameters.Add(returnParameter);

                        // Execute the stored procedure and read data
                        using (SqlDataReader reader = exampleCommand.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                Console.WriteLine("Student Records:");
                                Console.WriteLine("-------------------------------------------------");
                                Console.WriteLine("{0,-10} {1,-15} {2,-15} {3,-25} {4,-10}", "ID", "First Name", "Last Name", "Email", "Program");
                                Console.WriteLine("-------------------------------------------------");

                                while (reader.Read())
                                {
                                    string studentId = reader["StudentID"] != DBNull.Value ? reader["StudentID"].ToString() : "N/A";
                                    string firstName = reader["FirstName"] != DBNull.Value ? reader["FirstName"].ToString() : "N/A";
                                    string lastName = reader["LastName"] != DBNull.Value ? reader["LastName"].ToString() : "N/A";
                                    string email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : "N/A";
                                    string programCode = reader["ProgramCode"] != DBNull.Value ? reader["ProgramCode"].ToString() : "N/A";

                                    Console.WriteLine("{0,-10} {1,-15} {2,-15} {3,-25} {4,-10}", studentId, firstName, lastName, email, programCode);
                                }
                            }
                            else
                            {
                                Console.WriteLine("No student records found.");
                            }
                        }

                        // Retrieve the return value
                        int returnCode = (int)(returnParameter.Value ?? 1); // Default to 1 if null

                        // Check the return code
                        if (returnCode == 0)
                        {
                            Console.WriteLine("\nSuccess - Retrieved student records.");
                        }
                        else
                        {
                            Console.WriteLine($"\nFailure - GetStudent Failed with Return Code: {returnCode}");
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Error: {ex.Message}");
                    // Optionally, log the error or handle it as needed
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Error: {ex.Message}");
                    // Optionally, log the error or handle it as needed
                }
            }
        }

        static void GetStudentsByProgramExample()
        {
            // Define the connection string (consider securing this in a real application)
            string connectionString = @"Persist Security Info=False; Database=fnasoori1;User ID=fnasoori1; Password=D$xil3938;Server=dev1.baist.ca;";

            // Initialize the SQL connection with 'using' for automatic disposal
            using (SqlConnection myDataSource = new SqlConnection(connectionString))
            {
                try
                {
                    myDataSource.Open();
                    Console.WriteLine("Connected to the database successfully.\n");

                    using (SqlCommand exampleCommand = new SqlCommand("GetStudentsByProgram", myDataSource))
                    {
                        exampleCommand.CommandType = CommandType.StoredProcedure;

                        // Add the return value parameter
                        SqlParameter returnParameter = new SqlParameter
                        {
                            ParameterName = "@ReturnVal", // Arbitrary name for return value
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.ReturnValue
                        };
                        exampleCommand.Parameters.Add(returnParameter);

                        // Add input parameter @ProgramCode (Required)
                        Console.Write("Enter Program Code to retrieve students: ");
                        string programCodeInput = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(programCodeInput))
                        {
                            Console.WriteLine("Program Code cannot be empty.");
                            return;
                        }

                        SqlParameter programCodeParam = new SqlParameter
                        {
                            ParameterName = "@ProgramCode",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 10, // As defined in the stored procedure
                            Direction = ParameterDirection.Input,
                            Value = programCodeInput
                        };
                        exampleCommand.Parameters.Add(programCodeParam);

                        // Execute the stored procedure and read data
                        using (SqlDataReader reader = exampleCommand.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                Console.WriteLine("\nStudent Records:");
                                Console.WriteLine("-----------------------------------------------------------------------------------");
                                Console.WriteLine("{0,-10} {1,-15} {2,-15} {3,-25} {4,-10}", "ID", "First Name", "Last Name", "Email", "Program");
                                Console.WriteLine("-----------------------------------------------------------------------------------");

                                while (reader.Read())
                                {
                                    string studentId = reader["StudentID"] != DBNull.Value ? reader["StudentID"].ToString() : "N/A";
                                    string firstName = reader["FirstName"] != DBNull.Value ? reader["FirstName"].ToString() : "N/A";
                                    string lastName = reader["LastName"] != DBNull.Value ? reader["LastName"].ToString() : "N/A";
                                    string email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : "N/A";
                                    string programCode = reader["ProgramCode"] != DBNull.Value ? reader["ProgramCode"].ToString() : "N/A";

                                    Console.WriteLine("{0,-10} {1,-15} {2,-15} {3,-25} {4,-10}", studentId, firstName, lastName, email, programCode);
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nNo student records found for the provided ProgramCode.");
                            }
                        }

                        // Retrieve the return value
                        int returnCode = (int)(returnParameter.Value ?? 1); // Default to 1 if null

                        // Check the return code
                        if (returnCode == 0)
                        {
                            Console.WriteLine("\nSuccess - Retrieved student records.");
                        }
                        else
                        {
                            Console.WriteLine($"\nFailure - GetStudentsByProgram Failed with Return Code: {returnCode}");
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"\nSQL Error: {ex.Message}");
                    // Optionally, log the error or handle it as needed
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nGeneral Error: {ex.Message}");
                    // Optionally, log the error or handle it as needed
                }
            }
        }

        static void GetCustomersByCountryExample()
        {
            // Define the connection string (consider securing this in a real application)
            string connectionString = @"Persist Security Info=False; Database=Northwind;User ID=fnasoori1; Password=D$xil3938;Server=dev1.baist.ca;";

            // Initialize the SQL connection with 'using' for automatic disposal
            using (SqlConnection myDataSource = new SqlConnection(connectionString))
            {
                try
                {
                    myDataSource.Open();
                    Console.WriteLine("Connected to the database successfully.\n");

                    using (SqlCommand exampleCommand = new SqlCommand("fnasoori1.GetCustomersByCountry", myDataSource))
                    {
                        exampleCommand.CommandType = CommandType.StoredProcedure;

                        // Add the return value parameter
                        SqlParameter returnParameter = new SqlParameter
                        {
                            ParameterName = "@ReturnCode", // Renamed for clarity
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.ReturnValue
                        };
                        exampleCommand.Parameters.Add(returnParameter);

                        // Add input parameter @Country (Required)
                        Console.Write("Enter Country to retrieve customers: ");
                        string countryInput = Console.ReadLine();

                        if (string.IsNullOrWhiteSpace(countryInput))
                        {
                            Console.WriteLine("Country cannot be empty.");
                            return;
                        }

                        SqlParameter countryParam = new SqlParameter
                        {
                            ParameterName = "@Country",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 15, // As defined in the stored procedure
                            Direction = ParameterDirection.Input,
                            Value = countryInput.Trim() // Trim to remove any leading/trailing spaces
                        };
                        exampleCommand.Parameters.Add(countryParam);

                        // Execute the stored procedure and read data
                        using (SqlDataReader reader = exampleCommand.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                // Header with Delimiters
                                Console.WriteLine("\nCustomer Records:");
                                Console.WriteLine("{0,-12} | {1,-30} | {2,-25} | {3,-25} | {4,-35} | {5,-15} | {6,-10} | {7,-12} | {8,-20} | {9,-20}",
                                    "CustomerID", "CompanyName", "ContactName", "ContactTitle", "Address", "City", "Region", "PostalCode", "Phone", "Fax");

                                // Separator Line
                                Console.WriteLine(new string('-', 12) + "-+-" +
                                                  new string('-', 30) + "-+-" +
                                                  new string('-', 25) + "-+-" +
                                                  new string('-', 25) + "-+-" +
                                                  new string('-', 35) + "-+-" +
                                                  new string('-', 15) + "-+-" +
                                                  new string('-', 10) + "-+-" +
                                                  new string('-', 12) + "-+-" +
                                                  new string('-', 20) + "-+-" +
                                                  new string('-', 20));

                                // Data Rows with Delimiters
                                while (reader.Read())
                                {
                                    string customerId = reader["CustomerID"] != DBNull.Value ? reader["CustomerID"].ToString() : "N/A";
                                    string companyName = reader["CompanyName"] != DBNull.Value ? reader["CompanyName"].ToString() : "N/A";
                                    string contactName = reader["ContactName"] != DBNull.Value ? reader["ContactName"].ToString() : "N/A";
                                    string contactTitle = reader["ContactTitle"] != DBNull.Value ? reader["ContactTitle"].ToString() : "N/A";
                                    string address = reader["Address"] != DBNull.Value ? reader["Address"].ToString() : "N/A";
                                    string city = reader["City"] != DBNull.Value ? reader["City"].ToString() : "N/A";
                                    string region = reader["Region"] != DBNull.Value ? reader["Region"].ToString() : "N/A";
                                    string postalCode = reader["PostalCode"] != DBNull.Value ? reader["PostalCode"].ToString() : "N/A";
                                    string phone = reader["Phone"] != DBNull.Value ? reader["Phone"].ToString() : "N/A";
                                    string fax = reader["Fax"] != DBNull.Value ? reader["Fax"].ToString() : "N/A";

                                    Console.WriteLine("{0,-12} | {1,-30} | {2,-25} | {3,-25} | {4,-35} | {5,-15} | {6,-10} | {7,-12} | {8,-20} | {9,-20}",
                                        customerId, companyName, contactName, contactTitle, address, city, region, postalCode, phone, fax);
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nNo customer records found for the provided country.");
                            }
                        }

                        // Retrieve the return value
                        int returnCode = (int)(returnParameter.Value ?? 1); // Default to 1 if null

                        // Check the return code
                        if (returnCode == 0)
                        {
                            Console.WriteLine("\nSuccess - Retrieved customer records.");
                        }
                        else
                        {
                            Console.WriteLine($"\nFailure - GetCustomersByCountry Failed with Return Code: {returnCode}");
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"\nSQL Error: {ex.Message}");
                    // Optionally, log the error or handle it as needed
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nGeneral Error: {ex.Message}");
                    // Optionally, log the error or handle it as needed
                }
            }
        }

        static void GetCategoryById()
        {
            // Define the connection string (consider securing this in a real application)
            string connectionString = @"Persist Security Info=False; Database=Northwind;User ID=fnasoori1; Password=D$xil3938;Server=dev1.baist.ca;";

            // Initialize the SQL connection with 'using' for automatic disposal
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connected to the database successfully.\n");

                    using (SqlCommand command = new SqlCommand("fnasoori1.GetCategory", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add the return value parameter
                        SqlParameter returnParameter = new SqlParameter
                        {
                            ParameterName = "@ReturnCode",
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.ReturnValue
                        };
                        command.Parameters.Add(returnParameter);

                        // Prompt the user to enter a CategoryID
                        Console.Write("Enter CategoryID to retrieve category details: ");
                        string input = Console.ReadLine();

                        if (!int.TryParse(input, out int categoryId))
                        {
                            Console.WriteLine("Invalid input. Please enter a valid integer for CategoryID.");
                            return;
                        }

                        // Add the @CategoryID input parameter
                        SqlParameter categoryIdParam = new SqlParameter
                        {
                            ParameterName = "@CategoryID",
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Input,
                            Value = categoryId
                        };
                        command.Parameters.Add(categoryIdParam);

                        // Execute the stored procedure and read data
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                Console.WriteLine("\nCategory Details:");
                                Console.WriteLine("---------------------------------------------------");
                                Console.WriteLine("{0,-12} | {1,-25} | {2}", "CategoryID", "CategoryName", "Description");
                                Console.WriteLine("---------------------------------------------------");

                                while (reader.Read())
                                {
                                    int retrievedCategoryId = reader["CategoryID"] != DBNull.Value ? Convert.ToInt32(reader["CategoryID"]) : 0;
                                    string categoryName = reader["CategoryName"] != DBNull.Value ? reader["CategoryName"].ToString() : "N/A";
                                    string description = reader["Description"] != DBNull.Value ? reader["Description"].ToString() : "N/A";

                                    Console.WriteLine("{0,-12} | {1,-25} | {2}", retrievedCategoryId, categoryName, description);
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nNo category found with the provided CategoryID.");
                            }
                        }

                        // Retrieve the return value
                        int returnCode = (int)(returnParameter.Value ?? 1); // Default to 1 if null

                        // Check the return code
                        if (returnCode == 0)
                        {
                            Console.WriteLine("\nSuccess - Retrieved category details.");
                        }
                        else
                        {
                            Console.WriteLine($"\nFailure - GetCategory Failed with Return Code: {returnCode}");
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"\nSQL Error: {ex.Message}");
                    // Optionally, log the error or handle it as needed
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nGeneral Error: {ex.Message}");
                    // Optionally, log the error or handle it as needed
                }
            }
        }

        static void GetProductsByCategory()
        {
            // Connection string definition
            string connectionString = @"Persist Security Info=False; Database=Northwind;User ID=fnasoori1; Password=D$xil3938;Server=dev1.baist.ca;";

            // Using statement ensures the connection is closed properly
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Connected to the database successfully.\n");

                    using (SqlCommand command = new SqlCommand("fnasoori1.GetProductsByCategory", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Return parameter to capture the stored procedure's return code
                        SqlParameter returnParameter = new SqlParameter
                        {
                            ParameterName = "@ReturnCode",
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.ReturnValue
                        };
                        command.Parameters.Add(returnParameter);

                        // Prompt user for CategoryID
                        Console.Write("Enter CategoryID to retrieve products: ");
                        string input = Console.ReadLine();

                        // Validate input
                        if (!int.TryParse(input, out int categoryId))
                        {
                            Console.WriteLine("Invalid input. Please enter a valid integer for CategoryID.");
                            return;
                        }

                        // Optional: Validate that CategoryID is positive
                        if (categoryId <= 0)
                        {
                            Console.WriteLine("CategoryID must be a positive integer.");
                            return;
                        }

                        // Add @CategoryID parameter
                        SqlParameter categoryIdParam = new SqlParameter
                        {
                            ParameterName = "@CategoryID",
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Input,
                            Value = categoryId
                        };
                        command.Parameters.Add(categoryIdParam);

                        // Execute the stored procedure
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                Console.WriteLine("\nProduct Details:");
                                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine("{0,-10} | {1,-30} | {2,-30} | {3,-20} | {4,-10} | {5,-15} | {6,-15} | {7,-15} | {8,-12}",
                                    "ProductID", "ProductName", "SupplierCompanyName", "QuantityPerUnit", "UnitPrice", "UnitsInStock", "UnitsOnOrder", "ReORD", "Discontinued");
                                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------");

                                while (reader.Read())
                                {
                                    int productId = reader["ProductID"] != DBNull.Value ? Convert.ToInt32(reader["ProductID"]) : 0;
                                    string productName = reader["ProductName"] != DBNull.Value ? reader["ProductName"].ToString() : "N/A";
                                    string supplierCompanyName = reader["SupplierCompanyName"] != DBNull.Value ? reader["SupplierCompanyName"].ToString() : "N/A";
                                    string quantityPerUnit = reader["QuantityPerUnit"] != DBNull.Value ? reader["QuantityPerUnit"].ToString() : "N/A";
                                    decimal unitPrice = reader["UnitPrice"] != DBNull.Value ? Convert.ToDecimal(reader["UnitPrice"]) : 0;
                                    short unitsInStock = reader["UnitsInStock"] != DBNull.Value ? Convert.ToInt16(reader["UnitsInStock"]) : (short)0;
                                    short unitsOnOrder = reader["UnitsOnOrder"] != DBNull.Value ? Convert.ToInt16(reader["UnitsOnOrder"]) : (short)0;
                                    short reorderLevel = reader["ReorderLevel"] != DBNull.Value ? Convert.ToInt16(reader["ReorderLevel"]) : (short)0;
                                    bool discontinued = reader["Discontinued"] != DBNull.Value ? Convert.ToBoolean(reader["Discontinued"]) : false;

                                    Console.WriteLine("{0,-10} | {1,-30} | {2,-30} | {3,-20} | {4,-10:C} | {5,-15} | {6,-15} | {7,-15} | {8,-12}",
                                        productId, productName, supplierCompanyName, quantityPerUnit, unitPrice, unitsInStock, unitsOnOrder, reorderLevel, discontinued);
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nNo products found for the provided CategoryID.");
                            }
                        }

                        // Retrieve the return value
                        int returnCode = (int)(returnParameter.Value ?? 1); // Default to 1 if null

                        // Check the return code
                        if (returnCode == 0)
                        {
                            Console.WriteLine("\nSuccess - Retrieved product details.");
                        }
                        else
                        {
                            Console.WriteLine($"\nFailure - GetProductsByCategory Failed with Return Code: {returnCode}");
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"\nSQL Error: {ex.Message}");
                    // Optionally, log the error or handle it as needed
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nGeneral Error: {ex.Message}");
                    // Optionally, log the error or handle it as needed
                }
            }
        }


        static void Main()
        {
            // AddProgramExample();
            // GetProgramExample();
            // AddStudentExample();
            //UpdateStudentExample();
            //DeleteStudentExample();
            // GetStudentExample();
            // GetStudentsByProgramExample();
            //GetCustomersByCountryExample();
            // GetCategoryById();
            GetProductsByCategory();

        }









    }
}

