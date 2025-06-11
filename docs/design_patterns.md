# Design Patterns Used in Task Management System

This project demonstrates the use of several classic design patterns from all three categories: Creational, Structural, and Behavioral. Each pattern is applied to a real feature in the system.

---

## 1. Builder (Creational)

**Purpose:**  
Facilitates the step-by-step construction of complex `TaskItem` objects.

**Implementation:**  
- The `TaskBuilder` class allows setting properties such as title, description, assignee, reporter, priority, estimation time, and subtasks in a fluent manner.
- Ensures that tasks are always created in a valid state.

**Relevant Files:**  
- `src/features/taskManagement/TaskBuilder.cs`
- `src/core/entities/TaskItem.cs`

---

## 2. Composite (Structural)

**Purpose:**  
Enables tasks to have a tree structure, where each task can contain subtasks, and both are treated uniformly.

**Implementation:**  
- The `TaskItem` class contains a collection of subtasks, each of which is also a `TaskItem`.
- Aggregates estimation and logged time from all subtasks.

**Relevant Files:**  
- `src/core/entities/TaskItem.cs`

---

## 3. State (Behavioral)

**Purpose:**  
Manages the workflow of tasks by encapsulating state-specific behavior and transitions.

**Implementation:**  
- Abstract class `TaskState` and its concrete implementations (`ToDoState`, `InProgressState`, `CodeReviewState`, `QAState`) represent each workflow status.
- Each state controls allowed transitions and enforces role-based permissions (e.g., only managers can approve code, only QA can mark as done).

**Relevant Files:**  
- `src/workflow/TaskState.cs`
- `src/workflow/ToDoState.cs`
- `src/workflow/InProgressState.cs`
- `src/workflow/CodeReviewState.cs`
- `src/workflow/QAState.cs`

---

## 4. Decorator (Structural)

**Purpose:**  
Extends the notification system dynamically, allowing multiple notification channels and behaviors.

**Implementation:**  
- The `INotificationObserver` interface defines the notification contract.
- `BasicNotifier` provides base notification functionality.
- `NotificationDecorator` and its subclasses (`EmailNotifier`, `SmsNotifier`) add additional notification channels without modifying the core logic.

**Relevant Files:**  
- `src/features/notifications/INotificationObserver.cs`
- `src/features/notifications/BasicNotifier.cs`
- `src/features/notifications/NotificationDecorator.cs`
- `src/features/notifications/EmailNotifier.cs`
- `src/features/notifications/SmsNotifier.cs`

---

## 5. Memento (Behavioral)

**Purpose:**  
Enables saving and restoring the state of a task, supporting task history and undo functionality.

**Implementation:**  
- `TaskItemMemento` captures the state of a `TaskItem`.
- `TaskHistory` manages a stack of mementos for each task, allowing review and undo of changes.

**Relevant Files:**  
- `src/features/taskManagement/TaskItemMemento.cs`
- `src/features/taskManagement/TaskHistory.cs`

---

## Summary Table

| Pattern    | Category     | Main Class(es) / File(s)                        | Feature Implemented         |
|------------|--------------|-------------------------------------------------|----------------------------|
| Builder    | Creational   | TaskBuilder.cs, TaskItem.cs                     | Task creation              |
| Composite  | Structural   | TaskItem.cs                                     | Subtasks hierarchy         |
| State      | Behavioral   | TaskState.cs, ToDoState.cs, etc.                | Workflow/status management |
| Decorator  | Structural   | NotificationDecorator.cs, EmailNotifier.cs, etc.| Extensible notifications   |
| Memento    | Behavioral   | TaskItemMemento.cs, TaskHistory.cs              | Task history & undo        |

---
