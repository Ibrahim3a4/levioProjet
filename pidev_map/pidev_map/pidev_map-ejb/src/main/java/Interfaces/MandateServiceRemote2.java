package Interfaces;

import java.util.List;

import javax.ejb.Remote;

import Entities.Mandate;
@Remote
public interface MandateServiceRemote2 {
	public List<Mandate> GetById(int id);
	public void addMandate(Mandate m);
	List<Mandate> getall();
}
