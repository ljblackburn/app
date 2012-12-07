using System;
using System.Linq.Expressions;
using Machine.Specifications;
using app.specs.utility;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  public class ExpressionSpecs
  {
    public abstract class concern : Observes
    {
    }

    public class when_playing_around_with_expressions : concern
    {
      It should_be_able_to_evaluate_an_expression = () =>
      {
        var builder = ObjectFactory.expressions.to_target<Person>();
        builder.get_property_name_of(x => x.first_name).ShouldEqual("first_name");
      };

      It should_be_able_to_build_a_code_fragment_from_scratch = () =>
      {
        Func<int, bool> is_even = x => x%2 == 0;

        //build me a tree that represents an is_even check
        var dynamic_even = Expression.Lambda<Func<int, bool>>(....);
        dynamic_even.Compile().Invoke(2).ShouldBeTrue();
      };
    }

    public class Person
    {
      public string first_name { get; set; }
    }
  }
}