using UnityEngine;
using System.Collections;

public class RopeNode : ManagerNode {

	public RopeNode() : base(GameObjectType.ROPE)
	{
		
	}

	// Use this for initialization
	void Start () {
		GameObject tObj = (GameObject)MonoBehaviour.Instantiate (Resources.Load ("Prefabs/RopeBuilder/RopeTree"), new Vector3 (), new Quaternion ());
		tObj.transform.parent = this.transform;
		myTree = tObj.GetComponent<TreeComponent>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
