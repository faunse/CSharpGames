using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private ScoreSystem m_scoreSystem;

    private TMPro.TextMeshProUGUI m_ScoreText;

    private void Awake()
    {

        m_ScoreText = (TextMeshProUGUI)GetComponent<TMPro.TMP_Text>();

        m_scoreSystem = GameObject.Find("Character").GetComponent<ScoreSystem>();

    }

    private void Update()
    {
        m_ScoreText.text = "Score: " + m_scoreSystem.GetScore();
    }


}
