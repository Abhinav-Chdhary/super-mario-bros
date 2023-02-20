using UnityEngine;

public class SideScrolling : MonoBehaviour
{
    private Transform player;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void LateUpdate()
    {
        Vector3 cameraPosition = transform.position;
        cameraPosition.x = Mathf.Max(player.position.x, cameraPosition.x);
        transform.position = cameraPosition;

    }
}
