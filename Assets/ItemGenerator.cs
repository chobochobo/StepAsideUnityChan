using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject conePrefab;
    //スタート地点
    private int startPos = 80;
    //ゴール地点
    private int goalPos = 360;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    //Unityちゃんのオブジェクト
    private GameObject unitychan;

    float itempos;

    //Unityちゃんのオブジェクト
    float space = 20;
    float startpos = 65;

    bool itemflag;
    // Use this for initialization
    void Start()
    {
        itempos = 0;
        itemflag = true;
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
        
    }

    // Update is called once per frame
    void Update()
    {
        //space間隔でアイテムを出す
        if (itempos < unitychan.transform.position.z+ space && itemflag && unitychan.transform.position.z + 65 <= goalPos-20)
        {

            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, unitychan.transform.position.z + startpos);
                    itempos = cone.transform.position.z - space;
                    itemflag = false;
                }
            }
            else
            {
                //レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くZ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置:30%車配置:10%何もなし
                    if (4 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, unitychan.transform.position.z + startpos);
                        itempos = coin.transform.position.z - space;
                        itemflag = false;

                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, unitychan.transform.position.z + startpos);
                        itempos = car.transform.position.z - space;
                        itemflag = false;
                    }
                }
            }
        }
        else if(itempos >= unitychan.transform.position.z + space)
        {
            itemflag = true;
        }
    }
}