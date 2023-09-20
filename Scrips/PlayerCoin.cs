using UnityEngine;

public class PlayerCoin : MonoBehaviour
{
    [SerializeField]
    private float currentCoin = 10;

    public float CurrentCoin
    {
        set => currentCoin = Mathf.Max(0, value);
        get => currentCoin;
    }
}

/*
 * File : PlayerCoin.cs
 * Desc
 *  : PlayerStatus 오브젝트에게 부착
 */