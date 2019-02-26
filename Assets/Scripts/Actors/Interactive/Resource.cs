using UnityEngine;

public class Resource : Interactive
{
    public Material Material;
    public Transform SpawnPoint;

    private float _progress;
    private bool _isNeedReload;

    public ProgressBar ProgressBar;

    public override bool IsContinuous
    {
        get => true;
        set {}
    }

    public override void Process(Interactive obj)
    {
        if (_progress < 1)
        {
            ProgressBar.SetVisible(true);
            _progress += .1f;
            ProgressBar.SetValue(_progress);
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
                    Instantiate(Material, SpawnPoint);
                }
                ProgressBar.SetVisible(false);
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
