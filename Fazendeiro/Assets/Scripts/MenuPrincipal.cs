using UnityEngine;
using UnityEngine.SceneManagement;

// UnityEngine: biblioteca básica com tudo que o Unity usa (componentes, GameObject, MonoBehaviour, etc).
// UnityEngine.SceneManagement: permite carregar, trocar e manipular cenas (SceneManager.LoadScene).

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] private GameObject PainelMenuInicial;
    [SerializeField] private GameObject PainelOpcoes;
    [SerializeField] private GameObject PainelConfirmarSaida;
    [SerializeField] private GameObject PainelPausa;
    public void Jogar()
    {
        SceneManager.LoadScene("Jogar");
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void Victory()
    {
        SceneManager.LoadScene("Victory");
    }
      public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void AbrirOpcoes()
    {
        PainelMenuInicial.SetActive(false);
        PainelOpcoes.SetActive(true);
    }
    public void AbrirPause()
    {
        PainelPausa.SetActive(true);
    }
    public void FecharOpcoes()
    {
        PainelOpcoes.SetActive(false);
        PainelMenuInicial.SetActive(true);
       
    }

     public void SairDoJogo()
    {

        PainelConfirmarSaida.SetActive(true);
        PainelMenuInicial.SetActive(false);
    }

    public void ConfirmarSaida()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    public void CancelarSaida()
    {
    
        PainelConfirmarSaida.SetActive(false);
        PainelMenuInicial.SetActive(true);
    }
}
