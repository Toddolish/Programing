using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Variables
    public List<Item> inv = new List<Item>();//list of items
    public static bool showInv;//show or hide inventory
    public Item selectedItem;//the item we are interacting with
    public int money;//how much moolah we have

    public Vector2 scr = Vector2.zero;//16:9
    public Vector2 scrollPos = Vector2.zero;//scroll bar position

    public string sortType = "All";
    #endregion
    void Start()
    {
        inv.Add(ItemData.CreateItem(0));
        inv.Add(ItemData.CreateItem(2));
        inv.Add(ItemData.CreateItem(102));
        inv.Add(ItemData.CreateItem(201));
        inv.Add(ItemData.CreateItem(202));
        inv.Add(ItemData.CreateItem(302));
        inv.Add(ItemData.CreateItem(404));

        for (int i = 0; i < inv.Count; i++)
        {
            Debug.Log(inv[i].Name);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!PauseMenu.paused)
            {
                ToggleInv();
            }
        }
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            if (showInv)
            {
                inv.Add(ItemData.CreateItem(0));
                inv.Add(ItemData.CreateItem(2));
                inv.Add(ItemData.CreateItem(102));
                inv.Add(ItemData.CreateItem(201));
                inv.Add(ItemData.CreateItem(202));
                inv.Add(ItemData.CreateItem(302));
                inv.Add(ItemData.CreateItem(404));
            }
        }

    }
    public bool ToggleInv()
    {
        if (showInv)
        {
            showInv = false;
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            return (false);
        }
        else
        {
            showInv = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            return (true);
        }
    }
    //When mommy and daddy love each other very much...
    private void OnGUI()
    {
        if (!PauseMenu.paused)//only display if not paused
        {
            if (showInv)//and it toggled on;
            {
                if (scr.x != Screen.width / 16 || scr.y != Screen.height / 9)//update screen when needed
                {
                    scr.x = Screen.width / 16;
                    scr.y = Screen.height / 9;
                }
                GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "Iventory");
                if (GUI.Button(new Rect(5.5f * scr.x, 0.25f * scr.y, scr.x, 0.25f * scr.y), "All"))
                {
                    sortType = "All";
                }
                if (GUI.Button(new Rect(6.5f * scr.x, 0.25f * scr.y, scr.x, 0.25f * scr.y), "Consumables"))
                {
                    sortType = "Consumables";
                }
                if (GUI.Button(new Rect(7.5f * scr.x, 0.25f * scr.y, scr.x, 0.25f * scr.y), "Craftables"))
                {
                    sortType = "Craftable";
                }
                if (GUI.Button(new Rect(8.5f * scr.x, 0.25f * scr.y, scr.x, 0.25f * scr.y), "Weapons"))
                {
                    sortType = "Weapon";
                }
                if (GUI.Button(new Rect(9.5f * scr.x, 0.25f * scr.y, scr.x, 0.25f * scr.y), "Armour"))
                {
                    sortType = "Armour";
                }
                if (GUI.Button(new Rect(10.5f * scr.x, 0.25f * scr.y, scr.x, 0.25f * scr.y), "Misc"))
                {
                    sortType = "Misc";
                }
                if (GUI.Button(new Rect(11.5f * scr.x, 0.25f * scr.y, scr.x, 0.25f * scr.y), "Quest"))
                {
                    sortType = "Quest";
                }
                //Function Goes Here
                DisplayInv(sortType);

                if (selectedItem != null)//if we have an item
                {
                    //show the icon
                    GUI.DrawTexture(new Rect(11 * scr.x, 1.5f * scr.y, 2 * scr.x, 2 * scr.y), selectedItem.Icon);
                    if (selectedItem.Type != ItemTypes.Quest)
                    {
                        if (GUI.Button(new Rect(14 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Discard"))
                        {
                            //spawn item on ground
                            inv.Remove(selectedItem);
                            selectedItem = null;
                            return;
                        }
                    }
                    switch (selectedItem.Type)
                    {
                        case ItemTypes.Consumables:
                        GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.Name + "\n" + selectedItem.Description + "\nValue: " + selectedItem.Value + "\nHeal: " + selectedItem.Heal);

                            //if (curHealth < CharacterHandler.maxHealth)
                            if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Eat"))
                            {
                                //CharacterHandler.curHealth += selectedItem.Heal;
                                inv.Remove(selectedItem);
                                selectedItem = null;
                                return;
                            }
                            break;
                        case ItemTypes.Craftable:
                            GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.Name + "\n" + selectedItem.Description + "\nValue: " + selectedItem.Value);
                            if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Use"))
                            {
                                //craft system a +b = c
                            }
                            break;
                        case ItemTypes.Armour:
                            GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.Name + "\n" + selectedItem.Description + "\nValue: " + selectedItem.Value + "\nArmour: " + selectedItem.Armour);
                            if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Wear"))
                            {
                                //attach and wear on character
                            }
                            break;
                        case ItemTypes.Weapon:
                            GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.Name + "\n" + selectedItem.Description + "\nValue: " + selectedItem.Value + "\nDamage: " + selectedItem.Damage);
                            if (GUI.Button(new Rect(15 * scr.x, 8.75f * scr.y, scr.x, 0.25f * scr.y), "Equip"))
                            {
                                //use and spawn to character
                            }
                            break;
                        case ItemTypes.Misc:
                            GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.Name + "\n" + selectedItem.Description + "\nValue: " + selectedItem.Value);
                            break;
                        case ItemTypes.Quest:
                            GUI.Box(new Rect(8 * scr.x, 5 * scr.y, 8 * scr.x, 3 * scr.y), selectedItem.Name + "\n" + selectedItem.Description + "\nValue: " + selectedItem.Value);
                            break;
                    }
                }
            }
        }
    }
    void DisplayInv(string sortType)
    {
        if (!(sortType == "All" || sortType == ""))
        {
            ItemTypes type = (ItemTypes)System.Enum.Parse(typeof(ItemTypes), sortType);
            int a = 0;//amount of that type
            int s = 0;//slot position of ui item
            for (int i = 0; i < inv.Count; i++)
            {
                if (inv[i].Type == type)
                {
                    a++;
                }
            }
            if (a <= 35)
            {
                for (int i = 0; i < inv.Count; i++)
                {
                    if (inv[i].Type == type)
                    {
                        if (GUI.Button(new Rect(0.5f * scr.x, 0.25f * scr.y + s * (0.25f * scr.y), 3 * scr.x, 0.25f * scr.y), inv[i].Name))
                        {
                            selectedItem = inv[i];
                            Debug.Log(selectedItem.Name);
                        }
                        s++;
                    }
                }
            }
            // nice work u did it
            else
            {
                scrollPos = GUI.BeginScrollView(new Rect(0, 0.25f * scr.y, 3.75f * scr.x, 8.75f * scr.y), scrollPos, new Rect(0, 0, 0, 8.75f * scr.y + ((a - 35) * (0.25f * scr.y))), false, true);
                #region Items in Viewing Area

                for (int i = 0; i < inv.Count; i++)
                {
                    if (GUI.Button(new Rect(0.5f * scr.x, 0 * scr.y + s * (0.25f * scr.y), 3 * scr.x, 0.25f * scr.y), inv[i].Name))
                    {
                        selectedItem = inv[i];
                        Debug.Log(selectedItem.Name);
                    }
                    s++;
                }

                #endregion
                GUI.EndScrollView();
            }
        }
        else
        {
            #region Non Scroll Inventory
            if (inv.Count <= 35)//if we have 35 or less
            {
                for (int i = 0; i < inv.Count; i++)
                {
                    if (GUI.Button(new Rect(0.5f * scr.x, 0.25f * scr.y + i * (0.25f * scr.y), 3 * scr.x, 0.25f * scr.y), inv[i].Name))
                    //show GUI button on the screen for each item
                    {
                        selectedItem = inv[i];//if this item is selected set it to the selected item
                        Debug.Log(selectedItem.Name);
                    }
                }
            }
            #endregion
            #region Scroll Inventory
            else // we are greater than 35
            {
                //our moved position in scrolling   
                scrollPos =
                //the start of our viewing area
                GUI.BeginScrollView(
                //our view window         
                new Rect(0, 0.25f * scr.y, 3.75f * scr.x, 8.75f * scr.y),
                //our  current position in the scrolling
                scrollPos,
                //the viewable area
                new Rect(0, 0, 0, 8.75f * scr.y + ((inv.Count - 35) * (0.25f * scr.y))),
                //can we see the horizontal bar?
                false,
                //can we see the vertical bar?
                true);
                #region Items in Viewing Area
                for (int i = 0; i < inv.Count; i++)
                {
                    if (GUI.Button(new Rect(0.5f * scr.x, 0 * scr.y + i * (0.25f * scr.y), 3 * scr.x, 0.25f * scr.y), inv[i].Name))
                    //show GUI button on the screen for each item
                    {
                        selectedItem = inv[i];//if this item is selected set it to the selected item
                        Debug.Log(selectedItem.Name);
                    }
                }
                #endregion
                //the end of our viewing area
                GUI.EndScrollView();
            }
            #endregion
        }
    }
}