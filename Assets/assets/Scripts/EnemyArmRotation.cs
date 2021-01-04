using UnityEngine;
using System.Collections;

public class EnemyArmRotation : MonoBehaviour {

    public Transform target;

    void Start(){
        target = transform.parent.GetComponent<EnemyController>().target;
    }

    void Update() {
        if (target != null) {
            Vector2 difference = target.transform.position - transform.position;
            difference.Normalize();

            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

            if (rotZ > 90 || rotZ < -90) {
                transform.rotation = Quaternion.Euler(180, 0f, -rotZ);
                transform.localPosition = new Vector2(-0.3f, transform.localPosition.y);

            }
            else {
                transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
                transform.localPosition = new Vector2(0.3f, transform.localPosition.y);
            }
        }
    }
}
