using UnityEngine;
using System.Collections;

public class EnemyHealthManager : MonoBehaviour {

    public float EnemyCurrentHealth;
    public GameObject player;

    // Use this for initialization
    void Start() {
    }
    
    public void HurtEnemy(float damageCaused) {
        EnemyCurrentHealth -= damageCaused;
        if(EnemyCurrentHealth <= 0) {
            player.GetComponent<PlayerHealthManager>().GotKill();
            Destroy(transform.gameObject);
        }
    }
}
