using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearSceneController : MonoBehaviour
{
    public void RetryGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}