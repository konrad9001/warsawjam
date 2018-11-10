using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;


[RequireComponent(typeof(NavMeshAgent), typeof(Animator), typeof(Collider))]
public class BaseEnemy : MonoBehaviour {

    [SerializeField, ]
    NavMeshAgent navAgent;
    [SerializeField]
    float movement_speed;
    [SerializeField]
    int hp;
    [SerializeField]
    float distanceToRun;
    [SerializeField]
    float distanceToAttack;
    [SerializeField]
    Animator animator;
    [SerializeField]
    Renderer renderer;
    [SerializeField]
    Collider collider;
    [SerializeField]
    Collider attackCollider;

    bool seen;

    private bool isDead=false;

    private void OnEnable()
    {
        Assert.IsNotNull(navAgent, "navAgent in " + this.ToString() + " is absent");
        Assert.IsNotNull(animator, "animator in " + this.ToString() + " is absent");
        Assert.IsNotNull(renderer, "renderer in " + this.ToString() + " is absent");
    }

    public Renderer GetRenderer()
    {
        return renderer;
    }

    public void UpdateSeenStatus(Camera playerCamera)
    {
        Vector3 visTest =playerCamera.WorldToViewportPoint(transform.position);
        seen = (visTest.x >= 0 && visTest.y >= 0) && (visTest.x <= 1 && visTest.y <= 1) && visTest.z >= 0;
    }

    public bool GetSeen()
    {
        return seen;
    }

    public void UpdateEnemy(Transform playerTransform) {
        Debug.Log(CheckDistance(playerTransform.position, transform.position));
        if (isDead) return;
        if (CheckDistance(playerTransform.position, transform.position) <= distanceToAttack)
            Attack();
        else
            MoveToPlayer(playerTransform);
    }

    private void StopNavAgent()
    {
        navAgent.isStopped = true;
    }

    private void MoveToPlayer(Transform playerTransform) {
        //navAgent.isStopped = false;
        this.animator.SetBool(Keys.EnemyAnimations.ATTACK_BOOL, false);
        this.animator.SetBool(Keys.EnemyAnimations.HIT_BOOL, false);

        navAgent.SetDestination(playerTransform.position);
        animator.SetFloat(
            Keys.EnemyAnimations.WALK_RUN_BLEND, 
            Mathf.Clamp(CheckDistance(transform.position,playerTransform.position),0f,1f));        
    }

    private float CheckDistance(Vector3 a, Vector3 b)
    {
        return Vector3.Distance(a, b);
    }

    private void Attack() {
        navAgent.isStopped = true;
        this.animator.SetBool(Keys.EnemyAnimations.ATTACK_BOOL, true);
    }

    public void Hit()
    {
        Debug.Log("Hit on: " + this.ToString());
        hp--;
        if (hp <= 0)
            Death();
        else
            animator.SetBool(Keys.EnemyAnimations.HIT_BOOL, true);
    }

    private void Death() {
        animator.SetBool(Keys.EnemyAnimations.DEATH_BOOL, true);
        isDead = true;
        this.collider.enabled = false;
        //Destroy(this.gameObject);
    }



}
