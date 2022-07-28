using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 通知を発行するクラス
/// </summary>
public class Observable : IObservable<int>
{
    /// <summary>読されたIObserver<int>のリスト</summary>
    List<IObserver<int>> _observers = new List<IObserver<int>>();

    public IDisposable Subscribe(IObserver<int> observer)
    {
        if(!_observers.Contains(observer))
        {
            _observers.Add(observer);
        }
        //購読解除用のクラスをIDisposable
        return new Unsubscriber(_observers, observer);
    }

    public void SendNotice()
    {
        //すべての発行先に対して1,2,3を発行する
        foreach(var observer in _observers)
        {
            observer.OnNext(1);
            observer.OnNext(2);
            observer.OnNext(3);
        }
    }


    /// <summary>購読解除用内部クラスsummary>
    class Unsubscriber : IDisposable
    {
        /// <summary>発行先リスト</summary>
        List<IObserver<int>> _observers;
        /// <summary>DisposeされたときにRemoveするIObserver＜int＞</summary>
        IObserver<int> _observer;

        public Unsubscriber(List<IObserver<int>> observers, IObserver<int> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            //Disposeされたら発行先リストから対象の発行先を削除する
            _observers.Remove(_observer);
        }
    }
}
