using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int diez = 10;
    void Awake()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 60;
    }
}
