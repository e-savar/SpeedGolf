using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    private void Awake()
    {
        levelNumTxt.text = levelNum;
    }
    //UI
    [SerializeField] private Text levelNumTxt;
    [SerializeField] private string levelNum;
    [SerializeField] private int level;

    [Header("LevelSelectMenu")]
    [SerializeField] private GameObject levelSelectMenu;

    //GameLevel
    [SerializeField] private GameLevel toLoad;

    public void loadLevel()
    {
        toLoad.gameObject.SetActive(true);
        toLoad.loadLevel(level-1);
    }

    /*Version 0.4
    private int totalStars = 3;
    private int starsEarned;
    */
}
