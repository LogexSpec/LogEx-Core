using System;
using System.Collections.Generic;
using LogEx.Core;
using LogEx.Core.Explanations;
using LogEx.Core.Result;

namespace LogEx.Sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MyObj obj = new MyObj();
            obj.StringProp = "b";
            obj.IntProp = 1;

            MySet specs = new MySet();
            List<Specification<MyObj>> manySpecs =
                new List<Specification<MyObj>>
                {
                    specs.Numis1,
                    specs.StartsWithA.WithSeverity(Severity.Critical)
                    
                };
            foreach (Specification<MyObj> specification in manySpecs)
            {
                SpecificationResult result = specification.IsSatisfiedBy(obj);

                Console.WriteLine(result.IsSatisfied);
                result.Explanations.ForEach(x => Console.WriteLine($"{x.IsSatisfied} - {x.Message} - Sevrity: {x.Severity}"));
            }
        }
    }
}
