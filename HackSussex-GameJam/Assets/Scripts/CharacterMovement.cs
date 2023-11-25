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
    private int health = 100;
    private List<SkillType> skillInventory;


    [SerializeField]
    private List<SkillType> skills;
    // Start is called before the first frame update
    void Start()
    {
        skillInventory = new List<SkillType>();
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
        }
        Flip();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            onFloor = true;
        }

        else if(collision.gameObject.tag == "Fire")
        {
            if(skillInventory.Count < 2)
            {
                skillInventory.Add(skills[0]);
                Destroy(collision.gameObject);
            }
        }

        else if (collision.gameObject.tag == "Lightning")
        {
            if (skillInventory.Count < 2)
            {
                skillInventory.Add(skills[1]);
                Destroy(collision.gameObject);
            }
        }

        else if (collision.gameObject.tag == "Water")
        {
            if (skillInventory.Count < 2)
            {
                skillInventory.Add(skills[2]);
                Destroy(collision.gameObject);
            }
        }
    }

    private void Attack()
    {
        if(skillInventory.Count > 0)
        {
            animator.SetTrigger("AttackTrigger");
            skillInventory[0].SpawnPrefabEffect(spawnPoint.position, isFacingRight);
            skillInventory.RemoveAt(0);
        }
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
