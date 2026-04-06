using StudentManagementSystem.Models;
using System.Numerics;

namespace StudentManagementSystem.Interface
{
    /// <summary>
    /// This interface defines all operations related to Student Management.
    /// It follows a loosely coupled architecture where implementation is separated from definition.
    /// </summary>
    public interface IStudentInterface
    {
        /// <summary>
        /// Creates a new student record in the system.
        /// </summary>
        /// <param name="request">Contains student details to be created.</param>
        /// <returns>Returns response with status and created student details.</returns>
        Task<CreateStudentResponse> CreateNewStudent(CreateStudentRequest request);

        /// <summary>
        /// Retrieves the list of all students.
        /// </summary>
        /// <returns>Returns list of students with response metadata.</returns>
        Task<StudentListResponse>AllStudent();

        /// <summary>
        /// Updates an existing student record.
        /// </summary>
        /// <param name="request">Contains updated student information.</param>
        /// <returns>Returns common response indicating success or failure.</returns>
        Task<CommonResponse> UpdateStudent(UpdateStudentRequest request);

        /// <summary>
        /// Deletes a student record based on Student ID.
        /// </summary>
        /// <param name="StudentID">Unique identifier of the student.</param>
        /// <returns>Returns common response indicating success or failure.</returns>
        Task<CommonResponse> DeleteStudent(int? StudentID);
    }
}