using System;
using System.IO;
using System.Linq.Expressions;
using System.Web;
using developwithpassion.specifications.extensions;

namespace app.specs.utility
{
  public class ObjectFactory
  {
    public class web
    {
      public static HttpContext create_http_context()
      {
        return new HttpContext(create_request(), create_response());
      }

      static HttpResponse create_response()
      {
        return new HttpResponse(new StringWriter());
      }

      static HttpRequest create_request()
      {
        return new HttpRequest("blah.aspx", "http://localhost/blah.aspx", String.Empty);
      }
    }

    public class expressions
    {
      public static ExpressionBuilderFor<T> to_target<T>()
      {
        return new ExpressionBuilderFor<T>();
      }
    }
  }

  public class ExpressionBuilderFor<T>
  {
    public string get_property_name_of<PropertyType>(Expression<Func<T, PropertyType>> accessor)
    {
      return accessor.Body.downcast_to<MemberExpression>().Member.Name;
    }
  }
}