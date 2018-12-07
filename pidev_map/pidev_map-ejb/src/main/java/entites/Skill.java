package entites;

import java.io.Serializable;
import javax.persistence.*;


/**
 * The persistent class for the Skills database table.
 * 
 */
@Entity
@Table(name="Skills")
@NamedQuery(name="Skill.findAll", query="SELECT s FROM Skill s")
public class Skill implements Serializable {
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name="SkillId")
	private int skillId;

	@Column(name="SkillName")
	private Object skillName;

	public Skill() {
	}

	public int getSkillId() {
		return this.skillId;
	}

	public void setSkillId(int skillId) {
		this.skillId = skillId;
	}

	public Object getSkillName() {
		return this.skillName;
	}

	public void setSkillName(Object skillName) {
		this.skillName = skillName;
	}

}