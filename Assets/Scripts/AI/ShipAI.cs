using UnityEngine;

/// <summary>
/// Solar Ship artificial intelligence engine
/// </summary>
class ShipAI : MonoBehaviour
{
    /// <summary>
    /// Minimum runtime of event
    /// </summary>
    public int deltaMin = 0;

    /// <summary>
    /// Maximum runtime of event
    /// </summary>
    public int deltaMax = 1;
    
    /// <summary>
    /// Specified override object if solar ship has a set destination
    /// </summary>
    public GameObject overrideObjective = null;

    //object effect references so that they can be controlled by AI actions
    /// <summary>
    /// Local reference to lens flares attached to current solar ship to be controlled by AI engine
    /// </summary>
    public GameObject[] lensflare = null;

    /// <summary>
    /// Local reference to particle systems attached to current solar ship to be controlled by AI engine
    /// </summary>
    public GameObject[] particles = null;

    /// <summary>
    /// Speed limit for solar ship during travel
    /// </summary>
    public float maxSpeed = 10f; //speed limit for object

    /// <summary>
    /// Maximum rotation percentage for solar ship turning travel
    /// </summary>
    public float maxRotate = 0.1f;

    /// <summary>
    /// AI event queue
    /// </summary>
    private AIEventQueue currentEvents = new AIEventQueue();

    void Start() { currentEvents.Enqueue(CreateEvent()); }

    void FixedUpdate()
    {
        if (currentEvents.Poll()) currentEvents.Enqueue(CreateEvent()); //poll to maintain event processing
        if (Random.Range(1, 1000) == 500) currentEvents.Enqueue(CreateEvent()); //random event creation
    }

    /// <summary>
    /// Constructs an AI event object based on random factors
    /// </summary>
    /// <returns>Returns an AIEvent object for enqueuing onto an AIEventQueue for processing</returns>
    private AIEvent CreateEvent()
    {
        if (overrideObjective == null)
        {
            int randAction = Random.Range(0, 3);
            int randDuration = Random.Range(deltaMin, deltaMax);
            int randPriority = Random.Range(1, 5);

            if (randAction == 0) //stationary
            {
                return new AIEvent(randPriority, gameObject, particles, lensflare, AIAction.Stationary, null, 0, 0, randDuration);
            }
            else if (randAction == 1) //random travel
            {
                GameObject[] planets = GameObject.FindGameObjectsWithTag("Planet"); //all planets in scene
                int rand = Random.Range(0, planets.Length); //random integer to select planet with
                return new AIEvent(randPriority, gameObject, particles, lensflare, AIAction.Travel, planets[rand], maxSpeed, maxRotate, randDuration);
            }
            else if (randAction == 2) //follow player
            {
                return new AIEvent(randPriority, gameObject, particles, lensflare, AIAction.Travel, GameObject.FindGameObjectWithTag("Player"), maxSpeed, maxRotate, randDuration);
            }
            else if (randAction == 3) //hostile to player
            {
                return new AIEvent(randPriority, gameObject, particles, lensflare, AIAction.Hostile, GameObject.FindGameObjectWithTag("Player"), maxSpeed, maxRotate, randDuration);
            }
        }
        else return new AIEvent(0, gameObject, particles, lensflare, AIAction.Travel, overrideObjective, maxSpeed, maxRotate); //engage on override objective
        return new AIEvent(0, gameObject, particles, lensflare, AIAction.Stationary); //default event is long stationary
    }
};