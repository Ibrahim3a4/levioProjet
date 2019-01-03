package Service;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;
import java.util.List;

import javax.ejb.Local;
import javax.ejb.LocalBean;
import javax.ejb.Stateful;
import javax.ejb.Stateless;
import javax.persistence.EntityManager;
import javax.persistence.PersistenceContext;
import javax.persistence.PersistenceContextType;
import javax.ws.rs.client.Client;
import javax.ws.rs.client.ClientBuilder;
import javax.ws.rs.core.GenericType;
import javax.ws.rs.core.MediaType;


import Entities.Project;
import Interfaces.ProjectServiceLocal;
import Interfaces.ProjectServiceRemote;


@Stateless
@LocalBean
public  class ProjectService implements ProjectServiceLocal,ProjectServiceRemote {

	@PersistenceContext
	private EntityManager em;


		
	@Override
	public  List<Project> getAll() {
		 return em.createQuery("SELECT u from Project u").getResultList();
		
	}
	
	public ProjectService() {
		super();
	}

	@Override
	public List<Project> getAll2() {
		// TODO Auto-generated method stub
		return null;
	}




	      }
	
