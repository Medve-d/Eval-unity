using UnityEngine;

public class ControleurJoueur : MonoBehaviour
{
    public float vitesse = 7f;
    private Rigidbody rb;
    public GameManager gameManager;

    public Animator animator; // R�f�rence � l'Animator

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>(); // On r�cup�re le composant Animator
    }

    void FixedUpdate()
    {
        float deplacementHorizontal = Input.GetAxis("Horizontal");
        float deplacementVertical = Input.GetAxis("Vertical");
        Vector3 mouvement = new Vector3(deplacementHorizontal, 0.0f, deplacementVertical);

        // --- LIGNE CL� ---
        // On envoie la "longueur" du vecteur de mouvement (la vitesse)
        // au param�tre "Speed" de notre Animator.
        animator.SetFloat("Speed", mouvement.magnitude);

        // On applique le mouvement
        rb.MovePosition(transform.position + mouvement * vitesse * Time.fixedDeltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            gameManager.CollecterObjet();
            Destroy(other.gameObject);
        }
    }
}