using UnityEngine;

public class DetectionAudio : MonoBehaviour
{
    public AudioSource enemyAudio;

    
    void OnTriggerEnter(Collider other)
    {
        // check if object is an enemy
        if (!other.CompareTag("Enemy"))
            return;

        // raycast to make sure no walls are blocking
        Vector3 direction = other.transform.position - transform.position;

        Ray ray = new Ray(transform.position, direction);
        RaycastHit raycastHit;

        if (Physics.Raycast(ray, out raycastHit))
        {
            if (raycastHit.collider.CompareTag("Enemy"))
            {
                enemyAudio.Play();
            }
        }
    }
}
