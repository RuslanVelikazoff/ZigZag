using UnityEngine;

public class Player : MonoBehaviour
{
    bool hasGameFinished;

    void Start()
    {
        hasGameFinished = false;
    }

    void Update()
    {
        if(!Physics.Raycast(transform.position,Vector3.down,2f))
        {
            GetComponent<Rigidbody>().velocity = Vector3.down * 25f;
            if(!hasGameFinished)
            {
                hasGameFinished = true;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().isGameOver = true;
                GameManager.instance.GameOver();
                Destroy(gameObject, 5f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Diamond"))
        {
            AudioManager.instance.Play("Diamond");

            GameManager.instance.UpdateDiamond();
            Destroy(other.gameObject);
        }
    }
}
