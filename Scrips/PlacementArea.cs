using UnityEngine;

public class PlacementArea : MonoBehaviour
{
    public bool isBuildTower { set; get; }

    private void Awake()
    {
        isBuildTower = false;
    }
}

/*
 * File : PlacementArea.cs
 * Desc
 *  : 타워 배치가 가능한 PlacementArea 오브젝트에 부착
 */