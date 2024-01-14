using System.CommandLine;
using Chef.Cli.Commands;

namespace Chef.Cli;

public class ConsoleRunner
{
    private readonly ListCommandHandler _listCommandHandler;
    private readonly AddCommandHandler _addCommandHandler;
    private readonly DeleteCommandHandler _deleteCommandHandler;

    public ConsoleRunner(
        ListCommandHandler listCommandHandler,
        AddCommandHandler addCommandHandler,
        DeleteCommandHandler deleteCommandHandler)
    {
        _listCommandHandler = listCommandHandler;
        _addCommandHandler = addCommandHandler;
        _deleteCommandHandler = deleteCommandHandler;
    }
    
    private RootCommand BuildRootCommand()
    {
        var rootCommand = new RootCommand("A meal planner in your terminal");

        // Subcommand: add
        var addCommand = new Command("add", "Add a new meal");
        var addCommandPathArgument = new Argument<string>("path", "Path of the Mealfile to be added");
        addCommand.AddArgument(addCommandPathArgument);
        addCommand.SetHandler(_addCommandHandler.Handle, addCommandPathArgument);
        rootCommand.AddCommand(addCommand);
        
        // subcommand: list
        var listCommand = new Command("list", "Lists all saved meals");
        listCommand.SetHandler(_listCommandHandler.Handle);
        rootCommand.AddCommand(listCommand);
        
        // subcommand: delete
        var deleteCommand = new Command("delete", "Deletes a meal");
        var deleteCommandToDeleteArgument = new Argument<string>("toDelete",
            "ID or name of the meal to be deleted");
        deleteCommand.AddArgument(deleteCommandToDeleteArgument);
        deleteCommand.SetHandler(_deleteCommandHandler.Handle, deleteCommandToDeleteArgument);
        rootCommand.AddCommand(deleteCommand);
        
        return rootCommand;
    }
    
    public async Task Run(string[] args)
    {
        var rootCommand = BuildRootCommand();
        await rootCommand.InvokeAsync(args);
    }
}