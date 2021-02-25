
DEFINIZIONE DI SINGLETON ABSTRACT CLASS:
Classe che non può essere istanziata, ma le classi che la "ereditano (con il simbolo :)" possono essere
istanziate a loro volta. Assicura che le classi che "ereditanti" possano essere istanziate solo
una sola volta all'interno del programma.
GAME MANAGER, Player, AUDIO MANAGER e MANAGER che gestiscono la logica del software sono esempi di classi
che devono poter essere istanziate solo una volta durante l'esecuzione del software.

	
public abstract class Singleton<T> : MonoBehaviour where T : Component
{
    //crea un "punto di accesso" al componente passato in singleton <T>
	//e ne crea una variabile "istance" statica accessibile da ogni parte del programma
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






public class OtherPartOfGame : MonoBehaviour
{
    void Start() {
        Player.instance.DoSomething();
        Enemy.instance.DoSomething();
    }
}
