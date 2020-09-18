using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    private Transform _transform;
    public GameObject target;
    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        var x = target.transform.position.x;
        var y = _transform.position.y;
        var z = _transform.position.z;
        _transform.position = new Vector3(x + 1, y, z);
    }
}
