using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelsHolder : MonoBehaviour
{
    public Button[] levels;
    private void Start()
    {
        for (int i = 0; i < Profile.instance.levelsUnlocked; i++)
        {
            levels[i].interactable = true;
        }
    }
}
