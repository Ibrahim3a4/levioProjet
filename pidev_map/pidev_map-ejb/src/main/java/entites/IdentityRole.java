package entites;

import java.io.Serializable;
import javax.persistence.*;


/**
 * The persistent class for the IdentityRoles database table.
 * 
 */
@Entity
@Table(name="IdentityRoles")
@NamedQuery(name="IdentityRole.findAll", query="SELECT i FROM IdentityRole i")
public class IdentityRole implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="Id")
	private String id;

	@Column(name="Name")
	private Object name;

	public IdentityRole() {
	}

	public String getId() {
		return this.id;
	}

	public void setId(String id) {
		this.id = id;
	}

	public Object getName() {
		return this.name;
	}

	public void setName(Object name) {
		this.name = name;
	}

}