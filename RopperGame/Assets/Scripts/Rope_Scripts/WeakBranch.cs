using UnityEngine;
using System.Collections;

public class WeakBranch : RopeBranch
{
	
	public WeakBranch () : base(RopeEnum.WEAK)
	{
		
	}
	// Use this for initialization
	void Start () 
	{
		//Create all strong Ropes here.
		for (int i =0; i<GameRules.GetMaxRopes(); i++) 
		{
			GameObject tObj = (GameObject) MonoBehaviour.Instantiate(Resources.Load ("Prefabs/RopeBuilder/WeakRope"), new Vector3 (), new Quaternion ());
			tObj.transform.parent = this.transform;
			WeakRope tRope = tObj.GetComponent<WeakRope>();
            //Move Upwards
            //tRope.transform.position = new Vector3(0.0f,2.0f*i,0.0f);
            //Deactivate the object
            tRope.gameObject.SetActive(false);
			//since it starts off as active add as active
			AddReserveChild(tRope);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
}