using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Ԥ������ֵ
    public float moveSpeed = 3;
    private Vector3 BulletEulerAngles;
    private float timeVal;//��ʱ��
    private float defendTimeVal = 3;
    private bool isDefended = false;
    private float timeValChangeDirection=2;//AI�ı䷽���ʱ��
    private float v=-1, h;

    private SpriteRenderer sr;
    public Sprite[] tankSprite;
    public GameObject bulletPrefab;
    public GameObject explosionPrefab;
    // Start is called before the first frame update
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (timeVal >= 1.0f)
        {
            Attack();
        }
        else
        {
            timeVal += Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Attack()//tank�Ĺ�������
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.eulerAngles + BulletEulerAngles));
        timeVal = 0;
    }

    private void Move()//tank���ƶ�����
    {
        if (timeValChangeDirection >= 3.0f)
        {
            int num = Random.Range(0, 8);
            if (num > 5)
            {
                v = -1;
                h = 0;
            }
            else if (num == 0)
            {
                v = 1;
                h = 0;
            }
            else if (num >= 0 && num <= 2)
            {
                v = 0;
                h = 1;
            }
            else if (num >= 3 && num <= 4)
            {
                v = 0;
                h = -1;
            }
            timeValChangeDirection = 0;
        }
        else
        {
            timeValChangeDirection += Time.fixedDeltaTime;
        }

        transform.Translate(Vector3.right * h * moveSpeed * Time.deltaTime, Space.World);
        //Time.deltaTimeʹ���������ʹ�����Ϸ֡���ʶ���,Space.World��ʹ����������������ƶ�
        if (h < 0)
        {
            sr.sprite = tankSprite[3];
            BulletEulerAngles = new Vector3(0, 0, 90);
        }
        else if (h > 0)
        {

            sr.sprite = tankSprite[1];
            BulletEulerAngles = new Vector3(0, 0, -90);
        }

        if (h != 0)
        {
            return;
        }

        transform.Translate(Vector3.up * v * moveSpeed * Time.deltaTime, Space.World);
        if (v < 0)
        {
            sr.sprite = tankSprite[2];
            BulletEulerAngles = new Vector3(0, 0, -180);
        }
        else if (v > 0)
        {

            sr.sprite = tankSprite[0];
            BulletEulerAngles = new Vector3(0, 0, 0);
        }
    }
    private void Die()
    {
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        //������ը��Ч������
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            timeValChangeDirection = 3.0f;
        }
        if (collision.gameObject.tag == "Wall")
        {
            timeValChangeDirection = 3.0f;
        }
        if (collision.gameObject.tag == "Barriar")
        {
            timeValChangeDirection = 3.0f;
        }
        if (collision.gameObject.tag == "river")
        {
            timeValChangeDirection = 3.0f;
        }
    }
}
