# Bug Tracker
### Final Project for Blue Badge

The bug tracker is an API Tool designed to help you track bugs alongside projects and your developers that work on them.The Bug Tracker can be used to track Projects, People, and Bugs. 

Projects contain a start Date, Projected End Date to help you track bugs over it's Life cycle. Projects can be made inactive to indicate that a project is no longer being worked on. 

People(Person) can be added to the database so you are able to track what bugs they are assigned to fixing, as well as the role they occupy in your company.

Bugs can be created and tied to a project as well as the people that work on them. They come with a status that allows them to be tracked along the Defect life cycle. When a bug is fixed, you can input a resolution summary to explain the issue in depth if this was not already covered as well as the steps you took to fix it. The bug will then be set to inactive to remove it from most GET functions.

## Planning and Features
Below is a link to our bug tracking planning documentation. Below that is a short summary of the page if you want TL;DR instead:
- [Planning Documentation](https://docs.google.com/document/d/1ktK-8RbWFFBU3GeE9QMkWSnxeN5B-88NMvJKZRC3Klo/edit?usp=sharing)

### Mission Statement
To Develop a Bug Tracking API for Managers of Dev teams to track issues with projects and resolve them

### Database
Below are most of the properties of each type of data.

#### Project
- ##### ProjectId
- ##### ProjectName
- ##### IsActive
- ##### StartDate
- ##### DateProjectedEnd
- ##### DateEndActual

#### Person
- ##### PersonId
- ##### Name
- ##### Email
- ##### Role
- ##### AssignedProject
- ##### IsActive

### Bug
*This list is the least comprehensive as bug has too many properties to list here*
- ##### BugId
- ##### BugDescription
- ##### Status
- ##### Priority
- ##### ActiveProblem
- ##### ProjectId
- ##### AssignedTo

## [Database Diagram](https://dbdiagram.io/d/613f994c825b5b01460028dd)

## Features
### Version 1.0
- Search by ProjectId
- Search by BugId
- Search by Summary
- Search resolved/unresolved bugs
- Search by Oldest Date
- Search for active bug past Projected Date
- Add a Bug
- Edit a Bug
- Resolve a Bug

## [Trello](https://trello.com/b/Owecq6EG/bug-tracker)

## Comments
- We are aware that the archive Methods do not actually arcvhive any data, we however couldn't comee up with a more apt description for their functions.


