using UnityEngine;

namespace RayWenderlich.Unity.StatePatternInUnity
{    public class AttackState : NPCState
    {
        private int attackParam = Animator.StringToHash("Attack");

        public AttackState(NPC npc, NPCStateMachine stateMachine) : base(npc, stateMachine)
        {

        }

        public override void Enter()
        {
            base.Enter();
            //Play attack animation
            npc.TriggerAnimation(attackParam);
            //Enable attack hitbox
            npc.ActivateHitBox();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            //If there are any transitions in the first layer of the animator,
            //change current state to previous state
            if (npc.CheckTransition(0))
            {
                stateMachine.ChangeState(stateMachine.PreviousState);
            }
        }
    }
}
