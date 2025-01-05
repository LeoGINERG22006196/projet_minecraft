using UnityEngine;

public class BatMovement : MonoBehaviour
{
    public float distance = 5f; // Distance de déplacement (x)
    public float speed = 2f;    // Vitesse de déplacement

    private Vector3 startPosition;

    void Start()
    {
        // Enregistre la position de départ
        startPosition = transform.position;
    }

    void Update()
    {
        // Calcul du déplacement oscillant
        float offset = Mathf.PingPong(Time.time * speed, distance);
        transform.position = startPosition + new Vector3(0, 0, offset);
    }
}
