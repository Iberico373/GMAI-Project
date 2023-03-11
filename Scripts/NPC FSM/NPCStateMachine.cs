namespace RayWenderlich.Unity.StatePatternInUnity
{
    public class NPCStateMachine
    {
        public NPCState CurrentState { get; private set; }
        public NPCState PreviousState { get; private set; }

        //Configures the character state machine by setting 'CurrentState' to the 'startingState' 
        public void Initialize(NPCState startingState)
        {
            CurrentState = startingState;

            if (CurrentState != null)
            {
                CurrentState.Enter();
            }
        }

        //Handles transitions between States
        public void ChangeState(NPCState newState)
        {
            PreviousState = CurrentState;

            if (CurrentState != null)
            {
                CurrentState.Exit();
            }

            CurrentState = newState;

            if (CurrentState != null)
            {
                CurrentState.Enter();
            }
        }
    }
}
