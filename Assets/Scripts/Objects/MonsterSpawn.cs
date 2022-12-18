using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    [Header("Monster Details")]
    [SerializeField] private GameObject monster;
    [SerializeField] private float minScale = -0.1f;
    [SerializeField] private float maxScale = 0.1f;
    private GameObject WaypointObject;
    private List<Transform> waypoints = new List<Transform>();
    void Start()
    {
        WaypointObject = transform.Find("Waypoints").gameObject;
        foreach (Transform wp in WaypointObject.transform)
        {
            waypoints.Add(wp);
        }
        SpawnMonster(5);
    }

    public void SpawnMonster(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            var randomNum = Random.Range(minScale, maxScale);
            monster.transform.localScale += new Vector3(randomNum, randomNum, randomNum);
            var tempMon = Instantiate(monster, waypoints[Random.Range(0, waypoints.Count)].position, Quaternion.identity);
            tempMon.transform.SetParent(this.transform);
        }
    }
}
