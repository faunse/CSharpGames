using UnityEngine;

public class PointsPickUp : MonoBehaviour
{
    [SerializeField]
    private int m_Points;

    private Score m_scoresystem;

    private void Awake()
    {
        m_scoresystem= GameObject.Find("ScoreSystem").GetComponent<Score>();
        
    }

    public void Start()
    {
        
            m_scoresystem.AddScore(m_Points);
            
     
    }

    public void Addpoints()
    {
        m_scoresystem.AddScore(1);
    }




}
