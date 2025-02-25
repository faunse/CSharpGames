using TMPro;
using UnityEngine;
public class Timer : MonoBehaviour
{
    bool roundfinished = true;
    float remainingtime = 20;
    public TextMeshProUGUI TimerText;

    private void OnEnable()
    {
        roundfinished = true;
        remainingtime = 10;
      
    }




    // Update is called once per frame
    void Update()
    {
        if (roundfinished)
        {
            if (remainingtime < 0)
            {
                gameObject.SetActive(false);
            }
            if (remainingtime > 0)
            {
                remainingtime -= Time.deltaTime;
            }
            int minutes = Mathf.FloorToInt(remainingtime / 60);
            int seconds = Mathf.FloorToInt(remainingtime % 60);
            TimerText.text = string.Format("Shop open, Time remaining until next round {0:00}:{1:00}",minutes, seconds);
        }
    }
}
