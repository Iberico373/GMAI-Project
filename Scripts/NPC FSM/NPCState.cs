namespace RayWenderlich.Unity.StatePatternInUnity
{
    public abstract class NPCState
    {
        protected NPC npc;
        protected NPCStateMachine stateMachine;

        protected NPCState(NPC npc, NPCStateMachine stateMachine)
        {
            this.npc = npc;
            this.stateMachine = stateMachine;
        }

        //This function is called when the object enters a state 
        public virtual void Enter()
        {

        }

        //Part of the update loop that handles inputs 
        public virtual void HandleInput()
        {

        }

        //Part of the update loop that handles the core logic 
        public virtual void LogicUpdate()
        {

        }

        //Part of the update loop that handles physics logic and calculations
        public virtual void PhysicsUpdate()
        {

        }

        //This function is called when the object is exiting a state
        public virtual void Exit()
        {

        }
    }
}
