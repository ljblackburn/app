using app.web.application.catalogbrowsing.stubs;
using app.web.core;
using app.web.core.aspnet;

namespace app.web.application.catalogbrowsing
{
  public class ViewTheMainDepartmentsInTheStore : ISupportAUserFeature
  {
    IFindInformationInTheStore store_catalog;
    IDisplayInformation display_engine;

    public ViewTheMainDepartmentsInTheStore() : this(new StubStoreCatalog(),
                                                     new WebFormDisplayEngine())
    {
    }

    public ViewTheMainDepartmentsInTheStore(IFindInformationInTheStore information_in_the_store_catalog,
                                            IDisplayInformation department_viewer)
    {
      this.store_catalog = information_in_the_store_catalog;
      this.display_engine = department_viewer;
    }

    public void process(IContainRequestDetails request)
    {
      display_engine.display(store_catalog.get_the_main_departments_in_the_store());
    }
  }
}