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
        Debug.Log("ChangeScene");
        
    }

    public void stop()
    {
        Application.Quit();
    }



}
