using UnityEngine;

public class PassableCell : MonoBehaviour
{
    public enum Axis { None, Horizontal, Vertical, Both }
    public Axis allowedAxis = Axis.Both;
}
