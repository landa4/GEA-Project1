using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiPatrol : MonoBehaviour
{

    public float lookRadius = 10f;
    public float rotationSpeed = 5f;

    public float attackDamage = 1f;
    public float attacksPerSecond = 0.5f;
    private float lastAttack = 0;
    public float attackRange = 1.5f;

    private UnityEngine.AI.NavMeshAgent agent;
    private Animator animator;

    private GameObject target; 
    // Start is called before the first frame update
    void Start()
    {
        attacksPerSecond = 1f / attacksPerSecond;
        lastAttack = attacksPerSecond;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        lastAttack += Time.deltaTime;
        float distance = Vector3.Distance(target.transform.position, transform.position);

        if(distance <= lookRadius)
        {
            

            if(distance <= agent.stoppingDistance)
            {
                FaceTarget();
            }
            else
            {
                agent.SetDestination(target.transform.position);
                animator.SetFloat("Speed", 0.2f);
            }
        }
        //Debug.Log(lastAttack);
        if (lastAttack >= attacksPerSecond){

            lastAttack = attacksPerSecond;
            if (distance <= attackRange){

                target.GetComponent<PlayerHealth>().Damage(attackDamage);
                animator.SetTrigger("attack");
                lastAttack = 0;
            }
        }

        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    animator.SetFloat("Speed", 0f);
                }
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    void OnDrawGizmos()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
