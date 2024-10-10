using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 10.0f;        // Vitesse de d�placement du personnage
    public float jumpForce = 5.0f;        // Force du saut
    public Transform cameraTransform;      // R�f�rence � la cam�ra
    public LayerMask groundLayer;          // Layer pour d�tecter le sol
    public Transform groundCheck;          // Position pour v�rifier si le personnage est au sol
    public float groundDistance = 0.2f;    // Distance pour v�rifier si le personnage touche le sol

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        // Obtenir le Rigidbody attach� au personnage
        rb = GetComponent<Rigidbody>();
        // S'assurer que la rotation ne soit pas affect�e par la physique
        rb.freezeRotation = true;
    }

    void Update()
    {
        // V�rifier si le personnage est au sol
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

        // R�cup�rer les inputs de d�placement du joueur
        float horizontal = Input.GetAxis("Horizontal"); // A/D ou Q/D
        float vertical = Input.GetAxis("Vertical");     // W/S ou Z/S

        // Cr�er un vecteur de d�placement bas� sur les inputs
        Vector3 movementDirection = new Vector3(horizontal, 0, vertical).normalized;

        // Si le joueur se d�place, on ne permet pas de sauter
        if (movementDirection.magnitude >= 0.1f)
        {
            // R�cup�rer l'angle de direction bas� sur la cam�ra
            float targetAngle = Mathf.Atan2(movementDirection.x, movementDirection.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0, targetAngle, 0);

            // Calculer la direction dans laquelle se d�placer
            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;

            // D�placer le personnage
            rb.MovePosition(transform.position + moveDir.normalized * moveSpeed * Time.deltaTime);
        }

        // Sauter si le personnage est au sol et que la touche de saut est press�e (espace)
        if (Input.GetButtonDown("Jump") && isGrounded && movementDirection.magnitude < 0.1f)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
