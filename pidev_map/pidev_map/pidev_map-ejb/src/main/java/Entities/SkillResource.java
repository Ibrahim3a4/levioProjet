package Entities;

import java.io.Serializable;
import javax.persistence.*;


/**
 * The persistent class for the SkillResources database table.
 * 
 */
@Entity
@Table(name="SkillResources")
@NamedQuery(name="SkillResource.findAll", query="SELECT s FROM SkillResource s")
public class SkillResource implements Serializable {
	private static final long serialVersionUID = 1L;

	@EmbeddedId
	private SkillResourcePK id;

	@Column(name="Level")
	private int level;

	//bi-directional many-to-one association to Skill
	@ManyToOne
	@JoinColumn(name="SkillIdFK",insertable=false,updatable=false)
	private Skill skill;

	//bi-directional many-to-one association to User
	@ManyToOne
	@JoinColumn(name="ResourceIdFK",insertable=false,updatable=false)
	private User user;

	public SkillResource() {
	}

	public SkillResourcePK getId() {
		return this.id;
	}

	public void setId(SkillResourcePK id) {
		this.id = id;
	}

	public int getLevel() {
		return this.level;
	}

	public void setLevel(int level) {
		this.level = level;
	}

	public Skill getSkill() {
		return this.skill;
	}

	public void setSkill(Skill skill) {
		this.skill = skill;
	}

	public User getUser() {
		return this.user;
	}

	public void setUser(User user) {
		this.user = user;
	}

}