using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    [SerializeField] private GameObject monster;
    private GameObject WaypointObject;
    private List<Transform> waypoints = new List<Transform>();
    void Start()
    {
        WaypointObject = transform.Find("Waypoints").gameObject;
        foreach (Transform wp in WaypointObject.transform)
        {
            waypoints.Add(wp);
        }
        SpawnMonster(2);
    }

    public void SpawnMonster(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            var tempMon = Instantiate(monster, waypoints[Random.Range(0, waypoints.Count)].position, Quaternion.identity);
            tempMon.transform.SetParent(this.transform);
        }
    }
}
