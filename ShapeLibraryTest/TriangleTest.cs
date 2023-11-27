using Newtonsoft.Json.Linq;
using ShapeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeLibraryTest
{
    public class TriangleTest
    {
        //Check Create Triangle

        //1 - Creare triangle
        [Theory]
        [InlineData(1, 1, 1)]
        public void Triangle_CorrectValue_ReturnTriangleObject(double value1, double value2, double value3)
        {
            var triangle = new Triangle(value1, value2, value3);
            Assert.True(triangle is not null);
        }

        //1.1 - parameterized constructor : style = "Isosceles"
        [Fact]
        public void Triangle_SetTwoSides_ReturnIsoscelesTriangle()
        {
            var expectedStyle = Triangle.TriangleType.Isosceles;
            var valueside = 2.0;
            var valuebaseside = 1.0;

            var triangle = new Triangle(valueside, valuebaseside);

            Assert.Equal(expectedStyle, triangle.Type);
        }

        //1.2 - parameterized constructor : style = "Equilateral"
        [Fact]
        public void Triangle_SetTwoSides_ReturnEquilateralTriangle()
        {
            var expectedStyle = Triangle.TriangleType.Equilateral;
            var valueside = 1.0;

            var triangle = new Triangle(valueside);

            Assert.Equal(expectedStyle, triangle.Type);
        }

        //3 - Throw Exception
        [Theory]
        [InlineData(-1, 1, 1)]
        [InlineData(1, 1, -1)]
        [InlineData(0, 1, 1)]
        [InlineData(Double.MaxValue, 1, 1)]
        [InlineData(1, 1, 3)]
        public void Triangle_ValuesLessOrEqualThan0OrMoreThanLimitValueOrUncorrectSumm_ReturnArgumentException(double value1, double value2, double value3)
        {
            Assert.Throws<ArgumentException>(() => new Triangle(value1, value2, value3));
        }

        //3.1 - Message Throw Exception
        [Fact]
        public void Triangle_ValuesLessOrEqualThan0_ReturnArgumentExceptionMessage()
        {
            //Arrange
            double value1 = 1.0;
            double value2 = 1.0;
            double value3 = -1.0;
            var leadin = DataValidation.exDescList["leadin"];
            var exDesc = DataValidation.exDescList["_IsPositive"];
            //Act
            var ex = Assert.Throws<ArgumentException>(() => new Triangle(value1, value2, value3));
            //Assert
            Assert.Equal(string.Format("{0} {1} {2}", 
                leadin, 
                value3, 
                exDesc), ex.Message);
        }

        //3.2 - Throw Exception : Message 
        [Fact]
        public void Triangle_ValuesMoreThanLimitValue_ReturnArgumentExceptionMessage()
        {
            //Arrange
            double value1 = 1.0;
            double value2 = 1.0;
            double value3MorelimitValue = Double.MaxValue;

            var leadin = DataValidation.exDescList["leadin"];
            var exDesc = DataValidation.exDescList["_ExcessValueForTriangle"];
            var limitValue = DataValidation.UpperLimitValForDeg2;

            //Act
            var ex = Assert.Throws<ArgumentException>(() => new Triangle(value1, value2, value3MorelimitValue));
            //Assert
            Assert.Equal(string.Format("{0} {1}", 
                leadin, 
                exDesc), ex.Message);
        }

        //3.3 - Throw Exception : Message
        [Fact]
        public void Triangle_UnCorrectSummOfTriangleSides_ReturnArgumentExceptionMessage()
        {
            //Arrange
            double value1 = 1.0;
            double value2 = 1.0;
            double value3 = 3.0;

            var leadin = DataValidation.exDescList["leadin"];
            var exDesc = DataValidation.exDescList["_CorrectTriangleSidesSum"];
            var expected = $"{value1} + {value2} <= {value3}";

            var ex = Assert.Throws<ArgumentException>(() => new Triangle(value1, value2, value3));

            Assert.Equal(string.Format("{0} {1} {2}", 
                leadin, 
                expected, 
                exDesc), ex.Message);
        }


        //Get Area
        [Fact]
        public void GetArea_CorrectSidesValue_ReturnArea()
        {
            //Arrange
            var value1 = 3.0;
            var value2 = 4.0;
            var value3 = 5.0;

            var expectedArea = 6.0;

            var area = new Triangle(value1, value2, value3).Area;

            Assert.Equal(expectedArea, area, 2);
        }

        //Is Right - True
        [Fact]
        public void IsRight_RightSidesValue_ReturnTrue()
        {
            //Arrange
            var value1 = 3.0;
            var value2 = 4.0;
            var value3 = 5.0;

            var isright = new Triangle(value1, value2, value3).IsRight();

            Assert.True(isright);
        }

        //Is Right - False
        [Fact]
        public void IsRight_UnRightSidesValue_ReturnFalse()
        {
            //Arrange
            var value1 = 1.0;
            var value2 = 1.0;
            var value3 = 1.0;

            var isright = new Triangle(value1, value2, value3).IsRight();

            Assert.False(isright);
        }

    }
}
