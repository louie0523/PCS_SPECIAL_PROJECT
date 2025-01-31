using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController characterController;
    public float speed = 2.0f;
    Animator animator;
    bool isWalk = false;
    public bool isAttackCheck = false;
    int hp = 2;
    bool isStop = false;

    public GameObject PrefabBullet;
    public Transform BulletPoint;
    public float BulletDelay = 1.0f;
    public float BulletTime = 0f;
    bool isBullet = false;


   

    void Start()
    {
        characterController = this.GetComponent<CharacterController>();
        animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        if(!isStop)
        {
            Walk();
            Attack();
            Rotation();
        }
    }

    void Walk()
    {
        isWalk = false;
        if (Input.GetKey(KeyCode.W))
        {
            characterController.Move(this.transform.forward * Time.deltaTime * speed);
            isWalk = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            characterController.Move(-this.transform.forward * Time.deltaTime * speed);
            isWalk = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            characterController.Move(-this.transform.right * Time.deltaTime * speed);
            isWalk = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            characterController.Move(this.transform.right * Time.deltaTime * speed);
            isWalk = true;
        }

        if (isWalk)
        {
            animator.SetBool("isWalk", true);
        }
        else
        {
            animator.SetBool("isWalk", false);
        }
    }

    void Attack()
    {
        if(isBullet)
        {
            BulletTime += Time.deltaTime;
            if(BulletTime >= BulletDelay)
            {
                isBullet = false;
                BulletTime = 0;
            }
        }
        if(!isBullet)
        {
            if(Input.GetKey(KeyCode.Mouse0))
            {
                isBullet = true;
                animator.SetTrigger("isGunAttack");
                Invoke("SpawnBullet", 0.2f);
            }
        }
        /**if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            isAttackCheck = true;
            animator.SetTrigger("isAttack");
            Invoke("StopAttackCheck", 0.5f);
        }**/
    }

    void SpawnBullet()
    {
        Instantiate(PrefabBullet, BulletPoint.position, this.transform.rotation);
    }

    void StopAttackCheck()
    {
        isAttackCheck = false;
    }

    void Rotation()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Plane plane = new Plane(Vector3.up, Vector3.zero);

        float rayLength;
        if (plane.Raycast(ray, out rayLength))
        {
            Vector3 mousePoint = ray.GetPoint(rayLength);

            this.transform.LookAt(new Vector3(mousePoint.x, this.transform.position.y, mousePoint.z));
        }
    }

    public void SetHp(int damage)
    {
        if(!isStop)
        {
            hp -= damage;
            if(hp <= 0)
            {
                hp = 0;
                Debug.Log("GameOver");
                animator.SetTrigger("Death");
                isStop = true;
            }
        }
    }
}
