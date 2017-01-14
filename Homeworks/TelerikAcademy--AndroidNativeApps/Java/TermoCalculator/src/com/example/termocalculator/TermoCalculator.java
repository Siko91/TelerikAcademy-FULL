package com.example.termocalculator;

public class TermoCalculator {
	private double value;

	public TermoCalculator(double value) {
		this.value = value;
	}

	public double toCelsius() {
		return this.value / 2;
	}

	public double toFarenhaid() {

		return this.value * 2;
	}
}
