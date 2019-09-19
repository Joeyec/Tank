using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreation : MonoBehaviour {
    //0heart1wall2barriar3born4river5grass6airbarriar
    public GameObject[] item;
    private List<Vector3> itemPostionList = new List<Vector3>();
    private void Awake()
    {
        CreateItem(item[0], new Vector3(0, -7, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(-1, -7, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(1, -7, 0), Quaternion.identity);
        for(int i = -1; i < 2; i++)
        {
            CreateItem(item[1], new Vector3(i, -6, 0), Quaternion.identity);
        }
        //Instance Airbarriar
        for (int i = -11; i < 12; i++)
        {
            CreateItem(item[6],new Vector3(i,10,0),Quaternion.identity);
        }
        for (int i = -11; i < 12; i++)
        {
            CreateItem(item[6], new Vector3(i, -8, 0), Quaternion.identity);
        }
        for (int i = -6; i < 10; i++)
        {
            CreateItem(item[6], new Vector3(-11, i, 0), Quaternion.identity);
        }
        for (int i = -6; i < 10; i++)
        {
            CreateItem(item[6], new Vector3(11, i, 0), Quaternion.identity);
        }
        //Instance Player
        GameObject go = Instantiate(item[0], new Vector3(-2, -7, 0), Quaternion.identity);
        go.GetComponent<Born>().createPlayer = true;
        //Instance Enemy
        CreateItem(item[3], new Vector3(-10, 9, 0), Quaternion.identity);
        CreateItem(item[3], new Vector3(0, 9, 0), Quaternion.identity);
        CreateItem(item[3], new Vector3(10, 9, 0), Quaternion.identity);
        //Instance Map
        for (int i = 0; i < 60; i++)
        {
            CreateItem(item[1], CreatRandomPosition(), Quaternion.identity);
        }
        for (int i = 0; i < 20; i++)
        {
            CreateItem(item[2], CreatRandomPosition(), Quaternion.identity);
        }
        for (int i = 0; i < 20; i++)
        {
            CreateItem(item[4], CreatRandomPosition(), Quaternion.identity);
        }
        for(int i = 0; i < 20; i++)
        {
            CreateItem(item[5], CreatRandomPosition(), Quaternion.identity);
        }
    }
    private void CreateItem(GameObject createGameObject,Vector3 createPosition,Quaternion createRotation)
    {
        GameObject itemGo = Instantiate(createGameObject, createPosition, createRotation);
        itemGo.transform.SetParent(gameObject.transform);
        itemPostionList.Add(createPosition);
    }
    private Vector3 CreatRandomPosition()
    {
        while (true)
        {
            Vector3 createPosition = new Vector3(Random.Range(-9, 10), Random.Range(-6, 9), 0);
            if(!HasThePosition(createPosition))
            {
                return createPosition;
            }
        }
    }
    private bool HasThePosition(Vector3 createPos)
    {
        for (int i = 0; i < itemPostionList.Count; i++)
        {
            if (createPos == itemPostionList[i])
            {
                return true;
            }
        }
        return false;
    }
   
}
