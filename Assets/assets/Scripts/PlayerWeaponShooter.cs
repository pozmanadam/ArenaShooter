using UnityEngine;
using System.Collections;

public class PlayerWeaponShooter : MonoBehaviour
{

    public WeaponStats[] weaponStats;
    public GameObject bullet;
    public int equippedWeapon;


	// Use this for initialization
	void Start () {
        equippedWeapon = 0;
    }
	
	// Update is called once per frame
    
	void FixedUpdate () {
        //if (Menu.menuIsActive) { return; }
        if (weaponStats[equippedWeapon].cooldownCounter > 0)
        weaponStats[equippedWeapon].cooldownCounter -= Time.deltaTime;
        if (Input.GetMouseButton(0) && weaponStats[equippedWeapon].cooldownCounter <= 0 && weaponStats[equippedWeapon].ammunition != 0) {
            weaponStats[equippedWeapon].cooldownCounter = weaponStats[equippedWeapon].fireRate;

            switch (weaponStats[equippedWeapon].shootType) {
                case WeaponStats.ShootTypes.Single: {
                        CmdSingleShoot();
                        break;
                    }
                case WeaponStats.ShootTypes.Spread: {
                        CmdSpreadShoot();
                        break;
                    }
            }
            
        }
	}

    void CmdSingleShoot() {
        var newBullet = Instantiate(bullet, weaponStats[equippedWeapon].spawnPoint.position, weaponStats[equippedWeapon].spawnPoint.rotation) as GameObject;
        newBullet.GetComponent<PlayerBulletController>().damage = weaponStats[equippedWeapon].damage;
        newBullet.GetComponent<PlayerBulletController>().speed = weaponStats[equippedWeapon].speed;
        newBullet.GetComponent<PlayerBulletController>().accuracy = weaponStats[equippedWeapon].accuracy ;
    }

    void CmdSpreadShoot() {
        for (int i = 0; i < 4; i++) {
            var newBullet = Instantiate(bullet, weaponStats[equippedWeapon].spawnPoint.position, weaponStats[equippedWeapon].spawnPoint.rotation) as GameObject;
            newBullet.GetComponent<PlayerBulletController>().damage = weaponStats[equippedWeapon].damage;
            newBullet.GetComponent<PlayerBulletController>().speed = weaponStats[equippedWeapon].speed;
            newBullet.GetComponent<PlayerBulletController>().accuracy = weaponStats[equippedWeapon].accuracy;     
        }
    }
}
