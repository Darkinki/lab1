namespace memento;

public class EditorMemento
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