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
    public class StandingState : GroundedState
    {
        private bool jump;
        private bool crouch;
        private bool draw;
        private bool attack;

        public StandingState(Character character, StateMachine stateMachine) : base(character, stateMachine)
        {

        }

        public override void Enter()
        {
            base.Enter();
            //Applies the character's 'MovementSpeed' and 'RotationSpeed'
            //to the 'speed' and 'rotationSpeed' respectively
            speed = character.MovementSpeed;
            rotationSpeed = character.RotationSpeed;

            //Resets the following variables to false
            crouch = false;
            jump = false;
            attack = false;
            draw = false;
        }

        public override void HandleInput()
        {
            base.HandleInput();
            //Stores the player's input for crouching and jumping as 'crouch' and 'jump'
            crouch = Input.GetButtonDown("Fire3");
            jump = Input.GetButtonDown("Jump");
            attack = Input.GetButtonDown("Fire1");
            draw = Input.GetKeyDown(KeyCode.Z);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            //If 'crouch' is true, set 'CurrentState' to be 'ducking'
            if (crouch)
            {
                stateMachine.ChangeState(character.ducking);
            }

            //If 'jump' is true, set 'CurrentState' to be 'jumping'
            else if (jump)
            {
                stateMachine.ChangeState(character.jumping);
            }

            //If 'attack' is true and weapon is drawn,
            //set 'currentState' to be 'swinging'
            else if (attack && character.weaponDrawn)
            {
                stateMachine.ChangeState(character.swinging);
            }

            //If 'draw' is true, set 'CurrentState' to be 'drawSheath'
            else if (draw)
            {
                stateMachine.ChangeState(character.drawSheath);
            }
        }

    }
}
