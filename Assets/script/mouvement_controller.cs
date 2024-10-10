using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveSpeed = 5f; // Vitesse de d�placement
    public float rotationSpeed = 720f; // Vitesse de rotation (en degr�s par seconde)
    private Rigidbody rb;

    void Start()
    {
        // R�cup�re le Rigidbody de l'objet
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Entr�es clavier (ZQSD pour Avancer, Reculer, Gauche, Droite)
        float moveHorizontal = 0f;
        float moveVertical = 0f;

        if (Input.GetKey(KeyCode.Z))
        {
            moveVertical = 1f; // Avance
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveVertical = -1f; // Recule
        }
        if (Input.GetKey(KeyCode.Q))
        {
            moveHorizontal = -1f; // Gauche
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveHorizontal = 1f; // Droite
        }

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (movement != Vector3.zero)
        {
            MoveCharacter(movement);
            RotateCharacter(movement);
        }
    }

    void MoveCharacter(Vector3 direction)
    {
        // D�placement de l'objet en fonction de la direction et de la vitesse
        rb.MovePosition(transform.position + direction * moveSpeed * Time.deltaTime);
    }

    void RotateCharacter(Vector3 direction)
    {
        // Calcul de la nouvelle direction � regarder
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        // Interpolation pour lisser la rotation
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
