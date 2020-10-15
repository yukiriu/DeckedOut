﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceCard : MonoBehaviour
{
	[SerializeField]
	private GameObject[] cardPrefabs;
	private bool[,] grid = new bool[3,5];
	private bool cardPlaced;
	private int colN;
	private int rowN;
	private bool gridFull = false;
	public static int cardPrice = 10;

	public void Start(){
		InitGrid();
	}

	private void InitGrid(){
		for(int i = 0; i < grid.GetLength(0); i++){
			for(int j = 0; j < grid.GetLength(1); j++){
				grid[i,j] = false;
			}
		}
	}

	private bool is2DArrayFull(bool[,] grid){
		for(int i = 0; i < grid.GetLength(0); i++){
			for(int j = 0; j < grid.GetLength(1); j++){
				if(grid[i,j] == false){
					return false;
				}
			}
		}
		return true;
	}

	public void SpawnCard(){
		cardPlaced = false;
		Debug.Log("cLICK");
		do{
			gridFull = is2DArrayFull(grid);
			colN = Random.Range(0,5);
			rowN = Random.Range(0,3);
			if(!grid[rowN, colN] && cardPrice <= PlayerStats.CP){
				GameObject gO = Instantiate(cardPrefabs[Random.Range(0,5)], new Vector2( -102.2f, rowN * -49.8f - 12.7f), Quaternion.identity, GameObject.FindGameObjectWithTag("Panel").transform);
				gO.transform.localPosition = new Vector3(colN * -49.8f + 102.2f, rowN * -49.8f - 12.7f, 0);
				grid[rowN, colN] = true;
				cardPlaced = true;
				PlayerStats.CP -= cardPrice;
				cardPrice += 10;
			}
		}while(!cardPlaced && !gridFull && cardPrice < PlayerStats.CP);
	}
}
