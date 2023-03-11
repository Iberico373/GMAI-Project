using UnityEngine;

namespace RayWenderlich.Unity.StatePatternInUnity
{
    public class DeadState : State
    {
        private int deathParam = Animator.StringToHash("Death");

        public DeadState(Character character, StateMachine stateMachine) : base(character, stateMachine)
        {
            
        }

        public override void Enter()    
        {
            base.Enter();
            //Sheaths character's weapon
            character.SheathWeapon();
            //Triggers death animation
            character.TriggerAnimation(deathParam);
            //Set collider to be parallel to the ground
            character.GetComponent<CapsuleCollider>().direction = 2;
        }
    }
}


