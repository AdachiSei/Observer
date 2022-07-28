using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ʒm���󂯎��N���X
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
        Debug.Log($"{_name}���ʒm�̎󂯎�肪�������܂���");
    }

    public void OnError(Exception error)
    {
        Debug.Log($"{_name}�����̃G���[����M���܂���:{error.Message}");
    }

    public void OnNext(int value)
    {
        Debug.Log($"{_name}��{value}���󂯎��܂���");
    }
}
