using System;
using LogEx.Builder.Clauses;
using LogEx.Core;
using LogEx.Core.Explanations;
using LogEx.Core.Result;

namespace LogEx.Builder
{
    public class SpecificationBuilder<TTarget>
    {
        private WhenClause<TTarget> _when = new WhenClause<TTarget>();
        private ThenClause _then = new ThenClause();
        private ResultClause _result = new ResultClause();
        private ResultClause _elseResult = new ResultClause();


        public SpecificationBuilder<TTarget> When(Func<TTarget, bool> condition)
        {
            _when.Func = condition;
            return this;
        }

        public SpecificationBuilder<TTarget> When(bool condition)
        {
            _when.Func = target => condition;
            return this;
        }

        public SpecificationBuilder<TTarget> NotSatisfied()
        {
            _then.WillBeSatisfied = false;
            return this;
        }

        public SpecificationBuilder<TTarget> Then(string message, Severity severity = Severity.None)
        {
            _result.Explanation = new Explanation(true, message, severity);
            return this;
        }

        public SpecificationBuilder<TTarget> Else(string message, Severity severity = Severity.None)
        {
            _elseResult.Explanation = new Explanation(true, message, severity);
            return this;
        }


        public Specification<TTarget> Build()
        {
            return new Specification<TTarget>((target, options) =>
            {
                bool conditionResult = _when.Func.Invoke(target);

                //TODO CLEAN THIS UP
                if (conditionResult && _then.WillBeSatisfied)
                    return new SpecificationResult(_result.Explanation);
                if (!conditionResult && !_then.WillBeSatisfied)
                    return new SpecificationResult(_elseResult.Explanation);
                if (conditionResult && !_then.WillBeSatisfied)
                    return new SpecificationResult(_result.Explanation);
                if (!conditionResult && _then.WillBeSatisfied)
                    return new SpecificationResult(_result.Explanation);
                return null;
            });
        }
    }
}