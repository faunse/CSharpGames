using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class MainMenuScreen : MonoBehaviour
{
    public Scene s_scene;
    public void OnStart()
    {
        SceneManager.LoadScene("Level");
        Time.timeScale = 1.0f;
        
    }

    public void stop()
    {
        Application.Quit();
    }



}
