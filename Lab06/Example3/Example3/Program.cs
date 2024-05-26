using System;

namespace Example3
{
    public class WorkItem
    {
        private static int currentID;

        protected int ID { get; set; }
        protected string Title { get; set; }
        protected string Description { get; set; }
        protected TimeSpan jobLength { get; set; }
        public WorkItem()
        {
            ID = 0;
            Title = "Default title";
            Description = "Default Description";
            jobLength = new TimeSpan();
        }
        public WorkItem(string title, string desc, TimeSpan joblen)
        {
            this.ID = GetNextID();
            this.Title = title;
            this.Description = desc;
            this.jobLength = joblen;
        }
        static WorkItem()
        {
            currentID = 0;
        }
        protected int GetNextID()
        {
            return ++currentID;
        }
        public void Update(string title, TimeSpan joblen)
        {
            this.Title = title;
            this.jobLength = joblen;
        }
        public override string ToString()
        {
            return String.Format("{0} - {1}", this.ID, this.Title);
        }
    }
    public class ChangeRequest : WorkItem
    {
        protected int originalItemID { get; set; }
        public ChangeRequest()
        { }
        public ChangeRequest(string title, string desc, TimeSpan joblen, int originalID)
        {
            this.ID = GetNextID();
            this.Title = title;
            this.Description = desc;
            this.jobLength = joblen;
        }
        public ChangeRequest(int originalItemID)
        {
            this.originalItemID = originalItemID;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            WorkItem item = new WorkItem("Fix Bugs", "Fix all code bugs in my code branch", new TimeSpan(3, 4, 0, 0));
            ChangeRequest change = new ChangeRequest("Change Base Class Design", "Add members to the class", new TimeSpan(4, 0, 0), 1);
            Console.WriteLine(item.ToString());
            change.Update("Change the Design of the Base Class", new TimeSpan(4, 0, 0));
            Console.WriteLine(change.ToString());
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
