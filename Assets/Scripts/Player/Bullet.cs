using UnityEngine;

public class Bullet : MonoBehaviour
{
    Vector3 mousePos;
    Rigidbody rb;
    float speed = 5;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();        
    }
    private void Start()
    {
        // Obt�n la posici�n del mouse en la pantalla
        Vector3 mousePos = Input.mousePosition;

        // Definir una distancia fija del mouse en el eje Z
        float distanceFromCamera = 10f;  // Ajusta seg�n la escena y la distancia deseada

        // Convertir la posici�n del mouse a coordenadas del mundo 3D
        mousePos.z = distanceFromCamera;
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);

        // Calcular la direcci�n desde el objeto hacia el mouse
        Vector3 direction = (worldMousePos - transform.position);
        direction.y = 0;  // Mantener la direcci�n solo en los ejes X-Z (ignorar Y)

        // Normalizar la direcci�n para que tenga una magnitud de 1 (solo direcci�n, sin influencia de la distancia)
        direction = direction.normalized;

        // Aplicar una velocidad constante en esa direcci�n
        rb.linearVelocity = direction * speed;
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.name != "PlayerObj" && c.gameObject.name != "MinAtk" && c.gameObject.name != "MedAtk" && c.gameObject.name != "MaxAtk")
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        
    }
}
