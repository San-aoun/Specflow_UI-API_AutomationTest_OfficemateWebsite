using OfficeMate.API.Test.Common;

using TechTalk.SpecFlow;

namespace OfficeMate.API.Test.StepDefinitions
{
    public sealed class ScenarioLifeCycleStep
    {
        private static APISessionManager _apiSessionManager;

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featurecontext)
        {
            Console.WriteLine("BeforeFeature Starting " + featurecontext.FeatureInfo.Title);

            _apiSessionManager = new APISessionManager();
            featurecontext.FeatureContainer.RegisterInstanceAs(_apiSessionManager);

        }
    }
}
