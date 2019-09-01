using IndexableOptionTests.TestClasses;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IndexableOptionTests
{
    public class IndexableOptionArrayEqualityTest
    {
        [Fact]
        public void Reference_Equal_Equatable()
        {
            // Arrange
            int[] ints = { 0, 1, 4 };
            IndexableOption<int> first = ints;
            IndexableOption<int> second = ints;

            // Act
            bool areEqual = first.Equals(second);

            // Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void Reference_Equal_Equals()
        {
            // Arrange
            int[] ints = { 0, 1, 4 };
            IndexableOption<int> first = ints;
            IndexableOption<int> second = ints;

            // Act
            bool areEqual = first.Equals((object)second);

            // Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void Reference_Equal_Equals_Wrapped()
        {
            // Arrange
            int[] ints = { 0, 1, 4 };
            IndexableOption<int> first = ints;

            // Act
            bool areEqual = first.Equals(ints);

            // Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void Sequence_Equal_Equatable()
        {
            // Arrange
            int[] ints1 = { 0, 1, 4 };
            int[] ints2 = { 0, 1, 4 };

            IndexableOption<int> first = ints1;
            IndexableOption<int> second = ints2;

            // Act
            bool areEqual = first.Equals(second);

            // Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void Sequence_Equal_Equals()
        {
            // Arrange
            int[] ints1 = { 0, 1, 4 };
            int[] ints2 = { 0, 1, 4 };

            IndexableOption<int> first = ints1;
            IndexableOption<int> second = ints2;

            // Act
            bool areEqual = first.Equals((object)second);

            // Assert
            Assert.True(areEqual);
        }

        [Fact]
        public void Sequence_Equal_Equals_Wrapped()
        {
            // Arrange
            int[] ints1 = { 0, 1, 4 };
            int[] ints2 = { 0, 1, 4 };

            IndexableOption<int> first = ints1;

            // Act
            bool areEqual = first.Equals(ints2);

            // Assert
            Assert.True(areEqual);
        }
    }
}
