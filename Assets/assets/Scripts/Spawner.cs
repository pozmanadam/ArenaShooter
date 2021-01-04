using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject enemyHard;
    public GameObject player;
    PlayerStats playerStats;
    public float timer;
    public int time;
    GameObject temp;
    public List<GameObject> childrens = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {           
            childrens.Add(child.gameObject);                         
        }
        enemy.GetComponent<EnemyController>().target = player.transform;
        enemy.GetComponent<EnemyHealthManager>().player = player;
        enemyHard.GetComponent<EnemyController>().target = player.transform;
        enemyHard.GetComponent<EnemyHealthManager>().player = player;
        playerStats = player.GetComponent<PlayerStats>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0){
            timer -= Time.deltaTime; 
        }
        else
        {
            if (Random.Range(0, 100) - playerStats.killStreak < 10){
                temp = Instantiate(enemyHard);
            }
            else{
                temp = Instantiate(enemy);
            }
            temp.transform.position = childrens[Random.Range(0, childrens.Count)].transform.position;
            timer = time;
        }
    }
}
