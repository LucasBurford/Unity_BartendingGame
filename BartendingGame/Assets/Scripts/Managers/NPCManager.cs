using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public GameObject npcPrefab;

    public List<GameObject> spawnPointList;

    public int randSpawnChance;

    // Start is called before the first frame update
    void Start()
    {
        spawnPointList = new List<GameObject>();
        PopulateSpawnPointList();
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, randSpawnChance) == 1)
        {
            
        }
    }

    public void SpawnNPC()
    {
        Instantiate(npcPrefab, spawnPointList[Random.Range(0, spawnPointList.Count)].transform);
    }

    private void PopulateSpawnPointList()
    {
        spawnPointList.Add(GameObject.Find("NPCSpawnPoint1"));
        spawnPointList.Add(GameObject.Find("NPCSpawnPoint2"));
        spawnPointList.Add(GameObject.Find("NPCSpawnPoint3"));
        spawnPointList.Add(GameObject.Find("NPCSpawnPoint4"));
    }
}
