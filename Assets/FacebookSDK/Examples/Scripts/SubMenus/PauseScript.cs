using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity.Example;

public class PauseScript : MonoBehaviour
{
    bool isPaused;
    MainMenuInGame menu;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        menu = GetComponent<MainMenuInGame>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown( KeyCode.Escape )){
            Pause();
        }

    }
    public void Pause(){
            if(isPaused){
                Time.timeScale = 1;
                menu.enabled = false;
            }
            else{
                Time.timeScale = 0;
                menu.enabled = true;
            }
            isPaused = !isPaused;
        }
}
