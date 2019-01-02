package bean;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;

import javax.annotation.PostConstruct;
import javax.ejb.EJB;
import javax.faces.bean.ApplicationScoped;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;
import javax.faces.bean.ViewScoped;

import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.reflect.TypeToken;

import Entities.Project;
import Entities.User;

@ManagedBean
@SessionScoped
public class ClientBean {
    public   User user;
	public List<Project> ps ;


		public void setPs(List<Project> ps) {
			this.ps = ps;
		}
		public List<Project> getPs() {
					return ps;
			}
		
		public String init(User u){
			
            System.out.println(u);
	        String schema ="http://localhost:54331/Api/add/"+u.getId();
			try{
				Document data = Jsoup.connect(schema).ignoreContentType(true).get();
				String json = data.select("body").text();
				Gson g = new GsonBuilder().setDateFormat("yyyy-MM-dd").create();
				ps=g.fromJson(json, new TypeToken<List<Project>>(){}.getType());
				System.out.println(ps);
			}
			catch (Exception E){
				E.printStackTrace();
			}
			return "/Admin/listClientsProjects?faces-redirect=true";
		
		}
		
		public String stringToDate(Date dop) throws ParseException {
			final String OLD_FORMAT = "dd-MM-YYYY";  //wants t convert date in this format      
	        
			SimpleDateFormat newDateFormat = new SimpleDateFormat("dd-MM-yy HH:mm:ss");    
			 Date d =newDateFormat.parse(newDateFormat.format(dop));
			newDateFormat.applyPattern(OLD_FORMAT);
			           String new_date=newDateFormat.format(d);
			           System.out.println("new date format"+new_date);
			           return new_date;
		}
		public String goTo(){
			
			return "/Client/ProjectClient?faces-redirect=true";
		}
		public User getUser() {
			return user;
		}
		public void setUser(User user) {
			this.user = user;
		}
		
	}


