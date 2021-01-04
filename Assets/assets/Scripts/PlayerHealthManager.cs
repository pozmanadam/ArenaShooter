using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealthManager : MonoBehaviour {

    public PauseScript pause;
    public Text streakText;
    public Text highStreakText;
    PlayerStats playerStats;
    WeaponSwapper weaponSwapper; 
    int streakLimit;
    bool isGotHurt;
    public float timer;
    int time;

    void Start() {
        playerStats = GetComponent<PlayerStats>();
        weaponSwapper = transform.GetComponent<WeaponSwapper>();
        streakLimit = 5;
        time = 2;
        timer = time;
        streakText.text = "Kill Streak:\n0";
        highStreakText.text = "Highest Kill Streak:\n0";
    }

    void Update(){
        if (timer > 0){
            timer -= Time.deltaTime;
        }
    }

    public void HurtPlayer(int damageCaused) {
        if( timer > 0) return;

        playerStats.playerCurrentHealth -= damageCaused;
        playerStats.killStreak = 0;
        streakText.text = "Kill Streak:\n0";
        weaponSwapper.EquipWeapon( playerStats.playerCurrentHealth-1);
        timer = time;
        if(playerStats.playerCurrentHealth <= 0) {
            GameObject.Find("Spawner").SetActive( false);
            Destroy(gameObject);
            pause.Pause();
        }
    }

    public void GotKill() {
        playerStats.killStreak++;
        if(playerStats.killStreak > playerStats.highestKillStreak){
            playerStats.highestKillStreak =playerStats.killStreak ;
            highStreakText.text = "Highest Kill Streak:\n"+playerStats.highestKillStreak;
        }
        streakText.text = "Kill Streak:\n"+playerStats.killStreak;
        if(playerStats.playerCurrentHealth < 3 && playerStats.playerCurrentHealth * streakLimit < playerStats.killStreak ){
            weaponSwapper.EquipWeapon( playerStats.playerCurrentHealth);
            playerStats.playerCurrentHealth++;
        }
    }


}
