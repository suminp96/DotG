using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCtrl : MonoBehaviour {
    public GameObject enemyPrefab;
    public GameObject minePrefab;
    public GameObject stomperPrefab;
    public float radius;
    public float interval = 1.5f;
    public bool end = false;
    
    private PlayerCtrl player;
    private float lastLogTime;
    private void Awake()
    {
        player = FindObjectOfType<PlayerCtrl>();
    }
    void Update() {
        if (player)
        {
            if (!end && Time.time - lastLogTime > interval)
            {
                EnemySpawn();
                MineSpawn();
                StomperSpawn();
                lastLogTime = Time.time;
            }
        }
    }
    void EnemySpawn()
    {
        var enemy = Instantiate(enemyPrefab, transform);
        var theta = Random.Range(0, 2 * Mathf.PI);
        enemy.transform.position = new Vector3(radius * Mathf.Cos(theta) + player.transform.position.x, 0.5f, radius * Mathf.Sin(theta) + player.transform.position.z);
    }
    void StomperSpawn()
    {
        var x = Random.Range(player.transform.position.x - 15, player.transform.position.x + 15);
        var z = Random.Range(player.transform.position.z - 15, player.transform.position.z + 15);
        var stomper = Instantiate(stomperPrefab);
        stomper.transform.position = new Vector3(x, 30, z);
        stomper.GetComponent<Stomper>().InitiateShadow();
    }
    void MineSpawn()
    {
        var x = Random.Range(player.transform.position.x - 25, player.transform.position.x + 25);
        var z = Random.Range(player.transform.position.z - 25, player.transform.position.z + 25);
        var mine = Instantiate(minePrefab);
        mine.transform.position = new Vector3(x, 0.05f, z);
    }
}
