using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpItem : ItemBase
{
    public int upperLevel = 1;

    private void Start()
    {
        // itemFunctionに処理を設定する
        itemFunctionHandler += LevelUpItemFunction;
    }

    public void LevelUpItemFunction(CharacterParameterBase characterParameterBase)
    {
        characterParameterBase.LevelUp(upperLevel);
        this.gameObject.SetActive(false);
    }
}
