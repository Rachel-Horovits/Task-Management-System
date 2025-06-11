// יצירת משתמשים
using TaskManagement.src.core.entities;
using TaskManagement.src.core.enums;
using TaskManagement.src.core.services;
using TaskManagement.src.features.taskManagement;

User manager = UserFactory.GetUser("manager@example.com", "Manager", Role.Manager);
User developer = UserFactory.GetUser("developer@example.com", "Developer", Role.Developer);
User qa = UserFactory.GetUser("qa@example.com", "QA", Role.QA);
User qa2 = UserFactory.GetUser("qa@example.com", "QA", Role.QA);


// יצירת משימה ראשית באמצעות הבילדר
TaskItem mainTask = new TaskBuilder()
    .WithTitle("Implement Feature X")
    .WithDescription("Develop and test feature X")
    .WithAssignee(developer)
    .WithReporter(manager)
    .WithPriority(Priority.High)
    .WithEstimationTime(10)
    .Build();

////// יצירת תתי-משימות
TaskItem subTask1 = new TaskBuilder()
    .WithTitle("Design Feature X")
    .WithDescription("Design the architecture for feature X")
    .WithAssignee(developer)
    .WithReporter(manager)
    .WithPriority(Priority.Medium)
    .WithEstimationTime(3)
    .Build();

TaskItem subTask2 = new TaskBuilder()
    .WithTitle("Test Feature X")
    .WithDescription("Perform QA testing on feature X")
    .WithAssignee(qa)
    .WithReporter(manager)
    .WithPriority(Priority.Medium)
    .WithEstimationTime(2)
    .Build();

//// הוספת תתי-משימות למשימה הראשית
mainTask.AddTask(subTask1);
mainTask.AddTask(subTask2);

// רישום מנויים להתראות
mainTask.Subscribe(manager);
mainTask.Subscribe(developer);
mainTask.Subscribe(qa);

//// הדגמת מעבר בין מצבים
Console.WriteLine($"Current State: {mainTask.WorkflowState.GetStatus()}");
mainTask.WorkflowState.MoveToNext(); // ToDo -> InProgress
Console.WriteLine($"Current State: {mainTask.WorkflowState.GetStatus()}");
mainTask.WorkflowState.MoveToNext(); // InProgress -> CodeReview
Console.WriteLine($"Current State: {mainTask.WorkflowState.GetStatus()}");
mainTask.WorkflowState.MoveToNext(); // CodeReview -> QA
Console.WriteLine($"Current State: {mainTask.WorkflowState.GetStatus()}");
mainTask.WorkflowState.MoveToNext(); // QA -> Done
Console.WriteLine($"Current State: {mainTask.WorkflowState.GetStatus()}");

//// הצגת היסטוריית השינויים
Console.WriteLine("\nTask History:");
foreach (var memento in mainTask.GetHistory())
{
    Console.WriteLine($"- Title: {memento.Title}, Status: {memento.Status}, Priority: {memento.Priority}");
}