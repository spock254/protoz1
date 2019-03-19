

public class HorseState
{
    private static int CURRENT_DIALOG_STATE = 0;
    public enum State
    {
        HELLO = 0,
        CIGARETS,
        NO_CIGARETS

    }
    public static void SET_STATE(State node)
    {
        CURRENT_DIALOG_STATE = (int)node;
    }
    public static int GET_STATE()
    {
        return CURRENT_DIALOG_STATE;
    }
    public static State GET_STATE_RAW()
    {
        return (State)CURRENT_DIALOG_STATE;
    }
    
}
