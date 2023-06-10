using System;

namespace memento
{
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