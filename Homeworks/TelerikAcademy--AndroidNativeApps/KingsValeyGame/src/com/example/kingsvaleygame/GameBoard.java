package com.example.kingsvaleygame;

import android.content.Context;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Paint;
import android.util.AttributeSet;
import android.view.View;

public class GameBoard extends View {

	public GameBoard(Context context, AttributeSet attrs) {
		this(context, attrs, 0);
	}

	public GameBoard(Context context) {
		this(context, null);
	}

	public GameBoard(Context context, AttributeSet attrs, int defStyleAttr) {
		super(context, attrs, defStyleAttr);
		initGameBoard();
	}

	private final int FIELD_SIZE = 30;
	public static final int FIELD_COUNT = 5;
	private GameObject[] cells;
	private GameObject[] whiteSoldiers;
	private GameObject whiteKing;
	private GameObject[] blackSoldiers;
	private GameObject blackKing;
	private Paint dark;
	private Paint light;
	private Paint black;
	private Paint white;
	private Paint gold;

	@Override
	public void onLayout(boolean changed, int left, int top, int right,
			int bottom) {
		super.onLayout(changed, left, top, right, bottom);
	}

	@Override
	public void onDraw(Canvas canvas) {
		super.onDraw(canvas);
		drawCells(canvas);
		drawFigures(canvas);
	}

	private void initGameBoard() {
		initCells();
		initFigures();

		this.dark = new Paint();
		this.dark.setColor(Color.parseColor("#aaaaaa"));

		this.light = new Paint();
		this.light.setColor(Color.parseColor("#666666"));

		this.black = new Paint();
		this.black.setColor(Color.parseColor("#000000"));

		this.white = new Paint();
		this.white.setColor(Color.parseColor("#ffffff"));

		this.gold = new Paint();
		this.gold.setColor(Color.parseColor("#00cccc"));
	}

	private void initFigures() {
		this.whiteSoldiers = new GameObject[4];
		this.blackSoldiers = new GameObject[4];

		for (int i = 0; i < 2; i++) {
			this.whiteSoldiers[i] = new GameObject(0, i,
					GameObjectType.WhiteSoldier);
			this.blackSoldiers[i] = new GameObject(4, i,
					GameObjectType.BlackSoldier);
		}

		this.whiteKing = new GameObject(0, 2, GameObjectType.WhiteKing);
		this.blackKing = new GameObject(4, 2, GameObjectType.BlackKing);

		for (int i = 2; i < 4; i++) {
			this.whiteSoldiers[i] = new GameObject(0, i + 1,
					GameObjectType.WhiteSoldier);
			this.blackSoldiers[i] = new GameObject(4, i + 1,
					GameObjectType.BlackSoldier);
		}

	}

	private void initCells() {
		this.cells = new GameObject[25];
		for (int i = 0; i < cells.length; i++) {
			if (i % 2 == 0) {
				this.cells[i] = new GameObject(i / 5, i % 5,
						GameObjectType.DarkCell);
			} else {
				this.cells[i] = new GameObject(i / 5, i % 5,
						GameObjectType.LightCell);

			}
		}
		this.cells[2 * 5 + 2].type = GameObjectType.TargetCell;
	}

	private void drawCells(Canvas canvas) {
		for (GameObject cell : this.cells) {
			int row = cell.col;
			int col = cell.row;

			if (cell.type == GameObjectType.LightCell) {
				canvas.drawRect(this.getFieldSize() * row, this.getFieldSize()
						* col, this.getFieldSize() * row + this.getFieldSize(),
						this.getFieldSize() * col + this.getFieldSize(),
						this.light);
			} else if (cell.type == GameObjectType.DarkCell) {
				canvas.drawRect(this.getFieldSize() * row, this.getFieldSize()
						* col, this.getFieldSize() * row + this.getFieldSize(),
						this.getFieldSize() * col + this.getFieldSize(),
						this.dark);
			} else if (cell.type == GameObjectType.TargetCell) {
				canvas.drawRect(this.getFieldSize() * row, this.getFieldSize()
						* col, this.getFieldSize() * row + this.getFieldSize(),
						this.getFieldSize() * col + this.getFieldSize(),
						this.gold);
			}
		}
	}

	private void drawFigures(Canvas canvas) {
		for (GameObject soldier : this.whiteSoldiers) {
			canvas.drawCircle(
					this.getFieldSize() * soldier.col + this.getFieldSize() / 2,
					this.getFieldSize() * soldier.row + this.getFieldSize() / 2,
					this.getFieldSize() / 5, this.white);
		}
		for (GameObject soldier : this.blackSoldiers) {

			canvas.drawCircle(
					this.getFieldSize() * soldier.col + this.getFieldSize() / 2,
					this.getFieldSize() * soldier.row + this.getFieldSize() / 2,
					this.getFieldSize() / 5, this.black);
		}

		canvas.drawRect(
				this.getFieldSize() * this.blackKing.col + this.getFieldSize()
						/ 5,
				this.getFieldSize() * this.blackKing.row + this.getFieldSize()
						/ 5,
				this.getFieldSize() * this.blackKing.col + this.getFieldSize()
						/ 5 * 3,
				this.getFieldSize() * this.blackKing.row + this.getFieldSize()
						/ 5 * 3, this.black);

		canvas.drawRect(
				this.getFieldSize() * this.whiteKing.col + this.getFieldSize()
						/ 5,
				this.getFieldSize() * this.whiteKing.row + this.getFieldSize()
						/ 5,
				this.getFieldSize() * this.whiteKing.col + this.getFieldSize()
						/ 5 * 3,
				this.getFieldSize() * this.whiteKing.row + this.getFieldSize()
						/ 5 * 3, this.white);
	}

	public int getFieldSize() {
		return this.FIELD_SIZE;
	}
}
