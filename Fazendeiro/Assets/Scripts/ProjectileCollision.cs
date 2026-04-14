using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
            ScoreManager.instance.AddScore(1);

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}