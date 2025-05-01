using System.Collections.Generic;

public class CommandManager
{
    private Stack<ICommand> _undoStack = new Stack<ICommand>();
    private Stack<ICommand> _redoStack = new Stack<ICommand>();

    //execute the command in stack
    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _undoStack.Push(command);
        _redoStack.Clear(); 
    }

    //undo step
    public void Undo()
    {
        if (_undoStack.Count == 0) return;

        ICommand command = _undoStack.Pop();
        command.Undo();
        _redoStack.Push(command);
    }

    //redo the step
    public void Redo()
    {
        if (_redoStack.Count == 0) return;

        ICommand command = _redoStack.Pop();
        command.Execute();
        _undoStack.Push(command);
    }
}