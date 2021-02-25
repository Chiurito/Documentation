
DEFINIZIONE DI SINGLETON ABSTRACT CLASS:
Classe che NON può essere istanziata, ma le classi che la "ereditano (con il simbolo :)" possono essere istanziate. 
Assicura che le classi "ereditanti" possano essere istanziate solo e soltanto una volta durante l'esecuzione del programma.
	
GAME MANAGER, Player, AUDIO MANAGER e MANAGER che gestiscono la logica del software sono esempi di classi
che devono poter essere istanziate solo una volta durante l'esecuzione del software.

	
public abstract class Singleton<T> : MonoBehaviour where T : Component
{
    	//crea una variabile "istance" statica, accessibile da ogni parte del programma, del tipo passato in singleton.
	public static T instance;

   	 //in questo metodo viene controllato se c'è già un'istanza attiva della classe/oggetto/componente.
	//quindi se instance non è nulla (quindi già esiste) attiva un warning con il nome della istanza attiva.
	//Altrimenti crea un'istanza della classe/oggetto/componente passato al singleton (this as T).
	protected virtual void Awake()
    {
        if (instance != null) {
            string typename = typeof(T).Name;
            Debug.LogWarning($"More that one instance of {typename} found.");
        }
        instance = this as T;
    }
}




ESEMPIO DI CLASSE CHE EREDITA IL SINGLETON <di tipo Player>:

public class Player : Singleton<Player>
{
    public void DoSomething();
}



ESEMPIO DI CLASSE CHE EREDITA IL SINGLETON <di tipo Player>:

public class Enemy : Singleton<Enemy>
{
    public void DoSomething();
}


ESEMPIO DI CLASSE CHE UTILIZZA LA SINGOLA ISTANZA DELL'OGGETTO SINGLETON

public class OtherPartOfGame : MonoBehaviour
{
    void Start() {
        Player.instance.DoSomething();
        Enemy.instance.DoSomething();
    }
}
