using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public bool isGameOver;
    Vector3 offset;
    GameObject player;
    float speed;

    void Start()
    {
        isGameOver = false;
        player = GameObject.Find("Player");
        speed = 25f;
        offset = transform.position - player.transform.position;
    }

    private void FixedUpdate()
    {
        if (isGameOver) return;
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, speed * Time.deltaTime);
    }
}
