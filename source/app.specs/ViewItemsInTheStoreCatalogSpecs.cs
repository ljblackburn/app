using System.Collections.Generic;
using Machine.Specifications;
using app.web.application.catalogbrowsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(ViewItemsInTheStoreCatalog))]
    public class ViewItemsInTheStoreCatalogSpecs
  {
    public abstract class concern : Observes<ISupportAUserFeature,
                                      ViewItemsInTheStoreCatalog>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        request = fake.an<ISupportAUserFeature>();
        request.setup(x => x.)
        information_in_the_store_finder = depends.on<IFindInformationInTheStore>();
        the_main_departments = new List<DepartmentItem>();
        display_engine = depends.on<IDisplayInformation>();

        information_in_the_store_finder.setup(x => x.get_the_main_departments_in_the_store()).Return(the_main_departments);
      };

      Because b = () =>
        sut.process(request);

      It should_get_the_list_of_the_main_departments = () =>
      {
      };

      It should_display_the_main_departments = () =>
        display_engine.received(x => x.display(the_main_departments));

      static IFindInformationInTheStore information_in_the_store_finder;
      static ISupportAUserFeature request;
      static IEnumerable<DepartmentItem> the_main_departments;
      static IDisplayInformation display_engine;
    }
  }
}