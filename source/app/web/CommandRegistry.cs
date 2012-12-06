using System.Collections.Generic;

namespace app.web
{
  public class CommandRegistry : IFindCommands
  {
    IEnumerable<IRunOneRequest> all_the_possible_commands; 
    
    public CommandRegistry(IEnumerable<IRunOneRequest> all_the_possible_commands)
    {
        this.all_the_possible_commands = all_the_possible_commands;
    }

    public IRunOneRequest get_the_command_that_can_run(IContainRequestDetails the_request)
    {
        foreach (IRunOneRequest command in all_the_possible_commands)
        {
            if (command.can_run(the_request)) return command;
        }
        return null;
    }
  }
}