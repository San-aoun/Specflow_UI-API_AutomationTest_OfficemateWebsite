using Newtonsoft.Json;

using OfficeMate.API.Test.APIDto;

using TechTalk.SpecFlow;

using Xunit;

namespace OfficeMate.API.Test.StepDefinitions.Validation
{
    [Binding]
    public sealed class BasicHttpResponseValidation : BaseStepDefinition
    {
        public BasicHttpResponseValidation(FeatureContext featureContext) : base(featureContext) { }

        private void ValidateResponse(int expectStatusCode, int actualStatusCode, string expectReasonPhrase, string actualReasonPhrase)
        {
            Assert.Equal(expectStatusCode, actualStatusCode);
            Assert.Equal(expectReasonPhrase, actualReasonPhrase);
        }

        [Then(@"the user gets a response with code ""(.*)"" message ""(.*)""")]
        public void TheUserGetsAResponseWithCodeMessage(int statusCode, string message)
        {
            ValidateResponse(statusCode, (int)LatestResponseMessage.StatusCode, message, LatestResponseMessage.ReasonPhrase);
        }

        [Then(@"the user gets a response with code ""(.*)"" status message is ""(.*)""")]
        public async Task TheUserGetsAResponseWithCodeStatusMessage(int statusCode, string messageStatus)
        {
            var exceptionDto = await DeserializeResponse<ExceptionDto>();
            var exceptionStatus = exceptionDto.Status;

            Assert.Equal(exceptionStatus, messageStatus);
            Assert.Equal(statusCode, (int)LatestResponseMessage.StatusCode);
        }

        [Then(@"the user gets a response with status ""(.*)"" and error message ""(.*)""")]
        public async Task TheUserGetsAResponseWithErrorCodeTypeAndErrorMessage(string statusCode, string message)
        {
            var exceptionDto = await DeserializeResponse<ExceptionDto>();
            var exceptionMessage = exceptionDto.Message;
            var exceptionStatus = exceptionDto.Status;

            Assert.Equal(statusCode, exceptionStatus);
            Assert.Equal(message, exceptionMessage);
        }
        
        private async Task<T> DeserializeResponse<T>()
        {
            var responseContent = await LatestResponseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseContent);
        }
    }
}
