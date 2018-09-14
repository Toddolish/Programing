using UnityEngine;
using System.Collections;

[AddComponentMenu("FirstPerson/Character Handler")]
public class CharacterHandler : MonoBehaviour
{
    #region Variables

    #region Character 

    [Header("Character")]
    public bool alive;
    public CharacterController controller;
    #endregion

    #region Health
    [Space(20)]
    [Header("Health")]
    public GUIStyle RedBox;
    public float curHealth, maxHealth;
    
    [Space(20)]
    [Header("Mana")]
    public GUIStyle blueBox;
    public float curMana, maxMana;
    
    [Space(20)]
    [Header("Stamina")]
    public GUIStyle yellowBox;
    public float curStamina, maxStamina;

    #region Stats
    [Space(40)]
    [Header("Stats")]
    //Affects attack damage increased health
    public int Strength;

    //Affects Stamina
    public int Constitution;

    //Affects mana and mana regeneration
    public int Intelligence;

    //increases magical accuracy
    public int Wisdom;

    //AffectsCritical hit damage
    public int Dexterity;

    //Affects Critical hit Damage and the ability to evade more
    public int Luck;
    #endregion

    //dnd based stats
    //% of the constitution stat go towards health
    //% dex effects stamina and dexterity
    //crouch, walk, sprint with move speed
    //when sprinting loose stamina
    //when walking or crouching regen stamina
    #endregion
    #region Level and Exp
    [Header("Levels and Exp")]
    //players current level
    public int level;
    //max and min experience 
    public int maxEXP, curEXP;
    #endregion
    #region MiniMap
    [Header("Camera Connection")]
    //render texture for the mini map that we need to connect to a camera
    public RenderTexture miniMap;
    #endregion

    #endregion
    #region Start
    private void Start()
    {
        #region Health
        //set max health to 100
        maxHealth = 100;

        //set current health to max
        curHealth = maxHealth;

        //make sure player is alive
        alive = true;

        #endregion
        #region EXP
        //max exp starts at 60
        maxEXP = 60;
        //connect the Character Controller to the controller variable
        controller = GetComponent<CharacterController>();
        #endregion


        //stats
        maxHealth += Strength * 0.5f;
        maxMana += Wisdom * 1f;
        maxStamina += Dexterity * 1f;
    }
    #endregion
    #region Update
    private void Update()
    {
        //if our current experience is greater or equal to the maximum experience
        if (curEXP >= maxEXP)
        {
            //then the current experience is equal to our experience minus the maximum amount of experience
            curEXP -= maxEXP;

            //our level goes up by one
            level = level + 1;
            
            //the maximum amount of experience is increased by 50
            maxEXP = maxEXP + 50;
        }
        #region Stats

        #endregion

    }
    #endregion
    #region LateUpdate
    private void LateUpdate()
    {
        //if our current health is greater than our maximum amount of health
        if (curHealth > maxHealth)
        {
            //then our current health is equal to the max health
            curHealth = maxHealth;
        }

        if(curHealth < 0 || !alive)
        {
            //current health equals 0
            curHealth = 0;
            Debug.Log("If less than 0");
        }

        //if the player is alive
        //and our health is less than or equal to 0
        if (alive && curHealth <= 0)
        {
            //alive is false
            alive = false;

            //controller is turned off
            controller.enabled = false;
            Debug.Log("Disable on Death");
        }
    }

    #endregion
    #region OnGUI
    private void OnGUI()
    {
        //set up our aspect ratio for the GUI elements
        //scrW - 16
        float scrW = Screen.width / 16;
        //scrH - 9
        float scrH = Screen.height / 9;
        //GUI Box on screen for the healthbar background
        GUI.Box(new Rect(6*scrW,0.25f*scrH,4*scrW,0.5f*scrH),"");
        //GUI Box for current health that moves in same place as the background bar
        GUI.Box(new Rect(6 * scrW, 0.25f * scrH, curHealth*(4 * scrW)/maxHealth, 0.5f * scrH), curHealth.ToString("F0") + "/"+ maxHealth.ToString("F0"), RedBox);
        //current Health divided by the posistion on screen and timesed by the total max health

        //GUI Box on screen for the experience background
        GUI.Box(new Rect(6 * scrW, 0.75f * scrH, 4 * scrW, 0.35f * scrH), "");
        //GUI Box for current experience that moves in same place as the background bar
        GUI.Box(new Rect(6 * scrW, 0.75f * scrH, curEXP * (4 * scrW) / maxEXP, 0.35f * scrH), curEXP.ToString("F0") + "/" + maxEXP.ToString("F0"), blueBox);

        //current experience divided by the posistion on screen and timesed by the total max experience
        //GUI Draw Texture on the screen that has the mini map render texture attached
        GUI.DrawTexture(new Rect(13.75f*scrW, 0.25f*scrH, 2*scrW, 2*scrH), miniMap);
    }
    #endregion
}