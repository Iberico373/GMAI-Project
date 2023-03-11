using UnityEngine;

namespace RayWenderlich.Unity.StatePatternInUnity
{
    public class HitState : GroundedState
    {
        private int hitParam = Animator.StringToHash("Hit");

        public HitState(Character character, StateMachine stateMachine) : base(character, stateMachine)
        {

        }

        public override void Enter()
        {
            base.Enter();
            //Play hit animation
            character.TriggerAnimation(hitParam);
            //Change state back to the previous state;
            stateMachine.ChangeState(stateMachine.PreviousState);
        }
    }
}
