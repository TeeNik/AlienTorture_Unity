using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteractive : Interactive
{
    [SerializeField] private SpriteRenderer _sr;
    private readonly Color _selectedColor = new Color(1,1,1,0.9f);
    

    public override void Select()
    {
        _sr.color = _selectedColor;
    }

    public override void Deselect()
    {
        _sr.color = Color.white;
    }

    public override void Execute(Interactive obj)
    {
    }
}
