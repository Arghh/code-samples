import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;

public class WordCount {

  public static void main(String[] args) {
    Scanner scanner = new Scanner(System.in);

    System.out.println("Please enter some text");

    String[] strings = scanner.nextLine().split("\\P{L}+");

    System.out.println("");
    wordCount(strings);

    scanner.close();
  }

  public static void wordCount(String[] strings) {

    System.out.println("Total words: " + strings.length);
    System.out.println("");
    Map<String, Integer> map = new HashMap<String, Integer>();

    int x;

    for (int i = 0; i < strings.length; i++) {
      if (map.containsKey(strings[i])) {
        x = map.get(strings[i]);
        map.put(strings[i], x + 1);
      } else {
        map.put(strings[i], 1);
      }
    }

    for (String key : map.keySet()) {

      System.out.println(key + ": " + map.get(key));
    }
  }
}
