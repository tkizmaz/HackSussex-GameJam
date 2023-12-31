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
    public SkillType skillType;
    private float horizontal;
    [SerializeField]
    private Transform spawnPoint;
    private bool isFacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        characterBody = this.GetComponent<Rigidbody2D>();
        horizontal = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        CheckControls();
    }

    void CheckControls()
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        horizontal = Input.GetAxisRaw("Horizontal");
        characterBody.velocity = new Vector2(horizontal * moveSpeed, characterBody.velocity.y);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                characterBody.velocity = Vector2.up * jump;
                onFloor = false;
            }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Attack();
            animator.SetTrigger("AttackTrigger");
        }
        Flip();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            onFloor = true;
        }
    }

    private void Attack()
    {
        skillType.SpawnPrefabEffect(spawnPoint.position, isFacingRight);
    }

    private void Flip()
    {
        if(isFacingRight && horizontal < 0 || !isFacingRight && horizontal > 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;

        }
    }
}
