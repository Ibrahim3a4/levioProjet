package Service;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import javax.ejb.Local;
import javax.ejb.LocalBean;
import javax.ejb.Stateful;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.ws.rs.client.Client;
import javax.ws.rs.client.ClientBuilder;
import javax.ws.rs.client.WebTarget;

import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

import org.json.JSONArray;

import org.json.JSONObject;
import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;

import com.google.gson.Gson;
import com.google.gson.reflect.TypeToken;

import Entities.Mandate;
import Entities.Project;
import Entities.TypeP;
import Entities.User;
import Interfaces.ProjectServiceLocal;
import Interfaces.ProjectServiceRemote;



@Stateless
@LocalBean
public  class ProjectService implements ProjectServiceLocal,ProjectServiceRemote {

	@PersistenceContext
	private EntityManager em;

	@Override
	public List<Project> getAll2() {
		 List<Project> ps = new ArrayList<Project>();
		    String schema ="http://localhost:54331/Api/affichage";
				try{
					Document data = Jsoup.connect(schema).ignoreContentType(true).get();
					String json = data.select("body").text();
					ps=new Gson().fromJson(json, new TypeToken<List<Project>>(){}.getType());
				}
				catch (Exception E){
					E.printStackTrace();
				}
				 	
			return ps;
			}
		 	
		 	
	
		
	@Override
	public  List<Project> getAll() {
		 return em.createQuery("SELECT u from Project u").getResultList();
		
	}
	
	public ProjectService() {
		super();
	}




	@Override
	public Project getbyid(int id) {
		return em.find(Project.class, id);
	}




	@Override
	public List<Project> getPdone() {
		List<Project>psss = null;
		String jpql = "SELECT u FROM Project u WHERE u.Type=:param1 ";
		Query query = em.createQuery(jpql);
		query.setParameter("param1", TypeP.Done);
		
		
			psss = query.getResultList();
		

		return psss;
	}




	}
 

	
