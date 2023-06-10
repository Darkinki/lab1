using System;

namespace memento
{
    class EditorMemento
    {
        private string state; // place where we hold data

        public EditorMemento(string state)
        {
            this.state = state;
        }

        public string GetState()
        {
            return state;
        }
    }

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

    class Program
    {
        static void Main(string[] args)
        {
            TextEditor editor = new TextEditor();
            Console.WriteLine(editor.GetText()); // empty state

            editor.InsertText("whatever happens,");
            Console.WriteLine(editor.GetText());

            editor.InsertText(" happens");
            Console.WriteLine(editor.GetText());

            editor.DeleteText(0, 9);
            Console.WriteLine(editor.GetText());

            editor.UndoOperation();
            Console.WriteLine(editor.GetText());
        }
    }
}