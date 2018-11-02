using UnityEngine;

public static class ItemData
{
    public static Item CreateItem(int ItemID)
    {
        // This is what we need
        string name = "";
        string description = "";
        string icon = "";
        int value = 0;
        int damage = 0;
        int armour = 0;
        int amount = 0;
        int heal = 0;
        string mesh = "";
        ItemTypes type = ItemTypes.Armour;

        // This is where we set the item
        switch(ItemID)
        {
            #region Consumables 0-99
            case 0:
                name = "Apple";
                description = "A juicy fken Apple";
                value = 10;
                damage = 0;
                armour = 0;
                amount = 1;
                heal = 10;
                icon = "Apple_Icon";
                mesh = "";
                type = ItemTypes.Consumables;
                break;

            case 1:
                name = "Bacon";
                description = "A extra crispy juiced up bacon that was pan fried with some added flavours, salt and peeper";
                value = 10;
                damage = 0;
                armour = 0;
                amount = 1;
                heal = 10;
                icon = "CrispyBacon_Icon";
                mesh = "";
                type = ItemTypes.Consumables;
                break;

            case 2:
                name = "Health Potion";
                description = "This is a delicious brew of beer and spirits, oh yer and it fking heals you";
                value = 10;
                damage = 0;
                armour = 0;
                amount = 1;
                heal = 50;
                icon = "HealthPotion_Icon";
                mesh = "";
                type = ItemTypes.Consumables;
                break;

            #endregion
            #region Armour 100-199
            case 100:
                name = "Cling Wrapped Helmet";
                description = "This helmet has 1 protection and if used improperly can cause suffication";
                value = 100;
                damage = 0;
                armour = 1;
                amount = 1;
                heal = 0;
                icon = "ClingWrappedHelmet_Icon";
                mesh = "Cling Wrapped Helmet_Mesh";
                type = ItemTypes.Armour;
                break;

            case 101:
                name = "Steel Plate Helmet";
                description = "A very heavy and strong peice of armour used for a great amount of protection";
                value = 50;
                damage = 0;
                armour = 50;
                amount = 1;
                heal = 0;
                icon = "SteelPlateHelmet_Item";
                mesh = "SteelPlateHelmet_Mesh";
                type = ItemTypes.Armour;
                break;

            case 102:
                name = "Diamond Helmet";
                description = "This mighty helmet of rarity is served for only the best protection";
                value = 1000;
                damage = 0;
                armour = 200;
                amount = 1;
                heal = 0;
                icon = "DiamondHelmet_Icon";
                mesh = "DiamondHelmet_Mesh";
                type = ItemTypes.Armour;
                break;
            #endregion
            #region Weapon 200-299
            case 200:
                name = "Bronze Sword";
                description = "A very weak weapon but can still defend of those bugs.";
                value = 20;
                damage = 10;
                armour = 0;
                amount = 1;
                heal = 0;
                icon = "BronzeSword_Icon";
                mesh = "BronzeSword_Mesh";
                type = ItemTypes.Weapon;
                break;

            case 201:
                name = "Steel Axe";
                description = "A very heavy axe but can cut through most things, such as flesh.";
                value = 50;
                damage = 30;
                armour = 0;
                amount = 1;
                heal = 0;
                icon = "SteelAxe_Icon";
                mesh = "SteelAxe_Mesh";
                type = ItemTypes.Weapon;
                break;

            case 202:
                name = "Diamond Sword";
                description = "This mighty Sword can never be broken and will kill anything you throw at it.";
                value = 1000;
                damage = 80;
                armour = 0;
                amount = 1;
                heal = 0;
                icon = "DiamondSword_Icon";
                mesh = "DiamondSword_Mesh";
                type = ItemTypes.Weapon;
                break;
            #endregion
            #region Craftables 300-399
            case 300:
                name = "Iron Ore";
                description = "A very quick and easy material to melt and craft the basic equitment.";
                value = 20;
                damage = 0;
                armour = 0;
                amount = 1;
                heal = 0;
                icon = "IronOre_Icon";
                mesh = "IronOre_Mesh";
                type = ItemTypes.Craftable;
                break;

            case 301:
                name = "Meteorite Shard";
                description = "A very strong and powerful material used in crafting only the best or the best.";
                value = 1000;
                damage = 0;
                armour = 0;
                amount = 1;
                heal = 0;
                icon = "Meteorite_Icon";
                mesh = "Meteorite_Mesh";
                type = ItemTypes.Craftable;
                break;

            case 302:
                name = "Diamond Ore";
                description = "Diamonds can be very hard to find and once combined in crafting recipes can give you the most powerful equiptment.";
                value = 500;
                damage = 0;
                armour = 0;
                amount = 1;
                heal = 0;
                icon = "DiamondOre_Icon";
                mesh = "DiamondOre_Mesh";
                type = ItemTypes.Craftable;
                break;
            #endregion
            #region Misc 400-499
            case 400:
                name = "Trusty Kettle";
                description = "A home appliance plug it into a wall and off you go nice hot tea or coffee.";
                value = 40;
                damage = 0;
                armour = 0;
                amount = 1;
                heal = 0;
                icon = "TrustyKettle_Icon";
                mesh = "TrustyKettle_Mesh";
                type = ItemTypes.Misc;
                break;

            case 401:
                name = "Meteorite Trinket";
                description = "A very cool peice of art place on a nice table to make your place feel homely.";
                value = 500;
                damage = 0;
                armour = 0;
                amount = 1;
                heal = 0;
                icon = "MeteoriteTrinket_Icon";
                mesh = "MeteoriteTrinket_Mesh";
                type = ItemTypes.Misc;
                break;

            case 402:
                name = "Lamp";
                description = "Lite the way to shit land or sell it for 1 dollar.";
                value = 1;
                damage = 0;
                armour = 0;
                amount = 1;
                heal = 0;
                icon = "Lamp_Icon";
                mesh = "Lamp_Mesh";
                type = ItemTypes.Misc;
                break;
            #endregion
            default:
                name = "Bacon";
                description = "A extra crispy juiced up bacon that was pan fried with some added flavours, salt and peeper";
                value = 10;
                damage = 0;
                armour = 0;
                amount = 1;
                heal = 10;
                icon = "CrispyBacon_Icon";
                mesh = "";
                type = ItemTypes.Consumables;
                break;
        }


        // This is where we create the item
        Item temp = new Item();
        {
            temp.Name = name;
            temp.Id = ItemID;
            temp.Description = description;
            temp.Value = value;
            temp.Damage = damage;
            temp.Heal = heal;
            temp.Armour = armour;
            temp.Amount = amount;
            temp.Type = type;
            temp.Icon = Resources.Load("Icons/" + icon) as Texture2D;
            temp.MeshName = mesh;
        };


        return temp;
    }
}
