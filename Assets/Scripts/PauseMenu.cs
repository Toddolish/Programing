using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool paused;
    public GameObject pauseMenu;
    public CharacterHandler charHandler;
    public GameObject optionsMenu;
    public Slider sensitivity;
    public MouseLook mouseLook;
    void Start()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        charHandler = GameObject.Find("Player").GetComponent<CharacterHandler>();
        optionsMenu.SetActive(false);
        //sensitivity = GameObject.Find("Sensitivity").GetComponent<Slider>();
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) && !paused)
        {
            charHandler.enabled = false;
            paused = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.P) && paused)
        {
            charHandler.enabled = true;
            paused = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void Resume()
    {
        if (paused)
        {
            charHandler.enabled = true;
            paused = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
        paused = false;
        Time.timeScale = 1;
    }
    public void Restart()
    {
        charHandler.enabled = true;
        SceneManager.LoadScene("Level");
        paused = false;
        Time.timeScale = 1;
    }
    public void Options()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
    public void Back()
    {
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
    public void SensitivityMouse()
    {
        //sensitivity.value = mouseLook.sensitivityX;
    }
}
