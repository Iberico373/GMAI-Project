using UnityEngine;

namespace RayWenderlich.Unity.StatePatternInUnity
{
    public class NPCDeadState : NPCState
    {
        private int deathParam = Animator.StringToHash("Dead");

        public NPCDeadState(NPC npc, NPCStateMachine stateMachine) : base(npc, stateMachine)
        {

        }

        public override void Enter()
        {
            npc.TriggerAnimation(deathParam);
            npc.GetComponent<CapsuleCollider>().direction = 2;
        }
    }
}


