//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace DbRelationshipInDbContextLib.EF
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(StudentClubMatch))]
    public partial class Club
    {
        public Club()
        {
            this.StudentClubMatches = new HashSet<StudentClubMatch>();
        }
    
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
    
        [DataMember]
        public virtual ICollection<StudentClubMatch> StudentClubMatches { get; set; }
    }
    
}
