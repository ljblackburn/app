using System.Web;
using Machine.Specifications;
using app.specs.utility;
using app.web.core;
using app.web.core.aspnet;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(WebFormDisplayEngine))]
  public class WebFormDisplayEngineSpecs
  {
    public abstract class concern : Observes<IDisplayInformation,
                                      WebFormDisplayEngine>
    {
    }

    public class when_displaying_information : concern
    {
      Establish c = () =>
      {
        view_factory = depends.on<ICreateAWebFormView>();
        the_current_request = ObjectFactory.web.create_http_context();
        depends.on<IGetTheCurrentlyExecutingRequest>(() => the_current_request);
        detail = new AnItemToDisplay();
        view = fake.an<IHttpHandler>();

        view_factory.setup(x => x.create_view_that_can_display(detail)).Return(view);
      };

      Because b = () =>
        sut.display(detail);

      It should_tell_the_view_that_can_display_the_information_to_render = () =>
        view.received(x => x.ProcessRequest(the_current_request));

      static IHttpHandler view;
      static HttpContext the_current_request;
      static AnItemToDisplay detail;
      static ICreateAWebFormView view_factory;
    }

    public class AnItemToDisplay
    {
    }
  }
}