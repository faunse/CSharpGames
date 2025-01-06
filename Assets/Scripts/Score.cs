using UnityEngine;

public class Score : MonoBehaviour
{
    private int m_score;

    public void AddScore(int scoretoadd = 5)
    {
        m_score += scoretoadd;
    }

    public int GetScore()
    { 
        return m_score; 
    
    }
    
}
