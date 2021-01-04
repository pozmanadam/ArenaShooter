using UnityEngine;
using System.Collections;

public class HurtingPlayer : MonoBehaviour {

    public int damage;

    void OnTriggerEnter2D(Collider2D entered) {
        if (entered.gameObject.tag == "Player") {
            entered.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damage);
        }
    }
}
