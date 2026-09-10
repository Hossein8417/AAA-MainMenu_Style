using UnityEngine;

public class movement : MonoBehaviour
{
    private void Update()
    {
        MovementHandler();
    }
    private void MovementHandler()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        float speed = 5f;

        Vector3 playerPosition = new Vector3(horizontal, 0f, vertical);

        transform.position += playerPosition * speed * Time.deltaTime;
    }
}