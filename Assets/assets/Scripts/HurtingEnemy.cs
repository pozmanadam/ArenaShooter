using UnityEngine;
using System.Collections;

public class HurtingEnemy : MonoBehaviour {

    public float damage;

    public void OnTriggerEnter2D(Collider2D entered) {
        if (entered.gameObject.tag == "Enemy") {
            entered.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damage);
        }
    }
}
