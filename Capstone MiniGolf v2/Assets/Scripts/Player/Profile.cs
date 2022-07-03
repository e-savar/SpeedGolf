using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Profile : MonoBehaviour
{
    public static Profile instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }

        DontDestroyOnLoad(gameObject);
    }
    //Version 0.1
    public int levelsUnlocked = 1;
    public Ball ball;
    //Version 0.2
    private string name;
    public int coins = 0;
    public int gems = 0;
    public Skin[] unlockedSkins;
    [SerializeField] private Skin[] lockedSkins;
    public Image profileImage;
    public GameObject UI;

    public int currentStars = 0;
    [SerializeField] private int totalStars = 24;
    [SerializeField] private Text starText;
    [SerializeField] private Text coinText;
    [SerializeField] private Text gemText;

    [Header("Stats")]
    public int friction = 0;
    public int luck = 0;
    public int time = 0;
    [SerializeField] private Text fricText;
    [SerializeField] private Text luckText;
    [SerializeField] private Text timeText;
    [SerializeField] private Text fricStatText;
    [SerializeField] private Text luckStatText;
    [SerializeField] private Text timeStatText;
    [SerializeField] private int[] levelupgrades = {100, 500, 1000, 2000, 5000, 10000, 15000, 25000, 50000, 75000, 99999};
    //Version 0.3


    //methods
    public void changeLevels()
    {
        if (levelsUnlocked.Equals(null))
        {
            levelsUnlocked = 2;
        }
        else
        {
            levelsUnlocked++;
        }
    }

    public void unlockSkin(int lockedSkin)
    {
        unlockedSkins[lockedSkin] = lockedSkins[lockedSkin];
        selectSkin(lockedSkin);
    }

    public void selectSkin(int lockedSkin)
    {
        ball.skin.sprite = unlockedSkins[lockedSkin].GetComponent<Image>().sprite;
        profileImage.sprite = ball.skin.sprite;
    }

    public void openWindow(GameObject window)
    {
        window.SetActive(!window.activeInHierarchy);
        gemText.text = "Gems: " + gems.ToString();
        coinText.text = "Coins: " + coins + "g";
        starText.text = "Stars: " + currentStars.ToString() + "/" + totalStars.ToString();
    }

    public void transition(string sceneToTransition)
    {
        UI.SetActive(!UI.activeInHierarchy);
        SceneManager.LoadScene(sceneToTransition);
    }
    public void transitionBack(string sceneToTransition)
    {

        SceneManager.LoadScene(sceneToTransition);
        UI.SetActive(!UI.activeInHierarchy);
    }

    //shop
    public void changeStat(string stat)
    {
        if (stat == "time")
        {
            if (coins >= levelupgrades[time])
            {
                coins -= levelupgrades[time];
                time++;
                timeText.text = levelupgrades[time].ToString();
                timeStatText.text = "Time: " + time;
            }
        }
        else if(stat == "luck")
        {
            if (coins >= levelupgrades[luck])
            {
                coins -= levelupgrades[luck];
                luck++;
                luckText.text = levelupgrades[luck].ToString();
                luckStatText.text = "Luck: " + luck;
            }
        }
        else if(stat == "friction")
        {
            if (coins >= levelupgrades[friction])
            {
                coins -= levelupgrades[friction];
                friction++;
                fricText.text = levelupgrades[friction].ToString();
                fricStatText.text = "Friction: " + friction;
            }
        }
    }
}
