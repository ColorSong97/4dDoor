using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int currency;

    public SerializableDictionary<string, int> inventory;

    public GameData()
    {
        this.currency = 0;
        inventory = new SerializableDictionary<string, int>();
    }

    public void PrintSelf()
    {
        string str = "";
        str += "Currency: " + this.currency + "\n";
        foreach (KeyValuePair<string, int> pair in inventory)
        {
            str += pair.Key + ": " + pair.Value + "\n";
        }
        Debug.Log(str);
    }
}
