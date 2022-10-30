using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static float Random(this Vector2 vector)
    {
        return UnityEngine.Random.Range(vector.x, vector.y);
    }

    public static int Random(this Vector2Int vector)
    {
        return UnityEngine.Random.Range(vector.x, vector.y);
    }

    public static Vector2 Random(this Vector4 vector)
    {
        float x, y;
        x = new Vector2(vector.x, vector.y).Random();
        y = new Vector2(vector.z, vector.w).Random();
        return new Vector2(x, y);
    }

    public static Vector2 RandomVector2(this float num)
    {
        float x, y;
        x = UnityEngine.Random.Range(0, num);
        y = UnityEngine.Random.Range(0, num);

        return new Vector2(x, y);
    }
}
