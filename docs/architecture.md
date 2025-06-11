# Architecture Overview

## High-Level Structure

The Task Management System is organized into several core layers and feature modules, each responsible for a specific aspect of the application's functionality. The architecture follows SOLID principles and clean code practices, ensuring maintainability and extensibility.

---

## Main Components

### 1. Core Entities
- **User**: Represents a system user with properties such as name, email (ID), and role (Developer, Manager, QA).
- **TaskItem**: Represents a task, including properties for title, description, assignee, reporter, status, priority, estimation time, logged time, and a collection of subtasks.

### 2. Enums
- **Role**: Defines user roles (Developer, Manager, QA).
- **Priority**: Defines task priority levels (Low, Medium, High).
- **TaskItemStatus**: Defines task workflow statuses (To Do, In Progress, Code Review, QA, Done).

### 3. Services
- **UserFactory**: Handles creation of users.
- **TaskStatusFactory**: Provides state objects for task workflow.
- **PriorityFactory**: Handles priority assignment.

### 4. Features

#### User Management
- Handles user creation, role assignment, and access control.

#### Task Management
- **TaskBuilder**: Implements the Builder pattern for step-by-step task creation.
- **TaskHistory & TaskItemMemento**: Implements the Memento pattern for tracking and undoing changes to tasks.

#### Workflow
- **TaskState** and its derived classes (ToDoState, InProgressState, CodeReviewState, QAState): Implements the State pattern for managing task status transitions and enforcing role-based permissions.

#### Notifications
- **INotificationObserver**: Interface for notification observers.
- **BasicNotifier, EmailNotifier, SmsNotifier, NotificationDecorator**: Implements the Decorator pattern for extensible notification delivery to users (assignee and reporter).

---

## Design Patterns Used

- **Builder**: For complex task creation.
- **Composite**: TaskItem supports a hierarchy of subtasks.
- **State**: For workflow/status transitions.
- **Decorator**: For extensible notification system.
- **Memento**: For task history and undo functionality.

---

## Project Structure

- `src/core/entities` - Domain entities (User, TaskItem)
- `src/core/enums` - Enums for roles, priorities, statuses
- `src/core/services` - Factories and core services
- `src/features/userManagement` - User management and access control
- `src/features/taskManagement` - Task creation, history, and builder
- `src/features/notifications` - Notification system
- `src/workflow` - Task workflow state management

---

## Relationships

- **TaskItem** aggregates subtasks (Composite).
- **TaskItem** uses **TaskBuilder** for construction.
- **TaskItem** maintains a history via **TaskHistory** and **TaskItemMemento**.
- **TaskItem** transitions between workflow states using **TaskState** and its derivatives.
- **Notifications** are sent to users via decorators implementing **INotificationObserver**.

---

## Extensibility

- New notification channels can be added by extending the notification decorators.
- New workflow states can be added by implementing new **TaskState** classes.
- Additional features (e.g., task cloning, advanced filtering) can be integrated with minimal changes to existing code.
