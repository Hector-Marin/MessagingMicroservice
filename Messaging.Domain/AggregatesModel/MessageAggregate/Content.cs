using Messaging.Domain.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Messaging.Domain.AggregatesModel.MessageAggregate
{
    public class Content : ValueObject
    {
        public String Text { get; private set; }

        public Content() { }

        public Content(string text)
        {
            Text = text;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return Text;
        }
    }
}
