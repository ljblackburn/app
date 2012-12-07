using Machine.Specifications;
using app.web.application.catalogbrowsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(ViewA<SomeItemToDisplay>))]
  public class ViewASpecs
  {
    public abstract class concern : Observes<ISupportAUserFeature,
                                      ViewA<SomeItemToDisplay>>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        request = fake.an<IContainRequestDetails>();
        display_engine = depends.on<IDisplayInformation>();
        the_item = new SomeItemToDisplay();
        depends.on<IFetchA<SomeItemToDisplay>>(x =>
        {
          x.ShouldEqual(request);
          return the_item;
        });
      };

      Because b = () =>
        sut.process(request);

      It should_display_the_item_retrieved_by_the_query = () =>
        display_engine.received(x => x.display(the_item));

      static IContainRequestDetails request;
      static IDisplayInformation display_engine;
      static SomeItemToDisplay the_item;
    }

    public class SomeItemToDisplay
    {
    }
  }
}