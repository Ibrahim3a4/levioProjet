package bean;

import java.io.IOException;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.annotation.PostConstruct;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.ViewScoped;

import org.codehaus.jettison.json.JSONArray;
import org.codehaus.jettison.json.JSONException;
import org.codehaus.jettison.json.JSONObject;

import com.sun.jersey.api.uri.UriComponent.Type;

import Entities.Request;
@ManagedBean
@ViewScoped
public class RequestBean {
	private ArrayList<Request> requestet = new ArrayList<>();
	
	public ArrayList<Request> getRequestet() {
		return requestet;
	}

	public void setRequestet(ArrayList<Request> requestet) {
		this.requestet = requestet;
	}

	public RequestBean() {
		// TODO Auto-generated constructor stub
	}
	
	
	
	public List<Request> getRequest() {
		clientEmira ce=new clientEmira(2);
		ArrayList<Request> listeRequest = new ArrayList<>();
		
		try {
		JSONArray json = ce.readJsonFromUrl("http://localhost:54331/API/affichager");
		for (int i =0, count=json.length(); i<count; i++){
			
			Request request = new Request();
			
			JSONObject obj = (JSONObject) json.get(i);
			request.setCareer(obj.get("career").toString());
			//profileRequired
			request.setProfileRequired(obj.get("profileRequired").toString());
			request.setRequirements(obj.get("requirements").toString());
			request.setStartDate(obj.get("startDate").toString());
			request.setDepositDate(obj.get("depositDate").toString());
			request.setEndDate(obj.get("endDate").toString());
			
			listeRequest.add(request);
			
     
		}
		System.out.println(listeRequest);
		 } catch (IOException e) {
             e.printStackTrace();
         } catch (JSONException e) {
             e.printStackTrace();
         } 
		return  listeRequest;
			
			
			
			
		}
	
	
	@PostConstruct
	public void init(){
		
		List<Request> requests=new ArrayList<Request>();
		requestet=(ArrayList<Request>) getRequest();
	
	
	}
	}
	

