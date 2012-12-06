namespace app.web
{
  public class RequestCommand : IRunOneRequest
  {
    public void process(IContainRequestDetails the_request)
    {
      throw new System.NotImplementedException();
    }

    public bool can_run(IContainRequestDetails the_request)
    {
        throw new System.NotImplementedException(); 
    }
  }
}