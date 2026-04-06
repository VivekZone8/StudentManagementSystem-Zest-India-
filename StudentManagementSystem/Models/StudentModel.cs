namespace StudentManagementSystem.Models

{
    #region Request Response for Create API

    // It is use to create the student data.
    public class CreateStudentRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Age { get; set; }
        public string Course { get; set; }
        
    }
    #endregion
    // It is use to response the data of create student.
    #region Create Student Response
    public class CreateStudentResponse
    {
        public string Message { get; set; }
        public string Success { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Age { get; set; }
        public string Course { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
    #endregion
    // It is common response for update and delete student data.
    #region Common Response
    public class CommonResponse
    {
        public string Message { get; set; }
        public string Success { get; set; }
        public int Code { get; set; }

    }
    #endregion
    // It is use to response the data of student list.
    #region Request Response of Student List

    public class StudentListResponse
    {
        public string Message { get; set; }
        public string Success { get; set; }
        public int Code { get; set; }

        public List<StudentData> StudentData { get; set; }
    }
    public class StudentData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Age { get; set; }
        public string Course { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
    //It is use to map the data of student data.
    public class BasicStudentData
    {
        public string Message { get; set; }
        public string Success { get; set; }
        public int Code { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Age { get; set; }
        public string Course { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
    #endregion
    //It is use to update the student data.
    #region Update Student Request
    public class UpdateStudentRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Age { get; set; }
        public string Course { get; set; }
        
    }
    #endregion
}

