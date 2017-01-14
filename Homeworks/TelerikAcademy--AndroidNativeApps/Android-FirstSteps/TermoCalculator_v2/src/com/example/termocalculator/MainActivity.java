package com.example.termocalculator;

import android.support.v7.app.ActionBarActivity;
import android.content.Intent;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

public class MainActivity extends ActionBarActivity implements android.view.View.OnClickListener {

	private EditText text;
	private Button FtoCButton;
	private Button CtoFButton;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		this.text = (EditText) this.findViewById(R.id.editText1);
		this.FtoCButton = (Button) this.findViewById(R.id.FtoCbutton);
		this.CtoFButton = (Button) this.findViewById(R.id.CtoFbutton);
		
		this.FtoCButton.setOnClickListener(this);
		this.CtoFButton.setOnClickListener(this);
	  }

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);
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

	public void onClick(View v) {
		double value = 0;
		try {
			value = Double.parseDouble(this.text.getText().toString());
		} catch (NumberFormatException e) {
			return;
		}
		Intent intent = new Intent(MainActivity.this, ResultActivity.class);
		TermoCalculator termoCalc = new TermoCalculator(value);
		
		if (v.getId() == R.id.FtoCbutton) {
			intent.putExtra("Result", termoCalc.toCelsius() + " C");
		} else if (v.getId() == R.id.CtoFbutton) {
			intent.putExtra("Result", termoCalc.toFarenhaid() + " F");
		}
		
		this.startActivity(intent);
	}
}
