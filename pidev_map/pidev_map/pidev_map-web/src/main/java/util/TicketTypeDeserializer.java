package util;

import java.lang.reflect.Type;
import com.google.gson.JsonDeserializationContext;
import com.google.gson.JsonDeserializer;
import com.google.gson.JsonElement;
import com.google.gson.JsonParseException;

import Entities.TypeP;

public class TicketTypeDeserializer implements JsonDeserializer<TypeP> {


	@Override
	public TypeP deserialize(JsonElement element, Type arg1, JsonDeserializationContext arg2) throws JsonParseException {
		int key = element.getAsInt();
		return TypeP.fromKey(key);
	}
}
