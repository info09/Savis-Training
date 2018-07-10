using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewCMS.Common;
using NewCMS.Business.Config;
using NewCMS.Data;

namespace NewCMS.Business.Logic.Cms.Student
{
    public class DbStudentHandler : IStudentHandler
    {
        ILogService logger = BusinessServiceLocator.Instance.GetService<ILogService>();
            #region GET

        public Response<StudentModel> GetStudentById(int studentId)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var student = unitOfWork.GetRepository<cms_Student>().GetById(studentId);
                    return new Response<StudentModel>(ConfigType.SUCCESS, "OK", ConvertStudent(student));
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return new Response<StudentModel>(ConfigType.ERROR, ex.Message, null);
            }
        }

        public Response<GroupModel> GetGroupById(int groupId)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var group = unitOfWork.GetRepository<cms_Group>().GetById(groupId);
                    return new Response<GroupModel>(ConfigType.SUCCESS, "Ok", ConvertGroup(group));
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return new Response<GroupModel>(ConfigType.ERROR, ex.Message, null);
            }
        }

        

        public Response<StudentModel> GetStudentById(int studentId,  int classId)
        {
            try
            {
                using(var unitOfWork= new UnitOfWork())
                {
                    var student = unitOfWork.GetRepository<cms_Student>().Get(m => m.StudentId == studentId && m.ClassId == classId);
                    return new Response<StudentModel>(ConfigType.SUCCESS, "Ok", ConvertStudent(student));
                }
            }catch(Exception ex)
            {
                logger.Error(ex);
                return new Response<StudentModel>(ConfigType.ERROR, ex.Message, null);
            }
        }

        public Response<ClassModel> GetClassById(int classId)
        {
            try
            {
                using(var unitOfWork = new UnitOfWork())
                {
                    var c = unitOfWork.GetRepository<cms_Class>().GetById(classId);
                    return new Response<ClassModel>(ConfigType.SUCCESS,"Ok",ConvertClass(c));
                }
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                return new Response<ClassModel>(ConfigType.ERROR, ex.Message, null);
            }
        }

        public Response<IList<StudentModel>> GetFiler(StudentQueryFilter filter)
        {
            try
            {
                string textSearch = filter.textSearch;
                //int intSearch = filter.intSearch;
                using (var unitOfWork = new UnitOfWork())
                {
                    var data = from st in unitOfWork.GetRepository<cms_Student>().GetAll()
                               join cl in unitOfWork.GetRepository<cms_Class>().GetAll() on st.ClassId equals cl.ClassId
                               join gr in unitOfWork.GetRepository<cms_Group>().GetAll() on st.GroupId equals gr.GroupId
                               select new { Student = st, Class = cl, Group = gr };
                    if (!string.IsNullOrEmpty(textSearch))
                    {
                        data = data.Where(m => m.Student.Name.ToLower().Contains(textSearch.ToLower()));
                    }
                    //if (intSearch!=null)
                    //{
                    //    data = data.Where(i => i.Student.ClassId == intSearch);
                    //}
                    var count = data.Count();
                    List<StudentModel> studentModels = new List<StudentModel>();
                    foreach (var item in data)
                    {
                        studentModels.Add(ConvertStudent(item.Student));
                    }
                    Response<IList<StudentModel>> response = new Response<IList<StudentModel>>(ConfigType.SUCCESS, "Ok", studentModels);
                    return response;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return new Response<IList<StudentModel>>(ConfigType.ERROR, ex.Message, null);
            }
        }


        public Response<IList<StudentModel>> GetStudentByClassId(int classId)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var data = unitOfWork.GetRepository<cms_Student>().GetMany(i => i.ClassId == classId);

                    List<StudentModel> studentModel = new List<StudentModel>();

                    foreach (var item in data)
                    {
                        studentModel.Add(ConvertStudent(item));
                    }
                    return new Response<IList<StudentModel>>(ConfigType.SUCCESS, "Ok", studentModel);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return new Response<IList<StudentModel>>(ConfigType.ERROR, ex.Message, null);
            }
        }

            #endregion

            #region ADD,UPDATE,DELETE
        public Response<StudentModel> CreateStudent(StudentCreateRequestModel model)
        {
            try
            {
                using(var unitOfWork= new UnitOfWork())
                {
                    var db = unitOfWork.DataContext;

                    var newStudent = new cms_Student();
                    
                    newStudent.Name = model.Name;
                    newStudent.Phone = model.Phone;
                    newStudent.Address = model.Address;
                    newStudent.Email = model.Email;
                    newStudent.ClassId = model.ClassId;
                    newStudent.Facebook = model.Facebook;
                    newStudent.GroupId = model.GroupId;
                    db.cms_Student.Add(newStudent);
                    var commitResult = unitOfWork.Save();
                    if (commitResult >= ConfigType.SUCCESS)
                    {
                        return new Response<StudentModel>(ConfigType.SUCCESS, "Ok", ConvertStudent(newStudent));
                    }
                    else
                    {
                        return new Response<StudentModel>(ConfigType.NODATA, "NOT OK", null);
                    }
                    
                }
            }catch(Exception ex)
            {
                logger.Error(ex);
                return new Response<StudentModel>(ConfigType.ERROR, ex.Message, null);
            }
            
        }

        public Response<StudentDeleteResponseModel> DeleteStudent(int studentId)
        {
            try
            {
                using(var unitOfWork= new UnitOfWork())
                {
                    var db = unitOfWork.DataContext;
                    var modelStudent = unitOfWork.GetRepository<cms_Student>().GetById(studentId);
                    if (modelStudent != null)
                    {
                        unitOfWork.GetRepository<cms_Student>().Delete(modelStudent);

                        var commitResult = unitOfWork.Save();
                        if (commitResult >= ConfigType.NODATA)
                        {
                            return new Response<StudentDeleteResponseModel>(ConfigType.SUCCESS, "Succesfully deleted student with id= " + studentId, null);
                        }
                        else
                        {
                            return new Response<StudentDeleteResponseModel>(ConfigType.ERROR, "Unable to delete student with id= " + studentId, null);
                        }
                    }
                    else
                    {
                        return new Response<StudentDeleteResponseModel>(ConfigType.ERROR, "Unable to delete student with id= " + studentId, null);
                    }
                }
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                return new Response<StudentDeleteResponseModel>(ConfigType.ERROR, ex.Message, null);
            }
        }
        
        public Response<StudentModel> UpdateStudent(int studentId, StudentUpdateRequestModel model)
        {
            try
            {
                using(var unitOfWork= new UnitOfWork())
                {
                    var existingStudent = unitOfWork.GetRepository<cms_Student>().Get(m => m.StudentId == studentId);
                    existingStudent.Name = model.Name;
                    existingStudent.Address = model.Address;
                    existingStudent.Facebook = model.Facebook;
                    existingStudent.Email = model.Email;
                    existingStudent.Phone = model.Phone;
                    existingStudent.ClassId = model.ClassId;
                    existingStudent.GroupId = model.GroupId;
                    unitOfWork.GetRepository<cms_Student>().Update(existingStudent);
                    var commitResult = unitOfWork.Save();
                    if (commitResult >= ConfigType.SUCCESS)
                    {
                        return new Response<StudentModel>(ConfigType.SUCCESS, "OK", ConvertStudent(existingStudent));
                    }
                    else
                    {
                        return new Response<StudentModel>(ConfigType.ERROR, "NOT OK", null);
                    }
                }
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                return new Response<StudentModel>(ConfigType.ERROR, ex.Message, null);
            }
        }
        
        public Response<GroupModel> CreateGroup(GroupCreateRequestModel model)
        {
            try
            {
                using(var unitOfWork= new UnitOfWork())
                {
                    var db = unitOfWork.DataContext;
                    var newGroup = new cms_Group();
                    newGroup.GroupId = model.GroupId;
                    newGroup.Leader = model.Leader;
                    newGroup.ClassId = model.ClassId;
                    db.cms_Group.Add(newGroup);
                    var commitResult = unitOfWork.Save();
                    if (commitResult >= ConfigType.SUCCESS)
                    {
                        return new Response<GroupModel>(ConfigType.SUCCESS, "Ok", ConvertGroup(newGroup));
                    }else
                    {
                        return new Response<GroupModel>(ConfigType.ERROR, "NOT OK", null);
                    }
                }
            }catch(Exception ex)
            {
                logger.Error(ex);
                return new Response<GroupModel>(ConfigType.ERROR, ex.Message, null);
            }
        }

        public Response<GroupModel> UpdateGroup(int groupId, GroupUpdateRequestModel model)
        {
            try
            {
                using(var unitOfWork= new UnitOfWork())
                {
                    var existingGroup = unitOfWork.GetRepository<cms_Group>().Get(m => m.GroupId == groupId);
                    existingGroup.GroupId = model.GroupId;
                    existingGroup.Leader = model.Leader;
                    existingGroup.ClassId = model.ClassId;
                    unitOfWork.GetRepository<cms_Group>().Update(existingGroup);
                    var commitResult = unitOfWork.Save();
                    if (commitResult >= ConfigType.SUCCESS)
                    {
                        return new Response<GroupModel>(ConfigType.SUCCESS, "Ok", ConvertGroup(existingGroup));
                    }
                    else
                    {
                        return new Response<GroupModel>(ConfigType.ERROR, "NOT OK", null);
                    }
                }
            }catch(Exception ex)
            {
                logger.Error(ex);
                return new Response<GroupModel>(ConfigType.ERROR, ex.Message, null);
            }
        }

        public Response<GroupDeleteResponseModel> DeleteGroup(int groupId)
        {
            try
            {
                using(var unitOfWork= new UnitOfWork())
                {
                    var db = unitOfWork.DataContext;
                    var modelGroup = unitOfWork.GetRepository<cms_Group>().GetById(groupId);
                    if (modelGroup != null)
                    {
                        unitOfWork.GetRepository<cms_Group>().Delete(modelGroup);

                        var commitResult = unitOfWork.Save();
                        if (commitResult >= ConfigType.NODATA)
                        {
                            return new Response<GroupDeleteResponseModel>(ConfigType.SUCCESS, "Succesfully deleted group with id="+groupId,null);
                        }else
                        {
                            return new Response<GroupDeleteResponseModel>(ConfigType.ERROR, "Unable deleted group with id=" + groupId, null);
                        }
                    }
                    else
                    {
                        return new Response<GroupDeleteResponseModel>(ConfigType.ERROR, "Unable deleted group with id= " + groupId, null);
                    }
                }
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                return new Response<GroupDeleteResponseModel>(ConfigType.ERROR, ex.Message, null);
            }
        }
        
        public Response<ClassModel> CreateClass(ClassCreateRequestModel model)
        {
            try
            {
                using(var unitOfWork= new UnitOfWork())
                {
                    var db = unitOfWork.DataContext;
                    var newClass = new cms_Class();
                    newClass.Name = model.Name;
                    

                    db.cms_Class.Add(newClass);
                    var commitResult = unitOfWork.Save();
                    if (commitResult >= ConfigType.SUCCESS)
                    {
                        return new Response<ClassModel>(ConfigType.SUCCESS, "Ok", ConvertClass(newClass));
                    }else
                    {
                        return new Response<ClassModel>(ConfigType.ERROR, "NOT OK", null);
                    }
                }
            }catch(Exception ex)
            {
                logger.Error(ex);
                return new Response<ClassModel>(ConfigType.ERROR, ex.Message, null);
            }
        }

        public Response<ClassModel> UpdateClass(int classId,ClassUpdateRequestModel model)
        {
            try
            {
                using(var unitOfWork= new UnitOfWork())
                {
                    var existingClass = unitOfWork.GetRepository<cms_Class>().Get(m => m.ClassId == classId);
                    existingClass.Name = model.Name;
                    //existingClass.GroupId = model.GroupId;
                    unitOfWork.GetRepository<cms_Class>().Update(existingClass);
                    var commitResult = unitOfWork.Save();
                    if (commitResult >= ConfigType.SUCCESS)
                    {
                        return new Response<ClassModel>(ConfigType.SUCCESS, "OK", ConvertClass(existingClass));
                    }else
                    {
                        return new Response<ClassModel>(ConfigType.SUCCESS, "NOT OK", null);
                    }
                }
            }catch(Exception ex)
            {
                logger.Error(ex);
                return new Response<ClassModel>(ConfigType.ERROR, ex.Message, null);
            }
        }

             #endregion

            #region CONVERT
        
        public StudentModel ConvertStudent(cms_Student cmsStudent)
        {
            try
            {
                StudentModel model = new StudentModel();
                model.StudentId = cmsStudent.StudentId;
                model.Name = cmsStudent.Name;
                model.Address = cmsStudent.Address;
                model.Email = cmsStudent.Email;
                model.Facebook = cmsStudent.Facebook;
                model.ClassId = cmsStudent.ClassId;
                model.Phone = cmsStudent.Phone;
                model.GroupId = cmsStudent.GroupId;
                
                return model;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return new StudentModel();
            }
        }
        
        public GroupModel ConvertGroup(cms_Group cmsGroup)
        {
            try
            {
                GroupModel model = new GroupModel();
                model.GroupId = cmsGroup.GroupId;
                model.Leader = cmsGroup.Leader;
                model.ClassId = cmsGroup.ClassId;
                
                return model;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return new GroupModel();
            }
        }

        public ClassModel ConvertClass(cms_Class cmsClass)
        {
            try
            {
                ClassModel model = new ClassModel();
                model.ClassId = cmsClass.ClassId;
                model.Name = cmsClass.Name;
                
                return model;
            }catch(Exception ex)
            {
                logger.Error(ex);
                return new ClassModel();
            }
        }



        public Response<StudentModel> GetStudentByGroupId(int groupId)
        {
            try
            {
                using (var unitOfWork = new UnitOfWork())
                {
                    var student = unitOfWork.GetRepository<cms_Student>().GetById(groupId);
                    return new Response<StudentModel>(ConfigType.SUCCESS, "Ok", ConvertStudent(student));
                }
            }
            catch (Exception ex)
            {
                return new Response<StudentModel>(ConfigType.ERROR, ex.Message, null);
            }
        }

        



        #endregion
    }
}
