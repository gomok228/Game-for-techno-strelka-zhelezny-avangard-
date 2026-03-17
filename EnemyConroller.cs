using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;


public class EnemyConroller : MonoBehaviour
{
    
    public Transform target;
    public float lookRadius=50f;
    [SerializeField] private NavMeshAgent agent;
    public float timeReload = 0;
    private void Start()
    {
        agent=GetComponent<NavMeshAgent>();
        target=GetComponent<Transform>();
    }
    private void Update()
    {
        float distance=Vector3.Distance(target.position, transform.position);
        if(distance<=lookRadius)
        {
            agent.SetDestination(target.position);
            if(distance<=agent.stoppingDistance)
            {
                LookTarget();
                if (timeReload >= 5f)
                {
                    FrameMovementControll.Instance.durability -= 50;
                }
            }
        }
    }
    private void LookTarget()
    {
        Vector3 direction = (target.position);
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation,Time.deltaTime*5f);
    }
   
}
