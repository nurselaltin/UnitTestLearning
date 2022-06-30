using System.Collections.Generic;

namespace JobApplicationLibrary.Models
{
    public class JobApplication
    {
        public Applicant Applicant { get; set; }
        public int YearsOfExprience { get; set; }
        public List<string> TechStackList { get; set; } //Bildiği teknolojiler
    }
}
