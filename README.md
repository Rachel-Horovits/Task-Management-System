# Task Management System

בס"ד

## Overview
A Task Management System in C# (.NET 8) demonstrating the use of multiple design patterns (Creational, Structural, Behavioral).  
The system allows users to create, assign, update, and track tasks with support for roles, workflow, notifications, and task history.

---

## Features

- **User Management:**  
  - Users have name, email (ID), and role (Developer, Manager, QA).
- **Task Creation:**  
  - Tasks include: creation date, title, description, assignee, reporter, status, priority, estimation time, and logged time.
  - Supports complex task creation using the Builder pattern.
  - Tasks can have subtasks (Composite pattern).
- **Workflow Management:**  
  - Tasks move through statuses: To Do → In Progress → Code Review → QA → Done.
  - Only managers can approve code; only QA can mark as done.
  - Time management: estimation and logging, including aggregation for subtasks.
- **Notifications:**  
  - Assignee and reporter receive notifications on every change (Decorator pattern for extensibility).
- **Task History:**  
  - Every change is stored (Memento pattern), allowing review and undo.
- **Extensible Design:**  
  - Clean code, SOLID principles, and extensibility for future features.

---

## Design Patterns Used

- **Builder:** For step-by-step task creation.
- **Composite:** For tasks and subtasks hierarchy.
- **State:** For managing task workflow/status transitions.
- **Decorator:** For extensible notification system.
- **Memento:** For task history and undo functionality.

---

## Getting Started

1. **Clone the repository:**