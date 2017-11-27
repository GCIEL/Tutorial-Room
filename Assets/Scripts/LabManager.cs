using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabManager : MonoBehaviour {

    public GameObject leftController;
    public GameObject rightController;
    private int _inactiveSphereCount;
    public int inactiveSphereCount
    {
        get
        {
            return _inactiveSphereCount;
        }
        set
        {
            _inactiveSphereCount += value;
            if(_inactiveSphereCount == 0)
            {
                Debug.Log("All spheres activated");
            }
        }
    }

	// Use this for initialization
	void Start () {
        _inactiveSphereCount = 3;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
