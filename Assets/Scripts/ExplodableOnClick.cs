using UnityEngine;

[RequireComponent(typeof(Explodable))]
public class ExplodeOnClick : MonoBehaviour
{
    public Explodable _explodable;

    public void Start()
    {
        _explodable = GetComponent<Explodable>();
        if (_explodable == null)
        {
            Debug.LogError("Explodable component not found!");
        }
    }

    public void OnMouseDown()
    {
        if (_explodable != null)
        {
            _explodable.Explode();
            ExplosionForce ef = GameObject.FindObjectOfType<ExplosionForce>();
            if (ef != null)
            {
                ef.doExplosion(transform.position);
            }
            else
            {
                Debug.LogError("ExplosionForce component not found!");
            }
        }
    }
}


