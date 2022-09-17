using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TechTalk.SpecFlow;

namespace OfficeMate.API.Test.StepDefinitions
{
    public class BaseStepDefinition
    {
        protected readonly FeatureContext _featureContext;
        public BaseStepDefinition(FeatureContext featureContext)
        {
            _featureContext = featureContext;
        }
    }
}
