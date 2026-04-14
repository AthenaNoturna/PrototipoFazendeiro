using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Animal"))
    {
        PlayerStats player = GetComponent<PlayerStats>();
        PlayerController1 controller = GetComponent<PlayerController1>();

        if (player != null && controller != null)
        {
            if (!controller.IsGhost())
            {
                player.TakeDamage();
            }
        }

        Destroy(other.gameObject);
    }
}
}
