package Entities;

import java.io.Serializable;
import javax.persistence.*;
import java.util.List;


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
	private  String skillName;

	//bi-directional many-to-one association to SkillResource
	@OneToMany(mappedBy="skill")
	private List<SkillResource> skillResources;

	public Skill() {
	}

	public int getSkillId() {
		return this.skillId;
	}

	public void setSkillId(int skillId) {
		this.skillId = skillId;
	}

	public  String getSkillName() {
		return this.skillName;
	}

	public void setSkillName( String skillName) {
		this.skillName = skillName;
	}

	public List<SkillResource> getSkillResources() {
		return this.skillResources;
	}

	public void setSkillResources(List<SkillResource> skillResources) {
		this.skillResources = skillResources;
	}

	public SkillResource addSkillResource(SkillResource skillResource) {
		getSkillResources().add(skillResource);
		skillResource.setSkill(this);

		return skillResource;
	}

	public SkillResource removeSkillResource(SkillResource skillResource) {
		getSkillResources().remove(skillResource);
		skillResource.setSkill(null);

		return skillResource;
	}

}