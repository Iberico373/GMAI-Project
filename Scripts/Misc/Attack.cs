using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

public class Attack : Action
{
    private GameObject turtle;
    private Collider hitbox;
    private Animator anim;
    private int attackParam = Animator.StringToHash("Attack");
    private int attack2Param = Animator.StringToHash("Attack2");
    private bool nextAttack;

    public override void OnStart()
    {
        //Get and assign neccesary variables
        turtle = GameObject.Find("TurtleShell");
        //hitbox = turtle.GetComponentInChildren<BoxCollider>();
        hitbox = GameObject.Find("HitBoxCreature").GetComponent<Collider>();
        anim = turtle.GetComponent<Animator>();

        //Enable hitbox
        hitbox.enabled = true;

        //If this is the turtle's first attack, play the first
        //attack animation
        if (!nextAttack)
        {
            anim.SetTrigger(attackParam);
            nextAttack = true;
        }

        //If this is the turtle's next attack, play the second
        // attack animation
        else if (nextAttack)
        {
            anim.SetTrigger(attack2Param);
            nextAttack = false;
        }

    }

    public override TaskStatus OnUpdate()
    {
        //If attack animation has ended, disable hitbox and return task status success
        if (anim.IsInTransition(0))
        {
            hitbox.enabled = false;
            return TaskStatus.Success;
        }

        return TaskStatus.Running;
    }
}
