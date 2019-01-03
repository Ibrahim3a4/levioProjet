package Service;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;

import javax.ejb.LocalBean;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.ws.rs.client.Client;
import javax.ws.rs.client.ClientBuilder;
import javax.ws.rs.client.WebTarget;
import javax.ws.rs.core.GenericType;
import javax.ws.rs.core.MediaType;
import javax.ws.rs.core.Response;

import Entities.Parrain;
import Entities.Project;
import Entities.User;
import Interfaces.UserServiceLocal;
import Interfaces.UserServiceRemote;




@Stateless
@LocalBean
public class UserService implements UserServiceLocal,UserServiceRemote{

	@PersistenceContext
	private EntityManager em;

	public UserService() {
		super();
	}

	@Override
	public void AddUser(User user) {
		em.persist(user);
		
	}
	
	@Override
	public void DeleteUser(User user) {
		//em.remove(em.contains(user) ? user : em.merge(user));  remove simple sans consommation 
		
		
		Client client;
		WebTarget target;
		@SuppressWarnings("unused")
		String uri = "http://localhost:45464/api/User/Delete/?id="+user.getId();
		client = ClientBuilder.newClient();
		target = client.target("http://localhost:45464/api/User/Delete/").queryParam("id", user.getId());
		Response response = target.request().delete();
		String result = (String) response.readEntity(String.class);
		
	}

	@Override
	public User getUserById(String id) {
		return em.find(User.class, id);
	}

	@Override
	public void UpdateUser(User user) {
		em.merge(user);
		
	}
	
	
	@Override
	public User findUserByLogin(String login, String password) {
		User user = null;
		String jpql = "SELECT u FROM User u WHERE u.email=:param1 AND u.passwordHash=:param2";
		Query query = em.createQuery(jpql);
		query.setParameter("param1", login);
		query.setParameter("param2", password);
		try {
			user = (User) query.getSingleResult();
		} catch (Exception e) {
			System.err.println("user not found");
		}

		return user;
	}
	
	public Map<String,Long> getUsersByTown(){
		Map<String, Long> result= new HashMap<String, Long>();
		String jpql = "SELECT DISTINCT adresse from User";
		Query query = em.createQuery(jpql);
		ArrayList<String> towns= (ArrayList<String>) query.getResultList();
		Iterator<String> it = towns.iterator();
		while (it.hasNext()){
			String town= it.next();
			String jpql2= "SELECT Count(*) from User u where u.adresse=:town";
			Query q2 = em.createQuery(jpql2);
			q2.setParameter("town", town);
			result.put(town, (Long)q2.getSingleResult());
			
		}
		return result;
	}
	
	@Override
	public List<User> getAll() {
		return em.createQuery("SELECT u from User u").getResultList();
	}
	
public List<User>getAllInter(){
		Query q= em.createQuery("SELECT u from User u where u.addresse!='Canada' AND u.Parrain.idParrain IS NULL ");
		return q.getResultList();
	}

	public static  List<Project> getAll2() {
		List<Project> ps = new ArrayList<Project>();
		  Client client = ClientBuilder.newClient();

	     ps = client.target("http://localhost:54331/api/affichage").request().get(new GenericType<List<Project>>() {});
	    return ps ;
	      }

	@Override
	public List<User> getMostActiveUsers() {
		Query query= em.createQuery("SELECT u FROM User u order by activitytime desc").setMaxResults(5);
		return query.getResultList();
	}
	
	 public void deleteUserFromParrain(User u){
		 	Parrain p=null;
		    u.setParrain(null);
		    int i =u.getParrain().getIdParrain();
		    Query query=em.createQuery("Select p from Parrain where idParrain=i");
		    p= (Parrain) query.getSingleResult();
		    int nb =p.getNbUsers();
		   p.setNbUsers(nb-1);  
		   }
	 
		   
		    		
	   public void deleteUserInter(String id){
		   Query query=em.createQuery("delete from User s where s.id='"+id+"'");
		 
		   query.executeUpdate();
	   }

		
	
	
	}
