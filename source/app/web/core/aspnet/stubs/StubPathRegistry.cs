using System;
using System.Collections.Generic;
using app.web.application.catalogbrowsing;

namespace app.web.core.aspnet.stubs
{
  public class StubPathRegistry : IFindPathsToViewTemplates
  {
    public string get_the_path_to_the_view_that_can_display<TReportModel>()
    {
      var views = new Dictionary<Type, string>
      {
        {typeof(IEnumerable<DepartmentItem>), create_view_to("DepartmentBrowser")},
        {typeof(IEnumerable<Product>), create_view_to("ProductBrowser")}
      };

      return views[typeof(TReportModel)];
    }

    string create_view_to(string page_name)
    {
      return string.Format("~/views/{0}.aspx", page_name);
    }
  }
}