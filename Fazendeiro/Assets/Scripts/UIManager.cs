using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI pizzaText;

    public void UpdatePizzaUI(int value)
    {
        pizzaText.text = "PIZZAS: " + value;
    }
}