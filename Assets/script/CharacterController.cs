using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 10.0f;        // Vitesse de d�placement du personnage
    public float jumpForce = 5.0f;        // Force du saut
    public Transform cameraTransform;     // R�f�rence � la cam�ra
    public LayerMask groundLayer;         // Layer pour d�tecter le sol
    public Transform groundCheck;         // Position pour v�rifier si le personnage est au sol
    public float groundDistance = 0.2f;   // Distance pour v�rifier si le personnage touche le sol

    private Rigidbody rb;
    private bool isGrounded;
    private Animator animator;            // R�f�rence � l'Animator

    void Start()
    {
        // Obtenir le Rigidbody attach� au personnage
        rb = GetComponent<Rigidbody>();
        // S'assurer que la rotation ne soit pas affect�e par la physique
        rb.freezeRotation = true;

        // R�cup�rer l'Animator attach� au personnage
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // V�rifier si le personnage est au sol
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

        // Envoyer l'�tat "isGrounded" � l'Animator
        animator.SetBool("IsGrounded", isGrounded);

        // R�cup�rer les inputs de d�placement du joueur
        float horizontal = Input.GetAxis("Horizontal"); // A/D ou Q/D
        float vertical = Input.GetAxis("Vertical");     // W/S ou Z/S

        // Cr�er un vecteur de d�placement bas� sur les inputs
        Vector3 movementDirection = new Vector3(horizontal, 0, vertical).normalized;

        // Calculer la vitesse pour l'Animator
        float speed = movementDirection.magnitude;
        animator.SetFloat("Speed", speed * moveSpeed); // Envoie la vitesse � l'Animator
        UnityEngine.Debug.Log("Speed : " + speed);

        // Si le joueur se d�place, on ajuste la direction
        if (speed >= 0.1f)
        {
            // R�cup�rer l'angle de direction bas� sur la cam�ra
            float targetAngle = Mathf.Atan2(movementDirection.x, movementDirection.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0, targetAngle, 0);

            // Calculer la direction dans laquelle se d�placer
            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;

            // D�placer le personnage
            rb.MovePosition(transform.position + moveDir.normalized * moveSpeed * Time.deltaTime);
        }

        // G�rer le saut
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetTrigger("Jump"); // D�clenche l'animation de saut
        }
    }
}
