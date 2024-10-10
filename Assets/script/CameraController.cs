using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform; // Le Transform du personnage � suivre
    public float distance = 5.0f;     // Distance entre la cam�ra et le personnage
    public float height = 2.0f;       // Hauteur de la cam�ra par rapport au personnage
    public float cameraSpeed = 2.0f;  // Vitesse de rotation de la cam�ra

    private Vector3 offset;

    void Start()
    {
        // Calcul initial de l'offset bas� sur la distance et la hauteur
        offset = new Vector3(0, height, -distance);
    }

    void LateUpdate()
    {
        // Permet � la cam�ra de pivoter autour du personnage avec les mouvements de la souris
        float horizontal = Input.GetAxis("Mouse X") * cameraSpeed;
        float vertical = Input.GetAxis("Mouse Y") * cameraSpeed;

        // Appliquer une rotation autour du joueur
        offset = Quaternion.AngleAxis(horizontal, Vector3.up) * offset;

        // D�placement de la cam�ra vers la nouvelle position
        transform.position = playerTransform.position + offset;

        // Faire en sorte que la cam�ra regarde toujours le personnage
        transform.LookAt(playerTransform.position + Vector3.up * height);
    }
}
