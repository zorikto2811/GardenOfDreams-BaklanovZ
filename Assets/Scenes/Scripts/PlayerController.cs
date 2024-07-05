using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRB;
    public int speed;
    public float dirX, dirY;
    public Joystick joystick;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        dirX = joystick.Horizontal * speed;
        dirY = joystick.Vertical * speed;
    }

    private void FixedUpdate()
    {
        playerRB.velocity = new Vector2 (dirX, dirY);
    }
}
