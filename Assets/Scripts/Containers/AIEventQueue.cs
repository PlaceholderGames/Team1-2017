using System.Collections.Generic;

/// <summary>
/// AIEvent queue data structure for micromanaging AI events
/// </summary>
public class AIEventQueue
{
    /// <summary>
    /// Interal list of all AIEvents currently queued
    /// </summary>
    private List<AIEvent> events = null;

    /// <summary>
    /// Time until next sort cycle
    /// </summary>
    private int nextSort = 1000;

    public AIEventQueue(AIEvent startEvent = null)
    {
        events = new List<AIEvent>();
        if (startEvent != null) Enqueue(startEvent);
    }

    /// <summary>
    /// Allows an AI event to be added into the queue
    /// </summary>
    /// <param name="newEvent">New AI event to be added</param>
    public void Enqueue(AIEvent newEvent) { events.Add(newEvent); }

    /// <summary>
    /// Allows an AI event to be removed from the queue
    /// </summary>
    /// <param name="index">Desired event index to remove event at</param>
    /// <returns></returns>
    public AIEvent Dequeue(int index = 0) { AIEvent temp = events[index]; events.RemoveAt(index); return temp; }

    /// <summary>
    /// Maintains the event and gets current status
    /// </summary>
    /// <returns>Returns boolean status of event;
    /// true flags top of the queue event as complete so that it can be destroyed and a new event enqueued
    /// and false flags top of the queue event as incomplete and will require further polling to complete</returns>
    virtual public bool Poll()
    {
        if (nextSort == 0) //check if scheduled sort is due
        {
            Sort();
            nextSort = 1000; //reset schedule for next sort
        }
        else nextSort--;

        if (events[0].Poll()) //catch event completion
        {
            Dequeue(); //destroy current event into nothingness
            if (events.Count == 0) return true; //if no more events exist, flag for new event
            return false; //if events are still in the queue, flag for normal polling
        }
        else return false; //event unfinished, flag for normal polling
    }

    /// <summary>
    /// Sorts event list with lambda comparitor expression
    /// </summary>
    private void Sort() { events.Sort((a, b) => a.GetPriority().CompareTo(b.GetPriority())); }
};