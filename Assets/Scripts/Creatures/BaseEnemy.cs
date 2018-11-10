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
    bool seen;
    [SerializeField]Camera playerCamera;

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

    public void UpdateSeenStatus()
    {
        Vector3 visTest = playerCamera.WorldToViewportPoint(transform.position);
        seen = (visTest.x >= 0 && visTest.y >= 0) && (visTest.x <= 1 && visTest.y <= 1) && visTest.z >= 0;
    }

    public bool GetSeen()
    {
        return seen;
    }


    public void UpdateEnemy(Transform playerTransform) {
        if (isDead) return;
        //if (CheckDistance(playerTransform.position, transform.position, distanceToAttack))
        //{
        //    StopNavAgent();
        //    Attack();
        //}
        //else if (CheckDistance(playerTransform.position, transform.position, distanceToRun))
        //    Run(playerTransform);
        //else Walk(playerTransform);
        Run(playerTransform);
    }

    private bool CheckDistance(Vector3 a, Vector3 b, float limit)
    {
        return Vector3.Distance(a, b) <= limit;
    }

    private void StopNavAgent()
    {
        navAgent.isStopped = true;
    }

    private void Walk(Transform playerTransform)
    {
        navAgent.destination=(playerTransform.position);
        animator.SetFloat(Keys.EnemyAnimations.WALK_RUN_BLEND, 0.5f);
    }

    private void Run(Transform playerTransform) {
        navAgent.destination = (playerTransform.position);
        animator.SetFloat(Keys.EnemyAnimations.WALK_RUN_BLEND, 1f);
        //StartCoroutine(WalkToRunCoroutine());
    }

    IEnumerator WalkToRunCoroutine()
    {
        for(float i=1;i<=1f;i+=0.05f)
        {
            animator.SetFloat(Keys.EnemyAnimations.WALK_RUN_BLEND, i);
            yield return null;
        }
    }

    private void Attack() {
        navAgent.isStopped = true;
        this.animator.SetTrigger(Keys.EnemyAnimations.ATTACK);
    }

    public void Hit()
    {
        Debug.Log("Hit on: " + this.ToString());
        hp--;
        if (hp <= 0)
            Death();
        else
            animator.SetTrigger(Keys.EnemyAnimations.HIT);
    }

    private void Death() {
        animator.SetTrigger(Keys.EnemyAnimations.DEATH);
        isDead = true;
        this.collider.enabled = false;
        //Destroy(this.gameObject);
    }



}
