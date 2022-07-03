using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skin : MonoBehaviour
{
    public int price;

    [SerializeField] private Text priceText;

    [SerializeField] private bool isUnlocked;
    [SerializeField] private bool isSelected;

    private void Start()
    {
        
    }

    public void purchase(int lockedSkin)
    {
        if(!isUnlocked)
        {
            if (Profile.instance.coins >= price)
            {
                Profile.instance.unlockSkin(lockedSkin);
                priceText.text = "SELECT";
                Profile.instance.coins -= price;
                isUnlocked = true;
                isSelected = false;
            }
        }
        else if(isUnlocked)
        {
            if(!isSelected)
            {
                foreach(Skin skin in Profile.instance.unlockedSkins)
                {
                    if(skin != null)
                    {
                        skin.priceText.text = "SELECT";
                        skin.gameObject.GetComponent<Button>().interactable = true;
                        skin.isSelected = false;
                    }
                }
                priceText.text = "SELECTED";
                gameObject.GetComponent<Button>().interactable = false;
                isSelected = true;
            }

        }
    }
}
