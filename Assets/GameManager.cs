using UnityEngine;
using TMPro; // Important pour pouvoir manipuler du texte

public class GameManager : MonoBehaviour
{
    [Header("Références UI")]
    public TextMeshProUGUI texteChrono;
    public TextMeshProUGUI texteScore;
    public GestionnaireUI gestionnaireUI;

    [Header("Paramètres du Jeu")]
    public float tempsInitial = 45f;

    private float tempsRestant;
    private int score = 0;
    private int totalCollectibles;
    private bool jeuEnCours = false;

    // Cette fonction sera appelée par le GestionnaireUI pour démarrer la partie
    public void DemarrerPartie()
    {
        // Initialisation des variables
        tempsRestant = tempsInitial;
        score = 0;
        jeuEnCours = true;

        // Compte combien d'objets à ramasser sont dans la scène
        totalCollectibles = GameObject.FindGameObjectsWithTag("Collectible").Length;

        MettreAJourTexteScore();
    }

    void Update()
    {
        if (jeuEnCours)
        {
            // Gère le chronomètre
            tempsRestant -= Time.deltaTime;
            texteChrono.text = "Temps : " + Mathf.Max(0, Mathf.RoundToInt(tempsRestant));

            // Condition de défaite
            if (tempsRestant <= 0)
            {
                Perdu();
            }
        }
    }

    // Cette fonction sera appelée par le joueur quand il touche un objet
    public void CollecterObjet()
    {
        if (!jeuEnCours) return;

        score++;
        MettreAJourTexteScore();

        // Condition de victoire
        if (score >= totalCollectibles)
        {
            Gagne();
        }
    }

    void MettreAJourTexteScore()
    {
        texteScore.text = "Score : " + score + " / " + totalCollectibles;
    }

    void Gagne()
    {
        jeuEnCours = false;
        gestionnaireUI.AfficherVictoire();
    }

    void Perdu()
    {
        jeuEnCours = false;
        gestionnaireUI.AfficherGameOver();
    }
}