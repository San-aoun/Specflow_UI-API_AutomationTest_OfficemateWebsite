using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TechTalk.SpecFlow;

namespace OfficeMate.E2E.StepDefinition
{
    public abstract class BaseStepDefinition
    {
        protected readonly FeatureContext FeatureContext;

        protected BaseStepDefinition(FeatureContext featureContext)
        {
            FeatureContext = featureContext ?? throw new ArgumentNullException(nameof(featureContext));
        }
    }
}
