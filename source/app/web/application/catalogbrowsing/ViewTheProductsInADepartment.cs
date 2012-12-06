using app.web.application.catalogbrowsing.stubs;
using app.web.core;
using app.web.core.aspnet;

namespace app.web.application.catalogbrowsing
{
  public class ViewTheProductsInADepartment : ISupportAUserFeature
  {
    IFindInformationInTheStore store_catalog;
    IDisplayInformation display_engine;

    public ViewTheProductsInADepartment(IFindInformationInTheStore store_catalog,
                                        IDisplayInformation product_viewer)
    {
      this.store_catalog = store_catalog;
      this.display_engine = product_viewer;
    }

    public ViewTheProductsInADepartment() : this(new StubStoreCatalog(),
                                                 new WebFormDisplayEngine())
    {
    }

    public void process(IContainRequestDetails request)
    {
      display_engine.display(store_catalog.get_the_products_using(request.map<ViewTheProductsInDepartmentRequest>()));
    }
  }
}