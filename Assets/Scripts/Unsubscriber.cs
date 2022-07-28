using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class Unsubscriber : IDisposable
//{
//    /// <summary>発行先リスト</summary>
//    List<IObserver<int>> _observers;
//    /// <summary>DisposeされたときにRemoveするIObserver＜int＞</summary>
//    IObserver<int> _observer;

//    public Unsubscriber(List<IObserver<int>> observers,IObserver<int> observer)
//    {
//        _observers = observers;
//        _observer = observer;
//    }

//    public void Dispose()
//    {
//        //Disposeされたら発行先リストから対象の発行先を削除する
//        _observers.Remove(_observer);
//    }
//}