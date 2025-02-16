using Unity.VisualScripting;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public int m_score;
    public static int FinalScore;
    public static int[] ScoreArray;

    private void Start()
    {
     
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
