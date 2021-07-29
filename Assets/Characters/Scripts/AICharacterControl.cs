using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        private Transform target;                                    // target to aim for
        public Transform target1, target2;


        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

            agent.updateRotation = false;
            agent.updatePosition = true;

            if (target1 != null)
            {
                target = target1;
                agent.SetDestination(target.position);
                Debug.Log("target set");
            }

            else Debug.Log("No target");

        }


        private void Update()
        {
            if (gameObject.transform.position.z == target.position.z && gameObject.transform.position.x == target.position.x)
            {
                if (target == target1)
                    target = target2;

                else if (target == target2)
                    target = target1;

                agent.SetDestination(target.position);
            }


            if (agent.remainingDistance > agent.stoppingDistance)
                character.Move(agent.desiredVelocity * 0.5f, false, false);
            else
                character.Move(Vector3.zero, false, false);

        }


        public void SetTarget(Transform target1, Transform target2)
        {
            this.target1 = target1;
            this.target2 = target2;
        }

        private void OnCollisionEnter(Collision collision)
        {
            GameObject collideObj;
            collideObj = collision.gameObject;
            while(collideObj.transform.parent != null)
            {
                collideObj = collideObj.transform.parent.gameObject;
            }

            if(collideObj.name == "Player")
            {
                EventBroadcaster.Instance.PostEvent(EventNames.ON_PLAYER_CAUGHT);
            }
        }
    }
}
