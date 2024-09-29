using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    Rigidbody rb;
    Transform tm;
    GameManager gm;
    Camera cam;

    [Header("Movement")]
    public float moveSpeed;   
    Vector3 movement;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        tm = GetComponent<Transform>();
    }

    private void Update()
    {
        //Movimiento
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");

        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);       
    }   
}
