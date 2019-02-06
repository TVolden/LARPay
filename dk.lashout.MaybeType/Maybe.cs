using System.Collections.Generic;
using System.Linq;

namespace dk.lashout.MaybeType
{
    public class Maybe<ValueType>
    {
        private readonly IEnumerable<ValueType> values;

        public Maybe(ValueType value) => 
            values = new[] { value };

        public Maybe() => 
            values = new ValueType[0];

        public bool HasValue() =>
            values.Any();

        public ValueType ValueOrDefault(ValueType defaultValue) => 
            values.DefaultIfEmpty(defaultValue).Single();
    }
}
