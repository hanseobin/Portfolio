using UnityEngine;

public class Road : MonoBehaviour
{
    public bool isSummonKnight { set; get; }

    private void Awake()
    {
        isSummonKnight = false;
    }
}

/*
 * File : Road.cs
 * Desc
 *  : Road 오브젝트에게 부착
 */