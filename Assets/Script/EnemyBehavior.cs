using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyBehavior : MonoBehaviour
{
    public GameObject player;
    public float FOVradius;
    [Range(0, 360)]
    public float FOVangle;

    [SerializeField] private LayerMask targetMask;
    [SerializeField] private LayerMask obstructionMask;

    public bool playerInView;

    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        StartCoroutine(FOVRoutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);
        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(this.transform.position, this.FOVradius, this.targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position);

            if (Vector3.Angle(transform.forward, directionToTarget) < FOVangle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {
                    agent.isStopped = false;
                    playerInView = true;
                    agent.SetDestination(player.transform.position);
                    
                }
                else
                {
                    playerInView = false;
                    agent.isStopped = true;
                }
            }

            else playerInView = false;
        }

        else if (playerInView == true)
        {
            playerInView = false;
        }


    }
}
