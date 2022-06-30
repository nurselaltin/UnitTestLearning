using JobApplicationLibrary;
using JobApplicationLibrary.Models;
using NUnit.Framework;

namespace JobApplicationLibraryTest
{
    public class Tests
    {
        //UnitOfWork_Condition_ExpectedResult
        //Condition_Result

        [Test]
        public void Application_WithUnderAge_TransferredToAutorejected()
        {
            //Arrange
            var evaluator = new ApplicationEvalutor();
            var form = new JobApplication() {

                Applicant = new Applicant()
                {
                    Age = 17
                }

            };

            //Action
            var appResult = evaluator.Evaluate(form);

            //Assert
            Assert.AreEqual(appResult, ApplicationResult.AutoRejected);

        }

        [Test]
        public void Application_WithTechStack_TransferredToAutorejected()
        {
            //Arrange
            var evaluator = new ApplicationEvalutor();
            var form = new JobApplication()
            {

                Applicant = new Applicant(),
                TechStackList = new System.Collections.Generic.List<string>()
            };

            //Action
            var appResult = evaluator.Evaluate(form);

            //Assert
            Assert.AreEqual(appResult, ApplicationResult.AutoRejected);

        }

    }
}