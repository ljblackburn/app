using System.Web;

namespace app.web.core.aspnet
{
  public interface ICreateAWebFormView
  {
    IHttpHandler create_view_that_can_display<TReportModel>(TReportModel report);
  }
}