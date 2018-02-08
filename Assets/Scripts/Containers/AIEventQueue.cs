/*
    purpose: Queue data structure for micromanaging events
    usage: by an AI engine
*/

using System.Collections.Generic;

namespace Assets.Scripts.Containers
{
    public class AIEventQueue
    {
        private List<AIEvent> events = null;
        private int nextSort = 1000;

        public AIEventQueue(AIEvent startEvent = null)
        {
            //purpose: class constructor
            //parametres:
                //(startEvent) specified event to kick off with

            events = new List<AIEvent>();
            if (startEvent != null) Enqueue(startEvent);
        }

        public void Enqueue(AIEvent newEvent) { events.Add(newEvent); } //allows AI to add events
        public AIEvent Dequeue(int index = 0) { AIEvent temp = events[index]; events.RemoveAt(index); return temp; } //allows AI to force-dequeue any event if the need arises

        virtual public bool Poll()
        {
            //purpose: maintains event queue and returns current status
            //usage: used in the FixedUpdate() of an AI engine
            //returning true flags top of the queue event as complete
            //returning false flags top of the queue event as incomplete

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

        private void Sort()
        {
            //purpose: sorts AI event queue with lambda comparitor expression
            events.Sort((a, b) => a.GetPriority().CompareTo(b.GetPriority())); 
        }
    }
}
