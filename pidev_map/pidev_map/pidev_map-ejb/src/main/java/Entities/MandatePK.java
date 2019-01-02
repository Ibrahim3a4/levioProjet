package Entities;

import java.io.Serializable;
import javax.persistence.*;

/**
 * The primary key class for the Mandates database table.
 * 
 */
@Embeddable
public class MandatePK implements Serializable {
	//default serial version id, required for serializable classes.
	private static final long serialVersionUID = 1L;

	@Column(name="IdResource", insertable=false, updatable=false)
	private String idResource;
	
	@Column(name="IdProject", insertable=false, updatable=false)
	private int idProject;

	public MandatePK() {
	}
	public String getIdResource() {
		return this.idResource;
	}
	public void setIdResource(String idResource) {
		this.idResource = idResource;
		
	}
	public int getIdProject() {
		return this.idProject;
	}
	public void setIdProject(int idProject) {
		this.idProject = idProject;
	}

	public boolean equals(Object other) {
		if (this == other) {
			return true;
		}
		if (!(other instanceof MandatePK)) {
			return false;
		}
		MandatePK castOther = (MandatePK)other;
		return 
			this.idResource.equals(castOther.idResource)
			&& (this.idProject == castOther.idProject);
	}

	public int hashCode() {
		final int prime = 31;
		int hash = 17;
		hash = hash * prime + this.idResource.hashCode();
		hash = hash * prime + this.idProject;
		
		return hash;
	}
	public MandatePK(String idResource,int idProjet) {
		super();
		this.idResource = idResource;
		this.idProject=idProjet;
		
	}
	@Override
	public String toString() {
		return "MandatePK [idResource=" + idResource + ", idProject=" + idProject + "]";
	}
	
}