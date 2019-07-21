using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Data.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DbRelationshipInDbContextLib.EF;
using DbRelationshipInDbContextLib;

namespace DbRelationshipInDbContextTests
{
    [TestClass]
    public class RelationshipInEFDemoLibUnitTest
    {
        DbRelationshipLib _demoLib = new DbRelationshipLib();

        public RelationshipInEFDemoLibUnitTest() { 
            //Delete all records in table StudentClassMatch and StudentClubMatch to avoid possible conflict
            var matchList1 = _demoLib.DbContext.StudentClubMatches.ToList();
            foreach (var match in matchList1)
            {
                _demoLib.RemoveStudentFromClub(match.Student, match.Club);
            }

            var students = _demoLib.DbContext.Students.ToList();
            foreach (var s in students)
            {
                foreach (var c in s.Classes)
                {
                    _demoLib.RemoveStudentFromClass(s, c);
                }
            }
        }

        [TestMethod]
        public void TestAddUpdateRemoveAndDeleteClassForTeacher()
        {
            //AddVersion1 in the case that Navigation property t.Classes isn't loaded
            Class c = new Class();
            c.Name = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 8);
            c.Description = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 16);
            c.Grade = 3;
            c.TeacherId = 3;
            _demoLib.AddClassVersion1(c);
            Assert.IsNotNull(c.Teacher);
            Assert.IsTrue(c.Teacher.Classes.Contains(c));
            Assert.IsTrue(_demoLib.DbContext.Classes.ToList().Contains(c));   

            //AddVersion1 again because now the Navigation property t.Classes is loaded
            Class c2 = new Class();
            c2.Name = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 8);
            c2.Description = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 16);
            c2.Grade = 3;
            c2.TeacherId = 3;
            _demoLib.AddClassVersion1(c2);
            Assert.IsNotNull(c2.Teacher);
            Assert.IsTrue(c2.Teacher.Classes.Contains(c2));
            Assert.IsTrue(_demoLib.DbContext.Classes.ToList().Contains(c2));

            //AddVersion2 in the case that Navigation property t.Classes isn't loaded
            Class c3 = new Class();
            c3.Name = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 8);
            c3.Description = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 16);
            c3.Grade = 3;
            c3.TeacherId = 2;
            _demoLib.AddClassVersion1(c3);
            Assert.IsNotNull(c3.Teacher);
            Assert.IsTrue(c3.Teacher.Classes.Contains(c3));
            Assert.IsTrue(_demoLib.DbContext.Classes.ToList().Contains(c3));

            //AddVersion2 again because now the Navigation property t.Classes is loaded
            Class c4 = new Class();
            c4.Name = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 8);
            c4.Description = Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 16);
            c4.Grade = 3;
            c4.TeacherId = 3;
            _demoLib.AddClassVersion1(c4);
            Assert.IsNotNull(c4.Teacher);
            Assert.IsTrue(c4.Teacher.Classes.Contains(c4));
            Assert.IsTrue(_demoLib.DbContext.Classes.ToList().Contains(c4));  

            //Update with a new name
            String newName = "TestClassOnly";
            c.Name = newName;
            _demoLib.UpdateClass(c);
            Class cFromEF = _demoLib.DbContext.Classes.Single(o => o.Id == c.Id);
            Assert.AreEqual(cFromEF.Name, newName);

            //Update with a new Teacher
            Teacher oldTeacher = c.Teacher;            
            c.TeacherId = 2;
            _demoLib.UpdateClass(c);
            Teacher newTeacher = cFromEF.Teacher;
            cFromEF = _demoLib.DbContext.Classes.Single(o => o.Id == c.Id);
            Assert.AreNotSame(newTeacher, oldTeacher);
            Assert.IsTrue(newTeacher.Classes.Contains(cFromEF));
            Assert.IsFalse(oldTeacher.Classes.Contains(cFromEF));

            //Remove class c from its teachter
            Teacher teacherBk = c.Teacher;
            _demoLib.RemoveAClassFromTeacher(c);
            Assert.IsNull(c.TeacherId);
            Assert.IsNull(c.Teacher);
            Assert.IsFalse(teacherBk.Classes.Contains(c));
            Assert.IsTrue(_demoLib.DbContext.Classes.ToList().Contains(c));

            //Delete Class c
            _demoLib.DeleteClass(c);
            Assert.IsFalse(_demoLib.DbContext.Classes.ToList().Contains(c));
            
            //Delete Class c2
            Teacher teacher2 = c2.Teacher;
            _demoLib.DeleteClass(c2);
            Assert.IsFalse(_demoLib.DbContext.Classes.ToList().Contains(c2));
            Assert.IsFalse(teacher2.Classes.Contains(c2));

            //Delete Class c3
            Teacher teacher3 = c3.Teacher;
            _demoLib.DeleteClass(c3);
            Assert.IsFalse(teacher3.Classes.Contains(c3));
            Assert.IsFalse(_demoLib.DbContext.Classes.ToList().Contains(c3));

            //Delete Class c4
            Teacher teacher4 = c4.Teacher;
            _demoLib.DeleteClass(c4);
            Assert.IsFalse(_demoLib.DbContext.Classes.ToList().Contains(c4));
            Assert.IsFalse(teacher4.Classes.Contains(c4));
        }

        [TestMethod]
        public void TestAddRemoveStudentFromClass()
        {
            //Add student to class
            Student s = _demoLib.DbContext.Students.Single(o=>o.Id==1);
            Class c = _demoLib.DbContext.Classes.Single(o => o.Id == 2);
            _demoLib.AddStudentToClass(s, c);
            Assert.IsTrue(s.Classes.Contains(c));            
            Assert.IsTrue(c.Students.Contains(s));     

            //Delete Student from class
            _demoLib.RemoveStudentFromClass(s, c);
            Assert.IsFalse(s.Classes.Contains(c));
            Assert.IsFalse(c.Students.Contains(s));    
        }

        [TestMethod]
        public void TestAddRemoveStudentFromClub()
        {
            //Add student to class for Version1
            Student s = _demoLib.DbContext.Students.Single(o => o.Id == 1);
            Club c = _demoLib.DbContext.Clubs.Single(o => o.Id == 1);
            _demoLib.AddStudentToClubVersion1(s, c, false);
            StudentClubMatch scMatch = _demoLib.DbContext.StudentClubMatches.Single(o => o.ClubId == c.Id && o.StudentId == s.Id);
            Assert.AreSame(scMatch.Student, s);
            Assert.AreSame(scMatch.Club, c);
            Assert.IsTrue(s.StudentClubMatches.Contains(scMatch));
            Assert.IsTrue(c.StudentClubMatches.Contains(scMatch));
            Assert.IsTrue(_demoLib.DbContext.StudentClubMatches.ToList().Contains(scMatch));

            //Add student to class for Version2
            Student s2 = _demoLib.DbContext.Students.Single(o => o.Id == 2);
            Club c2 = _demoLib.DbContext.Clubs.Single(o => o.Id == 2);
            _demoLib.AddStudentToClubVersion2(s2, c2, false);
            StudentClubMatch scMatch2 = _demoLib.DbContext.StudentClubMatches.Single(o => o.ClubId == c2.Id && o.StudentId == s2.Id);
            Assert.AreSame(scMatch2.Student, s2);
            Assert.AreSame(scMatch2.Club, c2);
            Assert.IsTrue(s2.StudentClubMatches.Contains(scMatch2));
            Assert.IsTrue(c2.StudentClubMatches.Contains(scMatch2));
            Assert.IsTrue(_demoLib.DbContext.StudentClubMatches.ToList().Contains(scMatch2));

            //Delete Student from class
            _demoLib.RemoveStudentFromClub(s, c);
            Assert.IsFalse(s.StudentClubMatches.Contains(scMatch));
            Assert.IsFalse(c.StudentClubMatches.Contains(scMatch));
            Assert.IsFalse(_demoLib.DbContext.StudentClubMatches.ToList().Contains(scMatch));

            //Delete Student from class
            _demoLib.RemoveStudentFromClub(s2, c2);
            Assert.IsFalse(s.StudentClubMatches.Contains(scMatch2));
            Assert.IsFalse(c.StudentClubMatches.Contains(scMatch2));
            Assert.IsFalse(_demoLib.DbContext.StudentClubMatches.ToList().Contains(scMatch2));
        }
    }
}
