using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreation : MonoBehaviour
{
    public GameObject[] item;//����ʵ����Ԥ��������飬װ�γ�ʼ����ͼ����Ŀ�¡��
    //0�����أ�1��ǽ��2���ϰ��3������Ч����4��������5���ݵأ�6������ǽ

    private List<Vector3> itemPositionList = new List<Vector3>();

    private void Awake()
    {
        //ʵ��������
        CreateItem(item[0], new Vector3(0, -8, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(0, -7, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(-1, -7, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(-1, -8, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(1, -7, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(1, -8, 0), Quaternion.identity);

        for (int i = -10; i <= 10; i++)
        {
            CreateItem(item[6], new Vector3(i, -9, 0), Quaternion.identity);
        }
        for (int i = -10; i <= 10; i++)
        {
            CreateItem(item[6], new Vector3(i, 9, 0), Quaternion.identity);
        }
        for (int j = -8; j <= 8; j++)
        {
            CreateItem(item[6], new Vector3(-11, j, 0), Quaternion.identity);
        }
        for (int j = -8; j <= 8; j++)
        {
            CreateItem(item[6], new Vector3(11, j, 0), Quaternion.identity);
        }
        //ʵ������ͼ
        for (int i = 0; i <= 50; i++)
        {
            CreateItem(item[1], CreateRandomPosition(), Quaternion.identity);
        }
        for (int i = 0; i <= 30; i++)
        {
            CreateItem(item[2], CreateRandomPosition(), Quaternion.identity);
        }
        for (int i = 0; i <= 15; i++)
        {
            CreateItem(item[4], CreateRandomPosition(), Quaternion.identity);
        }
        for (int i = 0; i <= 35; i++)
        {
            CreateItem(item[5], CreateRandomPosition(), Quaternion.identity);
        }

        GameObject go = Instantiate(item[3], new Vector3(-2, -8, 0), Quaternion.identity);
        go.GetComponent<Born>().creatPlayer = true;

        CreateItem(item[3], new Vector3(10, 8, 0), Quaternion.identity);
        CreateItem(item[3], new Vector3(0,8, 0), Quaternion.identity);
        CreateItem(item[3], new Vector3(-10, 8, 0), Quaternion.identity);

        InvokeRepeating("CreateEnemy", 15.0f, 15.0f);
    }

    private void CreateItem(GameObject createGameObject,Vector3 createPosition,Quaternion createRotation)
    {
        GameObject itemGo = Instantiate(createGameObject, createPosition, createRotation);
        itemGo.transform.SetParent(gameObject.transform);
        itemPositionList.Add(createPosition);
    }

    private Vector3 CreateRandomPosition()
    {
        //һ�ּ򵥵������ͼ������������-10��10���У�-8��8���е�λ��
        while (true)
        {
            Vector3 createPosition = new Vector3(Random.Range(-9, 10), Random.Range(-7, 8), 0);
            if (!HasThePosition(createPosition))
            {
                return createPosition;
                break;
            }
        }
    }

    //�����ж��������λ���Ƿ��ѱ�ռ�õķ���
    private bool HasThePosition(Vector3 createPos)
    {
        for (int i = 0; i < itemPositionList.Count; i++)
        {
            if (createPos == itemPositionList[i])
            {
                return true;
            }
        }
        return false;
    }
    private void CreateEnemy()
    {
        int num = Random.Range(0, 3);
        Vector3 EnemyPos = new Vector3();
        if (num == 0)
        {
            EnemyPos = new Vector3(-10, 8, 0);
        }
        else if (num == 1)
        {
            EnemyPos = new Vector3(0, 8, 0);
        }
        else
        {
            EnemyPos = new Vector3(10, 8, 0);
        }
        CreateItem(item[3], EnemyPos, Quaternion.identity);
    }
}

