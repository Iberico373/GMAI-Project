using UnityEngine;

namespace RayWenderlich.Unity.StatePatternInUnity
{
    public class SwingingState : GroundedState
    {
        private int swingParam = Animator.StringToHash("SwingMelee");

        public SwingingState(Character character, StateMachine stateMachine) : base(character, stateMachine)
        {

        }

        public override void Enter()
        {
            base.Enter();
            //Play swing animation
            character.TriggerAnimation(swingParam);
            //Enable sword hitbox
            character.ActivateHitBox();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            //If there are any transitions in the 2nd layer of the animator,
            //change current state to the previous state
            if (character.CheckTransition(1))
            {
                stateMachine.ChangeState(stateMachine.PreviousState);
            }
        }

        public override void Exit()
        {
            base.Exit();
            //Disable sword hitbox
            character.DeactivateHitBox();
        }
    }
}



