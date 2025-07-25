using UnityEngine;
using UnityEngine.SceneManagement; // Requis pour recharger la sc�ne

public class GestionnaireUI : MonoBehaviour
{
    [Header("Panneaux de l'interface")]
    public GameObject panelMenuPrincipal;
    public GameObject panelJeu;
    public GameObject panelCredits;
    public GameObject panelGameOver;
    public GameObject panelVictoire;

    [Header("R�f�rences aux autres scripts")]
    public GameManager gameManager; // R�f�rence vers le gestionnaire de jeu

    // Au d�marrage du jeu, on s'assure que seul le menu est visible.
    void Start()
    {
        AfficherMenuPrincipal();
    }

    // --- Fonctions pour afficher les panneaux ---

    public void AfficherMenuPrincipal()
    {
        // Active le bon panel et d�sactive tous les autres
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

        // Tr�s important : on dit au GameManager de d�marrer la partie !
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
        // La fa�on la plus simple de recommencer est de recharger la sc�ne
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitterApplication()
    {
        Debug.Log("Le jeu quitte !"); // Message pour le test dans l'�diteur
        Application.Quit();
    }
}