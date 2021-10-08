using System.Collections.Generic;
using UnityEngine;

public class Hash
{
	//25 buckets
	List<Vert>[] vert = new List<Vert>[25];
	public struct Vert
	{
		//Data for each vert
		public Vector3 pos;
		//tri is it's triangle Index for the chunking
		public int tri;
	}

	//Setting up empty buckets
	public void hashInit()
	{
		for (int i = 0; i < 25; i++)
		{
			vert[i] = new List<Vert>();
		}

	}
	public int CheckAganstHash(Vector3 vertPos, int pottentialTri)
	{
		bool matched = false;
		int index = pottentialTri;
		//Key equasion to figure out what bucket to put the data in
		int key = Mathf.FloorToInt(((vertPos.x * vertPos.x) / 2.5f) * 3 + ((vertPos.y * vertPos.y) / 2.5f) * 3 + ((vertPos.z * vertPos.z) / 2.5f) * 3);

		//Getting the bucket
		if (vert[key % 25].Count != 0)
		{
			//Checking if the Vert Pos is in the bucket already 
			foreach (var item in vert[key % 24])
			{
				if (item.pos == vertPos)
				{
					index = item.tri;
					matched = true;
					return index;
				}
			}
			if (matched)
			{
				//If it is already in there return the tri index
				return index;
			}
		}
		//else make a new entry and fill out the bucket
		Vert v = new Vert();
		v.pos = vertPos;
		v.tri = index;
		vert[key % 24].Add(v);
		return index;
	}
}

