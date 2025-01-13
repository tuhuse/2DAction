using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneGameManager : MonoBehaviour
{
    public static SceneGameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject); // 重複インスタンスを削除
        }
        else
        {
            Instance = this;          
        }
    }
   
    public void OnTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
    public void OnMain()
    {
       SceneManager.LoadScene("MainScene");
    }
    public void OnGameOver()
    {
       
        SceneManager.LoadScene("GameOver");
    }
    public void OnGameClear()
    {
        SceneManager.LoadScene("GameClear");
    }
    public void OnExit()
    {
        Application.Quit();
    }
  
}
