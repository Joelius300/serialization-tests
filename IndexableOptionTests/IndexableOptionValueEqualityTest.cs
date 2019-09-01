using IndexableOptionTests.TestClasses;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IndexableOptionTests
{
    public class IndexableOptionValueEqualityTest
    {
        [Fact]
        public void Value_Equal_Equatable()
        {
            // Arrange
            int val = 0;
            IndexableOption<int> first = val;
            IndexableOption<int> second = val;

            // Act
            bool areEqual = first.Equals(second);

            // Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void Value_Equal_Equals()
        {
            // Arrange
            int val = 0;
            IndexableOption<int> first = val;
            IndexableOption<int> second = val;

            // Act
            bool areEqual = first.Equals((object)second);

            // Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void Value_Equal_Equals_Wrapped()
        {
            // Arrange
            int val = 0;
            IndexableOption<int> first = val;

            // Act
            bool areEqual = first.Equals(val);

            // Assert
            Assert.True(areEqual);
        }
    }
}
