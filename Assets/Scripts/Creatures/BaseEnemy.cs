using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;



public class BaseEnemy : MonoBehaviour {

    [SerializeField, ]
    NavMeshAgent navAgent;
    [SerializeField]
    float movement_speed;
    [SerializeField]
    int hp;
    [SerializeField]
    float distanceToMove;
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
    int numberOfDeathOponent;
    bool seen;
    float time;

    private bool isDead=false;

    private void OnEnable()
    {/*
        Assert.IsNotNull(navAgent, "navAgent in " + this.ToString() + " is absent");
        Assert.IsNotNull(animator, "animator in " + this.ToString() + " is absent");
        Assert.IsNotNull(renderer, "renderer in " + this.ToString() + " is absent");*/
        time = 0f;
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

    public void UpdateEnemy(Transform playerTransform, MusicController mc) {
        if (isDead) return;

        

        float distance = CheckDistance(playerTransform.position, transform.position);

        if (distance <= distanceToAttack)
            Attack();
        else if (distance <= distanceToMove)
        {
            MoveToPlayer(playerTransform);
            PlaySomeGrowl(mc);
        }
    }

    private void PlaySomeGrowl(MusicController mc)
    {
        time -= Time.deltaTime;
        if(time<=0f)
        {
            AudioSource temp = mc.GetRandomMonsterAudio();
            temp.gameObject.transform.SetParent(this.gameObject.transform);
            temp.Play();
            time = Random.Range(7f, 30f);
        }
    }


    private void BeIdle()
    {
        navAgent.isStopped = true;
        animator.SetFloat(Keys.EnemyAnimations.WALK_RUN_BLEND, 0f);
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
        numberOfDeathOponent++;
        //Destroy(this.gameObject);
    }

    public int GetNumberOfDeathOponent()
    {
        return numberOfDeathOponent;
    }
}
