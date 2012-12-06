 using System.Web;
 using Machine.Specifications;
 using app.web.core.aspnet;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(WebFormViewFactory))]  
  public class WebFormViewFactorySpecs
  {
    public abstract class concern : Observes<ICreateAWebFormView,
                                      WebFormViewFactory>
    {
        
    }

   
    public class when_creating_a_view_that_can_display_a_model : concern
    {
      Establish c = () =>
      {
        model = new WebFormDisplayEngineSpecs.AnItemToDisplay();
        the_view_that_can_display_the_model = fake.an<IDisplayA<WebFormDisplayEngineSpecs.AnItemToDisplay>>();
        path = "this is the path";
        view_template_path_registry = depends.on<IFindPathsToViewTemplates>();
        depends.on<ICreateTheRawAspView>((x,type) =>
        {
          x.ShouldEqual(path);
          type.ShouldEqual(typeof(IDisplayA<WebFormDisplayEngineSpecs.AnItemToDisplay>));
          return the_view_that_can_display_the_model;
        });

        view_template_path_registry.setup(x => x.get_the_path_to_the_view_that_can_display<WebFormDisplayEngineSpecs.AnItemToDisplay>())
          .Return(path);
      };

      Because b = () =>
        result = sut.create_view_that_can_display(model);

      It should_populate_the_view_with_the_information_it_needs_to_display = () =>
        the_view_that_can_display_the_model.report.ShouldEqual(model);
        
      It should_return_the_view_that_can_display_the_model = () =>
        result.ShouldEqual(the_view_that_can_display_the_model);

      static IHttpHandler result;
      static IDisplayA<WebFormDisplayEngineSpecs.AnItemToDisplay> the_view_that_can_display_the_model;
      static WebFormDisplayEngineSpecs.AnItemToDisplay model;
      static IFindPathsToViewTemplates view_template_path_registry;
      static string path;
    }
  }
}
