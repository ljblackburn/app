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
          request = fake.an<IContainRequestDetails>();
          store_catalog = depends.on<IFindInformationInTheStore>();
          display_engine = depends.on<IDisplayInformation>();
          items_request = new ViewItemsInTheStoreCatalog();
          the_items_in_the_store_catalog = new List<Product>();

          request.setup(x => x.map<ViewTheProductsInDepartmentRequest>()).Return(items_request);

          store_catalog.setup(x => x.get_the_products_using(items_request)).Return(the_items_in_the_store_catalog);
      };

      Because b = () =>
        sut.process(request);

      It should_display_the_items_in_the_store_catalog = () =>
        display_engine.received(x => x.display(the_items_in_the_store_catalog));

      static IContainRequestDetails request;
      static IEnumerable<Product> the_items_in_the_store_catalog;
      static IFindInformationInTheStore store_catalog;
      static ViewTheProductsInDepartmentRequest items_request;
      static IDisplayInformation display_engine;
    }
  }
}