using UnityEngine;

public class PizzaSpawner : MonoBehaviour
{
    public GameObject pizzaPickup;
    public float spawnRangeX = 15f;
    public float spawnZ = 0f;

    void Start()
    {
        InvokeRepeating("SpawnPizza", 1f, 1f);
    }

    void SpawnPizza()
    {
       Vector3 pos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 1f, spawnZ);

        GameObject pizza = Instantiate(pizzaPickup, pos, Quaternion.identity);

        Destroy(pizza, 3f); 
    }
}