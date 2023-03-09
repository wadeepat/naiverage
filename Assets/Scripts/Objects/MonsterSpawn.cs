using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
struct MonsterList
{
    public MonsterId monsterId;
    public GameObject model;
}
[System.Serializable]
struct MonsterAmount
{
    public MonsterId monsterId;
    public int amount;
}

public class MonsterSpawn : MonoBehaviour
{
    [Header("Monster Details")]
    [SerializeField] MonsterList[] monsterLists;
    [SerializeField] public bool isSpawn = true;
    [SerializeField] private bool enableTest = false;
    [SerializeField] private int capacity = 5;
    [SerializeField] MonsterAmount[] monsterSpawnLists;
    [SerializeField] MonsterAmount[] monsterTestLists;
    [SerializeField] private float spawnTimeDelay = 5f;
    private float spawnTimer = 0;
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
        if (enableTest)
        {
            foreach (MonsterAmount m in monsterTestLists)
            {
                SpawnMonster((int)m.monsterId, m.amount, false);
            }
        }
        if (isSpawn && PlayerManager.playerEvents["finishedTutorial"])
        {
            foreach (MonsterAmount m in monsterSpawnLists)
            {
                SpawnMonster((int)m.monsterId, m.amount, false);
            }
        }
    }
    private void Update()
    {
        if (isSpawn)
        {
            if (spawnTimer < spawnTimeDelay) spawnTimer += Time.deltaTime;
            else
            {
                if (transform.childCount < capacity + 1)
                {
                    SpawnMonster((int)monsterSpawnLists[Random.Range(0, monsterSpawnLists.Length)].monsterId, 1, false);

                }
                // foreach (MonsterAmount m in monsterSpawnLists)
                // {
                //     SpawnMonster((int)m.monsterId, m.amount, false);
                // }
                spawnTimer = 0;
            }
        }
    }
    public void SpawnMonster(int id, int amount, bool isAttackVictim)
    {
        for (int i = 0; i < amount; i++)
        {
            var randomNum = Random.Range(minScale, maxScale);
            // var tempMon = Instantiate(monsterLists[id].model, waypoints[Random.Range(0, waypoints.Count)].position, Quaternion.identity);
            var tempMon = Instantiate(monsterLists[id].model, waypoints[Random.Range(0, waypoints.Count)].position, Quaternion.identity);
            tempMon.transform.localScale += Vector3.one * randomNum;
            tempMon.transform.SetParent(this.transform);
            if (isAttackVictim) tempMon.GetComponent<Enemy>().AttackVictim();
        }
    }
}
