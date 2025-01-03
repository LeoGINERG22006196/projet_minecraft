using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 10.0f;        // Vitesse de déplacement du personnage
    public float jumpForce = 5.0f;        // Force du saut
    public Transform cameraTransform;     // Référence à la caméra
    public LayerMask groundLayer;         // Layer pour détecter le sol
    public Transform groundCheck;         // Position pour vérifier si le personnage est au sol
    public float groundDistance = 0.2f;   // Distance pour vérifier si le personnage touche le sol

    private Rigidbody rb;
    private bool isGrounded;
    private Animator animator;            // Référence à l'Animator

    void Start()
    {
        // Obtenir le Rigidbody attaché au personnage
        rb = GetComponent<Rigidbody>();
        // S'assurer que la rotation ne soit pas affectée par la physique
        rb.freezeRotation = true;

        // Récupérer l'Animator attaché au personnage
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Vérifier si le personnage est au sol
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

        // Envoyer l'état "isGrounded" à l'Animator
        animator.SetBool("IsGrounded", isGrounded);

        // Récupérer les inputs de déplacement du joueur
        float horizontal = Input.GetAxis("Horizontal"); // A/D ou Q/D
        float vertical = Input.GetAxis("Vertical");     // W/S ou Z/S

        // Créer un vecteur de déplacement basé sur les inputs
        Vector3 movementDirection = new Vector3(horizontal, 0, vertical).normalized;

        // Calculer la vitesse pour l'Animator
        float speed = movementDirection.magnitude;
        animator.SetFloat("Speed", speed * moveSpeed); // Envoie la vitesse à l'Animator
        UnityEngine.Debug.Log("Speed : " + speed);

        // Si le joueur se déplace, on ajuste la direction
        if (speed >= 0.1f)
        {
            // Récupérer l'angle de direction basé sur la caméra
            float targetAngle = Mathf.Atan2(movementDirection.x, movementDirection.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0, targetAngle, 0);

            // Calculer la direction dans laquelle se déplacer
            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;

            // Déplacer le personnage
            rb.MovePosition(transform.position + moveDir.normalized * moveSpeed * Time.deltaTime);
        }

        // Gérer le saut
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetTrigger("Jump"); // Déclenche l'animation de saut
        }
    }
}
