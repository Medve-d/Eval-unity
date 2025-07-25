using UnityEngine;
using UnityEngine.SceneManagement; // Requis pour recharger la scène

public class GestionnaireUI : MonoBehaviour
{
    [Header("Panneaux de l'interface")]
    public GameObject panelMenuPrincipal;
    public GameObject panelJeu;
    public GameObject panelCredits;
    public GameObject panelGameOver;
    public GameObject panelVictoire;

    [Header("Références aux autres scripts")]
    public GameManager gameManager; // Référence vers le gestionnaire de jeu

    // Au démarrage du jeu, on s'assure que seul le menu est visible.
    void Start()
    {
        AfficherMenuPrincipal();
    }

    // --- Fonctions pour afficher les panneaux ---

    public void AfficherMenuPrincipal()
    {
        // Active le bon panel et désactive tous les autres
        panelMenuPrincipal.SetActive(true);
        panelJeu.SetActive(false);
        panelCredits.SetActive(false);
        panelGameOver.SetActive(false);
        panelVictoire.SetActive(false);
    }

    public void AfficherPanelJeu()
    {
        panelMenuPrincipal.SetActive(false);
        panelJeu.SetActive(true); // Active le panel avec le chrono et le score

        // Très important : on dit au GameManager de démarrer la partie !
        gameManager.DemarrerPartie();
    }

    public void AfficherPanelCredits()
    {
        panelMenuPrincipal.SetActive(false);
        panelCredits.SetActive(true);
    }

    public void AfficherGameOver()
    {
        panelJeu.SetActive(false);
        panelGameOver.SetActive(true);
    }

    public void AfficherVictoire()
    {
        panelJeu.SetActive(false);
        panelVictoire.SetActive(true);
    }

    // --- Fonctions pour les actions des boutons ---

    public void RecommencerPartie()
    {
        // La façon la plus simple de recommencer est de recharger la scène
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitterApplication()
    {
        Debug.Log("Le jeu quitte !"); // Message pour le test dans l'éditeur
        Application.Quit();
    }
}