using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLevel : MonoBehaviour
{
    //In-Game
    [SerializeField] private Text levelHead;
    [SerializeField] private Image endPanel;
    [SerializeField] private Text timeText;
    [SerializeField] private CurrentLevel cLevel;
    [SerializeField] private Image starOne;
    [SerializeField] private Image starTwo;
    [SerializeField] private Image starThree;
    [SerializeField] private Text rewardText;
    //Timer
    [SerializeField] private float startTime;
    [SerializeField] private float stopTime;
    [SerializeField] private float timerTime;
    [SerializeField] private bool isRunning = false;
    [SerializeField] private bool isGoing = false;


    [Header("LevelSelectMenu")]
    [SerializeField] private GameObject levelSelectMenu;

    
    //BackEnd
    [SerializeField] private GameObject[] levelLayouts;
    int level;

    private void Start()
    {
        TimerReset();
        
    }
    private void Update()
    {
        if(isGoing)
        {
            timerTime = Mathf.Round((stopTime + (Time.time - startTime)) * 100f) / 100f;
        }
        timeText.text = timerTime.ToString() + "s";
    }

    public void loadLevel(int levelToLoad)
    {
        levelSelectMenu.SetActive(false);
        level = levelToLoad;
        levelLayouts[levelToLoad].gameObject.SetActive(true);
        levelHead.text = "Level " + (level + 1).ToString();
        Profile.instance.ball.gameObject.SetActive(true);
        TimerReset();
        TimerStart();
        isGoing = true;
        cLevel = levelLayouts[levelToLoad].GetComponent<CurrentLevel>();
    }

    public void EndLevel()
    {
        isGoing = false;
        TimerStop();
        levelLayouts[level].SetActive(false);
        Profile.instance.ball.transform.position = new Vector3(0, -3.5f, 0);
        Profile.instance.ball.gameObject.SetActive(false);
        endPanel.gameObject.SetActive(true);
        endPanel.GetComponent<Animator>().SetTrigger("Loaded");
        if(Profile.instance.levelsUnlocked < level+2)
        {
            Profile.instance.levelsUnlocked = level + 2;
        }
        if(timerTime < cLevel.oneStarTime)
        {
            if(cLevel.numCurrentStars < 1)
            {
                Profile.instance.currentStars += 1;
                cLevel.numCurrentStars = 1;
            }
            starOne.gameObject.SetActive(true);
            if (timerTime < cLevel.twoStarTime)
            {
                if (cLevel.numCurrentStars < 2)
                {
                    Profile.instance.currentStars += 1;
                    cLevel.numCurrentStars = 2;
                }
                starTwo.gameObject.SetActive(true);
                if (timerTime < cLevel.threeStarTime)
                {
                    if (cLevel.numCurrentStars < 3)
                    {
                        Profile.instance.currentStars += 1;
                        cLevel.numCurrentStars = 3;
                    }
                    starThree.gameObject.SetActive(true);
                }
            }
        }
        //Calculating reward
        int reward = Mathf.RoundToInt(((cLevel.reward+((100-timerTime)/timerTime)) * cLevel.difficulty)/Random.Range(8,10));
        if(reward > 0)
        {
            rewardText.text = reward.ToString();
            Profile.instance.coins += (reward*Profile.instance.luck);
            reward = 0;
        }
        else
        {
            rewardText.text = "0";
            reward = 0;
        }
        
    }

    //EndLevelMenu
    public void MainMenu()
    {
        TimerReset();
        endPanel.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
        starThree.gameObject.SetActive(false);
        starTwo.gameObject.SetActive(false);
        starOne.gameObject.SetActive(false);
        SceneManager.LoadScene("Main Menu");
        Profile.instance.UI.SetActive(true);
    }

    //NextLevelMenu
    public void NextLevel()
    {
        if (level+1 >= levelLayouts.Length)
        {
            MainMenu();
        }
        else
        {
            endPanel.gameObject.SetActive(false);
            loadLevel(level + 1);
            starThree.gameObject.SetActive(false);
            starTwo.gameObject.SetActive(false);
            starOne.gameObject.SetActive(false);
        }
    }

    public void TimerStart()
    {
        if (!isRunning)
        {
            isRunning = true;
            startTime = Time.time;
        }
    }

    public void TimerStop()
    {
        if (isRunning)
        {
            isRunning = false;
            stopTime = timerTime - (Profile.instance.time/10);
        }
    }

    public void TimerReset()
    {
        stopTime = 0;
        isRunning = false;
    }
}
