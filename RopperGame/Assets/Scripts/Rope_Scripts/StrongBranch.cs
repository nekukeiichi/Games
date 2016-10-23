using UnityEngine;
using System.Collections;

public class StrongBranch : RopeBranch
{
	public StrongBranch () : base(RopeEnum.STRONG)
	{

	}
	// Use this for initialization
	void Start () 
	{
		//Create all strong Ropes here.
		for (int i =0; i<GameRules.GetMaxRopes(); i++) 
		{
			GameObject tObj = (GameObject) MonoBehaviour.Instantiate(Resources.Load ("Prefabs/RopeBuilder/StrongRope"), new Vector3 (), new Quaternion ());
			tObj.transform.parent = this.transform;
			StrongRope tRope = tObj.GetComponent<StrongRope>();
            //Move Upwards
            //tRope.transform.position = new Vector3(0.0f,2.0f*i,0.0f);
            //Deactivate the rope
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
