using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeScreen : MonoBehaviour
{

    public bool isEscapeToExit;
    public GameObject MenuPanel;
    public GameObject HTPPanel;
    public GameObject HTPPanel2;
    // Start is called before the first frame update
    void Start()
    {
        MenuPanel.SetActive(true);
        HTPPanel.SetActive(false);
        HTPPanel2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void MulaiButtonClicked()
    {
        SceneManager.LoadScene("1");
    }
    public void HowToPlayButtonClicked()
    {
        MenuPanel.SetActive(false);
        HTPPanel.SetActive(true);
        HTPPanel2.SetActive(false);
    }
    public void HowToPlayButtonClicked2()
    {
        MenuPanel.SetActive(false);
        HTPPanel.SetActive(false);
        HTPPanel2.SetActive(true);
    }
    public void Exit_Clicked()
    {
        Application.Quit();
    }
    public void BackButtonClicked()
    {
        MenuPanel.SetActive(true);
        HTPPanel.SetActive(false);
        HTPPanel2.SetActive(false);
    }
    public void BackButton2Clicked()
    {
        MenuPanel.SetActive(false);
        HTPPanel.SetActive(true);
        HTPPanel2.SetActive(false);
    }

    public void KembaliKeMenu ()
    {
    SceneManager.LoadScene ("MainMenu");
    }

}
