using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform; // Le Transform du personnage à suivre
    public float distance = 5.0f;     // Distance entre la caméra et le personnage
    public float height = 2.0f;       // Hauteur initiale de la caméra
    public float cameraSpeed = 2.0f;  // Vitesse de rotation de la caméra
    public float verticalClampMin = -30.0f; // Limite inférieure pour le mouvement vertical
    public float verticalClampMax = 60.0f;  // Limite supérieure pour le mouvement vertical

    private float horizontalAngle = 0.0f;   // Angle de rotation horizontal
    private float verticalAngle = 0.0f;     // Angle de rotation vertical

    void LateUpdate()
    {
        // Récupérer les mouvements de la souris
        float horizontal = Input.GetAxis("Mouse X") * cameraSpeed;
        float vertical = Input.GetAxis("Mouse Y") * cameraSpeed;

        // Mettre à jour les angles de rotation
        horizontalAngle += horizontal;
        verticalAngle = Mathf.Clamp(verticalAngle - vertical, verticalClampMin, verticalClampMax);

        // Appliquer les rotations
        Quaternion rotation = Quaternion.Euler(verticalAngle, horizontalAngle, 0);

        // Calculer la position de la caméra en fonction de la rotation et de la distance
        Vector3 offset = rotation * new Vector3(0, 0, -distance);
        transform.position = playerTransform.position + offset;

        // Faire en sorte que la caméra regarde toujours le joueur
        transform.LookAt(playerTransform.position + Vector3.up * height);
    }
}
