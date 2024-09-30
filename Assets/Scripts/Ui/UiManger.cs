using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManger : MonoBehaviour
{
    [Header("References")]
    PlayerController pc;

    public TextMeshProUGUI ammoCount;

    private void Awake()
    {
        pc = FindObjectOfType<PlayerController>();
    }
    public void AmmoDown()
    {
        ammoCount.text = pc.ammo.ToString();
    }
}
