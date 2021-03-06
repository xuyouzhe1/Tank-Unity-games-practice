using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreation : MonoBehaviour
{
    public GameObject[] item;//用于实例化预制体的数组，装饰初始化地图所需的克隆体
    //0，基地；1，墙；2，障碍物；3，出生效果；4，河流；5，草地；6，空气墙

    private List<Vector3> itemPositionList = new List<Vector3>();

    private void Awake()
    {
        //实例化过程
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
        //实例化地图
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
        //一种简单的随机地图方案：不产生-10，10两列，-8，8两行的位置
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

    //用来判断随机到的位置是否已被占用的方法
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

