using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpin : MonoBehaviour
{
    // public Vector3 RotateAmount;
    public Vector3 axis = new Vector3( 0, 1, 0 );
    public float degrees = 90f;
    public float timespan = 1f;
    private float _rotated = 0;
    private Vector3 _rotationVector;


    // Start is called before the first frame update
    void Start()
    {
        axis.Normalize();
        _rotationVector = axis * degrees;
        
    }

    // Update is called once per frame
    void Update()
    {
     // transform.Rotate(RotateAmount);
        _rotated += degrees * (Time.deltaTime / timespan);
        if ( degrees > _rotated ){
	_rotated = 0;
            transform.Rotate( _rotationVector * (Time.deltaTime / timespan) );
	}
    }
}
