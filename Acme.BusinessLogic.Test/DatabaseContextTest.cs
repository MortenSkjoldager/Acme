using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using Acme.BusinessLogic.DataAccess;
using Acme.BusinessLogic.Model;
using Acme.BusinessLogic.Submissions;
using Acme.BusinessLogic.Submissions.Impl;
using Castle.Windsor;
using Moq;
using Component = Castle.MicroKernel.Registration.Component;

namespace Acme.BusinessLogic.Test
{
    [TestFixture]
    public class SubmissionTests
    {
        private void SetupFakeDbContextInContainer(FakeDbSet<Submission> submissionsToReturn, FakeDbSet<SerialNumber> serialNumbersToReturn)
        {
            var fakeContext = new Mock<DatabaseContext>();
            fakeContext.Setup(x => x.Submissions).Returns(submissionsToReturn);
            fakeContext.Setup(x => x.SerialNumbers).Returns(serialNumbersToReturn);

            Acme.BusinessLogic.DependencyInjection.Container.Initialize();

            Mock<IDatabaseContextProvider> mockProvider = new Mock<IDatabaseContextProvider>();

            mockProvider.Setup(x => x.GetDatabaseContext()).Returns(fakeContext.Object);
            
            var childContainer = new WindsorContainer();
            childContainer.Register(Component.For<IDatabaseContextProvider>().Instance(mockProvider.Object));
            childContainer.Register(Component.For<ISubmissionService>().ImplementedBy(typeof(SubmissionService)));
            // Add new container as child container
            Acme.BusinessLogic.DependencyInjection.Container.AddChildContainer(childContainer);
        }

        [Test]
        public void If_You_Are_At_Least_18_Years_Old_You_Can_Enter_The_Draw()
        {
            var validKey = Guid.NewGuid();
            var serialNumber = new SerialNumber() { Key = validKey };

            var submissionsToReturn = new FakeDbSet<Submission>()
            {
                new Submission()
                {
                    Email = "bogus",
                    FirstName = "bogus",
                    LastName = "bogus",
                    SerialNumber = serialNumber
                }
            };
            
            var serialNumbersToReturn = new FakeDbSet<SerialNumber>()
            {
                serialNumber
            };
            
            SetupFakeDbContextInContainer(submissionsToReturn, serialNumbersToReturn);

            var sut = Acme.BusinessLogic.DependencyInjection.Container.Instance.Resolve<ISubmissionService>();
            
            var submissionCreationResult = sut.CreateSubmission("bogus", "bogus", "bogus", 18, validKey);
            Assert.True(submissionCreationResult.Success);
        }

        [Test]
        public void If_You_Are_Below_18_Years_Old_You_Cant_Participate()
        {
            var invalidKey = Guid.NewGuid();
            var serialNumber = new SerialNumber() { Key = Guid.NewGuid() };

            var submissionsToReturn = new FakeDbSet<Submission>()
            {
                new Submission()
                {
                    Email = "bogus",
                    FirstName = "bogus",
                    LastName = "bogus",
                    SerialNumber = serialNumber
                }
            };
            
            var serialNumbersToReturn = new FakeDbSet<SerialNumber>()
            {
                serialNumber
            };
            
            SetupFakeDbContextInContainer(submissionsToReturn, serialNumbersToReturn);

            var sut = Acme.BusinessLogic.DependencyInjection.Container.Instance.Resolve<ISubmissionService>();
            
            var submissionCreationResult = sut.CreateSubmission("bogus", "bogus", "bogus", 17, invalidKey);
            Assert.False(submissionCreationResult.Success);
            Assert.AreEqual(Constants.ErrorMessages.InvalidKey, submissionCreationResult.Message);
        }
        
        [Test]
        public void You_Cant_Enter_With_Invalid_Key()
        {
            var invalidKey = Guid.NewGuid();
            var serialNumber = new SerialNumber() { Key = Guid.NewGuid() };

            var submissionsToReturn = new FakeDbSet<Submission>()
            {
                new Submission()
                {
                    Email = "bogus",
                    FirstName = "bogus",
                    LastName = "bogus",
                    SerialNumber = serialNumber
                }
            };
            
            var serialNumbersToReturn = new FakeDbSet<SerialNumber>()
            {
                serialNumber
            };
            
            SetupFakeDbContextInContainer(submissionsToReturn, serialNumbersToReturn);

            var sut = Acme.BusinessLogic.DependencyInjection.Container.Instance.Resolve<ISubmissionService>();
            
            var submissionCreationResult = sut.CreateSubmission("bogus", "bogus", "bogus", 18, invalidKey);
            Assert.False(submissionCreationResult.Success);
            Assert.AreEqual(Constants.ErrorMessages.InvalidKey, submissionCreationResult.Message);
        }
        
        [Test]
        public void You_Can_Only_Enter_Two_Times_With_The_Same_Serial()
        {
            var conflictingKey = Guid.NewGuid();
            var serialNumber = new SerialNumber() { Key = conflictingKey };

            var submissionsToReturn = new FakeDbSet<Submission>()
            {
                new Submission()
                {
                    Email = "bogus",
                    FirstName = "bogus",
                    LastName = "bogus",
                    SerialNumber = serialNumber
                },
                new Submission()
                {
                    Email = "bogus",
                    FirstName = "bogus",
                    LastName = "bogus",
                    SerialNumber = serialNumber
                }
            };
            
            var serialNumbersToReturn = new FakeDbSet<SerialNumber>()
            {
                serialNumber
            };
            
            SetupFakeDbContextInContainer(submissionsToReturn, serialNumbersToReturn);

            var sut = Acme.BusinessLogic.DependencyInjection.Container.Instance.Resolve<ISubmissionService>();
            
            var submissionCreationResult = sut.CreateSubmission("bogus", "bogus", "bogus", 19, conflictingKey);
            Assert.False(submissionCreationResult.Success);
            Assert.AreEqual(Constants.ErrorMessages.OnlyEnterTwiceMessage, submissionCreationResult.Message);
        }
    }
}
