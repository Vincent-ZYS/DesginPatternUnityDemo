using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAttr : ICharacterAttr
{
    public SoldierAttr(IAttrStrategy strategy, string name, int maxHP, float moveSpeed, string iconSpriteName, string prefabName) 
        : base(strategy, name, maxHP, moveSpeed, iconSpriteName, prefabName) { }
}
