using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool paused;
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
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //sensitivity = GameObject.Find("Sensitivity").GetComponent<Slider>();
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) && !paused )
        {
            charHandler.enabled = false;
            paused = true;
            Cursor.visible = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
        else if (Input.GetKeyDown(KeyCode.P) && paused && !Inventory.showInv)
        {
            charHandler.enabled = true;
            paused = false;
            Cursor.visible = true;
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (Input.GetKeyDown(KeyCode.P) && paused && Inventory.showInv)
        {
            paused = false;
            pauseMenu.SetActive(false);
            Cursor.visible = false;
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
