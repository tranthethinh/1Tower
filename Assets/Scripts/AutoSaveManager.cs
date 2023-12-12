using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSaveManager : MonoBehaviour
{
    void Start()
    {
        // InvokeRepeating takes the method to call, the initial delay, and the repeat interval
        InvokeRepeating("AutoSave", 5f, 5f);
    }

    void AutoSave()
    {
        // Assuming SaveSystem is a static class with a static Save method
        SaveSystem.Save();
        Debug.Log("Auto Save completed");
    }
}
