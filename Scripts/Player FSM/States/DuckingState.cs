/*
 * Copyright (c) 2019 Razeware LLC
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * Notwithstanding the foregoing, you may not use, copy, modify, merge, publish, 
 * distribute, sublicense, create a derivative work, and/or sell copies of the 
 * Software in any work that is designed, intended, or marketed for pedagogical or 
 * instructional purposes related to programming, coding, application development, 
 * or information technology.  Permission for such use, copying, modification,
 * merger, publication, distribution, sublicensing, creation of derivative works, 
 * or sale is expressly withheld.
 *    
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using UnityEngine;

namespace RayWenderlich.Unity.StatePatternInUnity
{
    public class DuckingState : GroundedState
    {
        private bool belowCeiling;
        private bool crouchHeld;

        public DuckingState(Character character, StateMachine stateMachine) : base(character, stateMachine)
        {

        }

        public override void Enter()
        {
            base.Enter();
            //Sets paramater to trigger crouch animation to be true
            character.SetAnimationBool(character.crouchParam, true);

            //Applies the character's 'CrouchSpeed' and 'CrouchRotationSpeed'
            //to 'speed' and 'rotationSpeed' respectively
            speed = character.CrouchSpeed;
            rotationSpeed = character.CrouchRotationSpeed;

            //Sets the character's collider size to the intended
            //collider height when crouching
            character.ColliderSize = character.CrouchColliderHeight;

            //Resets 'belowCeiling' to false
            belowCeiling = false;
        }

        public override void Exit()
        {
            base.Exit();
            //Sets paramater for crouch animation to be false
            character.SetAnimationBool(character.crouchParam, false);

            //Resets the chracter's collider size back to normal
            character.ColliderSize = character.NormalColliderHeight;
        }

        public override void HandleInput()
        {
            base.HandleInput();
            //Sets 'crouchHeld' to accept user input
            crouchHeld = Input.GetButton("Fire3");
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            //If 'crouchHeld' or 'belowCeiling' is false, set 'CurrentState' to be 'standing'
            if (!(crouchHeld || belowCeiling))
            {
                stateMachine.ChangeState(character.standing);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
            //'belowCeiling' is set by checking if there is a collision overlap
            //on top of the Character GameObject's head
            belowCeiling = character.CheckCollisionOverlap(character.transform.position + 
                Vector3.up * character.NormalColliderHeight);
        }

    }
}
