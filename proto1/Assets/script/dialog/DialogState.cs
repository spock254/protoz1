

public class DialogState
{
    public static class HorseDialogState
    {
        public static int CURRENT_DIALOG_STATE = 0;
        public enum Node
        {
            HELLO = 0,
            CIGARETS
        }
        public static int GET_STATE(Node node)
        {
            CURRENT_DIALOG_STATE = (int)node;
            return CURRENT_DIALOG_STATE;
        }
    }
}
