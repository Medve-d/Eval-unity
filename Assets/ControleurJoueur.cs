using UnityEngine;

public class ControleurJoueur : MonoBehaviour
{
    public float vitesse = 7f;
    public Transform cam; // Référence à la transform de la caméra
    private Rigidbody rb;
    public GameManager gameManager;
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        // Récupère les entrées du clavier
        float deplacementHorizontal = Input.GetAxis("Horizontal");
        float deplacementVertical = Input.GetAxis("Vertical");

        // Calcule la direction relative à la caméra
        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;
        camForward.y = 0; // On ne veut pas que le joueur s'envole ou s'enfonce
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        // Crée le vecteur de mouvement final
        Vector3 mouvement = (camForward * deplacementVertical + camRight * deplacementHorizontal).normalized;

        // Met à jour l'animation
        if (animator != null)
        {
            // On utilise la magnitude des inputs bruts pour l'animation
            animator.SetFloat("Speed", new Vector2(deplacementHorizontal, deplacementVertical).magnitude);
        }

        // Applique le mouvement de déplacement
        rb.MovePosition(transform.position + mouvement * vitesse * Time.fixedDeltaTime);

        // Applique la rotation pour que le joueur regarde dans la direction du mouvement
        if (mouvement != Vector3.zero)
        {
            Quaternion nouvelleRotation = Quaternion.LookRotation(mouvement);
            rb.MoveRotation(nouvelleRotation);
        }
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