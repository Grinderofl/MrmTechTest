using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace MrmTechTest.Tests
{
    public abstract class TestBase
    {
        [OneTimeSetUp]
        public virtual void Setup()
        {
            SharedContext();
            Context();
            Because();
        }

        protected virtual void SharedContext()
        {
        }

        protected virtual void Context()
        {
        }

        protected virtual void Because()
        {
        }

        [OneTimeTearDown]
        public virtual void Teardown()
        {
        }

        protected virtual Mock<T> CreateDependency<T>() where T : class
        {
            return new Mock<T>();
        }
    }
}
