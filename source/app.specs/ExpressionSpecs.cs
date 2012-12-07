using System;
using System.Data;
using System.Data.SqlClient;
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
        var parameter_expression = Expression.Parameter(typeof(int), "number");
        var number_two = Expression.Constant(2);
        var modulus_of_two = Expression.Modulo(parameter_expression, number_two);
        var equal_to_zero = Expression.Equal(modulus_of_two, Expression.Constant(0));
        var dynamic_even = Expression.Lambda<Func<int, bool>>(equal_to_zero,parameter_expression);

        dynamic_even.Compile().Invoke(2).ShouldBeTrue();
      };

      It should_be_able_to_cache_values_from_a_call = () =>
      {
        var enhanced = BlockCandy.to_run(create_connection)
                                 .cache_result();

        var first = enhanced();
        var second = enhanced();

        first.ShouldEqual(second);
      };

      static IDbConnection create_connection()
      {
        return new SqlConnection();
      }

    }

    public class Person
    {
      public string first_name { get; set; }
    }
  }
}