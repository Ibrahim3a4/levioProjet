package Entities;

public enum TypeP {
	 At_first(0), Current(1), Done(2);
    
    private final int key;
    
    TypeP(int key) {
         this.key = key;
    }

    public int getKey() {
         return this.key;
    }     

    public static TypeP fromKey(int key) {
         for(TypeP type : TypeP.values()) {
              if(type.getKey() == key) {
                   return type;
              }
         }
         return null;
    }
 
}
