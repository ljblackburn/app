using app.web.core;
using app.web.core.aspnet;

namespace app.web.application.catalogbrowsing
{
  public class ViewA<TReportModel> : ISupportAUserFeature
  {
    IDisplayInformation display_engine;
    IFetchA<TReportModel> query;

    public ViewA(IFetchA<TReportModel> query) : this(new WebFormDisplayEngine(), query)
    {
    }

    public ViewA(IDisplayInformation display_engine, IFetchA<TReportModel> query)
    {
      this.display_engine = display_engine;
      this.query = query;
    }

    public ViewA(IFetchAReportUsingARequest<TReportModel> query):this(query.fetch_report_using)
    {
    }

    public void process(IContainRequestDetails request)
    {
      display_engine.display(query(request));
    }
  }
}