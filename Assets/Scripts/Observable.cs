using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ʒm�𔭍s����N���X
/// </summary>
public class Observable : IObservable<int>
{
    /// <summary>�ǂ��ꂽIObserver<int>�̃��X�g</summary>
    List<IObserver<int>> _observers = new List<IObserver<int>>();

    public IDisposable Subscribe(IObserver<int> observer)
    {
        if(!_observers.Contains(observer))
        {
            _observers.Add(observer);
        }
        //�w�ǉ����p�̃N���X��IDisposable
        return new Unsubscriber(_observers, observer);
    }

    public void SendNotice()
    {
        //���ׂĂ̔��s��ɑ΂���1,2,3�𔭍s����
        foreach(var observer in _observers)
        {
            observer.OnNext(1);
            observer.OnNext(2);
            observer.OnNext(3);
        }
    }


    /// <summary>�w�ǉ����p�����N���Xsummary>
    class Unsubscriber : IDisposable
    {
        /// <summary>���s�惊�X�g</summary>
        List<IObserver<int>> _observers;
        /// <summary>Dispose���ꂽ�Ƃ���Remove����IObserver��int��</summary>
        IObserver<int> _observer;

        public Unsubscriber(List<IObserver<int>> observers, IObserver<int> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            //Dispose���ꂽ�甭�s�惊�X�g����Ώۂ̔��s����폜����
            _observers.Remove(_observer);
        }
    }
}
