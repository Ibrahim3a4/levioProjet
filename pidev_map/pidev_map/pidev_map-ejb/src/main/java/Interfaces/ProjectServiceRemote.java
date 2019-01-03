package Interfaces;

import java.util.List;

import javax.ejb.Remote;

import Entities.Project;

@Remote
public interface ProjectServiceRemote {
	public List<Project> getAll2();
	public  List<Project> getAll();
}
