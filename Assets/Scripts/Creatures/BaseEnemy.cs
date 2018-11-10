using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;


[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]
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

    public void UpdateEnemy(Transform playerTransform) {
        Debug.Log("Updating "+this.ToString());
        if (isDead) return;
        if (CheckDistance(playerTransform.position, transform.position, distanceToAttack))
        {
            StopNavAgent();
            Attack();
        }
        else if (CheckDistance(playerTransform.position, transform.position, distanceToRun))
            Run(playerTransform);
        else Walk(playerTransform);
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
        Debug.Log("Walking");
        navAgent.destination=(playerTransform.position);
        Debug.LogError("No animator trigger in Walk in " + this.ToString());
    }

    private void Run(Transform playerTransform) {
        Debug.Log("Running");
        navAgent.destination = (playerTransform.position);
        Debug.LogError("No animator trigger in Run in " + this.ToString());
    }

    private void Attack() {
        navAgent.isStopped = true;
        this.animator.SetTrigger(Keys.EnemyAnimations.ATTACK);
    }

    public void Hit()
    {
        this.hp--;
        if (hp <= 0) Death();
    }

    private void Death() {
        Debug.LogError("No animator trigger in Death in " + this.ToString());
        isDead = true;
        //Destroy(this.gameObject);
    }



}
