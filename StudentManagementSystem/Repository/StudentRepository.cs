using Dapper;
using Microsoft.Data.SqlClient;
using StudentManagementSystem.Interface;
using StudentManagementSystem.Models;
using System.Data;

namespace StudentManagementSystem.Repository
{
    /// <summary>
    /// Handles all database operations related to Student.
  
    /// </summary>
    public class StudentRepository : IStudentInterface
    {
        private readonly string _connectionString;

        /// <summary>
        /// Constructor - inject configuration to get connection string
        /// </summary>
        public StudentRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("constr");
        }

        #region Create Student

        /// <summary>
        /// Create new student in database
        /// </summary>
        public async Task<CreateStudentResponse> CreateNewStudent(CreateStudentRequest request)
        {
            var response = new CreateStudentResponse();

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Name", request.Name);
                parameters.Add("@Email", request.Email);
                parameters.Add("@Age", request.Age);
                parameters.Add("@Course", request.Course);

                using var connection = new SqlConnection(_connectionString);

                var result = await connection.QueryFirstOrDefaultAsync<CreateStudentResponse>(
                    "sp_CreateStudent",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                if (result == null)
                {
                    return new CreateStudentResponse
                    {
                        Message = "Failed to create student",
                        Success = "false",
                        Code = 500
                    };
                }

                return new CreateStudentResponse
                {
                    Message = "Student created successfully",
                    Success = "true",
                    Code = 201,
                    Name = result.Name,
                    Email = result.Email,
                    Age = result.Age,
                    Course = result.Course,
                    CreatedDate= result.CreatedDate
                };
            }
            catch (Exception ex)
            {
                return new CreateStudentResponse
                {
                    Message = ex.Message,
                    Success = "false",
                    Code = 500
                };
            }
        }

        #endregion

        #region Get All Students

        /// <summary>
        /// Fetch all students from database
        /// </summary>
        public async Task<StudentListResponse> AllStudent()
        {
            var response = new StudentListResponse
            {
                StudentData = new List<StudentData>()
            };

            try
            {
                using var connection = new SqlConnection(_connectionString);

                var result = await connection.QueryAsync<BasicStudentData>(
                    "sp_AllStudents",
                    commandType: CommandType.StoredProcedure
                );

                foreach (var item in result)
                {
                    // Set common response once
                    if (response.StudentData.Count == 0)
                    {
                        response.Message = item.Message;
                        response.Code = item.Code;
                        response.Success = item.Success;
                    }

                    response.StudentData.Add(new StudentData
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Email = item.Email,
                        Course = item.Course,
                        Age = item.Age,
                        CreatedDate=item.CreatedDate
                    });
                }

                return response;
            }
            catch (Exception ex)
            {
                return new StudentListResponse
                {
                    Message = ex.Message,
                    Code = 500,
                    Success = "false",
                    StudentData = new List<StudentData>()
                };
            }
        }

        #endregion

        #region Update Student

        /// <summary>
        /// Update existing student details
        /// </summary>
        public async Task<CommonResponse> UpdateStudent(UpdateStudentRequest request)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", request.Id);
                parameters.Add("@Name", request.Name);
                parameters.Add("@Course", request.Course);
                parameters.Add("@Email", request.Email);
                parameters.Add("@Age", request.Age);

                using var connection = new SqlConnection(_connectionString);

                return await connection.QueryFirstOrDefaultAsync<CommonResponse>(
                    "sp_UpdateStudent",
                    parameters,
                    commandType: CommandType.StoredProcedure
                )
                ?? new CommonResponse
                {
                    Message = "Update failed",
                    Code = 500,
                    Success = "false"
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse
                {
                    Message = ex.Message,
                    Code = 500,
                    Success = "false"
                };
            }
        }

        #endregion

        #region Delete Student

        /// <summary>
        /// Delete student by Id
        /// </summary>
        public async Task<CommonResponse> DeleteStudent(int? studentId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", studentId);

                using var connection = new SqlConnection(_connectionString);

                return await connection.QueryFirstOrDefaultAsync<CommonResponse>(
                    "sp_DeleteStudent",
                    parameters,
                    commandType: CommandType.StoredProcedure
                )
                ?? new CommonResponse
                {
                    Message = "Delete failed",
                    Code = 500,
                    Success = "false"
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse
                {
                    Message = ex.Message,
                    Code = 500,
                    Success = "false"
                };
            }
        }

        #endregion
    }
}