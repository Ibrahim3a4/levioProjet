import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;

public class main {
	  
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		try{
			URL uri = new URL("http://localhost:54331/Api/affichage");
			  HttpURLConnection conn = (HttpURLConnection) uri.openConnection();
	          conn.setRequestMethod("GET");
	          conn.setRequestProperty("Accept", "application/json");
	          if (conn.getResponseCode() != 200) {
	              throw new RuntimeException("Failed : HTTP Error code : "
	                      + conn.getResponseCode());
	          }
	          InputStreamReader in = new InputStreamReader(conn.getInputStream());
	          BufferedReader br = new BufferedReader(in);
	          String output;
	          while ((output = br.readLine()) != null) {
	        	
	              System.out.println(output);
	          }
	          conn.disconnect();

	      } catch (Exception e) {
	          System.out.println("Exception in NetClientGet:- " + e);
	      }
	}

}
