using LogEx.Core.Explanations;
using LogEx.Core.Result;

namespace LogEx.Core
{
    public class Specification<TTarget>
    {
        public Specification(SpecificationFunction<TTarget> specificationFunction)
        {
            SpecificationFunction = specificationFunction;
            _options = new InvocationOptions();
        }

        private SpecificationFunction<TTarget> SpecificationFunction { get; set; }
        private InvocationOptions _options { get; }

        protected Specification<TTarget> FromDelegate(SpecificationFunction<TTarget> specificationFunction)
        {
            SpecificationFunction = specificationFunction;
            return this;
        }

        public Specification<TTarget> WithSeverity(Severity severity)
        {
            _options.InstanceSeverity = severity;
            return this;
        }

        public SpecificationResult IsSatisfiedBy(TTarget target)
        {
            return SpecificationFunction.Invoke(target, _options);
        }
    }
}