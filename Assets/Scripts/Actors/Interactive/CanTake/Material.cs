﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialData
{
    public string Type;
    public string StateName;
    public string SpriteName;
    public string FabricType;
}

public class Material : CanTake
{
    private List<MaterialData> _data;
    private int _state;

    public MaterialData Data => _data[_state];
    public override string Type => Data.Type;

    public void Init(List<MaterialData> data)
    {
        _data = data;
    }

    public void Upgrade()
    {
        ++_state;
        Assert.Inv(_state <= _data.Count, "Illigal material state");
    }

    public override void Process(Interactive hands)
    {
        print("Hands");
        //base.Execute(hands);
        hands.Process(this);
    }
}
