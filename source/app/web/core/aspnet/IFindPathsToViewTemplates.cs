namespace app.web.core.aspnet
{
  public interface IFindPathsToViewTemplates
  {
    string get_the_path_to_the_view_that_can_display<TReportModel>();
  }
}