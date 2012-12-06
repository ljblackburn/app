using System.Web;

namespace app.web.core.aspnet
{
  public class WebFormDisplayEngine : IDisplayInformation
  {
    ICreateAWebFormView view_factory;
    IGetTheCurrentlyExecutingRequest current_request_resolution;

    public WebFormDisplayEngine(IGetTheCurrentlyExecutingRequest current_request_resolution,
                                ICreateAWebFormView view_factory)
    {
      this.current_request_resolution = current_request_resolution;
      this.view_factory = view_factory;
    }

    public WebFormDisplayEngine():this(() => HttpContext.Current,
      new WebFormViewFactory())
    {
    }

    public void display<ReportModel>(ReportModel model)
    {
      view_factory.create_view_that_can_display(model).ProcessRequest(current_request_resolution());
    }
  }
}