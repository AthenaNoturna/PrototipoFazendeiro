using UnityEngine;

public class PizzaPickup : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.up * 100 * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController1 player = other.GetComponent<PlayerController1>();

            if (player != null)
            {
                player.pizzaCount = Mathf.Min(player.pizzaCount + 1, player.maxPizza);

                FindFirstObjectByType<UIManager>().UpdatePizzaUI(player.pizzaCount);
            }

            Destroy(gameObject);
        }
    }
}