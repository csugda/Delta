using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_script_thing : MonoBehaviour
{

    public float walkingSpeed, sprintMultiplier, restTime;
    private int maxStamina, stamina;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        stamina = maxStamina = (int)(restTime * 60);
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        float sprint = Input.GetAxis("Sprint");

        Vector2 direction = new Vector2(horiz, vert).normalized;
        float magnitude = walkingSpeed;

        if (sprint == 1 && stamina > 1 && direction.magnitude == 1)
        {
            stamina -= 2;

            if (stamina > 1)
                magnitude *= sprintMultiplier;
        }
        else if (stamina < maxStamina)
            stamina++;

        rb2d.AddForce(direction * magnitude);
    }
}
