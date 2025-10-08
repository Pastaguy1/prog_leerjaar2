using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // A/D of pijltjes
        float moveZ = Input.GetAxis("Vertical");   // W/S of pijltjes

        Vector3 move = new Vector3(moveX, 0, moveZ);
        transform.Translate(move * moveSpeed * Time.deltaTime);
    }
}
