using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    public float time = 180;
    public TextMeshProUGUI timeText;

    private void Update()
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        time -= Time.deltaTime;
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
