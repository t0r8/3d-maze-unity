using UnityEngine;

public class ItemController : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField] private AudioClip itemGetSound;
    [SerializeField] private GameObject itemGetParticlePrefab;
    [SerializeField] private float particleLifetime = 1.0f;


    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.CollectItem();

            AudioSource.PlayClipAtPoint(itemGetSound, transform.position);

            GameObject particle = Instantiate(
                itemGetParticlePrefab,
                transform.position,
                Quaternion.identity
            );

            Destroy(particle, particleLifetime);

            gameObject.SetActive(false);
        }
    }
}
