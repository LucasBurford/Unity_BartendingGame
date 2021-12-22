using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    // Reference to NavMesh agent
    public NavMeshAgent agent;

    // List of goals
    public List<GameObject> goalList;

    // Move speed
    public float moveSpeed;

    // Start is called before the first frame update
    private void Start()
    {
        // Instantiate list
        goalList = new List<GameObject>();

        // Get NavMesh agent
        agent = gameObject.GetComponent<NavMeshAgent>();

        // Get all NPC goals
        PopulateGoalList();

        // On spawn, get a new destination
        SetNewDestination();
    }

    // Update is called once per frame
    void Update()
    {
        print(agent.pathStatus);
    }

    // Set a destination for the NavMesh agent
    public void SetNewDestination()
    {
        // Generate a random number
        int rand = Random.Range(0, goalList.Count);

        // Set the destination to the generated one
        agent.SetDestination(goalList[rand].transform.position);
    }

    // Find NPG goal GOs and store them
    private void PopulateGoalList()
    {
        goalList.Add(GameObject.Find("NPCGoal1"));
        goalList.Add(GameObject.Find("NPCGoal2"));
        goalList.Add(GameObject.Find("NPCGoal3"));
        goalList.Add(GameObject.Find("NPCGoal4"));
    }
}
