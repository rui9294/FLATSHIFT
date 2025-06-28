using UnityEngine;

public class MelodyDotState : MonoBehaviour
{
    [SerializeField] private bool isPassable = false;

    public bool IsPassable()
    {
        return isPassable;
    }

    public void SetPassable(bool value)
    {
        isPassable = value;
    }
}
