using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    [SerializeField]
    private int moveSpeed;
    [SerializeField]
    private int jump;
    private bool onFloor;
    private Rigidbody2D characterBody;
    // Start is called before the first frame update
    void Start()
    {
        characterBody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckControls();
    }

    void CheckControls()
    {
        if (onFloor)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                characterBody.velocity = new Vector2(moveSpeed, 0);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                characterBody.velocity = new Vector2(-moveSpeed, 0);
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                characterBody.velocity = Vector2.up * jump;
                onFloor = false;
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            onFloor = true;
        }
    }
}
