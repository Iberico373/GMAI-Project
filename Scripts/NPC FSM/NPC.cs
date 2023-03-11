using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime;

namespace RayWenderlich.Unity.StatePatternInUnity
{
    public class NPC : MonoBehaviour
    {
        #region Variables
        [SerializeField]
        private Animator anim;
        [SerializeField]
        private Collider hitBox;
        [SerializeField]
        private BehaviorTree bt;
        [SerializeField]
        private Character character;

        private Vector3[] path;
        private int targetIndex;

        public NPCStateMachine npcSM;
        public SeekState seek;
        public AttackState attack;
        public NPCDeadState dead;
        public float health;
        public float speed;
        #endregion

        #region Methods
        public void SetAnimationBool(int param, bool value)
        {
            anim.SetBool(param, value);
        }

        public void TriggerAnimation(int param)
        {
            anim.SetTrigger(param);
        }

        public bool CheckTransition(int layer)
        {
            return anim.IsInTransition(layer);
        }

        public void ActivateHitBox()
        {
            hitBox.enabled = true;
        }

        public void DeactivateHitBox()
        {
            hitBox.enabled = false;
        }

        public void OnPathFound(Vector3[] newPath, bool pathSuccessful)
        {
            if (pathSuccessful)
            {
                path = newPath;
                StopCoroutine("FollowPath");
                StartCoroutine("FollowPath");
            }
        }

        IEnumerator FollowPath()
        {
            Vector3 currentWaypoint = path[0];

            while (true)
            {
                if (transform.position == currentWaypoint)
                {
                    targetIndex++;

                    if (targetIndex >= path.Length)
                    {
                        yield break;
                    }

                    currentWaypoint = path[targetIndex];
                }

                transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed);
                yield return null;
            }
        }
        #endregion

        #region MonoBehaviour Callbacks

        private void Start()
        {
            PathRequestManager.RequestPath(transform.position, character.transform.position, OnPathFound);
        }

        private void Update()
        {
            if (bt != null)
            {
                bt.SetVariableValue("Health", health);
                bt.SetVariableValue("Player Health", character.health);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "HitBox")
            {
                bt.SetVariableValue("isHit", true);
            }
        }

        public void OnDrawGizmos()
        {
            if (path != null)
            {
                for (int i = targetIndex; i < path.Length; i++)
                {

                }
            }
        }
        #endregion
    }
}


