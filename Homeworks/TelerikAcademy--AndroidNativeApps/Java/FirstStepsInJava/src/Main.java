import java.io.*;
import java.nio.file.*;
import java.util.*;
import java.util.concurrent.atomic.AtomicInteger;

import static java.nio.file.StandardOpenOption.*;

public class Main {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		// DoTask1();
		DoTask2();
	}

	private static void DoTask2() {
		System.out
				.print("Task 2. Count words in text.\nInput: input.txt\nOutput: output.txt");

		String input = Task2Read("input.txt");
		Hashtable<String, AtomicInteger> counts = Task2Count(input);
		Task2Write(counts, "output.txt");
	}

	private static void Task2Write(Hashtable<String, AtomicInteger> counts,
			String target) {
		Path file = Paths.get(target);

		try (OutputStream out = new BufferedOutputStream(Files.newOutputStream(
				file, CREATE))) {

			for (Enumeration<String> e = counts.keys(); e.hasMoreElements();) {
				String key = e.nextElement();

				byte data[] = ("'" + key + "' : " + counts.get(key) + " times. \n\r")
						.getBytes();
				out.write(data, 0, data.length);
			}
		} catch (IOException x) {
			System.err.println(x);
		}

	}

	private static Hashtable<String, AtomicInteger> Task2Count(String input) {
		if (input == null) {
			System.err.println("Input is null");
			return null;
		}
		Hashtable<String, AtomicInteger> result = new Hashtable<String, AtomicInteger>();
		String[] splitted = input.split(" ");

		for (String word : splitted) {
			boolean exists = result.containsKey(word);
			if (exists) {
				exists = true;
				result.get(word).incrementAndGet();
			}
			else {
				result.put(word, new AtomicInteger(1));
			}
		}

		return result;
	}

	private static String Task2Read(String path) {
		Path file = Paths.get(path);

		try (InputStream in = Files.newInputStream(file);
				BufferedReader reader = new BufferedReader(
						new InputStreamReader(in))) {

			String line = null;
			String result = "";

			for (int i = 0; (line = reader.readLine()) != null; i++) {
				result += " " + line;
			}
			return result;
		} catch (IOException x) {
			System.err.println(x);
		}
		return null;
	}

	private static void DoTask1() {
		Scanner in = new Scanner(System.in);
		System.out.print("Task 1. Revert string. \nInput String to revert: ");
		String str = in.nextLine();
		str = new StringReverter().Revert(str);
		System.out.print(str);

		in.close();
	}

}
