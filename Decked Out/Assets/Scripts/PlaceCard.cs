using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceCard : MonoBehaviour
{
	[SerializeField]
	private GameObject[] cardPrefabs;
	public Vector2 pos = new Vector3(100, 100, 1);

	public void SpawnCard(){
		Instantiate(cardPrefabs[Random.Range(0,5)], pos, Quaternion.identity, GameObject.FindGameObjectWithTag("Panel").transform);
	}
}
