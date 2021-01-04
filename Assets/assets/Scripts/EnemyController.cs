using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour { 
    public Transform target;
    public float speed;

    Rigidbody2D rigidBody;

    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate(){
        transform.position = Vector2.MoveTowards(transform.position,target.transform.position,speed);
    }

}