using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow))
            move.y += 1;
        if (Input.GetKey(KeyCode.DownArrow))
            move.y -= 1;
        if (Input.GetKey(KeyCode.LeftArrow))
            move.x -= 1;
        if (Input.GetKey(KeyCode.RightArrow))
            move.x += 1;

        transform.position += move * moveSpeed * Time.deltaTime;
    }
}
