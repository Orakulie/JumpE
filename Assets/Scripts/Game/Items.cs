using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class Items {

    // Use this for initialization
    public string Name;
    public int ID;
    public string Beschreibung;
    public ItemType itemType;
    public enum ItemType
    {
        Waffe,
        Rüstung,
        Verbrauchbares
    }
    public float Schaden;
    public float Rüstung;
   
}
