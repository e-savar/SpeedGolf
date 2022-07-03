using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneAssistant : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void transition(string sceneToTransition)
    {
        Profile.instance.UI.SetActive(!Profile.instance.UI.activeInHierarchy);
        SceneManager.LoadScene(sceneToTransition);
    }
    //Profile UI Elements
    [SerializeField] private GameObject profileWindow;
    [SerializeField] private GameObject shopWindow;
    [SerializeField] private Text starsText;
    [SerializeField] private Text nameText; //Edit this in-app using Field
    [SerializeField] private Text levelText; //Max Level unlocked
    [SerializeField] private Image currentBallPic;
    [SerializeField] private Text coinText;
    [SerializeField] private Text gemText;

    

    public void Quit()
    {
        Application.Quit();
    }
}
