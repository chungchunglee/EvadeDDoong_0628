using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Behavior : MonoBehaviour
{
    public GameObject prefabsDDong;
    GameObject[] objectPull;
    [SerializeField]
    int IndexNum=0;
    int IndexDefine = 20;
    [SerializeField]
    float timeSpawnMin = 1.25f;
    [SerializeField]
    float timeSpawnMax = 2.5f;
    float timeSpawn;
    float lastSpawnTime;

    Vector2 PoolPosition = new Vector2(0, -8);
    float yPos = 4f;
    float xMax = 7;
    float xMin = -7;


    private void Awake()
    {
        //Debug.Log("Spawner Awake");
        objectPull = new GameObject[IndexDefine];
        for(int i = 0; i<IndexDefine;i++)
        {
            objectPull[i] = Instantiate(prefabsDDong, PoolPosition, Quaternion.identity);
        }
        lastSpawnTime = 0f;
        timeSpawn = 0f;
        
    }


    public void Update()
    {

        if(GameManager.instance.isGameover)
        {
            return;
        }

        
        if (Time.time>=lastSpawnTime+timeSpawn)
        {
            int spawnNum=Random.Range(1,3);
            // 생성 시간 구현
            lastSpawnTime = Time.time;
            timeSpawn = Random.Range(timeSpawnMin, timeSpawnMax);
            //중력 초기화
            /*
            //1차구현 - 1개씩
                //Debug.Log("Spawn Index :" + IndexNum);
                objectPull[IndexNum].SetActive(false);
                objectPull[IndexNum].SetActive(true);
                //위치 지정
                float xPos = Random.Range(xMin, xMax);
                objectPull[IndexNum].transform.position = new Vector2(xPos,yPos);
                //Debug.Log("Spawn Index + Position :" + IndexNum + objectPull[IndexNum].transform.position);
            IndexNum++;
            

            if(IndexNum>=IndexDefine)
            {
                IndexNum = 0;
            }
            */
            if (IndexNum + spawnNum >= IndexDefine)
            {
                //Debug.Log("Index Reset  " + IndexNum + IndexDefine);
                IndexNum = 0;
            }
            for (int i = IndexNum; i <= IndexNum+spawnNum; i++)
            {
                objectPull[i].SetActive(false);
                objectPull[i].SetActive(true);
                //위치 지정
                float xPos = Random.Range(xMin, xMax);
                objectPull[i].transform.position = new Vector2(xPos, yPos);
               // //Debug.Log("Index Num" +  IndexNum+" |"  +"Spawn Index :" + i );
            }
            //Debug.Log("Spawn Exit Num : " + IndexNum);
            IndexNum += spawnNum+1;
            //Debug.Log("Spawn  Num : " + IndexNum);
        }

    }



}
