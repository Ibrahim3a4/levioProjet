package bean;



import java.util.Iterator;
import java.util.Map;
import java.util.Map.Entry;
import java.util.Set;

import javax.ejb.EJB;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;
import javax.faces.bean.ViewScoped;

import Interfaces.UserServiceLocal;
@ManagedBean
@SessionScoped
public class StatBean {
	public Map<String, Long> m;

	@EJB
	UserServiceLocal service;
	public Map<String, Long> getM() {
		return m;
	}

	public void setM(Map<String, Long> m) {
		this.m = m;
	}
	
	public void init(){
		m = service.getUsersByTown();
	}
	public String getPieData(){
		Set<Entry<String, Long>> set = m.entrySet();
		String data="";
		Iterator<Entry<String, Long>> it = set.iterator();
		while (it.hasNext()){
			
			Entry<String, Long> e = it.next();
			data+="{ label :'"+e.getKey()+"', value:"+e.getValue()+"}";
			if (it.hasNext()){
				data+=",";
			}
		}
		return data;
	}
	
	public String getDate(Long millis){
		if(millis==null)
			millis=(long) 0;
		long second = (millis / 1000) % 60;
		long minute = (millis / (1000 * 60)) % 60;
		long hour = (millis / (1000 * 60 * 60)) % 24;
		long day= (millis / (1000 * 60 * 60)) / 24;
		return day+" days, "+hour+" hours, "+minute+" minutes and "+second+" seconds";
	}
	
}
