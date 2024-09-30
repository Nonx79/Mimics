using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    Rigidbody rb;
    GameManager gm;
    UiManger um;

    [Header("Light")]
    float reload = .5f;
    public Light flashlight;
    public Light light;

    [Header("Movement")]
    public float moveSpeed;   
    Vector3 movement;

    [Header("Pistol")]
    public int ammo = 15; //Change
    public GameObject bullet;
    [SerializeField] float timerBullet = 1.5f;
    public Transform bulletTranform;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        um = FindObjectOfType<UiManger>();
    }

    private void Update()
    {
        //Movimiento
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");

        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);     
        
        //Intensity light
        if (flashlight.intensity < 1)
        {
            flashlight.intensity += Time.deltaTime * reload;
        }
        if (light.intensity < 1)
        {
            light.intensity += Time.deltaTime * reload;
        }

        if (timerBullet <= 1.5f)
        {
            timerBullet += Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (timerBullet >= 1.5F)
            {
                ammo--;
                um.AmmoDown();
                Instantiate(bullet, bulletTranform.position, Quaternion.identity);
                timerBullet = 0;
            }
        }
    }   
}
