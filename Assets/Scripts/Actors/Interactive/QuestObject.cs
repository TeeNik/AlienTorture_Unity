using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : Interactive
{
    private float _progress;
    private bool _isNeedReload;

    public override bool IsContinuous
    {
        get => true;
        set { }
    }

    public override void Process(Interactive obj)
    {
        if (_progress < 1)
        {
            _progress += .1f;
            print(_progress);
        }
        else
        {
            if (!_isNeedReload)
            {
                _progress = 0;
                var hands = obj as Hands;
                if (hands.IsEmpty)
                {
                }
                _isNeedReload = true;
            }
        }
    }

    public override void Leave(Interactive obj)
    {
        base.Leave(obj);
        _isNeedReload = false;
    }
}
