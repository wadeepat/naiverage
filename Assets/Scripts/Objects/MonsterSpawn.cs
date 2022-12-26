using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
struct MonsterList
{
    public string name;
    public GameObject model;
}
public class MonsterSpawn : MonoBehaviour
{
    [Header("Monster Details")]
    [SerializeField] MonsterList[] monsterLists;
    // [SerializeField] private GameObject monster;
    private float minScale = -0.1f;
    private float maxScale = 0.1f;
    private GameObject WaypointObject;
    private List<Transform> waypoints = new List<Transform>();
    void Start()
    {
        WaypointObject = transform.Find("Waypoints").gameObject;
        foreach (Transform wp in WaypointObject.transform)
        {
            waypoints.Add(wp);
        }
        // SpawnMonster(0, 1);
        // SpawnMonster(1, 1);
        // SpawnMonster(2, 1);
    }

    public void SpawnMonster(int id, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            var randomNum = Random.Range(minScale, maxScale);
            var tempMon = Instantiate(monsterLists[id].model, waypoints[Random.Range(0, waypoints.Count)].position, Quaternion.identity);
            tempMon.transform.localScale += Vector3.one * randomNum;
            tempMon.transform.SetParent(this.transform);
        }
    }
}
