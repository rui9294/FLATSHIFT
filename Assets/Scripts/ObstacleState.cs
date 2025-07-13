using UnityEngine;

public class ObstacleState : MonoBehaviour
{
    [SerializeField] private bool isPassable = false;

    public bool IsPassable() => isPassable;

    public void SetPassable(bool value)
    {
        isPassable = value;
    }
}
