using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DbRelationshipInDbContextLib.EF;



namespace DbRelationshipInDbContextLib
{
    public class DbRelationshipLib
    {

        public ClassRegDemoEntities DbContext {get; set;}

        public DbRelationshipLib() {
            DbContext = new ClassRegDemoEntities();
            DbContext.Configuration.LazyLoadingEnabled = true;
            DbContext.Configuration.ProxyCreationEnabled = true;
        }

        // This function is used for the case which meet the following two condition: 
        // 1) All pass-in parameters are in detached state 
        // 2) DbContext.Configuration.LazyLoadingEnabled is true
        // Entity based version
        public void AddClassVersion1(Class c)
        {
            DbContext.Entry(c).State = EntityState.Added;
            if (c.Teacher == null) c.Teacher = DbContext.Teachers.Single(o => o.Id == c.TeacherId); 
            DbContext.SaveChanges();
        }

        // This function is used for the case which meet the following two condition: 
        // 1) All pass-in parameters are in detached state 
        // 2) DbContext.Configuration.LazyLoadingEnabled is true
        // Relationship based version
        public void AddClassVersion2(Class c)
        {
            if (c.Teacher == null) c.Teacher = DbContext.Teachers.Single(o => o.Id == c.TeacherId);
            c.Teacher.Classes.Add(c);
            DbContext.SaveChanges();
        }

        // This function is used for the case which meet the following two condition: 
        // 1) All pass-in parameters are in detached state 
        // 2) DbContext.Configuration.LazyLoadingEnabled is true
        public void DeleteClass(Class c)
        {
            DbContext.Entry(c).State = EntityState.Deleted;
            DbContext.SaveChanges();
        }

        // This function is used for the case which meet the following two condition: 
        // 1) All pass-in parameters are in detached state 
        // 2) DbContext.Configuration.LazyLoadingEnabled is true
        public void RemoveAClassFromTeacher(Class c) //After remove, this class is still in table 
        {            
            if (c.Teacher == null) c.Teacher = DbContext.Teachers.Single(o => o.Id == c.TeacherId);
            c.Teacher.Classes.Remove(c);
            c.Teacher = null;
            DbContext.SaveChanges();
        }

        // This function is used for the case which meet the following two condition: 
        // 1) All pass-in parameters are in detached state 
        // 2) DbContext.Configuration.LazyLoadingEnabled is true
        public void UpdateClass(Class c)
        {
            if (c.Teacher == null) c.Teacher = DbContext.Teachers.Single(o => o.Id == c.TeacherId); 
            DbContext.Entry(c).State = EntityState.Modified;
            DbContext.SaveChanges();
        }

        // This function is used for the case which meet the following two condition: 
        // 1) All pass-in parameters are in detached state 
        // 2) DbContext.Configuration.LazyLoadingEnabled is true
        public void AddStudentToClass(Student s, Class c)
        {
            s.Classes.Add(c);
            c.Students.Add(s);
            DbContext.SaveChanges();
        }

        // This function is used for the case which meet the following two condition: 
        // 1) All pass-in parameters are in detached state 
        // 2) DbContext.Configuration.LazyLoadingEnabled is true
        public void RemoveStudentFromClass(Student s, Class c)
        {
            s.Classes.Remove(c);
            c.Students.Remove(s);
            DbContext.SaveChanges();
        }

        // This function is used for the case which meet the following two condition: 
        // 1) All pass-in parameters are in detached state 
        // 2) DbContext.Configuration.LazyLoadingEnabled is true
        // Entity based version
        public void AddStudentToClubVersion1(Student s, Club c, bool isCommitteMember)
        {
            //Type II Many-to-Many relationship, which has been broken into two one-to-many relationship

            //Create and add the matching table record first.
            StudentClubMatch scMatch = new StudentClubMatch();
            scMatch.StudentId = s.Id;
            scMatch.ClubId = c.Id;
            scMatch.IsCommiteMember = isCommitteMember;
            DbContext.Entry(scMatch).State = EntityState.Added;
            DbContext.SaveChanges();
        }

        // This function is used for the case which meet the following two condition: 
        // 1) All pass-in parameters are in detached state 
        // 2) DbContext.Configuration.LazyLoadingEnabled is true
        // Relationship based version
        public void AddStudentToClubVersion2(Student s, Club c, bool isCommitteMember)
        {
            //Type II Many-to-Many relationship, which has been broken into two one-to-many relationship

            //Create and add the matching table record first.
            StudentClubMatch scMatch = new StudentClubMatch();
            scMatch.Student = s;
            s.StudentClubMatches.Add(scMatch);
            scMatch.Club = c;
            c.StudentClubMatches.Add(scMatch);
            scMatch.IsCommiteMember = isCommitteMember;
            DbContext.SaveChanges();
        }

        // This function is used for the case which meet the following two condition: 
        // 1) All pass-in parameters are in detached state 
        // 2) DbContext.Configuration.LazyLoadingEnabled is true
        public void RemoveStudentFromClub(Student s, Club c)
        {
            //Type II Many-to-Many relationship, which has been broken into two one-to-many relationship

            StudentClubMatch scMatch = DbContext.StudentClubMatches.Single(o=>o.ClubId == c.Id && o.StudentId == s.Id);

            // Remove student from a club by deleting the StudentClubMatch
            DbContext.Entry(scMatch).State = EntityState.Deleted;
            DbContext.SaveChanges();
        }
            
        // This function is used for the case which meet the following two condition: 
        // 1) All pass-in parameters are in detached state 
        // 2) DbContext.Configuration.LazyLoadingEnabled is true
        public void UpdateStudentClubMatch(StudentClubMatch match)
        {
            DbContext.Entry(match).State = EntityState.Modified;
            DbContext.SaveChanges();
        }
    }
}
