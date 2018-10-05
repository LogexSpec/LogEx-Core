using System.Collections.Generic;
using LogEx.Core.Explanations;

namespace LogEx.Core.Result
{
    public class SpecificationResult
    {
        public List<Explanation> Explanations;
        public bool IsSatisfied;

        public SpecificationResult(bool isSatisfied, IEnumerable<Explanation> explanations)
        {
            Explanations = new List<Explanation>(explanations);
            IsSatisfied = isSatisfied;
        }

        public SpecificationResult(Explanation explanation)
            : this(explanation.IsSatisfied, new List<Explanation> {explanation})
        {
        }
    }
}