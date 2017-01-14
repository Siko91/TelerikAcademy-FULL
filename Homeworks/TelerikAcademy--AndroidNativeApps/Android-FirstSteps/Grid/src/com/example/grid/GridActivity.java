package com.example.grid;

import java.util.ArrayList;

import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.ArrayAdapter;
import android.widget.GridView;

public class GridActivity extends ActionBarActivity {

	private ArrayList<String> gridItems;
	private GridView grid;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_grid);
		
		this.gridItems = new ArrayList<String>();
		this.gridItems.add("One!");
		this.gridItems.add("Two!");
		this.gridItems.add("Three!");
		this.gridItems.add("Four!");
		this.gridItems.add("Ten!");
		this.gridItems.add("Twelve!");
		this.gridItems.add("Urgh... A lot?");
		
		
		ArrayAdapter<String> adapter = new ArrayAdapter<String>(this, android.R.layout.simple_list_item_1 ,this.gridItems);
		
		this.grid = (GridView) this.findViewById(R.id.gridView1);
		this.grid.setAdapter(adapter);
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.grid, menu);
		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		// Handle action bar item clicks here. The action bar will
		// automatically handle clicks on the Home/Up button, so long
		// as you specify a parent activity in AndroidManifest.xml.
		int id = item.getItemId();
		if (id == R.id.action_settings) {
			return true;
		}
		return super.onOptionsItemSelected(item);
	}
}
