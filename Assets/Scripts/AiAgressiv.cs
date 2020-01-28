using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiAgressiv : MonoBehaviour
{

    private NavMeshAgent agent;
    private Animator animator; 
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        //agent.destination = new Vector3(0,2,0);
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
        animator.SetFloat("Speed", 0.2f);

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
}
