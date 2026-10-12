using UnityEngine;

public class FollowPlayer : MonoBehaviour
{   
    public GameObject player;
    private Vector3 offset = new Vector3(0,4,1);

    void LateUpdate()
    {
       transform.position = player.transform.position + player.transform.rotation * offset; 
       Vector3 targetPosition =transform.position + player.transform.forward;
       transform.LookAt(targetPosition);
    }
}
