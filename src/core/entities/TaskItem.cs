namespace TaskManagement.src.core.entities;

public class TaskItem
{



    // מאפיינים פרטיים
    public DateTime CreationDate { get; }
    private string _title;
    private string _description;
    private User _assignee;
    private User _reporter;
    private TaskItemStatus _status;
    public TaskState WorkflowState { get; set; }
    private Priority _priority;
    private double? _estimationTime;
    public double PrivateEstimationTime { get; set; }
    private double? _loggedTime;
    private double? _privateLogTime = 0;
    private List<TaskItem> _subtasks;
    protected TaskNotifier sendNotifier;

    public TaskNotifier _notifier

    {
        get
        {
            if (sendNotifier == null)
                sendNotifier = new TaskNotifier();
            return sendNotifier;
        }

    }

    // ניהול היסטוריית מצבים
    private readonly TaskHistory _taskHistory = new TaskHistory();
    //פונקציות לרישום מנויים להתראות
    public void Subscribe(INotificationObserver observer) => _notifier.Subscribe(observer);
    public void Unsubscribe(INotificationObserver observer) => _notifier.Unsubscribe(observer);


    // מאפיינים ציבוריים

    public string Title
    {
        get => _title;
        set
        {
            SaveState();
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Title cannot be null or empty.", nameof(Title));
            _title = value;
            _notifier.Notify($"Task '{_title}' title changed.");

        }
    }
    public string Description
    {
        get => _description;
        set
        {
            SaveState();
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Description cannot be null or empty.", nameof(Description));
            _description = value;
            _notifier.Notify($"Task '{_description}' description changed.");

        }
    }
    public User Assignee
    {
        get => _assignee;
        set
        {
            SaveState();
            sendNotifier.Unsubscribe(Assignee);
            _assignee = UserFactory.GetUser(value.Email, value.Name, value.UserRole) ?? throw new ArgumentNullException(nameof(Assignee), "Assignee cannot be null.");
            sendNotifier.Subscribe(Assignee);
            _notifier.Notify($"_assignee '{Assignee.Name}' assigned ");
        }
    }
    public User Reporter
    {
        get => _reporter;
        set
        {
            SaveState();
            sendNotifier.Unsubscribe(Reporter);
            _reporter = UserFactory.GetUser(value.Email, value.Name, value.UserRole) ?? throw new ArgumentNullException(nameof(Reporter), "Reporter cannot be null.");
            sendNotifier.Subscribe(Reporter);
            _notifier.Notify($"Reporter '{Reporter.Name}' reported");
        }
    }
    public TaskItemStatus Status
    {
        get => _status;
        set
        {
            SaveState();
            if (!Enum.IsDefined(typeof(TaskItemStatus), value))
                throw new ArgumentException("Invalid status value.", nameof(Status));
             _status = TaskStatusFactory.GetTaskItemStatus(value);
             _notifier.Notify($"Task  status changed");
        }
    }
    public Priority Priority
    {
        get => _priority;
        set
        {
            SaveState();
            if (!Enum.IsDefined(typeof(Priority), value))
                throw new ArgumentException("Invalid priority value.", nameof(Priority));
            _priority = PriorityFactory.GetPriority(value); ;
            _notifier.Notify($"Task priority changed.");
        }
    }

    public double? EstimationTime
    {
        get => CalculateEstimationTime();
        set
        {
            SaveState();
            if (value.HasValue && value.Value < 0)
                throw new ArgumentException("Estimation time cannot be negative.", nameof(EstimationTime));
            PrivateEstimationTime = (double)value;
        }
    }
    public double CalculateEstimationTime()
    {
        double estimationTime = (double)PrivateEstimationTime;
        if (Subtasks != null)
            foreach (var task in Subtasks)
                estimationTime += task.CalculateEstimationTime();
        return estimationTime;
    }
    public double? MyLoggedTime
    {
        set
        {
            SaveState();
            if (value.HasValue && value.Value < 0)
                throw new ArgumentException("Logged time cannot be negative.", nameof(LoggedTime));
            _notifier.Notify($"Task LoggedTime change");

           _privateLogTime += value;



        }
    }
    public double? LoggedTime
    {
        get => CalculateLoggedTime();

    }


    private double CalculateLoggedTime()
    {
        double loggedTime = (double)_privateLogTime;

        if (Subtasks != null)
            foreach (var task in Subtasks)
                loggedTime += task.CalculateLoggedTime();
        return loggedTime;
    }
    public List<TaskItem> Subtasks
    {
        get => _subtasks;
        set
        {

            SaveState();
            _subtasks = value ?? new List<TaskItem>();
            _notifier.Notify($"Task subtasks change");
        }
    }

    public TaskItem()
    {
        CreationDate = DateTime.UtcNow;
        _subtasks = new List<TaskItem>();
        WorkflowState = new ToDoState(this);
        Status = TaskItemStatus.ToDo;
    }
    public void AddTask(TaskItem task)
    {
        if (task == null) throw new ArgumentNullException(nameof(task));
        Subtasks.Add(task);

        _notifier.Notify($"Add Task to subtasks ");
    }
    // שמירת מצב נוכחי
    private void SaveState()
    {
        var memento = new TaskItemMemento(CreationDate, _title, _description, _assignee, _reporter, _status,
                                          _priority, _estimationTime, _loggedTime, _subtasks);
        _taskHistory.SaveState(memento);
    }

    // שחזור מצב קודם
    public void Undo()
    {
        _notifier.Notify($"You did control z ");
        var memento = _taskHistory.Undo();
        _title = memento.Title;
        _description = memento.Description;
        _assignee = memento.Assignee;
        _reporter = memento.Reporter;
        _status = memento.Status;
        _priority = memento.Priority;
        _estimationTime = memento.EstimationTime;
        _loggedTime = memento.LoggedTime;
        _subtasks = new List<TaskItem>(memento.Subtasks);
    }

    // צפייה בהיסטוריית השינויים
    public IEnumerable<TaskItemMemento> GetHistory()
    {
        return _taskHistory.GetHistory();
    }


}
