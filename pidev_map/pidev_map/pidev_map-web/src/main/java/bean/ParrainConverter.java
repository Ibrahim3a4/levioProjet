package bean;
import javax.el.ValueExpression;
import javax.faces.application.FacesMessage;
import javax.faces.component.UIComponent;
import javax.faces.context.FacesContext;
import javax.faces.convert.Converter;
import javax.faces.convert.ConverterException;
import javax.faces.convert.FacesConverter;
import javax.ws.rs.GET;

import Entities.Parrain;
import Service.ParrainService;
@FacesConverter(value = "ParrainConverter")
public class ParrainConverter implements Converter {
	

	 public Object getAsObject(FacesContext fc, UIComponent uic, String value) {
	        if(value != null && value.trim().length() > 0) {
	            try {
	            	ParrainS service = (ParrainS ) fc.getExternalContext().getApplicationMap().get("themeService");
	                return service.getPp().get(Integer.parseInt(value));
	            } catch(NumberFormatException e) {
	                throw new ConverterException(new FacesMessage(FacesMessage.SEVERITY_ERROR, "Conversion Error", "Not a valid theme."));
	            }
	        }
	        else {
	            return null;
	        }
	    }

	    public String getAsString(FacesContext fc, UIComponent uic, Object object) {
	        if(object != null) {
	            return String.valueOf(((Parrain) object).getIdParrain());
	        }
	        else {
	            return null;
	        }
	    }   
	}

