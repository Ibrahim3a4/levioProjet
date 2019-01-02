package Service;

import java.util.List;

import javax.ejb.LocalBean;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.Query;

import Entities.Mandate;
import Interfaces.MandateServiceLocal2;
import Interfaces.MandateServiceRemote2;



@Stateless
@LocalBean
public  class MandateService2 implements MandateServiceLocal2,MandateServiceRemote2 {

	@PersistenceContext
	private EntityManager em;

		 	
	
	
	public MandateService2() {
		super();
	}




	@Override
	public List<Mandate> GetById(int id) {
		String jpql = "SELECT z FROM Mandate z WHERE z.project.Project_id=:username";
		Query query = em.createQuery(jpql);
		query.setParameter("username", id);
	
	List<Mandate> user= null;
		try {
		  user=(List<Mandate>)query.getResultList();

	
} catch (Exception e) {
	// TODO: handle exception
}

		return user;
	}




	@Override
	public void addMandate(Mandate m) {
		em.persist(m);
		
	}




	@Override
	public List<Mandate> getall() {
		// TODO Auto-generated method stub
		return em.createQuery("SELECT u from Mandate u").getResultList();
	}
	
	
	}
 

	
