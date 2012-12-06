using System.Web;
using System.Web.Compilation;
using app.web.core.aspnet.stubs;

namespace app.web.core.aspnet
{
  public class WebFormViewFactory : ICreateAWebFormView
  {
    IFindPathsToViewTemplates view_template_path_registry;
    ICreateTheRawAspView raw_page_factory;

    public WebFormViewFactory(ICreateTheRawAspView raw_page_factory, IFindPathsToViewTemplates view_template_path_registry)
    {
      this.raw_page_factory = raw_page_factory;
      this.view_template_path_registry = view_template_path_registry;
    }

    public WebFormViewFactory():this(BuildManager.CreateInstanceFromVirtualPath,
      new StubPathRegistry())
    {
    }

    public IHttpHandler create_view_that_can_display<TReportModel>(TReportModel report)
    {
      var view = (IDisplayA<TReportModel>)raw_page_factory(view_template_path_registry.get_the_path_to_the_view_that_can_display<TReportModel>(),
        typeof(IDisplayA<TReportModel>));
      view.report = report;
      return view;
    }
  }
}