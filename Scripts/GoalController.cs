using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalController : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clearSound;
    [SerializeField] private float sceneChangeDelay = 1.0f;

    private bool isClearing = false;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameManager.IsAllItemsCollected())
            {
                if (!isClearing)
                {
                    StartCoroutine(ClearSequence());
                }
            }
            else
            {
                gameManager.ShowMessage("Collect all items!");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
           gameManager.ShowMessage("");
        }
    }

    private IEnumerator ClearSequence()
    {
        isClearing = true;

        if (audioSource != null && clearSound != null)
        {
            audioSource.PlayOneShot(clearSound);
        }

        yield return new WaitForSeconds(sceneChangeDelay);

        SceneManager.LoadScene("ClearScene");
    }
}