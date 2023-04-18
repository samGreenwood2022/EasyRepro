using System;
using TechTalk.SpecFlow;

namespace WCCIS.Specs.StepDefinitions
{
    [Binding]
    public class MPI0001_MPIStepDefinitions
    {
        [Then(@"an error message contains text '([^']*)'")]
        public void ThenAnErrorMessageContainsText(string p0)
        {
            throw new PendingStepException();
        }
    }
}
