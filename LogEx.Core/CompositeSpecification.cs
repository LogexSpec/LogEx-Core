using System.Collections.Generic;
using System.Linq;
using LogEx.Core.Result;

namespace LogEx.Core
{
    public abstract class CompositeSpecification<T> : Specification<T>
    {
        protected CompositeSpecification(IEnumerable<Specification<T>> specs) : base(null)
        {
            FromDelegate((target, options) =>
            {
                IEnumerable<SpecificationResult> results = specs.Select(x => x.IsSatisfiedBy(target));
                return IsCompositeSatisfied(results);
            });
        }

        protected abstract SpecificationResult IsCompositeSatisfied(IEnumerable<SpecificationResult> results);
    }
}