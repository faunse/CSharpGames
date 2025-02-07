using Unity.VisualScripting;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public int m_score;
    public static int FinalScore;
    public static int[] ScoreArray;

    private void Start()
    {
        if (FinalScore > 0)
        {
            ScoreArray = new int[FinalScore];
        }
    }
    public void AddScore(int scoretoadd = 15)
    {
        m_score += scoretoadd;
        FinalScore += m_score;
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
