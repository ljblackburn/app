using System;

namespace app
{
  public class SomeClassWithErrors
  {
    public void do_something()
    {
      throw new NotImplementedException();
    }
  }

  public class ConsumerOfClientThatThrowsErrors
  {
    SomeClassWithErrors error_item;

    public ConsumerOfClientThatThrowsErrors(SomeClassWithErrors error_item)
    {
      this.error_item = error_item;
    }

    public void run()
    {
    }
  }
}