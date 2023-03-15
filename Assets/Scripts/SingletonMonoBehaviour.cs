using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Singletonで宣言したいClassがTに入ります。
/// 例)SceneManagerとかSoundManagerとか
/// そうすると、シーンをまたいでいる最中でも音を鳴らすことができたりなど、利点があります。
/// また、他のクラスからInstanceを通してアクセスすることが可能です。
/// SoundManager.Instance.Hogehoge()みたいな感じで。
/// 制約としてMonoBehaviourを継承されます。
/// </summary>
/// <typeparam name="T"></typeparam>
public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    // 自分のインスタンスの変数
    private static T _instance;

    // 外から参照できる自分のインスタンス変数
    public static T Instance
    {
        get
        {
            // 外から参照された時に自分のインスタンスがなかったら
            if (_instance == null)
            {
                // いったん、Scene上に自分のインスタンスがないかを検索する
                _instance = (T)FindObjectOfType(typeof(T));

                // 無ければ、SetUpInstance()に進む
                if (_instance == null)
                {
                    SetupInstance();
                }
                else
                {
                    // あれば、ありましたよという表示をする
                    string typeName = typeof(T).Name;
                    
                    Debug.Log("[Singleton] " + typeName + " instance already created: " +
                        _instance.gameObject.name);
                }
            }

            return _instance;
        }
    }

    // シーン内だけのSingletonとする
    protected static bool isSceneinSingleton = false;

    public virtual void Awake()
    {
        RemoveDuplicates();
    }

    private static void SetupInstance()
    {
        // lazy instantiation
        _instance = (T)FindObjectOfType(typeof(T));

        // Instanceがなかったら
        if (_instance == null)
        {
            // Sceneに新しくGameObjectを作る
            GameObject gameObj = new GameObject();
            gameObj.name = typeof(T).Name;

            // 作られたGameObjectにAddComponentして、_instanceに返せるようにする
            _instance = gameObj.AddComponent<T>();
            // シーン内だけのSingletonとする
            if (!isSceneinSingleton)
            {
                // シーンをまたぐものに関しては、DontDestroyOnLoadをかけておく。
                // シーンをまたいでも破壊されない。
                DontDestroyOnLoad(gameObj);
            }
        }
    }

    private void RemoveDuplicates()
    {
        if (_instance == null)
        {
            _instance = this as T;
            // シーン内だけのSingletonとする
            if (!isSceneinSingleton)
            { 
                DontDestroyOnLoad(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
