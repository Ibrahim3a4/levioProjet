package Service;

import java.util.ArrayList;
import java.util.List;

import javax.ejb.LocalBean;
import javax.ejb.Stateless;
import javax.faces.bean.ApplicationScoped;
import javax.faces.bean.ManagedBean;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;
import javax.ws.rs.client.Client;
import javax.ws.rs.client.ClientBuilder;
import javax.ws.rs.client.WebTarget;
import javax.ws.rs.core.Response;

import Entities.Parrain;
import Entities.User;


/**
 * Session Bean implementation class ParrainService
 */
@Stateless
@LocalBean

public class ParrainService implements ParrainServiceRemote, ParrainServiceLocal {

    /**
     * Default constructor. 
     */
	@PersistenceContext
	private EntityManager em;
	
	private User u;
	private Parrain pp;
	private List<Parrain>p;
	public UserService service;
	public ArrayList<User> users ;
	public List<Parrain> parrains;
	
	private ParrainService serviceP;
	
	
	
	


	public ParrainService getServiceP() {
		return serviceP;
	}

	public void setServiceP(ParrainService serviceP) {
		this.serviceP = serviceP;
	}

	public Parrain getPp() {
		return pp;
	}

	public void setPp(Parrain pp) {
		this.pp = pp;
	}


	

	public List<Parrain> getParrains() {
		return parrains;
	}

	public void setParrains(ArrayList<Parrain> parrains) {
		this.parrains = parrains;
	}

	public UserService getService() {
		return service;
	}

	public void setService(UserService service) {
		this.service = service;
	}

	public ArrayList<User> getUsers() {
		return users;
	}

	public void setUsers(ArrayList<User> users) {
		this.users = users;
	}

	public List<Parrain> getP() {
		return p;
	}

	public void setP(List<Parrain> p) {
		this.p = p;
	}

	public EntityManager getEm() {
		return em;
	}

	public void setEm(EntityManager em) {
		this.em = em;
	}


	public User getU() {
		return u;
	}

	public void setU(User u) {
		this.u = u;
	}

	public ParrainService() {
    	super();
    }
    
    public void addParrain(Parrain p){
    	em.persist(p);
    	
    }
    public void addUti(User u)
    {
    	em.persist(u);
    }
    
 /*
   public void deleteParrainbyid(int id){
	   Query query=em.createQuery("delete from Parrain p where p.idParrain=:id");
	   query.setParameter("id", id);
	   query.executeUpdate();
   }
*/

    
    public void UpdateParrain(Parrain p){
    	em.merge(p);
    }
   
    
    public Parrain BestParrain(){
    	Query query=em.createQuery("select p from Parrain p order by nbUsers").setMaxResults(1);
		return (Parrain) query.getSingleResult();
    	
    } 
    
  
    public List<Parrain> getAll(){
    	return em.createQuery("select p from Parrain p").getResultList();
    }
    
    public List<User> afficherUser(){
    	
    	
    	Query q= em.createQuery("select u from User u where u.discriminator=Ressource ");
		
		return (List<User>)q.getResultList();
	}
	

    
    public void affecterUserParrain(String selectedUser, int selectedParrain){
    	User us=em.find(User.class, selectedUser);
    	Parrain parrain=em.find(Parrain.class,selectedParrain);
    	us.setParrain(parrain);
    	int n =parrain.getNbUsers();
    	parrain.setNbUsers(n+1);
    }

	@Override
	public List<Parrain> afficherParrain() {
		return em.createQuery("SELECT p from Parrain p").getResultList();
		
	}
    
	
    
    
   

}
