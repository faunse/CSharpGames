using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;



public class DeathMenu : MonoBehaviour
{
    
    public GameObject Menu;
    private TMPro.TextMeshProUGUI m_FinalScoreText;

    private void OnEnable()
    {
        m_FinalScoreText = (TextMeshProUGUI)GetComponent<TMPro.TMP_Text>();
        m_FinalScoreText.text = ("Final score: " + ScoreSystem.FinalScore);
    }


    public void MainMenu2()
    {
        SceneManager.LoadScene("StartScreen");

    }


}
