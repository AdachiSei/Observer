using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 通知を受け取るクラス
/// </summary>
public class Observer : IObserver<int>
{
    string _name;

    public Observer(string name)
    {
        _name = name;
    }

    public void OnCompleted()
    {
        Debug.Log($"{_name}が通知の受け取りが完了しました");
    }

    public void OnError(Exception error)
    {
        Debug.Log($"{_name}が次のエラーを受信しました:{error.Message}");
    }

    public void OnNext(int value)
    {
        Debug.Log($"{_name}が{value}を受け取りました");
    }
}
