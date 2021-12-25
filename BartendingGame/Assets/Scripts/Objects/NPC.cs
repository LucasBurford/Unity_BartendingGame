using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    // Reference to NavMesh agent
    public NavMeshAgent agent;

    // Refernce to NPC manager
    public NPCManager npcManager;

    // List of goals
    public List<GameObject> goalList;

    // Move speed
    public float moveSpeed;

    // How long the agent has been walking on a path
    public float pathLength;

    // Start is called before the first frame update
    private void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);

        // Instantiate list
        goalList = new List<GameObject>();

        // Get NavMesh agent
        agent = gameObject.GetComponent<NavMeshAgent>();

        // Get NPC Manager
        npcManager = FindObjectOfType<NPCManager>();

        // Get all NPC goals
        PopulateGoalList();

        // On spawn, get a new destination
        SetNewDestination();
    }

    // Update is called once per frame
    void Update()
    {
        // If agent reaches goal
        if (Vector3.Distance(transform.position, agent.destination) <= 1)
        {
            // Then destroy - decrement numberOfAgents active so more can spawn
            npcManager.numberOfAgentsActive--;
            Destroy(gameObject);
        }

        pathLength += 0.01f;

        if (pathLength >= 5)
        {
            SetNewDestination();
        }
    }

    // Set a destination for the NavMesh agent
    public void SetNewDestination()
    {
        // Set the destination to the generated one
        agent.SetDestination(goalList[Random.Range(0, goalList.Count)].transform.position);
    }

    // Find NPG goal GOs and store them
    private void PopulateGoalList()
    {
        goalList.Add(GameObject.Find("NPCGoal1"));
        goalList.Add(GameObject.Find("NPCGoal2"));
        goalList.Add(GameObject.Find("NPCGoal3"));
        goalList.Add(GameObject.Find("NPCGoal4"));
        goalList.Add(GameObject.Find("NPCGoal5"));
    }
}
