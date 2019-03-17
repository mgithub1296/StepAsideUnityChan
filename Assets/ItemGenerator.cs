using UnityEngine;
using System.Collections;

public class ItemGenerator : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject conePrefab;
    //スタート地点
    private int startPos = -160;

    //ゴール地点
    private int goalPos = 120;

    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    //現在のunityちゃんを入れる変数（自分）
    public GameObject unitychan;
    //アイテム生成目印（現在のunityちゃんがこのZ座標を越えた時、アイテムを生成するZ座標）（nextItemGenerationPositionZ）（自分）
    float unityZ;


    // Use this for initialization
    void Start()
    {
        //unitychan変数にunitychanの実体？インスペクタ？オブジェクト？を入れる（自分）
        this.unitychan = GameObject.Find("unitychan");

        //現在のunityちゃんのZ座標を更新（自分）
        //unityZ = unitychan.transform.position.z;（自分）
        //アイテム生成目印を設定（現在のunityちゃんの位置＋15M先を設定）（スタート開始後15M進むと50M先にアイテムが生成され始める）（自分）
        unityZ = unitychan.transform.position.z + 15f;
    }


    // Update is called once per frame
    void Update()
    {
        //アイテム生成そのままコピペ。startPosから生成されても、手前のモノはDestroyクラスで削除してくれる（自分）
        //if (unitychan.transform.position.z >= unityZ + 10)（自分）
        //現在のunityちゃんが、前回より15M進んだ時　かつ　ゴールより50M手前な場合（自分）
        if (unitychan.transform.position.z >= unityZ && unitychan.transform.position.z < goalPos - 50f)
        {
            //一定の距離ごとにアイテムを生成
            //for (int i = startPos; i < unitychan.transform.position.z + 50; i += 15)

            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab) as GameObject;
                    //cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);（自分）
                    //アイテム生成目印（unityちゃんが15M進んだ地点）から50M先にアイテムを生成する（自分）
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, unityZ + 50f);
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
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab) as GameObject;
                        //coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);（自分）
                        //アイテム生成目印（unityちゃんが15M進んだ地点）から50M先にアイテムを生成する（自分）
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, unityZ + 50f + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab) as GameObject;
                        //car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);（自分）
                        //アイテム生成目印（unityちゃんが15M進んだ地点）から50M先にアイテムを生成する（自分）
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, unityZ + 50f + offsetZ);
                    }
                }
            }
            //現在のunityちゃんのZ座標を更新（自分）
            //アイテム生成目印を15M先に更新（15M進むと50M先にアイテムが生成され始める）（自分）
            unityZ += 15;
        }
    }
}