using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIhandler : MonoBehaviour
{
  [SerializeField] Text currentScoretxt;
  [SerializeField] Text highScoretxt;

    private void Start()
    {
      currentScoretxt.text="Current Score:"+PlayerPrefs.GetInt("CurrentScore").ToString();
      if(PlayerPrefs.GetInt("CurrentScore")>PlayerPrefs.GetInt("HighScore"))

      {
        PlayerPrefs.SetInt("HighScore",PlayerPrefs.GetInt("CurrentScore"));
      }
      highScoretxt.text="High Score:"+PlayerPrefs.GetInt("HighScore").ToString();
    }



    public void StartGame()
    {
      SceneManager.LoadScene(1);
    }
    public void Exit()
    {
      Application.Quit();
    }
    public void Exitbtn()
    {
      SceneManager.LoadScene(0);
    }
}
