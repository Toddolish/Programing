using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems; //control the event (button shiz
using UnityEngine.Audio;

public class MenuHandler : MonoBehaviour {

    #region Variables
    [Header("OPTIONS")]
    public Vector2[] res = new Vector2[7];
    public int resIndex;
    public bool isFullScreen;
    public Dropdown resDropDown;

    [Header("Keys")]
    public KeyCode holdingKey;
    public KeyCode forward, backward, left, right, jump, crouch, sprint, interact;

    [Header("References")]
    public bool showOptions;
    public GameObject mainMenu, optionsMenu;
    public Slider volumeSlider;
    public Slider brightnessSlider;
    public Slider ambientSlider;
    public AudioSource mainAudio;
    public Light dirLight;

    [Header("KeyBing Reference")]
    public Text forwardText;
    public Text backwardText, leftText, rightText, jumpText, crouchText, sprintText, interactText;

    #endregion

    private void Start()
    {
        mainAudio = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        dirLight = GameObject.Find("Directional Light").GetComponent<Light>();
        optionsMenu.SetActive(false);
        forwardText.text = forwardText.ToString();

        #region Set Up Keys
        //set out the keys to the preset keys we may have saved, else we are going to set the keys to default
        forward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Forward", "W"));
        backward = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Backward", "S"));
        left = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "A"));
        right = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D"));
        jump = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Jump", "Space"));
        crouch = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Crouch", "C"));
        sprint = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Sprint", "LeftShift"));
        interact = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Interact", "E"));
        #endregion
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Level");
    }
    public void ExitGame()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
        Application.Quit();
    }
    public void ToggleOptions()
    {
        OptionsToggle();
    }
    bool OptionsToggle() //when click on toggle button "options" then "back"
    {
        if(showOptions)//if i clicked "Options" button
        {
            showOptions = false;
            mainMenu.SetActive(true);
            optionsMenu.SetActive(false);
            return false;
        }
        else //if i clicked "Back" button
        {
            showOptions = true;
            mainMenu.SetActive(false);
            optionsMenu.SetActive(true);
            brightnessSlider = GameObject.FindGameObjectWithTag("Bslide").GetComponent<Slider>();
            volumeSlider = GameObject.FindGameObjectWithTag("AudioSlider").GetComponent<Slider>();
            ambientSlider = GameObject.Find("Ambient").GetComponent<Slider>();
            resDropDown = GameObject.Find("Dropdown").GetComponent<Dropdown>();
            ambientSlider.value = RenderSettings.ambientIntensity;
            brightnessSlider.value = dirLight.intensity;
            volumeSlider.value = mainAudio.volume;
            return true;
        }
    }
    public void Volume()
    {
        mainAudio.volume = volumeSlider.value;
    }
    public void Brightness()
    {
        dirLight.intensity = brightnessSlider.value;
    }
    public void Ambient()
    {
        // RenderSettings.ambientIntensity = ambientSlider.value;
        RenderSettings.ambientIntensity = ambientSlider.value;
    }
    public void Resolution()
    {
        resDropDown.value = resIndex;
        Screen.SetResolution((int)res[resIndex].x,(int)res[resIndex].y,isFullScreen);
    }
    public void Save()
    {
        PlayerPrefs.SetString("Forward", forward.ToString());
        PlayerPrefs.SetString("Backward", backward.ToString());
        PlayerPrefs.SetString("Left", left.ToString());
        PlayerPrefs.SetString("Right", right.ToString());
        PlayerPrefs.SetString("Jump", jump.ToString());
        PlayerPrefs.SetString("Crouch", crouch.ToString());
        PlayerPrefs.SetString("Sprint", sprint.ToString());
        PlayerPrefs.SetString("Interact", interact.ToString());
    }
    private void OnGUI()
    {
        Event e = Event.current;
        if(forward == KeyCode.None)
        {
            Debug.Log("KeyCode " + e.keyCode);
            if (!(e.keyCode == backward || e.keyCode == left || e.keyCode == right || e.keyCode == jump || e.keyCode == sprint
                || e.keyCode == crouch || e.keyCode == interact)) 
            {
                forward = e.keyCode;
                holdingKey = KeyCode.None;
                forwardText.text = forward.ToString();
            }
        }
    }
    public void Forward()
    {
        if (!(backward == KeyCode.None || left == KeyCode.None || right == KeyCode.None || jump == KeyCode.None || sprint == KeyCode.None
                || crouch == KeyCode.None || interact == KeyCode.None))
        {
            holdingKey = forward;
            forward = KeyCode.None;
            forwardText.text = forward.ToString();
        }
    }
}
