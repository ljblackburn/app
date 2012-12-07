using System.Collections;
using System.Collections.Generic;
using app.web.application.catalogbrowsing;
using app.web.application.catalogbrowsing.stubs;

namespace app.web.core.stubs
{
  public class StubSetOfCommands : IEnumerable<IRunOneRequest>
  {
    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerator<IRunOneRequest> GetEnumerator()
    {
      yield return
        new RequestCommand(x => true,
                           new ViewA<IEnumerable<Product>>(
                             x =>
                               new StubStoreCatalog().get_the_products_using(x.map<ViewTheProductsInDepartmentRequest>())))
        ;
      yield return new RequestCommand(x => true, new ViewA<IEnumerable<DepartmentItem>>(new GetTheMainDepartments()));
      yield return
        new RequestCommand(x => true,
                           new ViewA<IEnumerable<DepartmentItem>>(
                             x =>
                               new StubStoreCatalog().get_the_departments_using(
                                 x.map<ViewDepartmentInDepartmentRequest>())));
    }

    public class GetTheMainDepartments : IFetchAReportUsingARequest<IEnumerable<DepartmentItem>>
    {
      public IEnumerable<DepartmentItem> fetch_report_using(IContainRequestDetails request)
      {
        return new StubStoreCatalog().get_the_main_departments_in_the_store();
      }
    }
  }
}