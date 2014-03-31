using UnityEngine;
using System.Collections;

public class IntVector3
{
    public readonly Vector3 vector3;

    public IntVector3 (float x, float y, float z) {
        this.vector3 = new Vector3(Mathf.RoundToInt(x), Mathf.RoundToInt(y), Mathf.RoundToInt(z));
    }

    public IntVector3 (Vector3 vector3)
    : this(vector3.x, vector3.y, vector3.z) {}

    public override bool Equals (object obj)
    {
        return vector3.Equals (obj);
    }

    public override int GetHashCode ()
    {
        return base.GetHashCode ();
    }
}

