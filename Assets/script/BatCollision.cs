using UnityEngine;

public class BatCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assurez-vous que Big Vegas a le tag "Player"
        {
            Debug.Log("Collision avec Big Vegas");
            HealthManager healthManager = FindObjectOfType<HealthManager>();

            if (healthManager != null)
            {
                healthManager.TakeDamage(); // Réduit la vie
            }
        }
    }
}
