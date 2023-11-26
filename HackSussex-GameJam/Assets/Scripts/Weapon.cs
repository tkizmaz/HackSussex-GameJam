using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private int damage;

    public int Damage { get; set; }
    private int weaponTag;

    private void Start()
    {
        damage = 50;
    }

    public void SetWeaponTag(int tag)
    {
        Debug.Log(tag);
        this.weaponTag = tag;
        Debug.Log(this.weaponTag);
    }

    public void Shoot(int tag, Vector3 spawnPosition, int direction)
    {
        Debug.Log(this.weaponTag);
        GameObject skill = Instantiate(GameManager.instance.skills[tag], spawnPosition, Quaternion.identity);
        skill.GetComponent<Rigidbody2D>().velocity = (Vector2.right * direction) * 3.5f;
        skill.GetComponent<Weapon>().weaponTag = tag;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(this.weaponTag);
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(this.weaponTag, damage);
            Destroy(this.gameObject);
        }
    }
}
