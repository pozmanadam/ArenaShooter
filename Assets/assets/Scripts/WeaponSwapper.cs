using UnityEngine;
using System.Collections;

public class WeaponSwapper : MonoBehaviour {


    int equippedWeapon;
    int selectedWeapon;
    int weaponCount;

    PlayerWeaponShooter weaponShooter;

    GameObject hand;

    // Use this for initialization
    void Start () {
        hand = transform.Find("Hand").gameObject;
        weaponCount = hand.transform.childCount;
        equippedWeapon = 0;
        
        weaponShooter = transform.GetComponent<PlayerWeaponShooter>();
    }
	

    public void EquipWeapon(int nextWeapon) {
        if(nextWeapon >= weaponCount || nextWeapon < 0) return;
        hand.transform.GetChild(equippedWeapon).gameObject.SetActive(false);
        hand.transform.GetChild(nextWeapon).gameObject.SetActive(true);
        equippedWeapon = nextWeapon;
         
        weaponShooter.equippedWeapon = nextWeapon;
    }

}
