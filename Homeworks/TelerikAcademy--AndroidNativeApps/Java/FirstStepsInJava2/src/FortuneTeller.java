import java.io.IOException;
import java.io.PrintStream;

import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.select.Elements;

public class FortuneTeller {

	public static void main(String[] args) {

		try {
	        PrintStream ps = new PrintStream(System.out, true, "UTF-8");
	        ps.println(getFortune());
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

	public static String getFortune() throws IOException {

		Document doc = Jsoup.connect("http://my.horoscope.com/astrology/free-daily-horoscope-libra.html").get();
		String searchPattern = "div#textline";

		Elements matches = doc.select(searchPattern);
		
		return matches.text();
	}
}
