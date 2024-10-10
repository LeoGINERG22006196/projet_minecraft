using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 10.0f;        // Vitesse de déplacement du personnage
    public float jumpForce = 5.0f;        // Force du saut
    public Transform cameraTransform;      // Référence à la caméra
    public LayerMask groundLayer;          // Layer pour détecter le sol
    public Transform groundCheck;          // Position pour vérifier si le personnage est au sol
    public float groundDistance = 0.2f;    // Distance pour vérifier si le personnage touche le sol

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        // Obtenir le Rigidbody attaché au personnage
        rb = GetComponent<Rigidbody>();
        // S'assurer que la rotation ne soit pas affectée par la physique
        rb.freezeRotation = true;
    }

    void Update()
    {
        // Vérifier si le personnage est au sol
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

        // Récupérer les inputs de déplacement du joueur
        float horizontal = Input.GetAxis("Horizontal"); // A/D ou Q/D
        float vertical = Input.GetAxis("Vertical");     // W/S ou Z/S

        // Créer un vecteur de déplacement basé sur les inputs
        Vector3 movementDirection = new Vector3(horizontal, 0, vertical).normalized;

        // Si le joueur se déplace, on ne permet pas de sauter
        if (movementDirection.magnitude >= 0.1f)
        {
            // Récupérer l'angle de direction basé sur la caméra
            float targetAngle = Mathf.Atan2(movementDirection.x, movementDirection.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0, targetAngle, 0);

            // Calculer la direction dans laquelle se déplacer
            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;

            // Déplacer le personnage
            rb.MovePosition(transform.position + moveDir.normalized * moveSpeed * Time.deltaTime);
        }

        // Sauter si le personnage est au sol et que la touche de saut est pressée (espace)
        if (Input.GetButtonDown("Jump") && isGrounded && movementDirection.magnitude < 0.1f)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
