
public class MainState 
{

    private static int CURRENT_MAIN_STATE;
    public void SET_STATE(State state) { CURRENT_MAIN_STATE = (int)state; }
    public State GET_STATE() { return (State)CURRENT_MAIN_STATE; }

    public enum State
    {
        peaceful,
        neutral,
        hostile,
        melancholy,
        hateful,
        dark,
        hidden
    }
    #region NPC

    #endregion

    /*public void SwitchState(State state)
    {
        switch (state)
        {
            case State.peaceful:
                { }
                break;
            case State.neutral:
                { }
                break;
            case State.hostile:
                { }
                break;
            case State.melancholy:
                { }
                break;
            case State.hateful:
                { }
                break;
            case State.dark:
                { }
                break;
            case State.hidden:
                { }
                break;
            default:
                break;
        }
    }
    */
}
