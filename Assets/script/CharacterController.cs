using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5.0f;    // Vitesse de d�placement du personnage
    public float rotationSpeed = 10.0f; // Vitesse de rotation du personnage
    public Transform cameraTransform; // R�f�rence � la cam�ra

    private Rigidbody rb;

    void Start()
    {
        // Obtenir le Rigidbody attach� au personnage
        rb = GetComponent<Rigidbody>();
        // S'assurer que la rotation ne soit pas affect�e par la physique
        rb.freezeRotation = true;
    }

    void Update()
    {
        // R�cup�rer les inputs de d�placement du joueur
        float horizontal = Input.GetAxis("Horizontal"); // A/D ou Q/D
        float vertical = Input.GetAxis("Vertical");     // W/S ou Z/S

        // Cr�er un vecteur de d�placement bas� sur les inputs
        Vector3 movementDirection = new Vector3(horizontal, 0, vertical).normalized;

        // Si le joueur se d�place
        if (movementDirection.magnitude >= 0.1f)
        {
            // Calculer l'angle de direction bas� sur la cam�ra
            float targetAngle = Mathf.Atan2(movementDirection.x, movementDirection.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationSpeed, 0.1f);

            // Tourner le personnage progressivement dans la direction de d�placement
            transform.rotation = Quaternion.Euler(0, smoothAngle, 0);

            // Calculer la direction dans laquelle se d�placer
            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;

            // D�placer le personnage
            rb.MovePosition(transform.position + moveDir.normalized * moveSpeed * Time.deltaTime);
        }
    }
}
