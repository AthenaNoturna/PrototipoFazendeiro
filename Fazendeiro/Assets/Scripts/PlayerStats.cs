using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int life = 3;

    public GameObject[] hearts; 

    public void TakeDamage()
    {
        life--;

        UpdateHearts();

        if (life <= 0)
        {
            GameOver();
        }
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < life)
            {
                hearts[i].SetActive(true);
            }
            else
            {
                hearts[i].SetActive(false);
            }
        }
    }

    void GameOver()
    {
        Debug.Log("Morreu");
        FindFirstObjectByType<MenuPrincipal>().GameOver();
    }
}