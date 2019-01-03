package Entities;

import java.io.Serializable;
import java.util.List;

import javax.persistence.*;

/**
 * Entity implementation class for Entity: Parrain
 *
 */
@Entity

public class Parrain implements Serializable {

	   
	@Id
	private Integer idParrain;
	private String nom;
	private int nbUsers;
	
	@OneToMany(mappedBy="Parrain",cascade=CascadeType.PERSIST, fetch = FetchType.EAGER)
	private List<User> users;
	
	
	
	
	public Parrain(Integer idParrain) {
		super();
		this.idParrain = idParrain;
	}
	private static final long serialVersionUID = 1L;

	public Parrain() {
		super();
	}   
	public Integer getIdParrain() {
		return this.idParrain;
	}

	public String getNom() {
		return nom;
	}
	public void setNom(String nom) {
		this.nom = nom;
	}
	public void setIdParrain(Integer idParrain) {
		this.idParrain = idParrain;
	}
	public List<User> getUsers() {
		return users;
	}
	public void setUsers(List<User> users) {
		this.users = users;
	}
	
	public int getNbUsers() {
		return nbUsers;
	}
	public void setNbUsers(int nbUsers) {
		this.nbUsers = nbUsers;
	}
	@Override
	public String toString() {
		return "Parrain [idParrain=" + idParrain + ", nom=" + nom + ", nbUsers=" + nbUsers +  "]";
	}
	@Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
		result = prime * result + ((idParrain == null) ? 0 : idParrain.hashCode());
		result = prime * result + nbUsers;
		result = prime * result + ((nom == null) ? 0 : nom.hashCode());
		result = prime * result + ((users == null) ? 0 : users.hashCode());
		return result;
	}
	@Override
	public boolean equals(Object obj) {
	    if(this.idParrain == ((Parrain) obj).idParrain) {
	        return true;
	    }else {
	        return false;
	    }
	}

	
   
}
