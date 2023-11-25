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

    [SerializeField]
    private Animator animator;

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
            animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
            Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
            transform.position = transform.position + horizontal * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                characterBody.velocity = Vector2.up * jump;
                onFloor = false;
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                animator.SetTrigger("AttackTrigger");
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
