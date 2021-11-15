using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CM.ZooLab.ClassLibrary
{
    public class ValidationErrorTests
    {
        [Fact]
        public void ShouldBeAbleToCreateValidationErrorObject()
        {
            ValidationError validationError = new ValidationError("test");
            Assert.Equal("test", validationError.Error);
        }
    }
}
