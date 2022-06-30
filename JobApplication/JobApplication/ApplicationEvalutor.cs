
using JobApplicationLibrary.Models;
using System.Collections.Generic;
using System.Linq;

namespace JobApplicationLibrary
{
    public class ApplicationEvalutor
    {
        private const int minAge = 18;
        private const int autoExpectedYearOfExperience = 15;
        private List<string> TechStackList = new() { "C#", "RabbitMQ", "Microservice", "Visual Studio" };

        public ApplicationResult Evaluate(JobApplication form)
        {
            if (form.Applicant.Age < minAge)
                return ApplicationResult.AutoRejected;

            int rate = GetTechStackSimilarityRate(form.TechStackList);

            //senaryo 1
            if (rate < 25)
                return ApplicationResult.AutoRejected;

            //senaryo 2
            if (rate > 75  && form.YearsOfExprience > autoExpectedYearOfExperience)
                return ApplicationResult.AutoAccepted;

            return ApplicationResult.AutoAccepted;
        }

        public int GetTechStackSimilarityRate(List<string> techStacks)
        {
            int matchCount = TechStackList
                              .Where(x => techStacks.Contains(x)).Count();

            return (int)((double)matchCount / TechStackList.Count) * 100;
        }
    }

    public enum ApplicationResult
    {
        AutoRejected,
        TransferredToHR,
        TransferredToLead,
        TransferredToCTO,
        AutoAccepted
    }
}
