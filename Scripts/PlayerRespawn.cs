using System.Collections;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private Transform startPoint;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip respawnSound;
    [SerializeField] private AudioClip ImpactSound;

    private Rigidbody rb;
    private bool isRespawning = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Respawn()
    {
        if (isRespawning)
        {
            return;
        }

        StartCoroutine(RespawnSequence());
    }

    private IEnumerator RespawnSequence()
    {
        isRespawning = true;

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        audioSource.PlayOneShot(ImpactSound);

        yield return new WaitForSeconds(0.15f);

        rb.position = startPoint.position;
        rb.rotation = startPoint.rotation;

        audioSource.PlayOneShot(respawnSound);

        isRespawning = false;
    }
}