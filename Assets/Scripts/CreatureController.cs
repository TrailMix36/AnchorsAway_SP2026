/*****************************************************************************
// File Name : CreatureController.cs
// Author : Simon Bruening-Wright
// Creation Date : 4/21/2026
//
// Brief Description : Controls the fish AI
*****************************************************************************/

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
    /// <summary>
    /// Assigns components to objects
    /// </summary>
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
    }

    /// <summary>
    /// Calls the patrol function each frame
    /// </summary>
    void Update()
    {
        Patrol();
    }
    /// <summary>
    /// Sets the AI navigation point
    /// </summary>
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
    /// <summary>
    /// Finds a random Navigation point and gives it to the patrol function
    /// </summary>
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
