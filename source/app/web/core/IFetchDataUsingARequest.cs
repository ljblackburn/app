namespace app.web.core
{
  public delegate TReportModel IFetchA<TReportModel>(IContainRequestDetails request);

  public interface IFetchAReportUsingARequest<TReportModel>
  {
    TReportModel fetch_report_using(IContainRequestDetails request);
  }
}