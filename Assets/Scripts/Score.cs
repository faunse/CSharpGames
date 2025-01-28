using UnityEngine;

public class Score : MonoBehaviour
{
    public int m_score;

    public void AddScore(int scoretoadd = 5)
    {
        m_score += scoretoadd;
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
