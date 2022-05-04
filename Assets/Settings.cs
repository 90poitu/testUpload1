using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public save save;
    public void autoSave(float value)
    {
        if (value != 0)
        {
            save.gameFile_.autoSave = true;
        }
        else
        {
            save.gameFile_.autoSave = false;
        }
    }
}