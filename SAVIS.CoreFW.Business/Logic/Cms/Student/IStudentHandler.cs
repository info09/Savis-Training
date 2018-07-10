using NewCMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCMS.Business.Logic.Cms.Student
{
   public interface IStudentHandler
    {
        Response<StudentModel> GetStudentById(int studentId);
        Response<StudentModel> CreateStudent(StudentCreateRequestModel model);
        Response<StudentModel> UpdateStudent(int studentId,StudentUpdateRequestModel model);
        Response<StudentDeleteResponseModel> DeleteStudent(int studentId);

        Response<GroupModel> GetGroupById(int groupId);
        Response<GroupModel> CreateGroup(GroupCreateRequestModel model);
        Response<GroupModel> UpdateGroup(int groupId, GroupUpdateRequestModel model);
        Response<GroupDeleteResponseModel> DeleteGroup(int groupId);

        
        Response<StudentModel> GetStudentById(int studentId, int classId);
        
        Response<ClassModel> GetClassById(int classId);
        Response<ClassModel> CreateClass(ClassCreateRequestModel model);
        Response<ClassModel> UpdateClass(int classId,ClassUpdateRequestModel model);

        Response<IList<StudentModel>> GetFiler(StudentQueryFilter filter);
        Response<IList<StudentModel>> GetStudentByClassId(int classId);
        //Response<IList<StudentModel>> GetStudentByGroupId(int groupId);
    }
}
