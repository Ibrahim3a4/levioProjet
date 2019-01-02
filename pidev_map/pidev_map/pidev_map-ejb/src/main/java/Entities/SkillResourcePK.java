package Entities;

import java.io.Serializable;
import javax.persistence.*;

/**
 * The primary key class for the SkillResources database table.
 * 
 */
@Embeddable
public class SkillResourcePK implements Serializable {
	//default serial version id, required for serializable classes.
	private static final long serialVersionUID = 1L;

	@Column(name="SkillIdFK", insertable=false, updatable=false)
	private int skillIdFK;

	@Column(name="ResourceIdFK", insertable=false, updatable=false)
	private String resourceIdFK;

	public SkillResourcePK() {
	}
	public int getSkillIdFK() {
		return this.skillIdFK;
	}
	public void setSkillIdFK(int skillIdFK) {
		this.skillIdFK = skillIdFK;
	}
	public String getResourceIdFK() {
		return this.resourceIdFK;
	}
	public void setResourceIdFK(String resourceIdFK) {
		this.resourceIdFK = resourceIdFK;
	}

	public boolean equals(Object other) {
		if (this == other) {
			return true;
		}
		if (!(other instanceof SkillResourcePK)) {
			return false;
		}
		SkillResourcePK castOther = (SkillResourcePK)other;
		return 
			(this.skillIdFK == castOther.skillIdFK)
			&& this.resourceIdFK.equals(castOther.resourceIdFK);
	}

	public int hashCode() {
		final int prime = 31;
		int hash = 17;
		hash = hash * prime + this.skillIdFK;
		hash = hash * prime + this.resourceIdFK.hashCode();
		
		return hash;
	}
}