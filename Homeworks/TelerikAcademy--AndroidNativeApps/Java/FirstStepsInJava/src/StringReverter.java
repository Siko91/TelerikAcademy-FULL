public class StringReverter {
	public String Revert(String text) {
		char[] arr = new char[text.length()];

		for (int i = 0; i < text.length(); i++) {
			arr[text.length() - 1 - i] = text.charAt(i);
		}

		return new String(arr);
	}
}
