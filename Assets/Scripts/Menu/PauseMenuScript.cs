using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public bool PausedGame = false;
    public GameObject Menu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PausedGame)
            {
                ResumeGame();

            }
            else
            {
                PauseGame();        

            }

        }
    }

    public void PauseGame()
    {
        Menu.SetActive(true);
        Time.timeScale = 0f;
        PausedGame = true;
    }

    public void ResumeGame()
    {
        Menu.SetActive(false);
        Time.timeScale = 1f;
        PausedGame = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("StartScreen");
        

    }


}
