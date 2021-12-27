using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NPCManager : MonoBehaviour
{
    public List<GameObject> spawnPointList;

    public GameObject[] prefabs;

    public int randSpawnChance;

    public int numberOfAgentsActive;
    public int maxAgentsActive;

    // Start is called before the first frame update
    void Start()
    {
        spawnPointList = new List<GameObject>();
        prefabs = Resources.LoadAll<GameObject>("Prefabs");
        PopulateSpawnPointList();

        SpawnNPC();
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, randSpawnChance) == 1 && numberOfAgentsActive < maxAgentsActive)
        {
            SpawnNPC();
        }
    }

    public void SpawnNPC()
    {
        Instantiate(prefabs[Random.Range(0, prefabs.Length)], spawnPointList[Random.Range(0, spawnPointList.Count)].transform);
        numberOfAgentsActive++;
    }

    private void PopulateSpawnPointList()
    {
        spawnPointList.Add(GameObject.Find("NPCSpawnPoint1"));
        spawnPointList.Add(GameObject.Find("NPCSpawnPoint2"));
        spawnPointList.Add(GameObject.Find("NPCSpawnPoint3"));
        spawnPointList.Add(GameObject.Find("NPCSpawnPoint4"));
        spawnPointList.Add(GameObject.Find("NPCSpawnPoint5"));
    }
}
