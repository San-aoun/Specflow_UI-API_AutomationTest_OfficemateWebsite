using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OfficeMate.API.Test.Common;

using TechTalk.SpecFlow;

namespace OfficeMate.API.Test.StepDefinitions
{
    public sealed class ScenarioLifeCycleStep
    {
        private static APISessionManager _apiSessionManager;

        [BeforeTestRun(Order = 0)]
        public static void BeforeTestRun()
        {
            Console.WriteLine("BeforeTestRun Starting");
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featurecontext)
        {
            Console.WriteLine("BeforeFeature Starting " + featurecontext.FeatureInfo.Title);

            _apiSessionManager = new APISessionManager();
        }
    }
}
