using CalculatorMicroservice;
using CalculatorMicroservice.Controllers;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using System.Text.Json;

namespace PruebasUnitarias
{
    public class CalculatorControllerTests : IntegrationBuilder
    {        

        [Fact]
        public async Task Add_ShouldReturnTwelve()
        {
            //Arrange            
            int firstOperand = 10;
            int secondOperand = 2;
            int expectedResult = 12;

            var sut = await TestClient.GetAsync($"/Calculator/Add?firstOperand={firstOperand}&secondOperand={secondOperand}");



            //Act
            var content = await sut.Content.ReadAsStringAsync();
            var result = Newtonsoft.Json.JsonSerializer.CreateDefault().Deserialize<ApiResult>(new JsonTextReader(new StringReader(content)));
            var actual = result.Answer;

            //Assert

            Assert.Equal(expectedResult, actual);

        }

        [Fact]
        public async Task Add_ShouldReturnEight()
        {
            //Arrange            
            int firstOperand = 10;
            int secondOperand = -2;
            int expectedResult = 8;


            var sut = await TestClient.GetAsync($"/Calculator/Add?firstOperand={firstOperand}&secondOperand={secondOperand}");
            //Act
            var content = await sut.Content.ReadAsStringAsync();
            var result = Newtonsoft.Json.JsonSerializer.CreateDefault().Deserialize<ApiResult>(new JsonTextReader(new StringReader(content)));
            var actual = result.Answer;

            //Assert

            Assert.Equal(expectedResult, actual);

        }
        [Fact]
        public async Task Substract_ShouldReturn8()
        {
            //Arrange            
            int firstOperand = 10;
            int secondOperand = 2;
            int expectedResult = 8;
            
            var sut = await TestClient.GetAsync($"/Calculator/Substract?firstOperand={firstOperand}&secondOperand={secondOperand}");

            //Act
            var content = await sut.Content.ReadAsStringAsync();
            var result = Newtonsoft.Json.JsonSerializer.CreateDefault().Deserialize<ApiResult>(new JsonTextReader(new StringReader(content)));
            var actual = result.Answer;

            //Assert

            Assert.Equal(expectedResult, actual);

        }
        [Fact]
        public async Task Multiply_ShouldReturnTwenty()
        {
            //Arrange            
            int firstOperand = 10;
            int secondOperand = 2;
            int expectedResult = 20;
            var loggerService = new Mock<ILogger<CalculatorController>>();

            var sut = await TestClient.GetAsync($"/Calculator/Multiply?firstOperand={firstOperand}&secondOperand={secondOperand}");
            //Act
            var content = await sut.Content.ReadAsStringAsync();
            var result = Newtonsoft.Json.JsonSerializer.CreateDefault().Deserialize<ApiResult>(new JsonTextReader(new StringReader(content)));
            var actual = result.Answer;

            //Assert

            Assert.Equal(expectedResult, actual);

        }
        [Fact]
        public async Task Divide_ShouldReturnFive()
        {
            //Arrange            
            int firstOperand = 10;
            int secondOperand = 2;
            int expectedResult = 5;

            var sut = await TestClient.GetAsync($"/Calculator/Divide?firstOperand={firstOperand}&secondOperand={secondOperand}");
            //Act
            var content = await sut.Content.ReadAsStringAsync();
            var result = Newtonsoft.Json.JsonSerializer.CreateDefault().Deserialize<ApiResult>(new JsonTextReader(new StringReader(content)));
            var actual = result.Answer;

            //Assert

            Assert.Equal(expectedResult, actual);

        }
        [Fact]
        public async Task Add_ResultShouldBeTypeApiResult()
        {
            //Arrange            
            int firstOperand = 10;
            int secondOperand = 2;

            var sut = await TestClient.GetAsync($"/Calculator/Add?firstOperand={firstOperand}&secondOperand={secondOperand}");
            //Act
            var content = await sut.Content.ReadAsStringAsync();
            var result = Newtonsoft.Json.JsonSerializer.CreateDefault().Deserialize<ApiResult>(new JsonTextReader(new StringReader(content)));

            //Assert            
            result.Should().BeOfType<ApiResult>();

        }


    }
    public class ApiResult
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("answer")]
        public double Answer { get; set; }
    }
}
