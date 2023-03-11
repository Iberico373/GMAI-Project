using UnityEngine;

namespace RayWenderlich.Unity.StatePatternInUnity
{
    public class DrawSheathState : GroundedState
    {
        private int drawParam = Animator.StringToHash("DrawMelee");
        private int sheathParam = Animator.StringToHash("SheathMelee");

        public DrawSheathState(Character character, StateMachine stateMachine) : base(character, stateMachine)
        {

        }

        public override void Enter()
        {
            base.Enter();
            //If the character's weapon is drawn...
            if (character.weaponDrawn)
            {
                //Set 'weaponDrawn' to false
                character.weaponDrawn = false;
                //Play the sheathing animation
                character.TriggerAnimation(sheathParam);
                //Place the character's weapon on their back
                character.SheathWeapon();
                //Change current state to 'standing'
                stateMachine.ChangeState(character.standing);
            }

            //If the character does not have their weapon drawn...
            else if (!character.weaponDrawn)
            {
                //Set 'weaponDrawn' to true
                character.weaponDrawn = true;
                //Equip the sheathed weapon on the player's hands
                character.Equip(null);
                //Play the weapon draw animation
                character.TriggerAnimation(drawParam);
                //Change current state to 'standing'
                stateMachine.ChangeState(character.standing);
            }
        }
    }
}
