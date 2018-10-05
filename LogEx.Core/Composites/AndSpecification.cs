using System.Collections.Generic;
using System.Linq;
using LogEx.Core.Result;

namespace LogEx.Core.Composites
{
    public class AndSpecification<T> : CompositeSpecification<T>
    {
        public AndSpecification(IEnumerable<Specification<T>> specs) : base(specs)
        {
        }


        protected override SpecificationResult IsCompositeSatisfied(IEnumerable<SpecificationResult> results)
        {
            IEnumerable<SpecificationResult> specificationResults = results as SpecificationResult[] ?? results.ToArray();
            var overallSatisfied = specificationResults.All(x => x.IsSatisfied);
            return new SpecificationResult(overallSatisfied, specificationResults.SelectMany(x => x.Explanations));
        }
    }
}