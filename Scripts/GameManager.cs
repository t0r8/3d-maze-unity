using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int collectedItemCount = 0;

    public int totalItemCount = 6;

    public TMP_Text itemCountText;

    public TMP_Text messageText;

    void Start()
    {
        UpdateItemCountText();

        messageText.text = "";
    }

    public void CollectItem()
    {
        collectedItemCount++;

        UpdateItemCountText();
    }

    private void UpdateItemCountText()
    {
        itemCountText.text =
            "Items: " + collectedItemCount
            + " / " + totalItemCount;
    }

    public bool IsAllItemsCollected()
    {
        return collectedItemCount >= totalItemCount;
    }

    public void ShowMessage(string message)
    {
        messageText.text = message;
    }
}