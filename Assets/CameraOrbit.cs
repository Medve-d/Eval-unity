using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform target; // Le joueur que la caméra doit suivre
    public float distance = 5.0f;
    public float sensitivity = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 20.0f; // Angle initial vers le bas

    void LateUpdate()
    {
        if (target)
        {
            // Lit les mouvements de la souris
            yaw += Input.GetAxis("Mouse X") * sensitivity;
            pitch -= Input.GetAxis("Mouse Y") * sensitivity;

            // Bloque l'angle vertical pour ne pas passer sous le personnage
            pitch = Mathf.Clamp(pitch, 5f, 80f);

            // Calcule la rotation et la position de la caméra
            Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
            Vector3 position = target.position - (rotation * Vector3.forward * distance);

            transform.position = position;
            transform.LookAt(target.position);
        }
    }
}