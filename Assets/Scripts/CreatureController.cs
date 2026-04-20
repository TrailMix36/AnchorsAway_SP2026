using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CreatureController : MonoBehaviour
{
    private GameObject player;
    private NavMeshAgent agent;
    [SerializeField] LayerMask groundLayer;
    private Vector3 destPoint;
    private bool walkPointSet;
    [SerializeField] private float range;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }
    private void Patrol()
    {
        if (!walkPointSet)
        {
            SearchForDest();
        }
        if (walkPointSet)
        {
            agent.SetDestination(destPoint);
        }
        if(Vector3.Distance(transform.position, destPoint) < range)
        {
            walkPointSet = false;
        }
    }
    
    private void SearchForDest()
    {
        float z = Random.Range(-range, range);
        float x = Random.Range(-range, range);
        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if (Physics.Raycast(destPoint, Vector3.down, groundLayer))
        {
            walkPointSet = true;
        }
    }
}
