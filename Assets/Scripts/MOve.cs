using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOve : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;

    [SerializeField] private GameObject sprite;
    private int faceDir = 1;
    [SerializeField] private float jumpPower;
    // Start is called before the first frame update
    public void Movement(int direction, int jump)
    {
        if (faceDir != direction && direction != 0) {
            faceDir = direction;
            sprite.transform.Rotate(0, 180, 0);
        }
        rb.velocity = new Vector2(direction * speed, 0);
        rb.AddForce(new Vector2(0, jump * jumpPower), ForceMode2D.Impulse);
    }
}
