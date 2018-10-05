using System.Collections.Generic;
using System.Linq;
using LogEx.Core.Result;

namespace LogEx.Core.Composites
{
    public class OrSpecification<T> : CompositeSpecification<T>
    {
        public OrSpecification(IEnumerable<Specification<T>> specs) : base(specs)
        {
        }

        protected override SpecificationResult IsCompositeSatisfied(IEnumerable<SpecificationResult> results)
        {
            IEnumerable<SpecificationResult> specificationResults = results as SpecificationResult[] ?? results.ToArray();
            var overallSatisfied = specificationResults.Any(x => x.IsSatisfied);
            return new SpecificationResult(overallSatisfied, specificationResults.SelectMany(x => x.Explanations));
        }
    }
}