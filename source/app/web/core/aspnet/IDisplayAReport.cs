using System.Web;
using System.Web.UI;

namespace app.web.core.aspnet
{
  public interface IDisplayA<TReportModel> : IHttpHandler
  {
    TReportModel report { get; set; }
  }


  public class SimpleViewFor<TReportModel> : Page,IDisplayA<TReportModel>
  {
    public TReportModel report { get; set; }
  }
}