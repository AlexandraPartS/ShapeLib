using ShapeLibrary;

namespace ShapeLibraryTest
{
    public class CircleTest
    {
        //Check Create Circle

        //1 - Creare circle
        [Theory]
        [InlineData(1)]
        public void Circle_CorrectValue_ReturnCircleObject(double value)
        {
            var circle = new Circle(value);
            Assert.True(circle is not null);
        }

        //2 - Throw Exception
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(Double.MaxValue)]
        public void Circle_ValuesLessOrEqualThan0OrMoreThanLimitValue_ReturnArgumentException(double value)
        {
            Assert.Throws<ArgumentException>(() => new Circle(value));
        }

        //2.1 - Throw Exception : Message 
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void Circle_ValuesLessOrEqualThan0_ReturnArgumentExceptionMessage(double value)
        {
            //Arrange
            var leadin = DataValidation.exDescList["leadin"];
            var exDesc = DataValidation.exDescList["_IsPositive"];
            //Act
            var ex = Assert.Throws<ArgumentException>(() => new Circle(value));
            //Assert
            Assert.Equal(string.Format("{0} {1} {2}", leadin, value, exDesc), ex.Message);
        }

        //2.2 - Throw Exception : Message 
        [Theory]
        [InlineData(Double.MaxValue)]
        public void Circle_ValuesMoreThanLimitValue_ReturnArgumentExceptionMessage(double value)
        {
            //Arrange
            var leadin = DataValidation.exDescList["leadin"];
            var exDesc = DataValidation.exDescList["_ExcessValueForCircle"];
            var limitValue = DataValidation.UpperLimitValForDeg2;
            //Act
            var ex = Assert.Throws<ArgumentException>(() => new Circle(value));
            //Assert
            Assert.Equal(string.Format("{0} {1} {2} {3}", leadin, value, exDesc, limitValue), ex.Message);
        }


        //Get Area
        [Fact]
        public void GetArea_CorrectFormatPositiveRadiusValue_ReturnArea()
        {
            var expectedArea = 3.14;
            var radius = 1.0;

            var area = new Circle(radius).Area;

            Assert.Equal(expectedArea, area, 2);
        }

    }
}