
namespace TestCosta.Presenters.Contexts
{
    public class Context
    {
        public Mode Mode { get; }

        public Context(Mode mode)
        {
            Mode = Mode;
        }
    }

    public enum Mode
    {
        Insert,
        Edit
    }
}
