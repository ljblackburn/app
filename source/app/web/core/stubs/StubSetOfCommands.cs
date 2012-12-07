using System.Collections;
using System.Collections.Generic;
using app.web.application.catalogbrowsing;

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
      yield return new RequestCommand(x => true, new ViewItemsInTheStoreCatalog(new ViewTheProductsInADepartment()));
      yield return new RequestCommand(x => true, new ViewItemsInTheStoreCatalog(new ViewTheDepartmentsInADepartment()));
      yield return new RequestCommand(x => true, new ViewItemsInTheStoreCatalog(new ViewTheMainDepartmentsInTheStore()));
    }
  }
}