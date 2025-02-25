using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScoreSystem : MonoBehaviour
{
    public int m_score;
    public static int FinalScore;
    public static int[] ScoreArray;
    private InputAction m_Money;

    private void Start()
    {
        m_Money = InputSystem.actions.FindAction("Money");

    }

    private void Update()
    {
        if (m_Money.IsPressed())
        {
            AddScore(1000);
        }
    }
    public void AddScore(int scoretoadd)
    {
        FinalScore = FinalScore + scoretoadd;
        m_score = m_score + scoretoadd;
    }

    public int GetScore()
    { 
        return m_score; 
    
    }

    public void Bought(int Cost)
    {
        m_score = m_score - Cost;
        
    }

  

  

}
