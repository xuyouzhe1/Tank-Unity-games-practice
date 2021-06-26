using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Ԥ������ֵ
    public float moveSpeed = 3;
    private Vector3 BulletEulerAngles;
    private float timeVal;
    private float defendTimeVal=3;
    private bool isDefended=true;
    private SpriteRenderer sr;
    public Sprite[] tankSprite;
    public GameObject bulletPrefab;
    public GameObject explosionPrefab;
    public GameObject defendEffectPrefab;
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

        if (isDefended)
        {
            defendEffectPrefab.SetActive(true);
            defendTimeVal -= Time.deltaTime;
            if (defendTimeVal <= 0)
            {
                isDefended = false;
            }
        }
        else
        {
            defendEffectPrefab.SetActive(false);
        }

        if (timeVal >= 0.4f)
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //�����ӵ��ǶȺ͵�ǰ̹�˵�ǰ��һ��
            Instantiate(bulletPrefab , transform.position, Quaternion.Euler(transform.eulerAngles+BulletEulerAngles));
            //��Ԫ�����͵�Quaternion.Euler
            timeVal = 0;
        }
    }

    private void Move()//tank���ƶ�����
    {
        //�̶�����֡ˢ�£���Ӧ�̶�ʱ��ˢ�£�
        float h = Input.GetAxisRaw("Horizontal");
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
        float v = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector3.up * v * moveSpeed * Time.deltaTime, Space.World);
        if (v < 0)
        {
            sr.sprite = tankSprite[2];
            BulletEulerAngles = new Vector3(0, 0,-180);
        }
        else if (v > 0)
        {

            sr.sprite = tankSprite[0];
            BulletEulerAngles = new Vector3(0, 0,0);
        }
    }
    private void Die()
    {
        if(isDefended==false)
        {
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            //������ը��Ч������
            Destroy(gameObject);
        }
    }
}
