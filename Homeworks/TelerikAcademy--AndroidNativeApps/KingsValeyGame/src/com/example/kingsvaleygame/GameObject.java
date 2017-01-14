package com.example.kingsvaleygame;

import android.R.integer;

public class GameObject {

	public int col;
	public int row;

	public GameObject(int row, int col, GameObjectType type) {
		this.row = row;
		this.col = col;
		this.type = type;
	}

	public GameObjectType type;
}
