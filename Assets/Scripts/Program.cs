using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Program : MonoBehaviour
{
    string[] _test = {"a","b"};

    private void Start()
    {
        MainTest(_test);
    }

    static public void MainTest(string[] args)
    {
        //値を受け取るクラスを３つ作成
        Observer observerA = new Observer("Aさん");
        Observer observerB = new Observer("Bさん");
        Observer observerC = new Observer("Cさん");

        //値を発行するクラスを作成
        Observable observable = new Observable();

        //３つのObserverが、自分自身を発行先として登録する（=購読）
        IDisposable disposableA = observable.Subscribe(observerA);
        IDisposable disposableB = observable.Subscribe(observerB);
        IDisposable disposableC = observable.Subscribe(observerC);
        Debug.Log("Aさん〜Cさんが値を購読しました");

        Debug.Log("値を発行させます");
        //Observableに値を発行させる
        observable.SendNotice();

        Debug.Log("Aさんが購読解除します");
        //Aさんが購読解除する
        disposableA.Dispose();

        Debug.Log("値を発行させます");
        //再び値を発行させる
        observable.SendNotice();

        Debug.Log("Bさんが購読解除します");
        //Bさんが購読解除する
        disposableB.Dispose();

        Debug.Log("値を発行させます");
        //再び値を発行させる
        observable.SendNotice();

        Console.ReadKey();
    }
}
