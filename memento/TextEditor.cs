namespace memento;

public class TextEditor
{
    private string text;
    private Stack<EditorMemento> history;

    public TextEditor()
    {
        text = "";
        history = new Stack<EditorMemento>();
    }

    public void InsertText(string text)
    {
        string currentState = text;
        history.Push(new EditorMemento(currentState));

        this.text += text;
    }

    public void DeleteText(int start, int end)
    {
        string currentState = text;
        history.Push(new EditorMemento(currentState));

        text = text.Remove(start, end - start);
    }

    public string GetText()
    {
        return text;
    }

    public void UndoOperation()
    {
        if (history.Count == 0)
        {
            Console.WriteLine("no available operations");
            return;
        }

        EditorMemento previousState = history.Pop();
        text = previousState.GetState();
    }
}
