using UnityEngine;
using System.Collections;

public class EnemyWeaponShooter : MonoBehaviour {

    WeaponStats weaponStats;
    public EnemyBulletController bullet;

    public bool isFiring;


    // Use this for initialization
    void Start() {
        isFiring = true;
        weaponStats = transform.Find("Hand").GetChild(0).GetComponent<WeaponStats>();
    }

    // Update is called once per frame
    void Update() {
        if (weaponStats.cooldownCounter > 0)
        weaponStats.cooldownCounter -= Time.deltaTime;
        if (isFiring && weaponStats.cooldownCounter <= 0 ) {
            weaponStats.cooldownCounter = weaponStats.fireRate;
            SingleShoot();

        }
    }
    
    void SingleShoot() {
        var newBullet = Instantiate(bullet, weaponStats.spawnPoint.position, weaponStats.spawnPoint.rotation) as EnemyBulletController;
        newBullet.damage = (int)weaponStats.damage;
        newBullet.speed = weaponStats.speed;
        newBullet.accuracy = weaponStats.accuracy;
    }

}
