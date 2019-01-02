package bean;

import java.net.URL;
import java.sql.Timestamp;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Date;
import java.util.List;
import java.util.stream.Collectors;

import javax.annotation.PostConstruct;
import javax.ejb.EJB;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;
import javax.faces.context.ExternalContext;
import javax.faces.context.FacesContext;
import javax.servlet.ServletOutputStream;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.xhtmlrenderer.pdf.ITextRenderer;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.reflect.TypeToken;

import Entities.Mandate;
import Entities.Project;
import Entities.TypeP;
import Entities.User;
import Interfaces.MandateServiceRemote2;
import Interfaces.ProjectServiceLocal;
import Interfaces.UserServiceLocal;
import util.TicketTypeDeserializer;




@ManagedBean
@SessionScoped
public class ProjectBean {
    @EJB
    UserServiceLocal serviceUser;
	@EJB
	ProjectServiceLocal serviceProject;
	@EJB
	MandateServiceRemote2 serviceMandate;
	private int selectedProjectId;
	private String selectedUserId;
    public List<User> usss;
	public List<Project> ps ;
	public List<Project> allProjects ;
	public List<User> us=new ArrayList<User>(); ;
	public List<Project> m ;
	public Project pe;
	public User u ;
   
  
	public List<User> getUsss() {
		return serviceUser.getRessources();
	}
	public void setUsss(List<User> usss) {
		this.usss = usss;
	}
	
	public List<Project> getAllProjects() {
		return serviceProject.getAll();
	}
	public void setAllProjects(List<Project> allProjects) {
		this.allProjects = allProjects;
	}
	public User getU() {
		return u;
	}
	public void setU(User u) {
		this.u = u;
	}
	public List<User> getUs() {
	
		 return us ;
	}
	public void setUs(List<User> us) {
		this.us = us;
	}
	public Project getPe() {
		return pe;
	}
	public void setPe(Project pe) {
		this.pe = pe;
	}
	public List<Project> getM() {
		return m;
	}
	public void setM(List<Project> m) {
		this.m = m;
	}
	public void setPs(List<Project> ps) {
		this.ps = ps;
	}
	public List<Project> getPs() {
	
		
		return ps;
		}
@PostConstruct
	public void init(){
	

        String schema ="http://localhost:54331/Api/affichage";
		try{
			Document data = Jsoup.connect(schema).ignoreContentType(true).get();
			String json = data.select("body").text();
			
			Gson g = new GsonBuilder().setDateFormat("yyyy-MM-dd").registerTypeAdapter(TypeP.class, new TicketTypeDeserializer()).create();
			
			ps=g.fromJson(json, new TypeToken<List<Project>>(){}.getType());
		 
			  
			Collections.sort(ps);
		
		}
		catch (Exception E){
			E.printStackTrace();
		}
		
	}
	
	public String stringToDate(Date dop) throws ParseException {
		final String OLD_FORMAT = "dd-MM-YYYY";  //wants t convert date in this format      
        
		SimpleDateFormat newDateFormat = new SimpleDateFormat("dd-MM-yy HH:mm:ss");    
		 Date d =newDateFormat.parse(newDateFormat.format(dop));
		newDateFormat.applyPattern(OLD_FORMAT);
		           String new_date=newDateFormat.format(d);
		       
		           return new_date;
	}
	
	public String getById(int id){
	
	        pe=serviceProject.getbyid(id);
		if (pe.getType()==TypeP.Done){
				System.out.println(pe);
				u=pe.getUser();
			
				
			
				System.out.println(m);
			us = new ArrayList<User>();
			
				us= pe.getMandates().stream().map(Mandate::getUser).collect(Collectors.toList());
			 

				System.out.println(us);
		return "/Admin/index?faces-redirect=true";
		}
		
		return	"/Admin/404?faces-redirect=true";
		
		
	}
	public long calculerJour(Date t1,Date t2){
		return(t1.getTime()-t2.getTime())/ 86400000;
	}
	public float calculer(long l,float a){
		return a*l;
	}
	public float somme() {
		float somme=0;
		 for (User ua : pe.getUsers()){
			 
			   somme=ua.getSalary()*calculerJour(pe.getEndDate(), pe.getStartDate())+somme;
		   }
		 return somme;
	}
	public void createPDF(){
		FacesContext facesContext=FacesContext.getCurrentInstance();
		ExternalContext externalContext=facesContext.getExternalContext();
		HttpSession session = (HttpSession) externalContext.getSession(true);
		String url ="http://localhost:18083/pidev_map-web/a.xhtml";
		ITextRenderer render = new ITextRenderer();
		try {
			render.setDocument(new URL(url).toString());
		
		render.layout();
		HttpServletResponse response = (HttpServletResponse) externalContext.getResponse();
		response.reset();
		response.setContentType("application/pdf");
		
		ServletOutputStream outputStream;
		
			outputStream = response.getOutputStream();
			render.createPDF(outputStream);
			facesContext.responseComplete();
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
				
	}
	public long calculer(long x){
		return (x*12)/100;
	}
	public void affecterDeviceAEmploye(){
		serviceUser.affecterUseraProject(selectedUserId, selectedProjectId);
		System.out.println(serviceProject.getbyid(selectedProjectId));
		System.out.println(selectedUserId);
		
	}
	public int getSelectedProjectId() {
		return selectedProjectId;
	}
	public void setSelectedProjectId(int selectedProjectId) {
		this.selectedProjectId = selectedProjectId;
	}
	public String getSelectedUserId() {
		return selectedUserId;
	}
	public void setSelectedUserId(String selectedUserId) {
		this.selectedUserId = selectedUserId;
	}
	


}
