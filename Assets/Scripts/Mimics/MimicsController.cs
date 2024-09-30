using UnityEngine;

public class MimicsController : MonoBehaviour
{
    [Header("References")]
    Timer timer;
    PlayerController pc;

    [Header("Collider")]
    public float seconds;
    public float damage;

    private void Awake()
    {
        timer = FindObjectOfType<Timer>();
        pc = FindObjectOfType<PlayerController>();
    }

    public void Attack()
    {
        timer.time -= damage;
        pc.flashlight.intensity = 0;
        pc.light.intensity = 0;
        transform.position = new Vector3 (10, 1, 10);        
    }

    private void OnCollisionEnter(Collision b)
    {
        if (b.gameObject.name == "Bullet" || b.gameObject.name == "Bullet(Clone)")
        {   
            Destroy(b.gameObject);
            Destroy(gameObject);
        }
    }
}
