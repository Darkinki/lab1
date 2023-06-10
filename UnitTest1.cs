using NUnit.Framework;
using memento;

namespace tests
{
    public class Tests
    {
        [Test]
        public void RevPrevState()
        {
            TextEditor editor = new TextEditor();
            editor.InsertText("Hello,");
            editor.InsertText(" my dear!");
            editor.DeleteText(0, 6);
            editor.UndoOperation();
            Assert.AreEqual("Hello, my dear!", editor.GetText());
        }
        [Test]
        public void InsertText_ReturnInserted()
        {
            TextEditor editor = new TextEditor();
            editor.InsertText("Hello");
            editor.InsertText(" World!");
            Assert.AreEqual("Hello World!", editor.GetText());
        }

        [Test]
        public void Del_Get_ReturnDelPart()
        {
            TextEditor editor = new TextEditor();
            editor.InsertText("Hello World!");
            editor.DeleteText(6, 12); // Видалення "World!"
            Assert.AreEqual("Hello ", editor.GetText());
        }
    }
}