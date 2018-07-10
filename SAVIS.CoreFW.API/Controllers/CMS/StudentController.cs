using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using NewCMS.Business;
using NewCMS.Business.Config;
using NewCMS.Common;
using Newtonsoft.Json;
using NewCMS.Business.Logic.Cms.Student;

namespace NewCMS.API.Controllers.CMS
{
    public class VideoController : ApiController
    {
        readonly IStudentHandler _studentHandler = BusinessServiceLocator.Instance.GetService<IStudentHandler>();
        
        #region GET
        
        [HttpGet]
        [Route("api/v3/cms/students/{studentId}")]
        public Response<StudentModel> GetStudentById(int studentId)
        {
            return _studentHandler.GetStudentById(studentId);
        }
        
        [HttpGet]
        [Route("api/v3/cms/groups/{groupId}")]
        public Response<GroupModel> GetGroupById(int groupId)
        {
            return _studentHandler.GetGroupById(groupId);
        }

        [HttpGet]
        [Route("api/v3/cms/students/{studentId}/{classId}")]
        public Response<StudentModel> GetStudentById(int studentId, int classId)
        {
            return _studentHandler.GetStudentById(studentId, classId);
        }

        [HttpGet]
        [Route("api/v3/cms/classes/{classId}")]
        public Response<ClassModel> GetClassId(int classId)
        {
            return _studentHandler.GetClassById(classId);
        }


        [HttpGet]
        [Route("api/v3/cms/students")]
        public Response<IList<StudentModel>> GetFilter(string filter)
        {
            StudentQueryFilter filterConvert = JsonConvert.DeserializeObject<StudentQueryFilter>(filter);
            var student = _studentHandler.GetFiler(filterConvert);
            return student;
        }

        [HttpGet]
        [Route("api/v3/cms/students/{classId}/class")]
        public Response<IList<StudentModel>> GetStudentByClassId(int classId)
        {
            return _studentHandler.GetStudentByClassId(classId);
        }

        //[HttpGet]
        //[Route("api/v3/cms/students/{groupId}/group")]
        //public Response<IList<StudentModel>> GetStudentByGroupId(int groupId)
        //{
        //    return _studentHandler.get
        //}

        #endregion

        #region ADD, UPDATE, DELETE
        [HttpPost]
        [Route("api/v3/cms/students")]
        public Response<StudentModel> CreateStudent(StudentCreateRequestModel model)
        {
            return _studentHandler.CreateStudent(model);
        }

        [HttpPost]
        [Route("api/v3/cms/groups")]
        public Response<GroupModel> CreateGroup(GroupCreateRequestModel model)
        {
            return _studentHandler.CreateGroup(model);
        }

        [HttpPost]
        [Route("api/v3/cms/classes")]
        public Response<ClassModel> CreateClass(ClassCreateRequestModel model)
        {
            return _studentHandler.CreateClass(model);
        }

        [HttpPut]
        [Route("api/v3/cms/students/{studentid}")]
        public Response<StudentModel> UpdateStudent(int studentId, StudentUpdateRequestModel model)
        {
            return _studentHandler.UpdateStudent(studentId, model);
        }

        [HttpPut]
        [Route("api/v3/cms/groups/{groupId}")]
        public Response<GroupModel> UpdateGroup(int groupId, GroupUpdateRequestModel model)
        {
            return _studentHandler.UpdateGroup(groupId, model);
        }

        [HttpPut]
        [Route("api/v3/cms/classes/{classId}")]
        public Response<ClassModel> UpdateClass(int classId, ClassUpdateRequestModel model)
        {
            return _studentHandler.UpdateClass(classId, model);
        }
        [HttpDelete]
        [Route("api/v3/cms/students/{studentId}")]
        public Response<StudentDeleteResponseModel> DeleteStudent(int studentId)
        {
            return _studentHandler.DeleteStudent(studentId);
        }

        [HttpDelete]
        [Route("api/v3/cms/groups/{groupId}")]
        public Response<GroupDeleteResponseModel> DeleteGroup(int groupId)
        {
            return _studentHandler.DeleteGroup(groupId);
        }

        
        #endregion
    }
}
