using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCMS.Business.Logic.Cms.Student
{
    public class StudentModel : StudentBaseModel
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Facebook { get; set; }
        public string Address { get; set; }
        public int ClassId { get; set; }
        public int GroupId { get; set; }
    }
    public class StudentBaseModel
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
    }
    public class GroupModel
    {
        public int GroupId { get; set; }
        public string Leader { get; set; }
        public int ClassId { get; set; }
        
    }
    public class ClassModel
    {
        public int ClassId { get; set; }
        public string Name { get; set; }
        
    }
    public class StudentQueryFilter
    {
        public string textSearch { get; set; }
        public int intSearch { get; set; }
        //public int? PageSize { get; set; }
        //public int? PageNumber { get; set; }
        //public StudentQueryFilter()
        //{
        //    PageNumber = 1;
        //    PageSize = 10;
        //}
    }
    //Create request model
    public class StudentCreateRequestModel
    {
        
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Facebook { get; set; }
        public string Address { get; set; }
        public int ClassId { get; set; }
        public int GroupId { get; set; }
    }
    public class StudentUpdateRequestModel
    {
        
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Facebook { get; set; }
        public string Address { get; set; }
        public int ClassId { get; set; }
        public int GroupId { get; set; }
    }
    public class StudentDeleteResponseModel
    {
        public int StudentId { get; set; }
    }

    public class GroupCreateRequestModel
    {
        public int GroupId { get; set; }
        public string Leader { get; set; }
        public int ClassId { get; set; }
    }
    public class GroupUpdateRequestModel
    {
        public int GroupId { get; set; }
        public string Leader { get; set; }
        public int ClassId { get; set; }
    }
    public class GroupDeleteResponseModel
    {
        public int GroupId { get; set; }
    }
    public class ClassCreateRequestModel
    {
        public string Name { get; set; }
        
    }
    public class ClassUpdateRequestModel
    {
        public string Name { get; set; }
        public int GroupId { get; set; }
    }
    public class ClassDeleteResponseModel
    {
        public int ClassId { get; set; }
    }
}
