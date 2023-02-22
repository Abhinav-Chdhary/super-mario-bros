using UnityEngine;

public static class Extensions
{
    private static LayerMask layerMask = LayerMask.GetMask("Default");
    public static bool Raycast(this Rigidbody2D _rigidbody, Vector2 direction)
    {
        if(_rigidbody.isKinematic)
        {
            return false;
        }
        float radius = 0.25f;
        float distance = 0.375f;

        RaycastHit2D hit = Physics2D.CircleCast(_rigidbody.position, radius, direction, distance, layerMask);
        return hit.collider!=null && hit.rigidbody!=_rigidbody;
    }
}
