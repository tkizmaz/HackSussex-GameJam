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
    private float horizontal;
    [SerializeField]
    private Transform spawnPoint;
    private bool isFacingRight = true;
    private int health = 100;
    private List<GameObject> skillInventory = new List<GameObject>(3);
    private int selectedSkillTag = 0;

    // Start is called before the first frame update
    void Start()
    {
        characterBody = this.GetComponent<Rigidbody2D>();
        horizontal = 1f;
        FillSkillInventory();
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

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedSkillTag = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedSkillTag = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedSkillTag = 2;
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

    private void FillSkillInventory()
    {    
        for(int i = 0; i < GameManager.instance.skills.Count; i++)
        {
            skillInventory.Add(GameManager.instance.skills[i]);
        }
    }

    private void Attack()
    {
        animator.SetTrigger("AttackTrigger");
        int direction = isFacingRight ? 1 : -1;
        skillInventory[selectedSkillTag].GetComponent<Weapon>().SetWeaponTag(selectedSkillTag);
        skillInventory[selectedSkillTag].GetComponent<Weapon>().Shoot(selectedSkillTag, spawnPoint.position, direction);
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
