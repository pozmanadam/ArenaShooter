using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public float moveSpeed;

    public int playerCurrentHealth;
    public int killStreak;
    public int highestKillStreak;

    // Use this for initialization
    void Start() {
        killStreak = 0;
        highestKillStreak = 0;
    }

}
